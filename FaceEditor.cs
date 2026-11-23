using KbbEditCS.Properties;
using Microsoft.VisualBasic;
using System.Drawing.Imaging;

namespace KbbEditCS
{
    public partial class FaceEditor : Form
    {
        public int sel_face_id = -1;
        public static int current_page = 0;

        ImportFaceForm F_ImportFace;
        FaceRecoveryForm F_RecoverFace;

        UFOCrewEditor F_UFOCrew;

        bool swapmode = false;

        static int[] daysbymonth = new int[]
        {
            31, // January
            28, // February
            31, // March
            30, // April
            31, // May
            30, // June
            31, // July
            31, // August
            30, // September
            31, // October
            30, // November
            31  // December
        };

        private PictureBox[] pbs;

        public FaceEditor()
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
            F_RecoverFace = new FaceRecoveryForm();

            F_UFOCrew = new UFOCrewEditor();
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
            // And also show the UFO on page 0
            if (page == 0)
            {
                B_PrevPage.Enabled = false;
                pbs[0].BackgroundImage = null;
                if (Globals.ordered_ufo_faces[0] != -1)
                {
                    pbs[0].Image = Globals.GetUFOCrewThumb();
                }
                pbs[0].Enabled = true;
            }
            else
            {
                B_PrevPage.Enabled = true;
                pbs[0].Image = Resources.FaceHole;
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

            // Check if we have reached the max amount of faces
            B_NewFace.Enabled = Globals.ordered_faces[48] == -1;
            B_Recover.Enabled = Globals.ordered_faces[48] == -1;
        }

        void ToggleControls(bool b)
        {
            NUD_MeetDay.Enabled = b;
            NUD_MeetMonth.Enabled = b;
            NUD_MeetYear.Enabled = b;

            NUD_FaceSelections.Enabled = b;
            DROP_FaceAge.Enabled = b;
            DROP_FaceGender.Enabled = b;

            NUD_HScroll.Enabled = b;
            NUD_VScroll.Enabled = b;
            NUD_HScale.Enabled = b;
            NUD_VScale.Enabled = b;
            NUD_Rotation.Enabled = b;

            B_ImportImg.Enabled = b;
            B_ExportImg.Enabled = b;

            B_NewFace.Enabled = b && (Globals.ordered_faces[48] == -1);
            B_Recover.Enabled = b && (Globals.ordered_faces[48] == -1);

            B_Delete.Enabled = b;
        }

        private void FaceEditor_Load(object sender, EventArgs e)
        {
            current_page = 0;
            DisplayFaces(current_page);
        }

        void UpdateMeetDate(sbyte day, sbyte month, short year)
        {
            NUD_MeetYear.Value = Math.Min((short)9999, Math.Max((short)1, year));
            NUD_MeetMonth.Value = Math.Min((short)12, Math.Max((short)1, month));

            // Set maximum value in meet date box
            if ((month == 2) && DateTime.IsLeapYear(year))
            {
                NUD_MeetDay.Maximum = 29; // February in leap years has 29 days
            }
            else
            {
                NUD_MeetDay.Maximum = daysbymonth[(int)NUD_MeetMonth.Value - 1];
            }

            NUD_MeetDay.Value = Math.Min((sbyte)NUD_MeetDay.Maximum, Math.Max((sbyte)1, day));

            NUD_MeetYear.Enabled = true;
            NUD_MeetMonth.Enabled = true;
            NUD_MeetDay.Enabled = true;
        }

        void UpdateSelFaceImg(int slot)
        {
            Globals.ConvertOnePhotoF(slot);
            Bitmap img = Globals.img_photof[slot];

            PB_CurrentFace.BackgroundImage = img;

            // Determine if the face's slot is in view.
            int sloto = Globals.GetOrderedSlot(Globals.kbbfile.face_records[slot].faceid);
            int page = (sloto + 1) / 10;
            int r = (sloto + 1) % 10;

            if (page == current_page)
            {
                pbs[r].BackgroundImage = img;
            }
        }

