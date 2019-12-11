namespace TestNotepad
{
    partial class OpenFileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn1 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Номер");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn2 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Имя");
            this.FileListView = new Telerik.WinControls.UI.RadListView();
            ((System.ComponentModel.ISupportInitialize)(this.FileListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // FileListView
            // 
            this.FileListView.AllowColumnReorder = false;
            this.FileListView.AllowColumnResize = false;
            this.FileListView.AllowEdit = false;
            this.FileListView.AllowRemove = false;
            listViewDetailColumn1.HeaderText = "Номер";
            listViewDetailColumn2.HeaderText = "Имя";
            this.FileListView.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn1,
            listViewDetailColumn2});
            this.FileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileListView.ItemSpacing = -1;
            this.FileListView.Location = new System.Drawing.Point(0, 0);
            this.FileListView.Name = "FileListView";
            this.FileListView.Size = new System.Drawing.Size(711, 288);
            this.FileListView.TabIndex = 1;
            this.FileListView.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            this.FileListView.ItemMouseDoubleClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.FileListView_ItemMouseDoubleClick);
            // 
            // OpenFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 288);
            this.Controls.Add(this.FileListView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenFileForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Открыть файл";
            this.Load += new System.EventHandler(this.OpenFileForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FileListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadListView FileListView;
    }
}
