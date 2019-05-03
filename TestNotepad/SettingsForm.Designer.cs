namespace TestNotepad
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.PathTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.FolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.ChooseFolderButton = new Telerik.WinControls.UI.RadButton();
            this.SaveButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.PathTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChooseFolderButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // PathTextBox
            // 
            this.PathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PathTextBox.Location = new System.Drawing.Point(164, 12);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.NullText = "Выберите папку хранения...";
            this.PathTextBox.Size = new System.Drawing.Size(187, 21);
            this.PathTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Путь хранения БД";
            // 
            // ChooseFolderButton
            // 
            this.ChooseFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChooseFolderButton.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.ChooseFolderButton.Font = new System.Drawing.Font("Sitka Text", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChooseFolderButton.Image = ((System.Drawing.Image)(resources.GetObject("ChooseFolderButton.Image")));
            this.ChooseFolderButton.Location = new System.Drawing.Point(357, 9);
            this.ChooseFolderButton.Name = "ChooseFolderButton";
            this.ChooseFolderButton.Size = new System.Drawing.Size(29, 24);
            this.ChooseFolderButton.TabIndex = 3;
            this.ChooseFolderButton.Text = "...";
            this.ChooseFolderButton.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.ChooseFolderButton.Click += new System.EventHandler(this.ChooseFolderButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Font = new System.Drawing.Font("Sitka Text", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.Location = new System.Drawing.Point(268, 46);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(118, 22);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 80);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ChooseFolderButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PathTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки программы";
            ((System.ComponentModel.ISupportInitialize)(this.PathTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChooseFolderButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox PathTextBox;
        private System.Windows.Forms.FolderBrowserDialog FolderDialog;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadButton ChooseFolderButton;
        private Telerik.WinControls.UI.RadButton SaveButton;
    }
}