        void HandleMeetDateChange()
        {
            short year = (short)NUD_MeetYear.Value;
            sbyte month = (sbyte)NUD_MeetMonth.Value;

            // Set maximum value in meet date box
            if ((month == 2) && DateTime.IsLeapYear(year))
            {
                NUD_MeetDay.Maximum = 29; // February in leap years has 29 days
            }
            else
            {
                NUD_MeetDay.Maximum = daysbymonth[month - 1];
            }

            sbyte day = (sbyte)Math.Clamp(NUD_MeetDay.Value, 1, NUD_MeetDay.Maximum);

            int slot = Globals.GetImgSlot(sel_face_id);
            if (slot == -1) return;

            Globals.kbbfile.face_records[slot].met_year = year;
            Globals.kbbfile.face_records[slot].met_month = month;
            Globals.kbbfile.face_records[slot].met_day = day;

            Globals.kbb_valid_flag = false;
        }

        void HandleTransformChange()
        {
            int slot = Globals.GetImgSlot(sel_face_id);
            if (slot == -1) return;

            Globals.kbbfile.face_records[slot].tx_move_x = (float)NUD_HScroll.Value;
            Globals.kbbfile.face_records[slot].tx_move_y = (float)NUD_VScroll.Value;
            Globals.kbbfile.face_records[slot].tx_stretch_x = (float)NUD_HScale.Value;
            Globals.kbbfile.face_records[slot].tx_stretch_y = (float)NUD_VScale.Value;
            Globals.kbbfile.face_records[slot].tx_rot = float.DegreesToRadians((float)NUD_Rotation.Value);

            UpdateSelFaceImg(slot);

            Globals.kbb_valid_flag = false;
        }

        float GetValidDecimal(float value, float min, float max, float fallback)
        {
            if (!float.IsFinite(value)) return fallback;

            if (value > max) return max;

            if (value < min) return min;

            return value;
        }

        void HandleFaceClick(int page, int slot)
        {
            int faceid = Globals.ordered_faces[10 * page + slot - 1];

            if (swapmode)
            {
                int s1 = Globals.GetImgSlot(sel_face_id);
                if (s1 == -1) return;
                Globals.FaceRecord f1 = Globals.kbbfile.face_records[s1];

                int s2 = Globals.GetImgSlot(faceid);
                if (s2 == -1) return;
                Globals.FaceRecord f2 = Globals.kbbfile.face_records[s2];

                // swap records
                Globals.kbbfile.face_records[s1] = f2;
                Globals.kbbfile.face_records[s2] = f1;

                // we shouldn't swap the face IDs though
                Globals.kbbfile.face_records[s1].faceid = f1.faceid;
                Globals.kbbfile.face_records[s2].faceid = f2.faceid;

                // swap images
                Globals.KbbPhoto p1 = Globals.photof[s1];
                Globals.KbbPhoto p2 = Globals.photof[s2];

                Globals.photof[s1] = p2;
                Globals.photof[s2] = p1;

                UpdateSelFaceImg(s1);
                UpdateSelFaceImg(s2);

                sel_face_id = f2.faceid;

                swapmode = false;
                ToggleControls(true);

                Text = "Face Editor";
            }
            else
            {
                int imgslot = Globals.GetImgSlot(faceid);
                if (imgslot == -1) return;

                sel_face_id = faceid;
                PB_CurrentFace.BackgroundImage = Globals.GetFaceImg(faceid);

                Globals.FaceRecord rec_face = Globals.kbbfile.face_records[imgslot];

                UpdateMeetDate(rec_face.met_day, rec_face.met_month, rec_face.met_year);

                // Get times chosen
                NUD_FaceSelections.Value = Math.Min((ushort)999, rec_face.selections);
                NUD_FaceSelections.Enabled = true;
                
                // Get age
                if (rec_face.age != -1) DROP_FaceAge.SelectedIndex = Math.Min((ushort)4, Math.Max((ushort)0, rec_face.age));

                else DROP_FaceAge.SelectedIndex = DROP_FaceAge.Items.Count - 1;

                DROP_FaceAge.Enabled = true;

                // Get gender
                if (rec_face.gender != -1) DROP_FaceGender.SelectedIndex = Math.Min((ushort)1, Math.Max((ushort)0, rec_face.gender));

                else DROP_FaceGender.SelectedIndex = DROP_FaceGender.Items.Count - 1;

                DROP_FaceGender.Enabled = true;

                // Get face transform
                NUD_HScroll.Value  = (decimal)GetValidDecimal(rec_face.tx_move_x, -0.5f, 0.5f, 0.0f);
                NUD_VScroll.Value  = (decimal)GetValidDecimal(rec_face.tx_move_y, -0.5f, 0.5f, 0.0f);
                NUD_HScale.Value   = (decimal)GetValidDecimal(rec_face.tx_stretch_x, 0.25f, 2.0f, 1.0f);
                NUD_VScale.Value   = (decimal)GetValidDecimal(rec_face.tx_stretch_y, 0.25f, 2.0f, 1.0f);
                NUD_Rotation.Value = (decimal)GetValidDecimal(float.RadiansToDegrees(rec_face.tx_rot), -90.0f, 90.0f, 0.0f);

                NUD_HScroll.Enabled  = true;
                NUD_VScroll.Enabled  = true;
                NUD_HScale.Enabled   = true;
                NUD_VScale.Enabled   = true;
                NUD_Rotation.Enabled = true;

                B_ImportImg.Enabled = true;
                B_ExportImg.Enabled = true;
                B_SwapFaces.Enabled = true;
                B_Delete.Enabled    = true;
            }
        }

