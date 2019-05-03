namespace TestNotepad
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.LanguageMenuItem = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem2 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem3 = new Telerik.WinControls.UI.RadMenuItem();
            this.SettingsMenuItem = new Telerik.WinControls.UI.RadMenuItem();
            this.TextEditor = new ScintillaNET.Scintilla();
            this.FileMenuItem = new Telerik.WinControls.UI.RadMenuItem();
            this.SaveMenuItem = new Telerik.WinControls.UI.RadMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ModeStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.OpenMenuItem = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radMenu1
            // 
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.FileMenuItem,
            this.LanguageMenuItem,
            this.SettingsMenuItem});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(744, 20);
            this.radMenu1.TabIndex = 3;
            // 
            // LanguageMenuItem
            // 
            this.LanguageMenuItem.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem2,
            this.radMenuItem3});
            this.LanguageMenuItem.Name = "LanguageMenuItem";
            this.LanguageMenuItem.Text = "Язык";
            // 
            // radMenuItem2
            // 
            this.radMenuItem2.Name = "radMenuItem2";
            this.radMenuItem2.Text = "XML";
            this.radMenuItem2.Click += new System.EventHandler(this.SetXMLStyle_Click);
            // 
            // radMenuItem3
            // 
            this.radMenuItem3.Name = "radMenuItem3";
            this.radMenuItem3.Text = "JSON";
            this.radMenuItem3.Click += new System.EventHandler(this.SetJSONStyle_Click);
            // 
            // SettingsMenuItem
            // 
            this.SettingsMenuItem.Name = "SettingsMenuItem";
            this.SettingsMenuItem.Text = "Настройки";
            this.SettingsMenuItem.Click += new System.EventHandler(this.OpenSettingsForm);
            // 
            // TextEditor
            // 
            this.TextEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextEditor.HScrollBar = false;
            this.TextEditor.Location = new System.Drawing.Point(0, 20);
            this.TextEditor.Name = "TextEditor";
            this.TextEditor.Size = new System.Drawing.Size(744, 443);
            this.TextEditor.TabIndex = 4;
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.OpenMenuItem,
            this.SaveMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Text = "Файл";
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.Text = "Сохранить";
            this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModeStripLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 463);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(744, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ModeStripLabel
            // 
            this.ModeStripLabel.Name = "ModeStripLabel";
            this.ModeStripLabel.Size = new System.Drawing.Size(104, 22);
            this.ModeStripLabel.Text = "Режим редактора";
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.Name = "OpenMenuItem";
            this.OpenMenuItem.Text = "Открыть";
            this.OpenMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 488);
            this.Controls.Add(this.TextEditor);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.radMenu1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Notepad ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem LanguageMenuItem;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem2;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem3;
        private ScintillaNET.Scintilla TextEditor;
        private Telerik.WinControls.UI.RadMenuItem SettingsMenuItem;
        private Telerik.WinControls.UI.RadMenuItem FileMenuItem;
        private Telerik.WinControls.UI.RadMenuItem SaveMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel ModeStripLabel;
        private Telerik.WinControls.UI.RadMenuItem OpenMenuItem;
    }
}