using System;

namespace TestNotepad
{
    public partial class SettingsForm : Telerik.WinControls.UI.RadForm
    {
        public SettingsForm()
        {
            InitializeComponent();
            PathTextBox.Text = AppConfiguration.GetSetting("PathToDb");
        }
        private void ChooseFolderButton_Click(object sender, EventArgs e)
        {
            FolderDialog.ShowDialog();
            PathTextBox.Text = FolderDialog.SelectedPath;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            AppConfiguration.SetSettings("PathToDb", PathTextBox.Text);
            Close();
        }
        
    }
}