        private void PB_Face1_Click(object sender, EventArgs e)
        {
            if (current_page == 0)
            {
                F_UFOCrew.Show();
            }
            else
            {
                HandleFaceClick(current_page, 0);
            }
        }
        private void PB_Face2_Click(object sender, EventArgs e) { HandleFaceClick(current_page, 1); }
        private void PB_Face3_Click(object sender, EventArgs e) { HandleFaceClick(current_page, 2); }
        private void PB_Face4_Click(object sender, EventArgs e) { HandleFaceClick(current_page, 3); }
        private void PB_Face5_Click(object sender, EventArgs e) { HandleFaceClick(current_page, 4); }
        private void PB_Face6_Click(object sender, EventArgs e) { HandleFaceClick(current_page, 5); }
        private void PB_Face7_Click(object sender, EventArgs e) { HandleFaceClick(current_page, 6); }
        private void PB_Face8_Click(object sender, EventArgs e) { HandleFaceClick(current_page, 7); }
        private void PB_Face9_Click(object sender, EventArgs e) { HandleFaceClick(current_page, 8); }
        private void PB_Face10_Click(object sender, EventArgs e) { HandleFaceClick(current_page, 9); }

        private void FaceEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void CB_Guide_Click(object sender, EventArgs e)
        {
            if (CB_Guide.Checked)
            {
                PB_CurrentFace.Image = Resources.FaceCalibrate;
            }
            else
            {
                PB_CurrentFace.Image = Resources.FaceHole;
            }
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

        private void NUD_MeetDate_ValueChanged(object sender, EventArgs e) { HandleMeetDateChange(); }
        private void NUD_MeetMonth_ValueChanged(object sender, EventArgs e) { HandleMeetDateChange(); }
        private void NUD_MeetYear_ValueChanged(object sender, EventArgs e) { HandleMeetDateChange(); }

        private void NUD_FaceSelections_ValueChanged(object sender, EventArgs e)
        {
            int slot = Globals.GetImgSlot(sel_face_id);
            if (slot == -1) return;
            Globals.kbbfile.face_records[slot].selections = (ushort)NUD_FaceSelections.Value;
            Globals.kbb_valid_flag = false;
        }

        private void DROP_FaceAge_SelectedIndexChanged(object sender, EventArgs e)
        {
            int slot = Globals.GetImgSlot(sel_face_id);
            if (slot == -1) return;
            if (DROP_FaceAge.SelectedIndex != DROP_FaceAge.Items.Count - 1)
            {
                Globals.kbbfile.face_records[slot].age = (short)DROP_FaceAge.SelectedIndex;
            }
            else
            {
                Globals.kbbfile.face_records[slot].age = -1;
            }
            Globals.kbb_valid_flag = false;
        }

        private void DROP_FaceGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            int slot = Globals.GetImgSlot(sel_face_id);
            if (slot == -1) return;
            if (DROP_FaceGender.SelectedIndex != DROP_FaceGender.Items.Count - 1)
            {
                Globals.kbbfile.face_records[slot].gender = (short)DROP_FaceGender.SelectedIndex;
            }
            else
            {
                Globals.kbbfile.face_records[slot].gender = -1;
            }
            Globals.kbb_valid_flag = false;
        }

