using System;
using System.Data.SQLite;
using System.IO;
using Telerik.WinControls.UI;

namespace TestNotepad
{
    public partial class OpenFileForm : RadForm
    {
        public int ChosenId { get; private set; }
        public OpenFileForm() => InitializeComponent();
        private void OpenFileForm_Load(object sender, EventArgs e)
        {
            var path = AppConfiguration.GetSetting("PathToDb");
            if (path != "" && File.Exists($"{path}\\{MainForm.DbName}"))//if db exists
            {
                string sql = "select * from Files";
                var connection = new SQLiteConnection($"Data Source={path}\\{MainForm.DbName};Version=3;");
                connection.Open();
                var reader = new SQLiteCommand(sql, connection).ExecuteReader();
                while (reader.Read())
                {
                    var item = new ListViewDataItem();
                    item[0] = reader["Id"];
                    item[1] = reader["Name"];
                    FileListView.Items.Add(item);
                }
                connection.Close();
            }
        }
        private void FileListView_ItemMouseDoubleClick(object sender, ListViewItemEventArgs e)
        {
            if (int.TryParse($"{e.Item[0]}", out int Id))
            {
                ChosenId = Id;
                Close();
            }
        }
    }
}
