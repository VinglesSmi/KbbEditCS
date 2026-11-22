namespace KbbEditCS
{
    public partial class FaceRecoveryForm : Form
    {
        public int res_slot = -1;
        int current_page = 0;

        int[] imgslots = new int[49];

        private PictureBox[] pbs;

        public FaceRecoveryForm()
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

        int GetImgSlot(int page, int slot)
        {
            return imgslots[(10*page)+slot];
        }

        void DisplayFaces(int page)
        {
            for (int i = 0; i < 10; i++)
            {
                int imgslotnum = imgslots[10 * page + i];
                if (imgslotnum < 49)
                {
                    pbs[i].Enabled = true;
                    pbs[i].BackgroundImage = Globals.img_photof[imgslotnum];
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
            B_PrevPage.Enabled = page != 0;

            // Check if the next page button should be enabled
            if (page == 4)
            {
                B_NextPage.Enabled = false;
            }
            else
            {
                int imgslotnum = imgslots[10 * (page + 1)];
                B_NextPage.Enabled = imgslotnum < 49;
            }
        }

        void ReturnSlotNum(int page, int slot)
        {
            res_slot = GetImgSlot(page, slot);
            DialogResult = DialogResult.OK;
            Close();
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

        private void FaceRecoveryForm_Load(object sender, EventArgs e)
        {
            int c = 0;
            for (int i = 0; i < 49; i++)
            {
                if ((Globals.kbbfile.face_records[i].faceid == -1) && Globals.photof_loaded_flags[i])
                {
                    imgslots[c] = i;
                    c++;
                }
            }
            for (int i = c; i < 49; i++)
            {
                imgslots[i] = 999;
            }

            Array.Sort(imgslots);

            current_page = 0;
            DisplayFaces(current_page);
        }

        private void PB_Face1_Click(object sender, EventArgs e) { ReturnSlotNum(current_page, 0); }
        private void PB_Face2_Click(object sender, EventArgs e) { ReturnSlotNum(current_page, 1); }
        private void PB_Face3_Click(object sender, EventArgs e) { ReturnSlotNum(current_page, 2); }
        private void PB_Face4_Click(object sender, EventArgs e) { ReturnSlotNum(current_page, 3); }
        private void PB_Face5_Click(object sender, EventArgs e) { ReturnSlotNum(current_page, 4); }
        private void PB_Face6_Click(object sender, EventArgs e) { ReturnSlotNum(current_page, 5); }
        private void PB_Face7_Click(object sender, EventArgs e) { ReturnSlotNum(current_page, 6); }
        private void PB_Face8_Click(object sender, EventArgs e) { ReturnSlotNum(current_page, 7); }
        private void PB_Face9_Click(object sender, EventArgs e) { ReturnSlotNum(current_page, 8); }
        private void PB_Face10_Click(object sender, EventArgs e) { ReturnSlotNum(current_page,9); }
    }
}
