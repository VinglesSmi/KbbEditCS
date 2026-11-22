namespace KbbEditCS
{
    partial class GlobalsEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlobalsEditor));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            panel1 = new Panel();
            NUD_UfoCounter = new NumericUpDown();
            label5 = new Label();
            DROP_UfoStg = new ComboBox();
            CB_UfoActive = new CheckBox();
            label1 = new Label();
            panel2 = new Panel();
            CB_SlideBtnStg4 = new CheckBox();
            CB_SlideBtnStg3 = new CheckBox();
            CB_SlideBtnStg2 = new CheckBox();
            CB_SlideBtnStg1 = new CheckBox();
            label2 = new Label();
            panel3 = new Panel();
            CB_SneakySnapsEnabled = new CheckBox();
            CB_SneakySnapsIntroduced = new CheckBox();
            CB_SneakySnapsUnlocked = new CheckBox();
            label3 = new Label();
            panel4 = new Panel();
            CB_CrownEnable = new CheckBox();
            CB_FaceCollectionUnlocked = new CheckBox();
            label4 = new Label();
            toolTip1 = new ToolTip(components);
            NUD_ScenesUnlocked = new NumericUpDown();
            NUD_LastViewedScene = new NumericUpDown();
            NUD_FriendFacesCounter = new NumericUpDown();
            panel5 = new Panel();
            label9 = new Label();
            label8 = new Label();
            label6 = new Label();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            panel6 = new Panel();
            label10 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_UfoCounter).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_ScenesUnlocked).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_LastViewedScene).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_FriendFacesCounter).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.uforender;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.sneakysnaps;
            pictureBox2.Location = new Point(3, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(32, 32);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.slidebtn;
            pictureBox3.Location = new Point(3, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(32, 32);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.facecollection;
            pictureBox4.Location = new Point(3, 3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(32, 32);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 4;
            pictureBox4.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(NUD_UfoCounter);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(DROP_UfoStg);
            panel1.Controls.Add(CB_UfoActive);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 150);
            panel1.TabIndex = 5;
            // 
            // NUD_UfoCounter
            // 
            NUD_UfoCounter.Location = new Point(103, 40);
            NUD_UfoCounter.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            NUD_UfoCounter.Name = "NUD_UfoCounter";
            NUD_UfoCounter.Size = new Size(40, 23);
            NUD_UfoCounter.TabIndex = 9;
            NUD_UfoCounter.TextAlign = HorizontalAlignment.Center;
            toolTip1.SetToolTip(NUD_UfoCounter, "This counter is used to track\r\nwhen should this field be toggled\r\nOn or Off.\r\n\r\nIf you're checking the box, you\r\nwould want this counter to be zero.");
            NUD_UfoCounter.ValueChanged += NUD_UfoCounter_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 72);
            label5.Name = "label5";
            label5.Size = new Size(82, 15);
            label5.TabIndex = 9;
            label5.Text = "Current Stage:";
            // 
            // DROP_UfoStg
            // 
            DROP_UfoStg.DropDownStyle = ComboBoxStyle.DropDownList;
            DROP_UfoStg.FormattingEnabled = true;
            DROP_UfoStg.Items.AddRange(new object[] { "Stage 1", "Stage 2", "Stage 3", "Final Stage", "SAF Stage 1" });
            DROP_UfoStg.Location = new Point(3, 90);
            DROP_UfoStg.Name = "DROP_UfoStg";
            DROP_UfoStg.Size = new Size(121, 23);
            DROP_UfoStg.TabIndex = 9;
            DROP_UfoStg.SelectedIndexChanged += DROP_UfoStg_SelectedIndexChanged;
            // 
            // CB_UfoActive
            // 
            CB_UfoActive.AutoSize = true;
            CB_UfoActive.Location = new Point(3, 41);
            CB_UfoActive.Name = "CB_UfoActive";
            CB_UfoActive.Size = new Size(94, 19);
            CB_UfoActive.TabIndex = 3;
            CB_UfoActive.Text = "UFO is active";
            toolTip1.SetToolTip(CB_UfoActive, "When checked, UFOs will be able\r\nto appear in the Stage selected below.");
            CB_UfoActive.UseVisualStyleBackColor = true;
            CB_UfoActive.Click += CB_UfoActive_Click;
            // 
            // label1
            // 
            label1.Location = new Point(41, 3);
            label1.Name = "label1";
            label1.Size = new Size(156, 32);
            label1.TabIndex = 2;
            label1.Text = "UFO Stage";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.Controls.Add(CB_SlideBtnStg4);
            panel2.Controls.Add(CB_SlideBtnStg3);
            panel2.Controls.Add(CB_SlideBtnStg2);
            panel2.Controls.Add(CB_SlideBtnStg1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pictureBox3);
            panel2.Location = new Point(218, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 150);
            panel2.TabIndex = 6;
            // 
            // CB_SlideBtnStg4
            // 
            CB_SlideBtnStg4.AutoSize = true;
            CB_SlideBtnStg4.Location = new Point(3, 116);
            CB_SlideBtnStg4.Name = "CB_SlideBtnStg4";
            CB_SlideBtnStg4.Size = new Size(141, 19);
            CB_SlideBtnStg4.TabIndex = 7;
            CB_SlideBtnStg4.Text = "Enabled in Final Stage";
            toolTip1.SetToolTip(CB_SlideBtnStg4, "When checked, this will allow you to\r\nselect a face before starting Final Stage.");
            CB_SlideBtnStg4.UseVisualStyleBackColor = true;
            CB_SlideBtnStg4.Click += CB_SlideBtnStg4_Click;
            // 
            // CB_SlideBtnStg3
            // 
            CB_SlideBtnStg3.AutoSize = true;
            CB_SlideBtnStg3.Location = new Point(3, 91);
            CB_SlideBtnStg3.Name = "CB_SlideBtnStg3";
            CB_SlideBtnStg3.Size = new Size(122, 19);
            CB_SlideBtnStg3.TabIndex = 6;
            CB_SlideBtnStg3.Text = "Enabled in Stage 3";
            toolTip1.SetToolTip(CB_SlideBtnStg3, "When checked, this will allow you to\r\nselect a face before starting Stage 3.");
            CB_SlideBtnStg3.UseVisualStyleBackColor = true;
            CB_SlideBtnStg3.Click += CB_SlideBtnStg3_Click;
            // 
            // CB_SlideBtnStg2
            // 
            CB_SlideBtnStg2.AutoSize = true;
            CB_SlideBtnStg2.Location = new Point(3, 66);
            CB_SlideBtnStg2.Name = "CB_SlideBtnStg2";
            CB_SlideBtnStg2.Size = new Size(122, 19);
            CB_SlideBtnStg2.TabIndex = 5;
            CB_SlideBtnStg2.Text = "Enabled in Stage 2";
            toolTip1.SetToolTip(CB_SlideBtnStg2, "When checked, this will allow you to\r\nselect a face before starting Stage 2.");
            CB_SlideBtnStg2.UseVisualStyleBackColor = true;
            CB_SlideBtnStg2.Click += CB_SlideBtnStg2_Click;
            // 
            // CB_SlideBtnStg1
            // 
            CB_SlideBtnStg1.AutoSize = true;
            CB_SlideBtnStg1.Location = new Point(3, 41);
            CB_SlideBtnStg1.Name = "CB_SlideBtnStg1";
            CB_SlideBtnStg1.Size = new Size(122, 19);
            CB_SlideBtnStg1.TabIndex = 4;
            CB_SlideBtnStg1.Text = "Enabled in Stage 1";
            toolTip1.SetToolTip(CB_SlideBtnStg1, "When checked, this will allow you to\r\nselect a face before starting Stage 1.");
            CB_SlideBtnStg1.UseVisualStyleBackColor = true;
            CB_SlideBtnStg1.Click += CB_SlideBtnStg1_Click;
            // 
            // label2
            // 
            label2.Location = new Point(41, 3);
            label2.Name = "label2";
            label2.Size = new Size(156, 32);
            label2.TabIndex = 3;
            label2.Text = "Slide Button";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            panel3.Controls.Add(CB_SneakySnapsEnabled);
            panel3.Controls.Add(CB_SneakySnapsIntroduced);
            panel3.Controls.Add(CB_SneakySnapsUnlocked);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(pictureBox2);
            panel3.Location = new Point(12, 168);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 128);
            panel3.TabIndex = 7;
            // 
            // CB_SneakySnapsEnabled
            // 
            CB_SneakySnapsEnabled.AutoSize = true;
            CB_SneakySnapsEnabled.Location = new Point(3, 91);
            CB_SneakySnapsEnabled.Name = "CB_SneakySnapsEnabled";
            CB_SneakySnapsEnabled.Size = new Size(68, 19);
            CB_SneakySnapsEnabled.TabIndex = 11;
            CB_SneakySnapsEnabled.Text = "Enabled";
            CB_SneakySnapsEnabled.UseVisualStyleBackColor = true;
            CB_SneakySnapsEnabled.Click += CB_SneakySnapsEnabled_Click;
            // 
            // CB_SneakySnapsIntroduced
            // 
            CB_SneakySnapsIntroduced.AutoSize = true;
            CB_SneakySnapsIntroduced.Location = new Point(3, 66);
            CB_SneakySnapsIntroduced.Name = "CB_SneakySnapsIntroduced";
            CB_SneakySnapsIntroduced.Size = new Size(84, 19);
            CB_SneakySnapsIntroduced.TabIndex = 10;
            CB_SneakySnapsIntroduced.Text = "Introduced";
            toolTip1.SetToolTip(CB_SneakySnapsIntroduced, "When unchecked, you will be\r\nintroduced to Sneaky Snaps by\r\nthe UFO at the end of a Stage.\r\n\r\nYou will not be able to save the image\r\nuntil another Stage is completed.");
            CB_SneakySnapsIntroduced.UseVisualStyleBackColor = true;
            CB_SneakySnapsIntroduced.Click += CB_SneakySnapsIntroduced_Click;
            // 
            // CB_SneakySnapsUnlocked
            // 
            CB_SneakySnapsUnlocked.AutoSize = true;
            CB_SneakySnapsUnlocked.Location = new Point(3, 41);
            CB_SneakySnapsUnlocked.Name = "CB_SneakySnapsUnlocked";
            CB_SneakySnapsUnlocked.Size = new Size(76, 19);
            CB_SneakySnapsUnlocked.TabIndex = 9;
            CB_SneakySnapsUnlocked.Text = "Unlocked";
            CB_SneakySnapsUnlocked.UseVisualStyleBackColor = true;
            CB_SneakySnapsUnlocked.Click += CB_SneakySnapsUnlocked_Click;
            // 
            // label3
            // 
            label3.Location = new Point(41, 3);
            label3.Name = "label3";
            label3.Size = new Size(156, 32);
            label3.TabIndex = 3;
            label3.Text = "Sneaky Snaps";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            panel4.Controls.Add(CB_CrownEnable);
            panel4.Controls.Add(CB_FaceCollectionUnlocked);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(pictureBox4);
            panel4.Location = new Point(218, 168);
            panel4.Name = "panel4";
            panel4.Size = new Size(200, 128);
            panel4.TabIndex = 8;
            // 
            // CB_CrownEnable
            // 
            CB_CrownEnable.AutoSize = true;
            CB_CrownEnable.Location = new Point(3, 66);
            CB_CrownEnable.Name = "CB_CrownEnable";
            CB_CrownEnable.Size = new Size(185, 19);
            CB_CrownEnable.TabIndex = 13;
            CB_CrownEnable.Text = "Most chosen face has a crown";
            CB_CrownEnable.UseVisualStyleBackColor = true;
            CB_CrownEnable.Click += CB_CrownEnable_Click;
            // 
            // CB_FaceCollectionUnlocked
            // 
            CB_FaceCollectionUnlocked.AutoSize = true;
            CB_FaceCollectionUnlocked.Location = new Point(3, 41);
            CB_FaceCollectionUnlocked.Name = "CB_FaceCollectionUnlocked";
            CB_FaceCollectionUnlocked.Size = new Size(76, 19);
            CB_FaceCollectionUnlocked.TabIndex = 12;
            CB_FaceCollectionUnlocked.Text = "Unlocked";
            CB_FaceCollectionUnlocked.UseVisualStyleBackColor = true;
            CB_FaceCollectionUnlocked.Click += CB_FaceCollectionUnlocked_Click;
            // 
            // label4
            // 
            label4.Location = new Point(41, 3);
            label4.Name = "label4";
            label4.Size = new Size(156, 32);
            label4.TabIndex = 9;
            label4.Text = "Face Collection";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // NUD_ScenesUnlocked
            // 
            NUD_ScenesUnlocked.Location = new Point(114, 38);
            NUD_ScenesUnlocked.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            NUD_ScenesUnlocked.Name = "NUD_ScenesUnlocked";
            NUD_ScenesUnlocked.Size = new Size(50, 23);
            NUD_ScenesUnlocked.TabIndex = 10;
            NUD_ScenesUnlocked.TextAlign = HorizontalAlignment.Center;
            toolTip1.SetToolTip(NUD_ScenesUnlocked, "This counter is used to track\r\nwhen should this field be toggled\r\nOn or Off.\r\n\r\nIf you're checking the box, you\r\nwould want this counter to be zero.");
            NUD_ScenesUnlocked.ValueChanged += NUD_ScenesUnlocked_ValueChanged;
            // 
            // NUD_LastViewedScene
            // 
            NUD_LastViewedScene.Location = new Point(114, 67);
            NUD_LastViewedScene.Maximum = new decimal(new int[] { 19, 0, 0, 0 });
            NUD_LastViewedScene.Name = "NUD_LastViewedScene";
            NUD_LastViewedScene.Size = new Size(50, 23);
            NUD_LastViewedScene.TabIndex = 13;
            NUD_LastViewedScene.TextAlign = HorizontalAlignment.Center;
            toolTip1.SetToolTip(NUD_LastViewedScene, "This counter is used to track\r\nwhen should this field be toggled\r\nOn or Off.\r\n\r\nIf you're checking the box, you\r\nwould want this counter to be zero.");
            NUD_LastViewedScene.ValueChanged += NUD_LastViewedScene_ValueChanged;
            // 
            // NUD_FriendFacesCounter
            // 
            NUD_FriendFacesCounter.Location = new Point(128, 38);
            NUD_FriendFacesCounter.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            NUD_FriendFacesCounter.Name = "NUD_FriendFacesCounter";
            NUD_FriendFacesCounter.Size = new Size(50, 23);
            NUD_FriendFacesCounter.TabIndex = 15;
            NUD_FriendFacesCounter.TextAlign = HorizontalAlignment.Center;
            toolTip1.SetToolTip(NUD_FriendFacesCounter, "This counter is used to track\r\nwhen should this field be toggled\r\nOn or Off.\r\n\r\nIf you're checking the box, you\r\nwould want this counter to be zero.");
            NUD_FriendFacesCounter.ValueChanged += NUD_FriendFacesCounter_ValueChanged;
            // 
            // panel5
            // 
            panel5.Controls.Add(label9);
            panel5.Controls.Add(NUD_LastViewedScene);
            panel5.Controls.Add(NUD_ScenesUnlocked);
            panel5.Controls.Add(label8);
            panel5.Controls.Add(label6);
            panel5.Controls.Add(pictureBox6);
            panel5.Location = new Point(12, 302);
            panel5.Name = "panel5";
            panel5.Size = new Size(200, 100);
            panel5.TabIndex = 9;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(3, 69);
            label9.Name = "label9";
            label9.Size = new Size(105, 15);
            label9.TabIndex = 14;
            label9.Text = "Last viewed Scene:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 40);
            label8.Name = "label8";
            label8.Size = new Size(98, 15);
            label8.TabIndex = 12;
            label8.Text = "Scenes unlocked:";
            // 
            // label6
            // 
            label6.Location = new Point(73, 3);
            label6.Name = "label6";
            label6.Size = new Size(124, 32);
            label6.TabIndex = 10;
            label6.Text = "Title Screen";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.film;
            pictureBox6.Location = new Point(3, 3);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(64, 32);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 11;
            pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.SAF;
            pictureBox5.Location = new Point(3, 3);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(32, 32);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 10;
            pictureBox5.TabStop = false;
            // 
            // panel6
            // 
            panel6.Controls.Add(NUD_FriendFacesCounter);
            panel6.Controls.Add(label10);
            panel6.Controls.Add(label7);
            panel6.Controls.Add(pictureBox5);
            panel6.Location = new Point(218, 302);
            panel6.Name = "panel6";
            panel6.Size = new Size(200, 100);
            panel6.TabIndex = 11;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(3, 40);
            label10.Name = "label10";
            label10.Size = new Size(119, 15);
            label10.TabIndex = 16;
            label10.Text = "Friend Faces counter:";
            // 
            // label7
            // 
            label7.Location = new Point(41, 3);
            label7.Name = "label7";
            label7.Size = new Size(156, 32);
            label7.TabIndex = 10;
            label7.Text = "Show a Friend!";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // GlobalsEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 414);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "GlobalsEditor";
            Text = "Globals Editor";
            FormClosing += GlobalsEditor_FormClosing;
            Load += GlobalsEditor_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_UfoCounter).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_ScenesUnlocked).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_LastViewedScene).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_FriendFacesCounter).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private Panel panel3;
        private Label label3;
        private Panel panel4;
        private Label label4;
        private CheckBox CB_UfoActive;
        private ComboBox DROP_UfoStg;
        private Label label5;
        private CheckBox CB_SlideBtnStg4;
        private CheckBox CB_SlideBtnStg3;
        private CheckBox CB_SlideBtnStg2;
        private CheckBox CB_SlideBtnStg1;
        private CheckBox CB_SneakySnapsEnabled;
        private CheckBox CB_SneakySnapsIntroduced;
        private CheckBox CB_SneakySnapsUnlocked;
        private CheckBox CB_FaceCollectionUnlocked;
        private CheckBox CB_CrownEnable;
        private ToolTip toolTip1;
        private NumericUpDown NUD_UfoCounter;
        private Panel panel5;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private Label label6;
        private Panel panel6;
        private Label label7;
        private Label label9;
        private NumericUpDown NUD_LastViewedScene;
        private NumericUpDown NUD_ScenesUnlocked;
        private Label label8;
        private NumericUpDown NUD_FriendFacesCounter;
        private Label label10;
    }
}