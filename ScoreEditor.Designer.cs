namespace KbbEditCS
{
    partial class ScoreEditor
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreEditor));
            panel1 = new Panel();
            B_TutorialStg = new Button();
            B_SAF_Stg2 = new Button();
            B_SAF_StgBonus = new Button();
            B_SAF_Stg1 = new Button();
            B_StgExtra = new Button();
            B_StgBonus = new Button();
            B_Stg4 = new Button();
            B_Stg3 = new Button();
            B_Stg2 = new Button();
            B_Stg1 = new Button();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            CB_BeatLvl = new CheckBox();
            CB_LvlUnlockAnim = new CheckBox();
            Label3 = new Label();
            CB_LvlUnlock = new CheckBox();
            NUD_MaxCombo = new NumericUpDown();
            NUD_Record5 = new NumericUpDown();
            PB_Record5Face = new PictureBox();
            NUD_Record4 = new NumericUpDown();
            PB_Record4Face = new PictureBox();
            NUD_Record3 = new NumericUpDown();
            PB_Record3Face = new PictureBox();
            NUD_Record2 = new NumericUpDown();
            PB_Record2Face = new PictureBox();
            NUD_Record1 = new NumericUpDown();
            PB_Record1Face = new PictureBox();
            toolTip1 = new ToolTip(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_MaxCombo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Record5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PB_Record5Face).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Record4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PB_Record4Face).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Record3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PB_Record3Face).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Record2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PB_Record2Face).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Record1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PB_Record1Face).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(B_TutorialStg);
            panel1.Controls.Add(B_SAF_Stg2);
            panel1.Controls.Add(B_SAF_StgBonus);
            panel1.Controls.Add(B_SAF_Stg1);
            panel1.Controls.Add(B_StgExtra);
            panel1.Controls.Add(B_StgBonus);
            panel1.Controls.Add(B_Stg4);
            panel1.Controls.Add(B_Stg3);
            panel1.Controls.Add(B_Stg2);
            panel1.Controls.Add(B_Stg1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(306, 432);
            panel1.TabIndex = 0;
            // 
            // B_TutorialStg
            // 
            B_TutorialStg.Location = new Point(105, 394);
            B_TutorialStg.Name = "B_TutorialStg";
            B_TutorialStg.Size = new Size(96, 32);
            B_TutorialStg.TabIndex = 11;
            B_TutorialStg.Text = "Tutorial Stage";
            toolTip1.SetToolTip(B_TutorialStg, "A copy of SAF Stage 1.\r\nThis is the stage you play before unlocking the Campaign.");
            B_TutorialStg.UseVisualStyleBackColor = true;
            B_TutorialStg.Click += B_TutorialStg_Click;
            // 
            // B_SAF_Stg2
            // 
            B_SAF_Stg2.FlatAppearance.BorderSize = 0;
            B_SAF_Stg2.FlatStyle = FlatStyle.Flat;
            B_SAF_Stg2.ForeColor = SystemColors.Control;
            B_SAF_Stg2.Image = Properties.Resources.OtherStage;
            B_SAF_Stg2.Location = new Point(207, 271);
            B_SAF_Stg2.Name = "B_SAF_Stg2";
            B_SAF_Stg2.Size = new Size(96, 80);
            B_SAF_Stg2.TabIndex = 10;
            B_SAF_Stg2.UseVisualStyleBackColor = true;
            B_SAF_Stg2.Click += B_SAF_Stg2_Click;
            // 
            // B_SAF_StgBonus
            // 
            B_SAF_StgBonus.FlatAppearance.BorderSize = 0;
            B_SAF_StgBonus.FlatStyle = FlatStyle.Flat;
            B_SAF_StgBonus.ForeColor = SystemColors.Control;
            B_SAF_StgBonus.Image = Properties.Resources.BonusStage;
            B_SAF_StgBonus.Location = new Point(105, 271);
            B_SAF_StgBonus.Name = "B_SAF_StgBonus";
            B_SAF_StgBonus.Size = new Size(96, 80);
            B_SAF_StgBonus.TabIndex = 9;
            B_SAF_StgBonus.UseVisualStyleBackColor = true;
            B_SAF_StgBonus.Click += B_SAF_StgBonus_Click;
            // 
            // B_SAF_Stg1
            // 
            B_SAF_Stg1.FlatAppearance.BorderSize = 0;
            B_SAF_Stg1.FlatStyle = FlatStyle.Flat;
            B_SAF_Stg1.ForeColor = SystemColors.Control;
            B_SAF_Stg1.Image = Properties.Resources.Stage1;
            B_SAF_Stg1.Location = new Point(3, 271);
            B_SAF_Stg1.Name = "B_SAF_Stg1";
            B_SAF_Stg1.Size = new Size(96, 80);
            B_SAF_Stg1.TabIndex = 8;
            B_SAF_Stg1.UseVisualStyleBackColor = true;
            B_SAF_Stg1.Click += B_SAF_Stg1_Click;
            // 
            // B_StgExtra
            // 
            B_StgExtra.FlatAppearance.BorderSize = 0;
            B_StgExtra.FlatStyle = FlatStyle.Flat;
            B_StgExtra.ForeColor = SystemColors.Control;
            B_StgExtra.Image = Properties.Resources.ExtraStage;
            B_StgExtra.Location = new Point(207, 137);
            B_StgExtra.Name = "B_StgExtra";
            B_StgExtra.Size = new Size(96, 80);
            B_StgExtra.TabIndex = 7;
            B_StgExtra.UseVisualStyleBackColor = true;
            B_StgExtra.Click += B_StgExtra_Click;
            // 
            // B_StgBonus
            // 
            B_StgBonus.FlatAppearance.BorderSize = 0;
            B_StgBonus.FlatStyle = FlatStyle.Flat;
            B_StgBonus.ForeColor = SystemColors.Control;
            B_StgBonus.Image = Properties.Resources.BonusStage;
            B_StgBonus.Location = new Point(105, 137);
            B_StgBonus.Name = "B_StgBonus";
            B_StgBonus.Size = new Size(96, 80);
            B_StgBonus.TabIndex = 6;
            B_StgBonus.UseVisualStyleBackColor = true;
            B_StgBonus.Click += B_StgBonus_Click;
            // 
            // B_Stg4
            // 
            B_Stg4.FlatAppearance.BorderSize = 0;
            B_Stg4.FlatStyle = FlatStyle.Flat;
            B_Stg4.ForeColor = SystemColors.Control;
            B_Stg4.Image = Properties.Resources.Stage4;
            B_Stg4.Location = new Point(3, 137);
            B_Stg4.Name = "B_Stg4";
            B_Stg4.Size = new Size(96, 80);
            B_Stg4.TabIndex = 5;
            B_Stg4.UseVisualStyleBackColor = true;
            B_Stg4.Click += B_Stg4_Click;
            // 
            // B_Stg3
            // 
            B_Stg3.FlatAppearance.BorderSize = 0;
            B_Stg3.FlatStyle = FlatStyle.Flat;
            B_Stg3.ForeColor = SystemColors.Control;
            B_Stg3.Image = Properties.Resources.Stage3;
            B_Stg3.Location = new Point(207, 51);
            B_Stg3.Name = "B_Stg3";
            B_Stg3.Size = new Size(96, 80);
            B_Stg3.TabIndex = 4;
            B_Stg3.UseVisualStyleBackColor = true;
            B_Stg3.Click += B_Stg3_Click;
            // 
            // B_Stg2
            // 
            B_Stg2.FlatAppearance.BorderSize = 0;
            B_Stg2.FlatStyle = FlatStyle.Flat;
            B_Stg2.ForeColor = SystemColors.Control;
            B_Stg2.Image = Properties.Resources.Stage2;
            B_Stg2.Location = new Point(105, 51);
            B_Stg2.Name = "B_Stg2";
            B_Stg2.Size = new Size(96, 80);
            B_Stg2.TabIndex = 3;
            B_Stg2.UseVisualStyleBackColor = true;
            B_Stg2.Click += B_Stg2_Click;
            // 
            // B_Stg1
            // 
            B_Stg1.FlatAppearance.BorderSize = 0;
            B_Stg1.FlatStyle = FlatStyle.Flat;
            B_Stg1.ForeColor = SystemColors.Control;
            B_Stg1.Image = Properties.Resources.Stage1;
            B_Stg1.Location = new Point(3, 51);
            B_Stg1.Name = "B_Stg1";
            B_Stg1.Size = new Size(96, 80);
            B_Stg1.TabIndex = 2;
            B_Stg1.UseVisualStyleBackColor = true;
            B_Stg1.Click += B_Stg1_Click;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 220);
            label2.Name = "label2";
            label2.Size = new Size(300, 48);
            label2.TabIndex = 1;
            label2.Text = "SAF Stages";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(300, 48);
            label1.TabIndex = 0;
            label1.Text = "Main Stages";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(CB_BeatLvl);
            panel2.Controls.Add(CB_LvlUnlockAnim);
            panel2.Controls.Add(Label3);
            panel2.Controls.Add(CB_LvlUnlock);
            panel2.Controls.Add(NUD_MaxCombo);
            panel2.Controls.Add(NUD_Record5);
            panel2.Controls.Add(PB_Record5Face);
            panel2.Controls.Add(NUD_Record4);
            panel2.Controls.Add(PB_Record4Face);
            panel2.Controls.Add(NUD_Record3);
            panel2.Controls.Add(PB_Record3Face);
            panel2.Controls.Add(NUD_Record2);
            panel2.Controls.Add(PB_Record2Face);
            panel2.Controls.Add(NUD_Record1);
            panel2.Controls.Add(PB_Record1Face);
            panel2.Location = new Point(324, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(188, 432);
            panel2.TabIndex = 1;
            // 
            // CB_BeatLvl
            // 
            CB_BeatLvl.CheckAlign = ContentAlignment.MiddleRight;
            CB_BeatLvl.Enabled = false;
            CB_BeatLvl.Font = new Font("Segoe UI Semibold", 15F);
            CB_BeatLvl.Location = new Point(3, 321);
            CB_BeatLvl.Name = "CB_BeatLvl";
            CB_BeatLvl.Size = new Size(182, 32);
            CB_BeatLvl.TabIndex = 26;
            CB_BeatLvl.Text = "Stage complete?";
            toolTip1.SetToolTip(CB_BeatLvl, "Having this turned off will show an advice tip when taking a picture, before playing some stages.");
            CB_BeatLvl.UseVisualStyleBackColor = true;
            CB_BeatLvl.Click += CB_BeatLvl_Click;
            // 
            // CB_LvlUnlockAnim
            // 
            CB_LvlUnlockAnim.CheckAlign = ContentAlignment.MiddleRight;
            CB_LvlUnlockAnim.Enabled = false;
            CB_LvlUnlockAnim.Font = new Font("Segoe UI Semibold", 14F);
            CB_LvlUnlockAnim.Location = new Point(3, 397);
            CB_LvlUnlockAnim.Name = "CB_LvlUnlockAnim";
            CB_LvlUnlockAnim.Size = new Size(182, 32);
            CB_LvlUnlockAnim.TabIndex = 25;
            CB_LvlUnlockAnim.Text = "Unlock animation";
            toolTip1.SetToolTip(CB_LvlUnlockAnim, "The game sets this field by default which plays an animation showing the stage being unlocked.\r\nIf you're unlocking the stage using the editor, you don't necessarily need this to be set.");
            CB_LvlUnlockAnim.UseVisualStyleBackColor = true;
            CB_LvlUnlockAnim.Click += CB_LvlUnlockAnim_Click;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Segoe UI Semibold", 15F);
            Label3.Location = new Point(3, 279);
            Label3.Name = "Label3";
            Label3.Size = new Size(124, 28);
            Label3.TabIndex = 22;
            Label3.Text = "Max combo:";
            Label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CB_LvlUnlock
            // 
            CB_LvlUnlock.CheckAlign = ContentAlignment.MiddleRight;
            CB_LvlUnlock.Enabled = false;
            CB_LvlUnlock.Font = new Font("Segoe UI Semibold", 15F);
            CB_LvlUnlock.Location = new Point(3, 359);
            CB_LvlUnlock.Name = "CB_LvlUnlock";
            CB_LvlUnlock.Size = new Size(182, 32);
            CB_LvlUnlock.TabIndex = 24;
            CB_LvlUnlock.Text = "Stage unlocked?";
            toolTip1.SetToolTip(CB_LvlUnlock, "This controls whether the stage can be played or not.");
            CB_LvlUnlock.UseVisualStyleBackColor = true;
            CB_LvlUnlock.Click += CB_LvlUnlock_Click;
            // 
            // NUD_MaxCombo
            // 
            NUD_MaxCombo.Enabled = false;
            NUD_MaxCombo.Font = new Font("Segoe UI Variable Display Semib", 20F, FontStyle.Regular, GraphicsUnit.Pixel);
            NUD_MaxCombo.Location = new Point(137, 278);
            NUD_MaxCombo.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            NUD_MaxCombo.Name = "NUD_MaxCombo";
            NUD_MaxCombo.Size = new Size(48, 34);
            NUD_MaxCombo.TabIndex = 23;
            NUD_MaxCombo.TextAlign = HorizontalAlignment.Right;
            NUD_MaxCombo.ValueChanged += NUD_MaxCombo_ValueChanged;
            // 
            // NUD_Record5
            // 
            NUD_Record5.Enabled = false;
            NUD_Record5.Font = new Font("Segoe UI Semibold", 23F, FontStyle.Bold);
            NUD_Record5.Location = new Point(57, 219);
            NUD_Record5.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            NUD_Record5.Name = "NUD_Record5";
            NUD_Record5.Size = new Size(128, 48);
            NUD_Record5.TabIndex = 9;
            NUD_Record5.TextAlign = HorizontalAlignment.Right;
            NUD_Record5.ValueChanged += NUD_Record5_ValueChanged;
            // 
            // PB_Record5Face
            // 
            PB_Record5Face.BackgroundImage = Properties.Resources.DummyFace;
            PB_Record5Face.BackgroundImageLayout = ImageLayout.Stretch;
            PB_Record5Face.Enabled = false;
            PB_Record5Face.Image = Properties.Resources.FaceHole;
            PB_Record5Face.Location = new Point(3, 219);
            PB_Record5Face.Name = "PB_Record5Face";
            PB_Record5Face.Size = new Size(48, 48);
            PB_Record5Face.SizeMode = PictureBoxSizeMode.StretchImage;
            PB_Record5Face.TabIndex = 8;
            PB_Record5Face.TabStop = false;
            PB_Record5Face.MouseClick += PB_Record5Face_MouseClick;
            // 
            // NUD_Record4
            // 
            NUD_Record4.Enabled = false;
            NUD_Record4.Font = new Font("Segoe UI Semibold", 23F, FontStyle.Bold);
            NUD_Record4.Location = new Point(57, 165);
            NUD_Record4.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            NUD_Record4.Name = "NUD_Record4";
            NUD_Record4.Size = new Size(128, 48);
            NUD_Record4.TabIndex = 7;
            NUD_Record4.TextAlign = HorizontalAlignment.Right;
            NUD_Record4.ValueChanged += NUD_Record4_ValueChanged;
            // 
            // PB_Record4Face
            // 
            PB_Record4Face.BackgroundImage = Properties.Resources.DummyFace;
            PB_Record4Face.BackgroundImageLayout = ImageLayout.Stretch;
            PB_Record4Face.Enabled = false;
            PB_Record4Face.Image = Properties.Resources.FaceHole;
            PB_Record4Face.Location = new Point(3, 165);
            PB_Record4Face.Name = "PB_Record4Face";
            PB_Record4Face.Size = new Size(48, 48);
            PB_Record4Face.SizeMode = PictureBoxSizeMode.StretchImage;
            PB_Record4Face.TabIndex = 6;
            PB_Record4Face.TabStop = false;
            PB_Record4Face.MouseClick += PB_Record4Face_MouseClick;
            // 
            // NUD_Record3
            // 
            NUD_Record3.Enabled = false;
            NUD_Record3.Font = new Font("Segoe UI Semibold", 23F, FontStyle.Bold);
            NUD_Record3.Location = new Point(57, 111);
            NUD_Record3.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            NUD_Record3.Name = "NUD_Record3";
            NUD_Record3.Size = new Size(128, 48);
            NUD_Record3.TabIndex = 5;
            NUD_Record3.TextAlign = HorizontalAlignment.Right;
            NUD_Record3.ValueChanged += NUD_Record3_ValueChanged;
            // 
            // PB_Record3Face
            // 
            PB_Record3Face.BackgroundImage = Properties.Resources.DummyFace;
            PB_Record3Face.BackgroundImageLayout = ImageLayout.Stretch;
            PB_Record3Face.Enabled = false;
            PB_Record3Face.Image = Properties.Resources.FaceHole;
            PB_Record3Face.Location = new Point(3, 111);
            PB_Record3Face.Name = "PB_Record3Face";
            PB_Record3Face.Size = new Size(48, 48);
            PB_Record3Face.SizeMode = PictureBoxSizeMode.StretchImage;
            PB_Record3Face.TabIndex = 4;
            PB_Record3Face.TabStop = false;
            PB_Record3Face.MouseClick += PB_Record3Face_MouseClick;
            // 
            // NUD_Record2
            // 
            NUD_Record2.Enabled = false;
            NUD_Record2.Font = new Font("Segoe UI Semibold", 23F, FontStyle.Bold);
            NUD_Record2.Location = new Point(57, 57);
            NUD_Record2.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            NUD_Record2.Name = "NUD_Record2";
            NUD_Record2.Size = new Size(128, 48);
            NUD_Record2.TabIndex = 3;
            NUD_Record2.TextAlign = HorizontalAlignment.Right;
            NUD_Record2.ValueChanged += NUD_Record2_ValueChanged;
            // 
            // PB_Record2Face
            // 
            PB_Record2Face.BackgroundImage = Properties.Resources.DummyFace;
            PB_Record2Face.BackgroundImageLayout = ImageLayout.Stretch;
            PB_Record2Face.Enabled = false;
            PB_Record2Face.Image = Properties.Resources.FaceHole;
            PB_Record2Face.Location = new Point(3, 57);
            PB_Record2Face.Name = "PB_Record2Face";
            PB_Record2Face.Size = new Size(48, 48);
            PB_Record2Face.SizeMode = PictureBoxSizeMode.StretchImage;
            PB_Record2Face.TabIndex = 2;
            PB_Record2Face.TabStop = false;
            PB_Record2Face.MouseClick += PB_Record2Face_MouseClick;
            // 
            // NUD_Record1
            // 
            NUD_Record1.Enabled = false;
            NUD_Record1.Font = new Font("Segoe UI Semibold", 23F, FontStyle.Bold);
            NUD_Record1.Location = new Point(57, 3);
            NUD_Record1.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            NUD_Record1.Name = "NUD_Record1";
            NUD_Record1.Size = new Size(128, 48);
            NUD_Record1.TabIndex = 1;
            NUD_Record1.TextAlign = HorizontalAlignment.Right;
            NUD_Record1.ValueChanged += NUD_Record1_ValueChanged;
            // 
            // PB_Record1Face
            // 
            PB_Record1Face.BackgroundImage = Properties.Resources.DummyFace;
            PB_Record1Face.BackgroundImageLayout = ImageLayout.Stretch;
            PB_Record1Face.Enabled = false;
            PB_Record1Face.Image = Properties.Resources.FaceHole;
            PB_Record1Face.Location = new Point(3, 3);
            PB_Record1Face.Name = "PB_Record1Face";
            PB_Record1Face.Size = new Size(48, 48);
            PB_Record1Face.SizeMode = PictureBoxSizeMode.StretchImage;
            PB_Record1Face.TabIndex = 0;
            PB_Record1Face.TabStop = false;
            PB_Record1Face.MouseClick += PB_Record1Face_MouseClick;
            // 
            // ScoreEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 456);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ScoreEditor";
            Text = "Score Editor";
            FormClosing += ScoreEditor_FormClosing;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_MaxCombo).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Record5).EndInit();
            ((System.ComponentModel.ISupportInitialize)PB_Record5Face).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Record4).EndInit();
            ((System.ComponentModel.ISupportInitialize)PB_Record4Face).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Record3).EndInit();
            ((System.ComponentModel.ISupportInitialize)PB_Record3Face).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Record2).EndInit();
            ((System.ComponentModel.ISupportInitialize)PB_Record2Face).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Record1).EndInit();
            ((System.ComponentModel.ISupportInitialize)PB_Record1Face).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Label label2;
        private Button B_Stg1;
        private Button B_StgExtra;
        private Button B_StgBonus;
        private Button B_Stg4;
        private Button B_Stg3;
        private Button B_Stg2;
        private Button B_TutorialStg;
        private Button B_SAF_Stg2;
        private Button B_SAF_StgBonus;
        private Button B_SAF_Stg1;
        private NumericUpDown NUD_Record1;
        private PictureBox PB_Record1Face;
        private NumericUpDown NUD_Record5;
        private PictureBox PB_Record5Face;
        private NumericUpDown NUD_Record4;
        private PictureBox PB_Record4Face;
        private NumericUpDown NUD_Record3;
        private PictureBox PB_Record3Face;
        private NumericUpDown NUD_Record2;
        private PictureBox PB_Record2Face;
        internal Label Label3;
        internal NumericUpDown NUD_MaxCombo;
        internal CheckBox CB_BeatLvl;
        internal CheckBox CB_LvlUnlockAnim;
        internal CheckBox CB_LvlUnlock;
        private ToolTip toolTip1;
    }
}