namespace KbbEditCS
{
    partial class LinksForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinksForm));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.GitHubBranding;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(96, 96);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(114, 12);
            label1.Name = "label1";
            label1.Size = new Size(133, 30);
            label1.TabIndex = 2;
            label1.Text = "GitHub Page";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(114, 153);
            label2.Name = "label2";
            label2.Size = new Size(153, 30);
            label2.TabIndex = 5;
            label2.Text = "Discord Server";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.DiscordBranding;
            pictureBox2.Location = new Point(12, 153);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(96, 96);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.ForeColor = Color.Blue;
            textBox1.Location = new Point(114, 85);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(192, 23);
            textBox1.TabIndex = 6;
            textBox1.TabStop = false;
            textBox1.Text = "github.com/VinglesSmi/KbbEditCS";
            // 
            // textBox2
            // 
            textBox2.ForeColor = Color.Blue;
            textBox2.Location = new Point(114, 226);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(192, 23);
            textBox2.TabIndex = 7;
            textBox2.TabStop = false;
            textBox2.Text = "discord.gg/DXGveHZ4Gr";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(114, 42);
            label3.Name = "label3";
            label3.Size = new Size(155, 15);
            label3.TabIndex = 8;
            label3.Text = "Source code of the Program";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(114, 183);
            label4.Name = "label4";
            label4.Size = new Size(196, 15);
            label4.TabIndex = 9;
            label4.Text = "(15+) Discussion about Face Raiders";
            // 
            // LinksForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 261);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "LinksForm";
            Text = "Links";
            FormClosing += LinksForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private Label label4;
    }
}