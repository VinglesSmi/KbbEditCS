using KbbEditCS.Properties;
using System.Drawing.Drawing2D;

namespace KbbEditCS
{
    public partial class ImportFaceForm : Form
    {
        private Bitmap? srcimg; // source image
        public Bitmap resimg;  // result image

        float c_zoom = 2.0f;
        float c_rot = 0.0f;
        float c_offs_x = 0.0f;
        float c_offs_y = 0.0f;

        bool u_dragging;
        Point lastmousepos;

        public ImportFaceForm()
        {
            InitializeComponent();

            PB_Face.MouseWheel += PB_Face_MouseWheel; // Visual Studio does not show this event in the properties tab for some reason.

            u_dragging = false;
            DROP_Interpolation.SelectedIndex = 0;
            resimg = new Bitmap(1, 1);
        }

        private InterpolationMode GetInterpolationMode()
        {
            switch (DROP_Interpolation.SelectedItem?.ToString())
            {
                case "Low": return InterpolationMode.Low;
                case "High": return InterpolationMode.High;
                case "Bilinear": return InterpolationMode.Bilinear;
                case "Bicubic": return InterpolationMode.Bicubic;
                case "Nearest Neighbor": return InterpolationMode.NearestNeighbor;
                case "High Quality Bilinear": return InterpolationMode.HighQualityBilinear;
                case "High Quality Bicubic": return InterpolationMode.HighQualityBicubic;
                default: return InterpolationMode.Default;
            }
        }

        void ResetTransform()
        {
            c_zoom = 2.0f;
            c_rot = 0.0f;
            c_offs_x = 0.0f;
            c_offs_y = 0.0f;

            PB_Face.Invalidate();
        }

        void DrawTransformedImg(Graphics g, int w, int h)
        {
            if (srcimg == null) return;

            // First step: Scaling
            float sx = (float)w / (float)PB_Face.ClientSize.Width;
            float sy = (float)h / (float)PB_Face.ClientSize.Height;

            float cx = (PB_Face.ClientSize.Width / 2.0f + c_offs_x) * sx;
            float cy = (PB_Face.ClientSize.Height / 2.0f + c_offs_y) * sy;

            float b = srcimg.Width >= srcimg.Height ? srcimg.Width : srcimg.Height;
            sx /= b/128.0f; sy /= b/128.0f;

            // Second step: Rotation
            float angle = float.DegreesToRadians(c_rot);

            float cos = MathF.Cos(angle);
            float sin = MathF.Sin(angle);

            float hw = srcimg.Width * c_zoom / 2.0f;
            float hh = srcimg.Height * c_zoom / 2.0f;

            // Third step: image horizontal and vertical vectors
            float ux = cos * hw * sx;
            float uy = sin * hw * sy;

            float vx = -sin * hh * sx;
            float vy = cos * hh * sy;

            // Vertices of the parallelogram
            PointF[] corners = {
                new PointF(cx - ux - vx, cy - uy - vy),
                new PointF(cx + ux - vx, cy + uy - vy),
                new PointF(cx - ux + vx, cy - uy + vy)
            };

            g.DrawImage(srcimg, corners);
        }

        private Bitmap GenerateResImg()
        {
            Bitmap res = new Bitmap(128, 128);
            using (Graphics g = Graphics.FromImage(res))
            {
                g.Clear(Color.Black);
                g.InterpolationMode = GetInterpolationMode();
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;

                DrawTransformedImg(g, 128, 128);
            }
            return res;
        }

        private void ImportFaceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            srcimg?.Dispose();
        }

        private void B_Abort_Click(object sender, EventArgs e)
        {
            resimg?.Dispose();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void B_Finish_Click(object sender, EventArgs e)
        {
            resimg?.Dispose();
            resimg = GenerateResImg();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void B_SelectImg_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap newimg = new Bitmap(Image.FromFile(openFileDialog1.FileName));

                srcimg?.Dispose();
                srcimg = newimg;

                ResetTransform();

                B_Finish.Enabled = true;

                PB_Face.Invalidate();
            }
        }

        private void B_ResetTransform_Click(object sender, EventArgs e) { ResetTransform(); }

        private void PB_Face_MouseDown(object sender, MouseEventArgs e)
        {
            if (srcimg == null || e.Button != MouseButtons.Left) return;

            u_dragging = true;
            lastmousepos = e.Location;
            PB_Face.Cursor = Cursors.SizeAll;
        }

        private void PB_Face_MouseUp(object sender, MouseEventArgs e)
        {
            if (srcimg == null || e.Button != MouseButtons.Left) return;

            u_dragging = false;
            lastmousepos = e.Location;
            PB_Face.Cursor = Cursors.Default;
        }

        private void PB_Face_MouseMove(object sender, MouseEventArgs e)
        {
            if (!u_dragging) return;

            float s = (float)NUD_TrPow.Value;

            float dx = e.X - lastmousepos.X;
            float dy = e.Y - lastmousepos.Y;

            c_offs_x += dx * s;
            c_offs_y += dy * s;

            lastmousepos = e.Location;

            PB_Face.Invalidate();
        }

        private void PB_Face_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (srcimg == null) return;

            float ws = e.Delta / 120.0f; // wheel steps

            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                // Ctrl + wheel = Zoom
                float pow = (float)NUD_ZoomPow.Value;

                float factor = MathF.Pow(1.1f, ws * pow);

                c_zoom *= factor;

                // Prevent unreasonable zoom values.
                c_zoom = MathF.Max(1.0f, MathF.Min(20.0f, c_zoom));
            }
            else
            {
                // Wheel = Rotation
                c_rot += ws * 5.0f;

                // Keep rotation within 0-360 degrees
                c_rot %= 360.0f;
            }

            PB_Face.Invalidate();
        }

        private void PB_Face_Paint(object sender, PaintEventArgs e)
        {
            if (srcimg == null) return;

            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            g.InterpolationMode = GetInterpolationMode();

            DrawTransformedImg(g, PB_Face.Width, PB_Face.Height);

            if (CB_Guide.Checked)
            {
                g.DrawImage(Resources.FaceGuide, 0, 0, PB_Face.Width, PB_Face.Height);
            }
        }

        private void DROP_Interpolation_SelectedIndexChanged(object sender, EventArgs e)
        {
            PB_Face.Invalidate();
        }

        private void CB_Guide_CheckedChanged(object sender, EventArgs e)
        {
            PB_Face.Invalidate();
        }
    }
}
