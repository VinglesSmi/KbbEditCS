namespace KbbEditCS
{
    public partial class SelectFaceDialog : Form
    {
        public int sel_face_id = -1;
        public static int current_page = 0;

        private PictureBox[] pbs;

        public SelectFaceDialog()
        {
            InitializeComponent();

            pbs = new PictureBox[] {
                PB_Face1,
                PB_Face2,
                PB_Face3,
                PB_Face4,
                PB_Face5,
                PB_Face6,
                PB_Face7,
                PB_Face8,
                PB_Face9,
                PB_Face10
            };
        }

        void DisplayFaces(int page)
        {
            for (int i = page == 0 ? 1 : 0; i < 10; i++)
            {
                int faceid = Globals.ordered_faces[10 * page + i - 1];
                if (faceid != -1)
                {
                    pbs[i].Enabled = true;
                    pbs[i].BackgroundImage = Globals.GetFaceImg(faceid);
                }
                else
                {
                    B_NextPage.Enabled = false;
                    for (int j = i; j < 10; j++)
                    {
                        pbs[j].Enabled = false;
                        pbs[j].BackgroundImage = null;
                    }
                    break;
                }
            }

            // Check if the previous page button should be enabled
            if (page == 0)
            {
                B_PrevPage.Enabled = false;
                pbs[0].BackgroundImage = null;
                pbs[0].Enabled = false;
            }
            else
            {
                B_PrevPage.Enabled = true;
            }

            // Check if the next page button should be enabled
            if (page == 4)
            {
                B_NextPage.Enabled = false;
            }
            else
            {
                int faceid = Globals.ordered_faces[10 * (page + 1) - 1];
                B_NextPage.Enabled = faceid != -1;
            }
        }

        void ReturnFaceID(int page, int slot)
        {
            sel_face_id = Globals.ordered_faces[10*page+slot-1];
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SelectFaceDialog_Load(object sender, EventArgs e)
        {
            current_page = 0;
            DisplayFaces(current_page);
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void B_PrevPage_Click(object sender, EventArgs e)
        {
            current_page--;
            DisplayFaces(current_page);
        }

        private void B_NextPage_Click(object sender, EventArgs e)
        {
            current_page++;
            DisplayFaces(current_page);
        }

        private void PB_Face1_Click(object sender, EventArgs e) { ReturnFaceID(current_page, 0); }
        private void PB_Face2_Click(object sender, EventArgs e) { ReturnFaceID(current_page, 1); }
        private void PB_Face3_Click(object sender, EventArgs e) { ReturnFaceID(current_page, 2); }
        private void PB_Face4_Click(object sender, EventArgs e) { ReturnFaceID(current_page, 3); }
        private void PB_Face5_Click(object sender, EventArgs e) { ReturnFaceID(current_page, 4); }
        private void PB_Face6_Click(object sender, EventArgs e) { ReturnFaceID(current_page, 5); }
        private void PB_Face7_Click(object sender, EventArgs e) { ReturnFaceID(current_page, 6); }
        private void PB_Face8_Click(object sender, EventArgs e) { ReturnFaceID(current_page, 7); }
        private void PB_Face9_Click(object sender, EventArgs e) { ReturnFaceID(current_page, 8); }
        private void PB_Face10_Click(object sender, EventArgs e) { ReturnFaceID(current_page,9); }
    }
}
