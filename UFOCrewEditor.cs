using KbbEditCS.Properties;
using Microsoft.VisualBasic;
using System.Drawing.Imaging;

namespace KbbEditCS
{
    public partial class UFOCrewEditor : Form
    {
        public int sel_face_id = -1;

        ImportFaceForm F_ImportFace;
        UFOFaceRecoveryForm F_RecoverFace;

        bool swapmode = false;

        private PictureBox[] pbs;

        public UFOCrewEditor()
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

            F_ImportFace = new ImportFaceForm();
            F_RecoverFace = new UFOFaceRecoveryForm();
        }

        private void UFOCrewEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        DateTime dsepoch = new DateTime(2000, 1, 1, 0, 0, 0);
        DateTime secs2date(long s) { return dsepoch.AddSeconds(Math.Clamp(s, -9223372036, 9223372036)); }
        long date2secs(DateTime d) { return (long)(d - dsepoch).TotalSeconds; }

        void DisplayFaces()
        {
            for (int i = 0; i < 10; i++)
            {
                int faceid = Globals.ordered_ufo_faces[i];
                if (faceid != -1)
                {
                    pbs[i].Enabled = true;
                    pbs[i].BackgroundImage = Globals.GetUFOCrewFaceImg(faceid);
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

            // Check if we have reached the max amount of faces
            B_NewFace.Enabled = Globals.ordered_ufo_faces[9] == -1;
            B_Recover.Enabled = Globals.ordered_ufo_faces[9] == -1;
        }

        private void UFOCrewEditor_Load(object sender, EventArgs e) { DisplayFaces(); }

        void ToggleControls(bool b)
        {
            DROP_FaceAge.Enabled = b;
            DROP_FaceGender.Enabled = b;
            dateTimePicker1.Enabled = b;
            CB_NewBubble.Enabled = b;

            B_ImportImg.Enabled = b;
            B_ExportImg.Enabled = b;

            B_NewFace.Enabled = b && (Globals.ordered_ufo_faces[9] == -1);
            B_Recover.Enabled = b && (Globals.ordered_ufo_faces[9] == -1);

            B_Delete.Enabled = b;
        }

        void HandleFaceClick(int slot)
        {
            int faceid = Globals.ordered_ufo_faces[slot];

            if (swapmode)
            {
                int s1 = Globals.GetUFOImgSlot(sel_face_id);
                if (s1 == -1) return;
                Globals.UFORecord f1 = Globals.kbbfile.ufo_records[s1];

                int s2 = Globals.GetUFOImgSlot(faceid);
                if (s2 == -1) return;
                Globals.UFORecord f2 = Globals.kbbfile.ufo_records[s2];

                // this time, we only swap the face IDs
                Globals.kbbfile.ufo_records[s1].faceid = f2.faceid;
                Globals.kbbfile.ufo_records[s2].faceid = f1.faceid;

                sel_face_id = f2.faceid;

                swapmode = false;
                ToggleControls(true);
                DisplayFaces(); // refresh!

                Text = "UFO Crew Editor";
            }
            else
            {
                sel_face_id = faceid;
                PB_CurrentFace.BackgroundImage = Globals.GetUFOCrewFaceImg(faceid);

                int imgslot = Globals.GetUFOImgSlot(faceid);
                if (imgslot == -1) return;
                Globals.UFORecord rec_face = Globals.kbbfile.ufo_records[imgslot];

                dateTimePicker1.Value = secs2date(rec_face.makernote.capturedate);

                CB_NewBubble.Checked = rec_face.field_NEW;

                dateTimePicker1.Enabled = true;
                CB_NewBubble.Enabled = true;

                // Get age
                if (rec_face.age != -1)
                {
                    DROP_FaceAge.SelectedIndex = rec_face.age;
                }
                else
                {
                    DROP_FaceAge.SelectedIndex = DROP_FaceAge.Items.Count - 1;
                }
                DROP_FaceAge.Enabled = true;

                // Get gender
                if (rec_face.gender != -1)
                {
                    DROP_FaceGender.SelectedIndex = rec_face.gender;
                }
                else
                {
                    DROP_FaceGender.SelectedIndex = DROP_FaceGender.Items.Count - 1;
                }
                DROP_FaceGender.Enabled = true;

                B_ImportImg.Enabled = true;
                B_ExportImg.Enabled = true;
                B_SwapFaces.Enabled = true;
                B_Delete.Enabled = true;
            }
        }

        private void PB_Face1_Click(object sender, EventArgs e) { HandleFaceClick(0); }
        private void PB_Face2_Click(object sender, EventArgs e) { HandleFaceClick(1); }
        private void PB_Face3_Click(object sender, EventArgs e) { HandleFaceClick(2); }
        private void PB_Face4_Click(object sender, EventArgs e) { HandleFaceClick(3); }
        private void PB_Face5_Click(object sender, EventArgs e) { HandleFaceClick(4); }
        private void PB_Face6_Click(object sender, EventArgs e) { HandleFaceClick(5); }
        private void PB_Face7_Click(object sender, EventArgs e) { HandleFaceClick(6); }
        private void PB_Face8_Click(object sender, EventArgs e) { HandleFaceClick(7); }
        private void PB_Face9_Click(object sender, EventArgs e) { HandleFaceClick(8); }
        private void PB_Face10_Click(object sender, EventArgs e) { HandleFaceClick(9); }

        private void CB_Guide_Click(object sender, EventArgs e)
        {
            if (CB_Guide.Checked)
            {
                PB_CurrentFace.Image = Resources.FaceGuide;
            }
            else
            {
                PB_CurrentFace.Image = null;
            }
        }

        private void CB_NewBubble_Click(object sender, EventArgs e)
        {
            int slot = Globals.GetUFOImgSlot(sel_face_id);
            if (slot == -1) return;
            Globals.kbbfile.ufo_records[slot].field_NEW = CB_NewBubble.Checked;
            Globals.kbb_valid_flag = false;
        }

        private void DROP_FaceAge_SelectedIndexChanged(object sender, EventArgs e)
        {
            int slot = Globals.GetUFOImgSlot(sel_face_id);
            if (slot == -1) return;
            if (DROP_FaceAge.SelectedIndex != DROP_FaceAge.Items.Count - 1)
            {
                Globals.kbbfile.ufo_records[slot].age = (short)DROP_FaceAge.SelectedIndex;
            }
            else
            {
                Globals.kbbfile.ufo_records[slot].age = -1;
            }
            Globals.kbb_valid_flag = false;
        }

        private void DROP_FaceGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            int slot = Globals.GetUFOImgSlot(sel_face_id);
            if (slot == -1) return;
            if (DROP_FaceGender.SelectedIndex != DROP_FaceGender.Items.Count - 1)
            {
                Globals.kbbfile.ufo_records[slot].gender = (short)DROP_FaceGender.SelectedIndex;
            }
            else
            {
                Globals.kbbfile.ufo_records[slot].gender = -1;
            }
            Globals.kbb_valid_flag = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int slot = Globals.GetUFOImgSlot(sel_face_id);
            if (slot == -1) return;
            Globals.kbbfile.ufo_records[slot].makernote.capturedate = date2secs(dateTimePicker1.Value);
            Globals.kbb_valid_flag = false;
        }

        private void B_ImportImg_Click(object sender, EventArgs e)
        {
            F_ImportFace?.Dispose();
            F_ImportFace = new ImportFaceForm();
            if (F_ImportFace.ShowDialog() == DialogResult.OK)
            {
                int slot = Globals.GetUFOImgSlot(sel_face_id);
                if (slot == -1) return;
                Bitmap? newimg = F_ImportFace.resimg;

                Globals.photop[slot].pxdata = Globals.EncodeTX(newimg);

                Globals.ConvertOnePhotoP(slot);
                int i = Globals.GetOrderedUFOCrewSlot(sel_face_id);
                pbs[i].BackgroundImage = Globals.img_photop[slot];
                PB_CurrentFace.BackgroundImage = Globals.img_photop[slot];
            }
        }

        private void B_ExportImg_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int slot = Globals.GetUFOImgSlot(sel_face_id);
                if (slot == -1) return;
                Bitmap img = Globals.DecodeTX(Globals.photop[slot].pxdata);

                img.Save(saveFileDialog1.FileName, ImageFormat.Png);
                img.Dispose();
            }
        }

        private void B_NewFace_Click(object sender, EventArgs e)
        {
            // MAKE SURE that we have AT LEAST one slot free
            if (Globals.ordered_ufo_faces[9] == -1)
            {
                F_ImportFace?.Dispose();
                F_ImportFace = new ImportFaceForm();
                if (F_ImportFace.ShowDialog() == DialogResult.OK)
                {
                    int slot = Globals.AddNewUFOFace(F_ImportFace.resimg,date2secs(DateTime.Now));
                    DisplayFaces();
                    HandleFaceClick(slot); // focus on that new face
                }
            }
        }

        private void B_SwapFaces_Click(object sender, EventArgs e)
        {
            swapmode = !swapmode;
            if (swapmode)
            {
                ToggleControls(false);
                Text = "Select the other face to be swapped with.";
            }
            else
            {
                ToggleControls(true);
                Text = "UFO Crew Editor";
            }
        }

        private void B_Recover_Click(object sender, EventArgs e)
        {
            int c = Globals.CountDeletedUFOFaces();
            if (c > 0)
            {
                F_RecoverFace?.Dispose();
                F_RecoverFace = new UFOFaceRecoveryForm();
                if (F_RecoverFace.ShowDialog() == DialogResult.OK)
                {
                    int imgslot = F_RecoverFace.res_slot;
                    int slot = Globals.RecoverUFOFace(imgslot,date2secs(DateTime.Now));
                    DisplayFaces();
                    HandleFaceClick(slot); // focus on that new face
                }
            }
            else
            {
                Interaction.MsgBox("No Face to be recovered!", MsgBoxStyle.Information, "");
            }
        }

        private void B_Delete_Click(object sender, EventArgs e)
        {
            MsgBoxResult res = Interaction.MsgBox("Are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "");
            if (res == MsgBoxResult.Yes)
            {
                Globals.DeleteUFOCrewFace(sel_face_id);
                PB_CurrentFace.BackgroundImage = null;

                DisplayFaces();
                ToggleControls(false);
                B_NewFace.Enabled = true;
                B_Recover.Enabled = true;
                B_SwapFaces.Enabled = false;
            }
        }
    }
}
