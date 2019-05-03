﻿using ScintillaNET;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls;

/* Реализовать текстовый редактор с возможностью сохранения/загрузки файлов в/из БД.
   В качестве БД желательно использовать SQLite, но непринципиально.
   Условия выполнения задания:
- Настройки подключения к базе в файле конфигурации приложения
- Разработать форму выбора файла для загрузки
Дополнительные задания:
- Обеспечить сжатие информации при хранении в БД средством любой ThirdParty библиотеки



- Загрузка файла из базы и сохранение в базу асинхронно
- Разработать форму ввода имени файла для сохранения
- Для форматов json и xml обеспечить подсветку синтаксиса и форматирование
 */
namespace TestNotepad
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        int CurrentId = -1;
        Archiver archiver;
        Mode CurrentMode = Mode.Custom;
        internal const string DbName = @"TestNotepadDatabase.sqlite";
        public MainForm()
        {
            archiver = new Archiver();
            InitializeComponent();
            SaveMenuItem.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.S));
            OpenMenuItem.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.O));
            ModeStripLabel.Text = $"Режим: {CurrentMode}";
            Text += ProductVersion;
            TextEditor.StyleResetDefault();
            TextEditor.Styles[Style.Default].Font = "Consolas";
            TextEditor.Styles[Style.Default].Size = 11;
            TextEditor.StyleClearAll();
        }
        private void SetXMLStyle()
        {
            TextEditor.Styles[Style.Xml.Default].ForeColor = Color.Black;
            TextEditor.Styles[Style.Xml.Attribute].ForeColor = Color.Red;
            TextEditor.Styles[Style.Xml.TagUnknown].ForeColor = Color.SaddleBrown;
            TextEditor.Styles[Style.Xml.DoubleString].ForeColor = Color.FromArgb(0, 0, 255);
            TextEditor.Styles[Style.Xml.Comment].ForeColor = Color.FromArgb(0, 128, 0);
            TextEditor.Styles[Style.Xml.XmlStart].ForeColor = Color.DarkGreen;
            TextEditor.Styles[Style.Xml.XmlEnd].ForeColor = Color.DarkGreen;
            TextEditor.Styles[Style.Xml.Tag].ForeColor = Color.SaddleBrown;
            TextEditor.Styles[Style.Xml.TagEnd].ForeColor = Color.SaddleBrown;
            TextEditor.Lexer = Lexer.Xml;
            CurrentMode = Mode.XML;
            ModeStripLabel.Text = $"Режим: {CurrentMode}";
        }
        private void SetJSONStyle()
        {
            TextEditor.Styles[Style.Json.Operator].ForeColor = Color.Black;
            TextEditor.Styles[Style.Json.Default].ForeColor = Color.Black;
            TextEditor.Styles[Style.Json.Keyword].ForeColor = Color.FromArgb(0, 0, 255);
            TextEditor.Styles[Style.Json.LdKeyword].ForeColor = Color.FromArgb(0, 0, 255);
            TextEditor.Styles[Style.Json.LdKeyword].Underline = true;
            TextEditor.Styles[Style.Json.PropertyName].ForeColor = Color.Purple;
            TextEditor.Styles[Style.Json.String].ForeColor = Color.Green;
            TextEditor.Lexer = Lexer.Json;
            CurrentMode = Mode.JSON;
            ModeStripLabel.Text = $"Режим: {CurrentMode}";
        }
        private void SetXMLStyle_Click(object sender, EventArgs e) => SetXMLStyle();
        private void SetJSONStyle_Click(object sender, EventArgs e) => SetJSONStyle();
        private async void MainForm_Load(object sender, EventArgs e)
        {
            var path = AppConfiguration.GetSetting("PathToDb");
            if (path != "" && File.Exists($"{path}\\{DbName}"))//if db exists
            {
                string sql = "select * from Files";
                var connection = new SQLiteConnection($"Data Source={path}\\{DbName};Version=3;");
                connection.Open();
                var reader = new SQLiteCommand(sql, connection).ExecuteReader();
                while (await reader.ReadAsync())
                    TextEditor.Text = archiver.Unzip((byte[])reader["data"]);
                connection.Close();
            }
        }
        private void OpenSettingsForm(object sender, EventArgs e) => new SettingsForm().Show();
        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            var openForm = new OpenFileForm();
            openForm.ShowDialog();
        }
        private async void SaveMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileForm = new SaveFileForm();
            saveFileForm.ShowDialog();
            var path = AppConfiguration.GetSetting("PathToDb");
            if (path != "" && File.Exists($"{path}\\{DbName}"))//if db exists
            {
                SQLiteConnection connection = new SQLiteConnection($"Data Source={path}\\{DbName};Version=3;");
                connection.Open();
                var sql = $"insert into Files (name) values ('{saveFileForm.FileName}', '{TextEditor.Text.Replace("'", "''")}', 'Custom')";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
            else
            {
                SQLiteConnection.CreateFile(DbName);
                SQLiteConnection connection = new SQLiteConnection($"Data Source={DbName};Version=3;");
                connection.Open();
                string sql = "create table Files (Id INTEGER PRIMARY KEY AUTOINCREMENT, name text, data BLOB)";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                await command.ExecuteNonQueryAsync();
                command.CommandText = "insert into Files (name, data) VALUES (@name, @data)";
                command.Parameters.Add("@name", DbType.String, 50).Value = saveFileForm.FileName;
                command.Parameters.Add("@data", DbType.Binary, 20).Value = archiver.Zip(TextEditor.Text);
                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
        }
    }
}