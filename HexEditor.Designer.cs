namespace KbbEditCS
{
    partial class HexEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HexEditor));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            CB_FileSelect = new ToolStripComboBox();
            toolStripSeparator1 = new ToolStripSeparator();
            closeToolStripMenuItem = new ToolStripMenuItem();
            PB_Draw = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PB_Draw).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { CB_FileSelect, toolStripSeparator1, closeToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // CB_FileSelect
            // 
            CB_FileSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_FileSelect.Items.AddRange(new object[] { "Kbb.dat", "PhotoF00.dat", "PhotoF01.dat", "PhotoF02.dat", "PhotoF03.dat", "PhotoF04.dat", "PhotoF05.dat", "PhotoF06.dat", "PhotoF07.dat", "PhotoF08.dat", "PhotoF09.dat", "PhotoF10.dat", "PhotoF11.dat", "PhotoF12.dat", "PhotoF13.dat", "PhotoF14.dat", "PhotoF15.dat", "PhotoF16.dat", "PhotoF17.dat", "PhotoF18.dat", "PhotoF19.dat", "PhotoF20.dat", "PhotoF21.dat", "PhotoF22.dat", "PhotoF23.dat", "PhotoF24.dat", "PhotoF25.dat", "PhotoF26.dat", "PhotoF27.dat", "PhotoF28.dat", "PhotoF29.dat", "PhotoF30.dat", "PhotoF31.dat", "PhotoF32.dat", "PhotoF33.dat", "PhotoF34.dat", "PhotoF35.dat", "PhotoF36.dat", "PhotoF37.dat", "PhotoF38.dat", "PhotoF39.dat", "PhotoF40.dat", "PhotoF41.dat", "PhotoF42.dat", "PhotoF43.dat", "PhotoF44.dat", "PhotoF45.dat", "PhotoF46.dat", "PhotoF47.dat", "PhotoF48.dat", "PhotoP00.dat", "PhotoP01.dat", "PhotoP02.dat", "PhotoP03.dat", "PhotoP04.dat", "PhotoP05.dat", "PhotoP06.dat", "PhotoP07.dat", "PhotoP08.dat", "PhotoP09.dat" });
            CB_FileSelect.Name = "CB_FileSelect";
            CB_FileSelect.Size = new Size(121, 23);
            CB_FileSelect.SelectedIndexChanged += CB_FileSelect_SelectedIndexChanged;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(178, 6);
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Image = Properties.Resources.Close_red_16x;
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(181, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // PB_Draw
            // 
            PB_Draw.BackColor = Color.Black;
            PB_Draw.Dock = DockStyle.Fill;
            PB_Draw.Location = new Point(0, 24);
            PB_Draw.Name = "PB_Draw";
            PB_Draw.Size = new Size(800, 396);
            PB_Draw.TabIndex = 1;
            PB_Draw.TabStop = false;
            PB_Draw.MouseClick += PB_Draw_MouseClick;
            PB_Draw.MouseWheel += PB_Draw_MouseWheel;
            // 
            // HexEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 420);
            Controls.Add(PB_Draw);
            Controls.Add(menuStrip1);
            Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(816, 459);
            Name = "HexEditor";
            Text = "Hex Editor";
            FormClosing += HexEditor_FormClosing;
            SizeChanged += HexEditor_SizeChanged;
            KeyPress += HexEditor_KeyPress;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PB_Draw).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripComboBox CB_FileSelect;
        private PictureBox PB_Draw;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem closeToolStripMenuItem;
    }
}