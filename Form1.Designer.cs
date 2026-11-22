namespace KbbEditCS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newSaveToolStripMenuItem = new ToolStripMenuItem();
            loadSaveToolStripMenuItem = new ToolStripMenuItem();
            saveChangesToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            quitToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            linksToolStripMenuItem = new ToolStripMenuItem();
            hexEditorToolStripMenuItem = new ToolStripMenuItem();
            B_OpenGameFlagsEdit = new Button();
            B_OpenFaceEdit = new Button();
            B_OpenScoreEdit = new Button();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, aboutToolStripMenuItem, hexEditorToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(264, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newSaveToolStripMenuItem, loadSaveToolStripMenuItem, saveChangesToolStripMenuItem, toolStripSeparator1, quitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newSaveToolStripMenuItem
            // 
            newSaveToolStripMenuItem.Image = Properties.Resources.NewFile_16x;
            newSaveToolStripMenuItem.Name = "newSaveToolStripMenuItem";
            newSaveToolStripMenuItem.Size = new Size(147, 22);
            newSaveToolStripMenuItem.Text = "New Save";
            newSaveToolStripMenuItem.Click += newSaveToolStripMenuItem_Click;
            // 
            // loadSaveToolStripMenuItem
            // 
            loadSaveToolStripMenuItem.Image = Properties.Resources.OpenFile_16x;
            loadSaveToolStripMenuItem.Name = "loadSaveToolStripMenuItem";
            loadSaveToolStripMenuItem.Size = new Size(147, 22);
            loadSaveToolStripMenuItem.Text = "Load Save";
            loadSaveToolStripMenuItem.Click += loadSaveToolStripMenuItem_Click;
            // 
            // saveChangesToolStripMenuItem
            // 
            saveChangesToolStripMenuItem.Image = Properties.Resources.Save_16x;
            saveChangesToolStripMenuItem.Name = "saveChangesToolStripMenuItem";
            saveChangesToolStripMenuItem.Size = new Size(147, 22);
            saveChangesToolStripMenuItem.Text = "Save Changes";
            saveChangesToolStripMenuItem.Click += saveChangesToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(144, 6);
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Image = Properties.Resources.Close_red_16x;
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(147, 22);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { helpToolStripMenuItem, linksToolStripMenuItem });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Image = Properties.Resources.Question_16x;
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(101, 22);
            helpToolStripMenuItem.Text = "Help";
            helpToolStripMenuItem.Click += helpToolStripMenuItem_Click;
            // 
            // linksToolStripMenuItem
            // 
            linksToolStripMenuItem.Image = Properties.Resources.LinkVertical_16x;
            linksToolStripMenuItem.Name = "linksToolStripMenuItem";
            linksToolStripMenuItem.Size = new Size(101, 22);
            linksToolStripMenuItem.Text = "Links";
            linksToolStripMenuItem.Click += linksToolStripMenuItem_Click;
            // 
            // hexEditorToolStripMenuItem
            // 
            hexEditorToolStripMenuItem.Enabled = false;
            hexEditorToolStripMenuItem.Name = "hexEditorToolStripMenuItem";
            hexEditorToolStripMenuItem.Size = new Size(73, 20);
            hexEditorToolStripMenuItem.Text = "Hex Editor";
            hexEditorToolStripMenuItem.Click += hexEditorToolStripMenuItem_Click;
            // 
            // B_OpenGameFlagsEdit
            // 
            B_OpenGameFlagsEdit.Enabled = false;
            B_OpenGameFlagsEdit.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            B_OpenGameFlagsEdit.Location = new Point(12, 143);
            B_OpenGameFlagsEdit.Name = "B_OpenGameFlagsEdit";
            B_OpenGameFlagsEdit.Size = new Size(240, 52);
            B_OpenGameFlagsEdit.TabIndex = 6;
            B_OpenGameFlagsEdit.Text = "Game globals";
            B_OpenGameFlagsEdit.UseVisualStyleBackColor = true;
            B_OpenGameFlagsEdit.Click += B_OpenGameFlagsEdit_Click;
            // 
            // B_OpenFaceEdit
            // 
            B_OpenFaceEdit.Enabled = false;
            B_OpenFaceEdit.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            B_OpenFaceEdit.Location = new Point(12, 85);
            B_OpenFaceEdit.Name = "B_OpenFaceEdit";
            B_OpenFaceEdit.Size = new Size(240, 52);
            B_OpenFaceEdit.TabIndex = 5;
            B_OpenFaceEdit.Text = "Face editor";
            B_OpenFaceEdit.UseVisualStyleBackColor = true;
            B_OpenFaceEdit.Click += B_OpenFaceEdit_Click;
            // 
            // B_OpenScoreEdit
            // 
            B_OpenScoreEdit.Enabled = false;
            B_OpenScoreEdit.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            B_OpenScoreEdit.Location = new Point(12, 27);
            B_OpenScoreEdit.Name = "B_OpenScoreEdit";
            B_OpenScoreEdit.Size = new Size(240, 52);
            B_OpenScoreEdit.TabIndex = 4;
            B_OpenScoreEdit.Text = "Score editor";
            B_OpenScoreEdit.UseVisualStyleBackColor = true;
            B_OpenScoreEdit.Click += B_OpenScoreEdit_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "Face Raiders save file|Kbb.dat";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.FileName = "Kbb.dat";
            saveFileDialog1.Filter = "Face Raiders save file|Kbb.dat";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(264, 207);
            Controls.Add(B_OpenGameFlagsEdit);
            Controls.Add(B_OpenFaceEdit);
            Controls.Add(B_OpenScoreEdit);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            Text = "KbbEdit";
            FormClosing += Form1_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newSaveToolStripMenuItem;
        private ToolStripMenuItem loadSaveToolStripMenuItem;
        private ToolStripMenuItem saveChangesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem linksToolStripMenuItem;
        private ToolStripMenuItem hexEditorToolStripMenuItem;
        internal Button B_OpenGameFlagsEdit;
        internal Button B_OpenFaceEdit;
        internal Button B_OpenScoreEdit;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
    }
}
