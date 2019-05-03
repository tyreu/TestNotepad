using System;
using System.Windows.Forms;

namespace TestNotepad
{
    public partial class SaveFileForm : Telerik.WinControls.UI.RadForm
    {
        public string FileName { get; private set; }
        public SaveFileForm() => InitializeComponent();
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (FilenameTextBox.Text == "")
            {
                MessageBox.Show("Имя файла не может быть пустым!", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FileName = FilenameTextBox.Text;
            Close();
        }
    }
}
