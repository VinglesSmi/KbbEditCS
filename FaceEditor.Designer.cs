namespace KbbEditCS
{
    partial class FaceEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaceEditor));
            B_NextPage = new Button();
            PB_Face10 = new PictureBox();
            PB_Face9 = new PictureBox();
            PB_Face8 = new PictureBox();
            PB_Face7 = new PictureBox();
            PB_Face6 = new PictureBox();
            PB_Face5 = new PictureBox();
            PB_Face4 = new PictureBox();
            PB_Face3 = new PictureBox();
            PB_Face2 = new PictureBox();
            B_PrevPage = new Button();
            PB_Face1 = new PictureBox();
            panel1 = new Panel();
            PB_CurrentFace = new PictureBox();
            panel2 = new Panel();
            B_Recover = new Button();
            B_Delete = new Button();
            B_SwapFaces = new Button();
            B_NewFace = new Button();
            B_ImportImg = new Button();
            B_ExportImg = new Button();
            NUD_VScale = new NumericUpDown();
            DROP_FaceGender = new ComboBox();
            NUD_VScroll = new NumericUpDown();
            NUD_MeetYear = new NumericUpDown();
            NUD_HScale = new NumericUpDown();
            DROP_FaceAge = new ComboBox();
            NUD_Rotation = new NumericUpDown();
            NUD_MeetMonth = new NumericUpDown();
            NUD_HScroll = new NumericUpDown();
            label12 = new Label();
            NUD_FaceSelections = new NumericUpDown();
            label11 = new Label();
            NUD_MeetDay = new NumericUpDown();
            label9 = new Label();
            label5 = new Label();
            label10 = new Label();
            label6 = new Label();
            label8 = new Label();
            label3 = new Label();
            label7 = new Label();
            label2 = new Label();
            label4 = new Label();
            CB_Guide = new CheckBox();
            label1 = new Label();
            toolTip1 = new ToolTip(components);
            saveFileDialog1 = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)PB_Face10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PB_Face9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PB_Face8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PB_Face7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PB_Face6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PB_Face5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PB_Face4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PB_Face3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PB_Face2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PB_Face1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PB_CurrentFace).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_VScale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_VScroll).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_MeetYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_HScale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Rotation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_MeetMonth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_HScroll).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_FaceSelections).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_MeetDay).BeginInit();
            SuspendLayout();
            // 
            // B_NextPage
            // 
            B_NextPage.Enabled = false;
            B_NextPage.Location = new Point(743, 102);
            B_NextPage.Name = "B_NextPage";
            B_NextPage.Size = new Size(64, 64);
            B_NextPage.TabIndex = 36;
            B_NextPage.Text = "Next\r\n⟶";
            B_NextPage.UseVisualStyleBackColor = true;
            B_NextPage.Click += B_NextPage_Click;
            // 
            // PB_Face10
            // 
            PB_Face10.BackgroundImage = Properties.Resources.DummyFace;
            PB_Face10.BorderStyle = BorderStyle.FixedSingle;
            PB_Face10.Enabled = false;
            PB_Face10.Image = Properties.Resources.FaceHole;
            PB_Face10.Location = new Point(609, 137);
            PB_Face10.Name = "PB_Face10";
            PB_Face10.Size = new Size(128, 128);
            PB_Face10.TabIndex = 35;
            PB_Face10.TabStop = false;
            PB_Face10.Click += PB_Face10_Click;
            // 
            // PB_Face9
            // 
            PB_Face9.BackgroundImage = Properties.Resources.DummyFace;
            PB_Face9.BorderStyle = BorderStyle.FixedSingle;
            PB_Face9.Enabled = false;
            PB_Face9.Image = Properties.Resources.FaceHole;
            PB_Face9.Location = new Point(475, 137);
            PB_Face9.Name = "PB_Face9";
            PB_Face9.Size = new Size(128, 128);
            PB_Face9.TabIndex = 34;
            PB_Face9.TabStop = false;
            PB_Face9.Click += PB_Face9_Click;
            // 
            // PB_Face8
            // 
            PB_Face8.BackgroundImage = Properties.Resources.DummyFace;
            PB_Face8.BorderStyle = BorderStyle.FixedSingle;
            PB_Face8.Enabled = false;
            PB_Face8.Image = Properties.Resources.FaceHole;
            PB_Face8.Location = new Point(341, 137);
            PB_Face8.Name = "PB_Face8";
            PB_Face8.Size = new Size(128, 128);
            PB_Face8.TabIndex = 33;
            PB_Face8.TabStop = false;
            PB_Face8.Click += PB_Face8_Click;
            // 
            // PB_Face7
            // 
            PB_Face7.BackgroundImage = Properties.Resources.DummyFace;
            PB_Face7.BorderStyle = BorderStyle.FixedSingle;
            PB_Face7.Enabled = false;
            PB_Face7.Image = Properties.Resources.FaceHole;
            PB_Face7.Location = new Point(207, 137);
            PB_Face7.Name = "PB_Face7";
            PB_Face7.Size = new Size(128, 128);
            PB_Face7.TabIndex = 32;
            PB_Face7.TabStop = false;
            PB_Face7.Click += PB_Face7_Click;
            // 
            // PB_Face6
            // 
            PB_Face6.BackgroundImage = Properties.Resources.DummyFace;
            PB_Face6.BorderStyle = BorderStyle.FixedSingle;
            PB_Face6.Enabled = false;
            PB_Face6.Image = Properties.Resources.FaceHole;
            PB_Face6.Location = new Point(73, 137);
            PB_Face6.Name = "PB_Face6";
            PB_Face6.Size = new Size(128, 128);
            PB_Face6.TabIndex = 31;
            PB_Face6.TabStop = false;
            PB_Face6.Click += PB_Face6_Click;
            // 
            // PB_Face5
            // 
            PB_Face5.BackgroundImage = Properties.Resources.DummyFace;
            PB_Face5.BorderStyle = BorderStyle.FixedSingle;
            PB_Face5.Enabled = false;
            PB_Face5.Image = Properties.Resources.FaceHole;
            PB_Face5.Location = new Point(609, 3);
            PB_Face5.Name = "PB_Face5";
            PB_Face5.Size = new Size(128, 128);
            PB_Face5.TabIndex = 30;
            PB_Face5.TabStop = false;
            PB_Face5.Click += PB_Face5_Click;
            // 
            // PB_Face4
            // 
            PB_Face4.BackgroundImage = Properties.Resources.DummyFace;
            PB_Face4.BorderStyle = BorderStyle.FixedSingle;
            PB_Face4.Enabled = false;
            PB_Face4.Image = Properties.Resources.FaceHole;
            PB_Face4.Location = new Point(475, 3);
            PB_Face4.Name = "PB_Face4";
            PB_Face4.Size = new Size(128, 128);
            PB_Face4.TabIndex = 29;
            PB_Face4.TabStop = false;
            PB_Face4.Click += PB_Face4_Click;
            // 
            // PB_Face3
            // 
            PB_Face3.BackgroundImage = Properties.Resources.DummyFace;
            PB_Face3.BorderStyle = BorderStyle.FixedSingle;
            PB_Face3.Enabled = false;
            PB_Face3.Image = Properties.Resources.FaceHole;
            PB_Face3.Location = new Point(341, 3);
            PB_Face3.Name = "PB_Face3";
            PB_Face3.Size = new Size(128, 128);
            PB_Face3.TabIndex = 28;
            PB_Face3.TabStop = false;
            PB_Face3.Click += PB_Face3_Click;
            // 
            // PB_Face2
            // 
            PB_Face2.BackgroundImage = Properties.Resources.DummyFace;
            PB_Face2.BorderStyle = BorderStyle.FixedSingle;
            PB_Face2.Enabled = false;
            PB_Face2.Image = Properties.Resources.FaceHole;
            PB_Face2.Location = new Point(207, 3);
            PB_Face2.Name = "PB_Face2";
            PB_Face2.Size = new Size(128, 128);
            PB_Face2.TabIndex = 27;
            PB_Face2.TabStop = false;
            PB_Face2.Click += PB_Face2_Click;
            // 
            // B_PrevPage
            // 
            B_PrevPage.Enabled = false;
            B_PrevPage.Location = new Point(3, 102);
            B_PrevPage.Name = "B_PrevPage";
            B_PrevPage.Size = new Size(64, 64);
            B_PrevPage.TabIndex = 26;
            B_PrevPage.Text = "Previous\r\n⟵";
            B_PrevPage.UseVisualStyleBackColor = true;
            B_PrevPage.Click += B_PrevPage_Click;
            // 
            // PB_Face1
            // 
            PB_Face1.BackgroundImage = Properties.Resources.DummyFace;
            PB_Face1.BorderStyle = BorderStyle.FixedSingle;
            PB_Face1.Enabled = false;
            PB_Face1.Image = Properties.Resources.FaceHole;
            PB_Face1.Location = new Point(73, 3);
            PB_Face1.Name = "PB_Face1";
            PB_Face1.Size = new Size(128, 128);
            PB_Face1.TabIndex = 25;
            PB_Face1.TabStop = false;
            PB_Face1.Click += PB_Face1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(PB_Face1);
            panel1.Controls.Add(B_NextPage);
            panel1.Controls.Add(B_PrevPage);
            panel1.Controls.Add(PB_Face10);
            panel1.Controls.Add(PB_Face2);
            panel1.Controls.Add(PB_Face9);
            panel1.Controls.Add(PB_Face3);
            panel1.Controls.Add(PB_Face8);
            panel1.Controls.Add(PB_Face4);
            panel1.Controls.Add(PB_Face7);
            panel1.Controls.Add(PB_Face5);
            panel1.Controls.Add(PB_Face6);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(810, 268);
            panel1.TabIndex = 37;
            // 
            // PB_CurrentFace
            // 
            PB_CurrentFace.BorderStyle = BorderStyle.FixedSingle;
            PB_CurrentFace.Enabled = false;
            PB_CurrentFace.Image = Properties.Resources.FaceHole;
            PB_CurrentFace.Location = new Point(3, 18);
            PB_CurrentFace.Name = "PB_CurrentFace";
            PB_CurrentFace.Size = new Size(128, 128);
            PB_CurrentFace.TabIndex = 37;
            PB_CurrentFace.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(B_Recover);
            panel2.Controls.Add(B_Delete);
            panel2.Controls.Add(B_SwapFaces);
            panel2.Controls.Add(B_NewFace);
            panel2.Controls.Add(B_ImportImg);
            panel2.Controls.Add(B_ExportImg);
            panel2.Controls.Add(NUD_VScale);
            panel2.Controls.Add(DROP_FaceGender);
            panel2.Controls.Add(NUD_VScroll);
            panel2.Controls.Add(NUD_MeetYear);
            panel2.Controls.Add(NUD_HScale);
            panel2.Controls.Add(DROP_FaceAge);
            panel2.Controls.Add(NUD_Rotation);
            panel2.Controls.Add(NUD_MeetMonth);
            panel2.Controls.Add(NUD_HScroll);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(NUD_FaceSelections);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(NUD_MeetDay);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(CB_Guide);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(PB_CurrentFace);
            panel2.Location = new Point(12, 286);
            panel2.Name = "panel2";
            panel2.Size = new Size(810, 174);
            panel2.TabIndex = 38;
            // 
            // B_Recover
            // 
            B_Recover.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            B_Recover.ForeColor = Color.SeaGreen;
            B_Recover.Location = new Point(492, 129);
            B_Recover.Name = "B_Recover";
            B_Recover.Size = new Size(155, 42);
            B_Recover.TabIndex = 61;
            B_Recover.Text = "Face Recovery";
            B_Recover.UseVisualStyleBackColor = true;
            B_Recover.Click += B_Recover_Click;
            // 
            // B_Delete
            // 
            B_Delete.Enabled = false;
            B_Delete.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            B_Delete.ForeColor = Color.Red;
            B_Delete.Location = new Point(653, 129);
            B_Delete.Name = "B_Delete";
            B_Delete.Size = new Size(154, 42);
            B_Delete.TabIndex = 60;
            B_Delete.Text = "Delete Face";
            B_Delete.UseVisualStyleBackColor = true;
            B_Delete.Click += B_Delete_Click;
            // 
            // B_SwapFaces
            // 
            B_SwapFaces.Enabled = false;
            B_SwapFaces.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            B_SwapFaces.Location = new Point(653, 51);
            B_SwapFaces.Name = "B_SwapFaces";
            B_SwapFaces.Size = new Size(154, 42);
            B_SwapFaces.TabIndex = 59;
            B_SwapFaces.Text = "Swap Faces";
            B_SwapFaces.UseVisualStyleBackColor = true;
            B_SwapFaces.Click += B_SwapFaces_Click;
            // 
            // B_NewFace
            // 
            B_NewFace.Enabled = false;
            B_NewFace.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            B_NewFace.Location = new Point(492, 51);
            B_NewFace.Name = "B_NewFace";
            B_NewFace.Size = new Size(155, 42);
            B_NewFace.TabIndex = 58;
            B_NewFace.Text = "New Face";
            B_NewFace.UseVisualStyleBackColor = true;
            B_NewFace.Click += B_NewFace_Click;
            // 
            // B_ImportImg
            // 
            B_ImportImg.Enabled = false;
            B_ImportImg.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            B_ImportImg.Location = new Point(492, 3);
            B_ImportImg.Name = "B_ImportImg";
            B_ImportImg.Size = new Size(155, 42);
            B_ImportImg.TabIndex = 52;
            B_ImportImg.Text = "Import Image";
            B_ImportImg.UseVisualStyleBackColor = true;
            B_ImportImg.Click += B_ImportImg_Click;
            // 
            // B_ExportImg
            // 
            B_ExportImg.Enabled = false;
            B_ExportImg.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            B_ExportImg.Location = new Point(653, 3);
            B_ExportImg.Name = "B_ExportImg";
            B_ExportImg.Size = new Size(154, 42);
            B_ExportImg.TabIndex = 51;
            B_ExportImg.Text = "Export Image";
            B_ExportImg.UseVisualStyleBackColor = true;
            B_ExportImg.Click += B_ExportImg_Click;
            // 
            // NUD_VScale
            // 
            NUD_VScale.DecimalPlaces = 3;
            NUD_VScale.Enabled = false;
            NUD_VScale.Font = new Font("Segoe UI", 12F);
            NUD_VScale.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            NUD_VScale.Location = new Point(413, 68);
            NUD_VScale.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            NUD_VScale.Minimum = new decimal(new int[] { 25, 0, 0, 131072 });
            NUD_VScale.Name = "NUD_VScale";
            NUD_VScale.Size = new Size(73, 29);
            NUD_VScale.TabIndex = 54;
            toolTip1.SetToolTip(NUD_VScale, "This scales the Face's image vertically.");
            NUD_VScale.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NUD_VScale.ValueChanged += NUD_VScale_ValueChanged;
            // 
            // DROP_FaceGender
            // 
            DROP_FaceGender.DropDownStyle = ComboBoxStyle.DropDownList;
            DROP_FaceGender.Enabled = false;
            DROP_FaceGender.Font = new Font("Segoe UI", 9F);
            DROP_FaceGender.FormattingEnabled = true;
            DROP_FaceGender.Items.AddRange(new object[] { "Male", "Female", "??" });
            DROP_FaceGender.Location = new Point(207, 123);
            DROP_FaceGender.Name = "DROP_FaceGender";
            DROP_FaceGender.Size = new Size(121, 23);
            DROP_FaceGender.TabIndex = 44;
            DROP_FaceGender.SelectedIndexChanged += DROP_FaceGender_SelectedIndexChanged;
            // 
            // NUD_VScroll
            // 
            NUD_VScroll.DecimalPlaces = 3;
            NUD_VScroll.Enabled = false;
            NUD_VScroll.Font = new Font("Segoe UI", 12F);
            NUD_VScroll.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            NUD_VScroll.Location = new Point(413, 18);
            NUD_VScroll.Maximum = new decimal(new int[] { 5, 0, 0, 65536 });
            NUD_VScroll.Minimum = new decimal(new int[] { 5, 0, 0, -2147418112 });
            NUD_VScroll.Name = "NUD_VScroll";
            NUD_VScroll.Size = new Size(73, 29);
            NUD_VScroll.TabIndex = 53;
            toolTip1.SetToolTip(NUD_VScroll, "This applies a vertical translation on the Face's image.");
            NUD_VScroll.ValueChanged += NUD_VScroll_ValueChanged;
            // 
            // NUD_MeetYear
            // 
            NUD_MeetYear.Enabled = false;
            NUD_MeetYear.Font = new Font("Segoe UI", 12F);
            NUD_MeetYear.Location = new Point(137, 117);
            NUD_MeetYear.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            NUD_MeetYear.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NUD_MeetYear.Name = "NUD_MeetYear";
            NUD_MeetYear.Size = new Size(64, 29);
            NUD_MeetYear.TabIndex = 42;
            NUD_MeetYear.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            NUD_MeetYear.ValueChanged += NUD_MeetYear_ValueChanged;
            // 
            // NUD_HScale
            // 
            NUD_HScale.DecimalPlaces = 3;
            NUD_HScale.Enabled = false;
            NUD_HScale.Font = new Font("Segoe UI", 12F);
            NUD_HScale.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            NUD_HScale.Location = new Point(334, 68);
            NUD_HScale.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            NUD_HScale.Minimum = new decimal(new int[] { 25, 0, 0, 131072 });
            NUD_HScale.Name = "NUD_HScale";
            NUD_HScale.Size = new Size(73, 29);
            NUD_HScale.TabIndex = 50;
            toolTip1.SetToolTip(NUD_HScale, "This scales the Face's image horizontally.");
            NUD_HScale.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NUD_HScale.ValueChanged += NUD_HScale_ValueChanged;
            // 
            // DROP_FaceAge
            // 
            DROP_FaceAge.DropDownStyle = ComboBoxStyle.DropDownList;
            DROP_FaceAge.Enabled = false;
            DROP_FaceAge.Font = new Font("Segoe UI", 9F);
            DROP_FaceAge.FormattingEnabled = true;
            DROP_FaceAge.Items.AddRange(new object[] { "Baby (up to 3 years)", "Child (4-9 years)", "Young (10-29 years)", "Adult (30-49 years)", "Adult (over 50 years)", "??" });
            DROP_FaceAge.Location = new Point(207, 73);
            DROP_FaceAge.Name = "DROP_FaceAge";
            DROP_FaceAge.Size = new Size(121, 23);
            DROP_FaceAge.TabIndex = 42;
            DROP_FaceAge.SelectedIndexChanged += DROP_FaceAge_SelectedIndexChanged;
            // 
            // NUD_Rotation
            // 
            NUD_Rotation.DecimalPlaces = 6;
            NUD_Rotation.Enabled = false;
            NUD_Rotation.Font = new Font("Segoe UI", 12F);
            NUD_Rotation.Location = new Point(334, 117);
            NUD_Rotation.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            NUD_Rotation.Minimum = new decimal(new int[] { 180, 0, 0, int.MinValue });
            NUD_Rotation.Name = "NUD_Rotation";
            NUD_Rotation.Size = new Size(114, 29);
            NUD_Rotation.TabIndex = 49;
            toolTip1.SetToolTip(NUD_Rotation, "This applies rotation to the Face's image.");
            NUD_Rotation.ValueChanged += NUD_Rotation_ValueChanged;
            // 
            // NUD_MeetMonth
            // 
            NUD_MeetMonth.Enabled = false;
            NUD_MeetMonth.Font = new Font("Segoe UI", 12F);
            NUD_MeetMonth.Location = new Point(137, 68);
            NUD_MeetMonth.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            NUD_MeetMonth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NUD_MeetMonth.Name = "NUD_MeetMonth";
            NUD_MeetMonth.Size = new Size(54, 29);
            NUD_MeetMonth.TabIndex = 41;
            NUD_MeetMonth.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NUD_MeetMonth.ValueChanged += NUD_MeetMonth_ValueChanged;
            // 
            // NUD_HScroll
            // 
            NUD_HScroll.DecimalPlaces = 3;
            NUD_HScroll.Enabled = false;
            NUD_HScroll.Font = new Font("Segoe UI", 12F);
            NUD_HScroll.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            NUD_HScroll.Location = new Point(334, 18);
            NUD_HScroll.Maximum = new decimal(new int[] { 5, 0, 0, 65536 });
            NUD_HScroll.Minimum = new decimal(new int[] { 5, 0, 0, -2147418112 });
            NUD_HScroll.Name = "NUD_HScroll";
            NUD_HScroll.Size = new Size(73, 29);
            NUD_HScroll.TabIndex = 48;
            toolTip1.SetToolTip(NUD_HScroll, "This applies a horizontal translation on the Face's image.");
            NUD_HScroll.ValueChanged += NUD_HScroll_ValueChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(334, 100);
            label12.Name = "label12";
            label12.Size = new Size(117, 15);
            label12.TabIndex = 57;
            label12.Text = "Rotation (in degrees)";
            // 
            // NUD_FaceSelections
            // 
            NUD_FaceSelections.Enabled = false;
            NUD_FaceSelections.Font = new Font("Segoe UI", 12F);
            NUD_FaceSelections.Location = new Point(207, 18);
            NUD_FaceSelections.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            NUD_FaceSelections.Name = "NUD_FaceSelections";
            NUD_FaceSelections.Size = new Size(89, 29);
            NUD_FaceSelections.TabIndex = 41;
            toolTip1.SetToolTip(NUD_FaceSelections, resources.GetString("NUD_FaceSelections.ToolTip"));
            NUD_FaceSelections.ValueChanged += NUD_FaceSelections_ValueChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(413, 50);
            label11.Name = "label11";
            label11.Size = new Size(53, 15);
            label11.TabIndex = 56;
            label11.Text = "Y stretch";
            // 
            // NUD_MeetDay
            // 
            NUD_MeetDay.Enabled = false;
            NUD_MeetDay.Font = new Font("Segoe UI", 12F);
            NUD_MeetDay.Location = new Point(137, 18);
            NUD_MeetDay.Maximum = new decimal(new int[] { 28, 0, 0, 0 });
            NUD_MeetDay.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NUD_MeetDay.Name = "NUD_MeetDay";
            NUD_MeetDay.Size = new Size(54, 29);
            NUD_MeetDay.TabIndex = 40;
            NUD_MeetDay.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NUD_MeetDay.ValueChanged += NUD_MeetDate_ValueChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(413, 0);
            label9.Name = "label9";
            label9.Size = new Size(45, 15);
            label9.TabIndex = 55;
            label9.Text = "Y scroll";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(207, 0);
            label5.Name = "label5";
            label5.Size = new Size(63, 15);
            label5.TabIndex = 40;
            label5.Text = "Selections:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(334, 50);
            label10.Name = "label10";
            label10.Size = new Size(53, 15);
            label10.TabIndex = 52;
            label10.Text = "X stretch";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Location = new Point(207, 56);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 43;
            label6.Text = "Age:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(334, 0);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 51;
            label8.Text = "X scroll";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(137, 50);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 44;
            label3.Text = "Month met:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Location = new Point(207, 106);
            label7.Name = "label7";
            label7.Size = new Size(48, 15);
            label7.TabIndex = 45;
            label7.Text = "Gender:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(137, 0);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 43;
            label2.Text = "Day met:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(137, 100);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 45;
            label4.Text = "Year met:";
            // 
            // CB_Guide
            // 
            CB_Guide.AutoSize = true;
            CB_Guide.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CB_Guide.Location = new Point(3, 152);
            CB_Guide.Name = "CB_Guide";
            CB_Guide.Size = new Size(150, 19);
            CB_Guide.TabIndex = 39;
            CB_Guide.Text = "Show Calibration Guide";
            toolTip1.SetToolTip(CB_Guide, "This helps to see where the eyes and mouth should go.");
            CB_Guide.UseVisualStyleBackColor = true;
            CB_Guide.Click += CB_Guide_Click;
            // 
            // label1
            // 
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 38;
            label1.Text = "Selected Face:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Filter = "PNG Image|*.png";
            // 
            // FaceEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 472);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FaceEditor";
            Text = "Face Editor";
            FormClosing += FaceEditor_FormClosing;
            Load += FaceEditor_Load;
            ((System.ComponentModel.ISupportInitialize)PB_Face10).EndInit();
            ((System.ComponentModel.ISupportInitialize)PB_Face9).EndInit();
            ((System.ComponentModel.ISupportInitialize)PB_Face8).EndInit();
            ((System.ComponentModel.ISupportInitialize)PB_Face7).EndInit();
            ((System.ComponentModel.ISupportInitialize)PB_Face6).EndInit();
            ((System.ComponentModel.ISupportInitialize)PB_Face5).EndInit();
            ((System.ComponentModel.ISupportInitialize)PB_Face4).EndInit();
            ((System.ComponentModel.ISupportInitialize)PB_Face3).EndInit();
            ((System.ComponentModel.ISupportInitialize)PB_Face2).EndInit();
            ((System.ComponentModel.ISupportInitialize)PB_Face1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PB_CurrentFace).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_VScale).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_VScroll).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_MeetYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_HScale).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_Rotation).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_MeetMonth).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_HScroll).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_FaceSelections).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_MeetDay).EndInit();
            ResumeLayout(false);
        }

        #endregion

        internal Button B_NextPage;
        internal PictureBox PB_Face10;
        internal PictureBox PB_Face9;
        internal PictureBox PB_Face8;
        internal PictureBox PB_Face7;
        internal PictureBox PB_Face6;
        internal PictureBox PB_Face5;
        internal PictureBox PB_Face4;
        internal PictureBox PB_Face3;
        internal PictureBox PB_Face2;
        internal Button B_PrevPage;
        internal PictureBox PB_Face1;
        private Panel panel1;
        internal PictureBox PB_CurrentFace;
        private Panel panel2;
        private Label label1;
        private CheckBox CB_Guide;
        internal Label label2;
        internal NumericUpDown NUD_MeetYear;
        internal NumericUpDown NUD_MeetMonth;
        internal NumericUpDown NUD_MeetDay;
        internal Label label3;
        internal Label label4;
        internal ComboBox DROP_FaceGender;
        internal ComboBox DROP_FaceAge;
        internal NumericUpDown NUD_FaceSelections;
        internal Label label5;
        internal Label label6;
        internal Label label7;
        internal NumericUpDown NUD_VScale;
        internal NumericUpDown NUD_VScroll;
        internal NumericUpDown NUD_HScale;
        internal NumericUpDown NUD_Rotation;
        internal NumericUpDown NUD_HScroll;
        internal Label label12;
        internal Label label11;
        internal Label label9;
        internal Label label10;
        internal Label label8;
        private ToolTip toolTip1;
        internal Button B_ImportImg;
        internal Button B_ExportImg;
        internal Button B_SwapFaces;
        internal Button B_NewFace;
        internal Button B_Recover;
        internal Button B_Delete;
        private SaveFileDialog saveFileDialog1;
    }
}