        private void NUD_HScroll_ValueChanged(object sender, EventArgs e) { HandleTransformChange(); }
        private void NUD_VScroll_ValueChanged(object sender, EventArgs e) { HandleTransformChange(); }
        private void NUD_HScale_ValueChanged(object sender, EventArgs e) { HandleTransformChange(); }
        private void NUD_VScale_ValueChanged(object sender, EventArgs e) { HandleTransformChange(); }
        private void NUD_Rotation_ValueChanged(object sender, EventArgs e) { HandleTransformChange(); }

        private void B_ImportImg_Click(object sender, EventArgs e)
        {
            F_ImportFace?.Dispose();
            F_ImportFace = new ImportFaceForm();
            if (F_ImportFace.ShowDialog() == DialogResult.OK)
            {
                int slot = Globals.GetImgSlot(sel_face_id);
                if (slot == -1) return;
                Bitmap? newimg = F_ImportFace.resimg;

                Globals.photof[slot].pxdata = Globals.EncodeTX(newimg);

                NUD_HScroll.Value = 0.0M;
                NUD_VScroll.Value = 0.0M;
                NUD_HScale.Value = 1.0M;
                NUD_VScale.Value = 1.0M;
                NUD_Rotation.Value = 0.0M;
                HandleTransformChange();
            }
        }

        private void B_ExportImg_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int slot = Globals.GetImgSlot(sel_face_id);
                if (slot == -1) return;
                Bitmap img = Globals.DecodeTX(Globals.photof[slot].pxdata);

                img.Save(saveFileDialog1.FileName,ImageFormat.Png);
                img.Dispose();
            }
        }

        private void B_NewFace_Click(object sender, EventArgs e)
        {
            // MAKE SURE that we have AT LEAST one slot free
            if (Globals.ordered_faces[48] == -1)
            {
                F_ImportFace?.Dispose();
                F_ImportFace = new ImportFaceForm();
                if (F_ImportFace.ShowDialog() == DialogResult.OK)
                {
                    int slot = Globals.AddNewFace(F_ImportFace.resimg);
                    if (slot % 10 == 9) current_page++;
                    DisplayFaces(current_page);
                    HandleFaceClick((slot+1)/10,(slot+1)%10); // focus on that new face
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
                Text = "Face Editor";
            }
        }

        private void B_Recover_Click(object sender, EventArgs e)
        {
            int c = Globals.CountDeletedFaces();
            if (c > 0) {
                F_RecoverFace?.Dispose();
                F_RecoverFace = new FaceRecoveryForm();
                if (F_RecoverFace.ShowDialog() == DialogResult.OK)
                {
                    int imgslot = F_RecoverFace.res_slot;
                    int slot = Globals.RecoverFace(imgslot);
                    current_page = (slot + 1) / 10;
                    DisplayFaces(current_page);
                    HandleFaceClick((slot + 1) / 10, (slot + 1) % 10); // focus on that new face
                }
            }
            else
            {
                Interaction.MsgBox("No Face to be recovered!",MsgBoxStyle.Information,"");
            }
        }

        private void B_Delete_Click(object sender, EventArgs e)
        {
            MsgBoxResult res = Interaction.MsgBox("Are you sure?",MsgBoxStyle.YesNo|MsgBoxStyle.Question,"");
            if (res == MsgBoxResult.Yes)
            {
                int slot = Globals.GetOrderedSlot(sel_face_id);
                Globals.DeleteFace(sel_face_id);
                PB_CurrentFace.BackgroundImage = null;
                if ((slot % 10 == 9) && Globals.ordered_faces[slot] == -1) current_page--;
                DisplayFaces(current_page);
                ToggleControls(false);
                B_NewFace.Enabled = true;
                B_Recover.Enabled = true;
                B_SwapFaces.Enabled = false;
            }
        }
    }
}
