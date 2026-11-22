namespace KbbEditCS
{
    public partial class UFOFaceRecoveryForm : Form
    {
        public int res_slot = -1;

        int[] imgslots = new int[10];

        private PictureBox[] pbs;

        public UFOFaceRecoveryForm()
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

        void DisplayFaces()
        {
            for (int i = 0; i < 10; i++)
            {
                int imgslotnum = imgslots[i];
                if (imgslotnum < 10)
                {
                    pbs[i].Enabled = true;
                    pbs[i].BackgroundImage = Globals.img_photop[imgslotnum];
                }
                else
                {
                    for (int j = i; j < 10; j++)
                    {
                        pbs[j].Enabled = false;
                        pbs[j].BackgroundImage = null;
                    }
                    break;
                }
            }
        }

        void ReturnSlotNum(int slot)
        {
            res_slot = imgslots[slot];
            DialogResult = DialogResult.OK;
            Close();
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void UFOFaceRecoveryForm_Load(object sender, EventArgs e)
        {
            int c = 0;
            for (int i = 0; i < 10; i++)
            {
                if ((Globals.kbbfile.ufo_records[i].faceid == -1) && Globals.photop_loaded_flags[i])
                {
                    imgslots[c] = i;
                    c++;
                }
            }
            for (int i = c; i < 10; i++)
            {
                imgslots[i] = 999;
            }

            Array.Sort(imgslots);

            DisplayFaces();
        }

        private void PB_Face1_Click(object sender, EventArgs e) { ReturnSlotNum(0); }
        private void PB_Face2_Click(object sender, EventArgs e) { ReturnSlotNum(1); }
        private void PB_Face3_Click(object sender, EventArgs e) { ReturnSlotNum(2); }
        private void PB_Face4_Click(object sender, EventArgs e) { ReturnSlotNum(3); }
        private void PB_Face5_Click(object sender, EventArgs e) { ReturnSlotNum(4); }
        private void PB_Face6_Click(object sender, EventArgs e) { ReturnSlotNum(5); }
        private void PB_Face7_Click(object sender, EventArgs e) { ReturnSlotNum(6); }
        private void PB_Face8_Click(object sender, EventArgs e) { ReturnSlotNum(7); }
        private void PB_Face9_Click(object sender, EventArgs e) { ReturnSlotNum(8); }
        private void PB_Face10_Click(object sender, EventArgs e) { ReturnSlotNum(9); }
    }
}
