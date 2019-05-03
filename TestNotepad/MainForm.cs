using ScintillaNET;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls;

/*
- Настройки подключения к базе в файле конфигурации приложения
- Обеспечить сжатие информации при хранении в БД средством любой ThirdParty библиотеки
- Разработать форму выбора файла для загрузки
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
        public string Path => AppConfiguration.GetSetting("PathToDb");
        public MainForm()
        {
            archiver = new Archiver();
            InitializeComponent();
            SaveMenuItem.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.S));
            SaveAsMenuItem.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.Shift, Keys.S));
            OpenMenuItem.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.O));
            NewMenuItem.Shortcuts.Add(new RadShortcut(Keys.Control, Keys.N));
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
        private void OpenSettingsForm(object sender, EventArgs e) => new SettingsForm().Show();
        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            var openForm = new OpenFileForm();
            openForm.ShowDialog();
            CurrentId = openForm.ChosenId;//открыть файл по id 
            SQLiteConnection connection = new SQLiteConnection($"Data Source={Path}\\{DbName};Version=3;");
            connection.Open();
            var sql = $"select data from files where id = {CurrentId}";
            var reader = new SQLiteCommand(sql, connection).ExecuteReader();
            while (reader.Read())
                TextEditor.Text = archiver.Unzip((byte[])reader["data"]);
            connection.Close();
        }
        private async void SaveMenuItem_Click(object sender, EventArgs e)
        {
            if (Path != "" && File.Exists($"{Path}\\{DbName}"))//if db exists
            {
                SQLiteConnection connection = new SQLiteConnection($"Data Source={Path}\\{DbName};Version=3;");
                connection.Open();
                string sql = "";
                SQLiteCommand command = new SQLiteCommand(connection);
                if (CurrentId == -1)//если документ новый
                {
                    var saveFileForm = new SaveFileForm();
                    saveFileForm.ShowDialog();
                    command.CommandText = "insert into Files (name, data) VALUES (@name, @data)";
                    command.Parameters.Add("@name", DbType.String, 50).Value = saveFileForm.FileName;
                    command.Parameters.Add("@data", DbType.Binary, 20).Value = archiver.Zip(TextEditor.Text);
                    await command.ExecuteNonQueryAsync();
                }
                else//если открыли существующий файл
                {
                    sql = $"update files set data = @data where Id = @id";
                    command.CommandText = "update files set data = @data";
                    command.Parameters.Add("@data", DbType.Binary, 20).Value = archiver.Zip(TextEditor.Text);
                    command.Parameters.Add("@id", DbType.Int32, 20).Value = CurrentId;
                    await command.ExecuteNonQueryAsync();
                }
                connection.Close();
            }
            else
            {
                var saveFileForm = new SaveFileForm();
                saveFileForm.ShowDialog();
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

        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
