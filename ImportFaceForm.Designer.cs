namespace KbbEditCS
{
    partial class ImportFaceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportFaceForm));
            B_Abort = new Button();
            DROP_Interpolation = new ComboBox();
            Label3 = new Label();
            B_Finish = new Button();
            CB_Guide = new CheckBox();
            Label2 = new Label();
            Label1 = new Label();
            NUD_TrPow = new NumericUpDown();
            NUD_ZoomPow = new NumericUpDown();
            B_ResetTransform = new Button();
            B_SelectImg = new Button();
            PB_Face = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)NUD_TrPow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_ZoomPow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PB_Face).BeginInit();
            SuspendLayout();
            // 
            // B_Abort
            // 
            B_Abort.BackColor = Color.Red;
            B_Abort.FlatAppearance.BorderSize = 0;
            B_Abort.FlatStyle = FlatStyle.Flat;
            B_Abort.Location = new Point(195, 466);
            B_Abort.Name = "B_Abort";
            B_Abort.Size = new Size(75, 23);
            B_Abort.TabIndex = 23;
            B_Abort.Text = "Abort";
            B_Abort.UseVisualStyleBackColor = false;
            B_Abort.Click += B_Abort_Click;
            // 
            // DROP_Interpolation
            // 
            DROP_Interpolation.DropDownStyle = ComboBoxStyle.DropDownList;
            DROP_Interpolation.FormattingEnabled = true;
            DROP_Interpolation.Items.AddRange(new object[] { "Default", "Low", "High", "Bilinear", "Bicubic", "Nearest Neighbor", "High Quality Bilinear", "High Quality Bicubic" });
            DROP_Interpolation.Location = new Point(150, 408);
            DROP_Interpolation.Name = "DROP_Interpolation";
            DROP_Interpolation.Size = new Size(120, 23);
            DROP_Interpolation.TabIndex = 22;
            DROP_Interpolation.SelectedIndexChanged += DROP_Interpolation_SelectedIndexChanged;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Pixel);
            Label3.Location = new Point(12, 408);
            Label3.Name = "Label3";
            Label3.Size = new Size(109, 23);
            Label3.TabIndex = 21;
            Label3.Text = "Interpolation";
            // 
            // B_Finish
            // 
            B_Finish.BackColor = Color.Chartreuse;
            B_Finish.Enabled = false;
            B_Finish.FlatAppearance.BorderSize = 0;
            B_Finish.FlatStyle = FlatStyle.Flat;
            B_Finish.Location = new Point(195, 437);
            B_Finish.Name = "B_Finish";
            B_Finish.Size = new Size(75, 23);
            B_Finish.TabIndex = 20;
            B_Finish.Text = "Finish";
            B_Finish.UseVisualStyleBackColor = false;
            B_Finish.Click += B_Finish_Click;
            // 
            // CB_Guide
            // 
            CB_Guide.AutoSize = true;
            CB_Guide.Location = new Point(12, 440);
            CB_Guide.Name = "CB_Guide";
            CB_Guide.Size = new Size(150, 19);
            CB_Guide.TabIndex = 19;
            CB_Guide.Text = "Show Calibration Guide";
            CB_Guide.UseVisualStyleBackColor = true;
            CB_Guide.CheckedChanged += CB_Guide_CheckedChanged;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Pixel);
            Label2.Location = new Point(12, 379);
            Label2.Name = "Label2";
            Label2.Size = new Size(129, 23);
            Label2.TabIndex = 18;
            Label2.Text = "Translate Power";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Pixel);
            Label1.Location = new Point(12, 350);
            Label1.Name = "Label1";
            Label1.Size = new Size(106, 23);
            Label1.TabIndex = 17;
            Label1.Text = "Zoom Power";
            // 
            // NUD_TrPow
            // 
            NUD_TrPow.DecimalPlaces = 2;
            NUD_TrPow.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            NUD_TrPow.Location = new Point(150, 379);
            NUD_TrPow.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            NUD_TrPow.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            NUD_TrPow.Name = "NUD_TrPow";
            NUD_TrPow.Size = new Size(120, 23);
            NUD_TrPow.TabIndex = 16;
            NUD_TrPow.TextAlign = HorizontalAlignment.Center;
            NUD_TrPow.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // NUD_ZoomPow
            // 
            NUD_ZoomPow.DecimalPlaces = 2;
            NUD_ZoomPow.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            NUD_ZoomPow.Location = new Point(150, 350);
            NUD_ZoomPow.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            NUD_ZoomPow.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            NUD_ZoomPow.Name = "NUD_ZoomPow";
            NUD_ZoomPow.Size = new Size(120, 23);
            NUD_ZoomPow.TabIndex = 15;
            NUD_ZoomPow.TextAlign = HorizontalAlignment.Center;
            NUD_ZoomPow.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // B_ResetTransform
            // 
            B_ResetTransform.Font = new Font("Segoe UI", 12F);
            B_ResetTransform.Location = new Point(12, 313);
            B_ResetTransform.Name = "B_ResetTransform";
            B_ResetTransform.Size = new Size(258, 31);
            B_ResetTransform.TabIndex = 14;
            B_ResetTransform.Text = "Reset image transform";
            B_ResetTransform.UseVisualStyleBackColor = true;
            B_ResetTransform.Click += B_ResetTransform_Click;
            // 
            // B_SelectImg
            // 
            B_SelectImg.Font = new Font("Segoe UI", 12F);
            B_SelectImg.Location = new Point(12, 276);
            B_SelectImg.Name = "B_SelectImg";
            B_SelectImg.Size = new Size(258, 31);
            B_SelectImg.TabIndex = 13;
            B_SelectImg.Text = "Select image...";
            B_SelectImg.UseVisualStyleBackColor = true;
            B_SelectImg.Click += B_SelectImg_Click;
            // 
            // PB_Face
            // 
            PB_Face.BackgroundImageLayout = ImageLayout.Stretch;
            PB_Face.BorderStyle = BorderStyle.FixedSingle;
            PB_Face.Location = new Point(12, 12);
            PB_Face.Name = "PB_Face";
            PB_Face.Size = new Size(258, 258);
            PB_Face.SizeMode = PictureBoxSizeMode.StretchImage;
            PB_Face.TabIndex = 12;
            PB_Face.TabStop = false;
            PB_Face.Paint += PB_Face_Paint;
            PB_Face.MouseDown += PB_Face_MouseDown;
            PB_Face.MouseMove += PB_Face_MouseMove;
            PB_Face.MouseUp += PB_Face_MouseUp;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp";
            // 
            // ImportFaceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 501);
            ControlBox = false;
            Controls.Add(B_Abort);
            Controls.Add(DROP_Interpolation);
            Controls.Add(Label3);
            Controls.Add(B_Finish);
            Controls.Add(CB_Guide);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Controls.Add(NUD_TrPow);
            Controls.Add(NUD_ZoomPow);
            Controls.Add(B_ResetTransform);
            Controls.Add(B_SelectImg);
            Controls.Add(PB_Face);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ImportFaceForm";
            Text = "Import Face";
            FormClosed += ImportFaceForm_FormClosed;
            ((System.ComponentModel.ISupportInitialize)NUD_TrPow).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_ZoomPow).EndInit();
            ((System.ComponentModel.ISupportInitialize)PB_Face).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal Button B_Abort;
        internal ComboBox DROP_Interpolation;
        internal Label Label3;
        internal Button B_Finish;
        internal CheckBox CB_Guide;
        internal Label Label2;
        internal Label Label1;
        internal NumericUpDown NUD_TrPow;
        internal NumericUpDown NUD_ZoomPow;
        internal Button B_ResetTransform;
        internal Button B_SelectImg;
        internal PictureBox PB_Face;
        private OpenFileDialog openFileDialog1;
    }
}