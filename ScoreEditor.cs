using KbbEditCS.Properties;

namespace KbbEditCS
{
    public partial class ScoreEditor : Form
    {
        SelectFaceDialog selectFaceDialog;

        private Button[] buttons;
        private Bitmap[] img_unsel;
        private Bitmap[] img_sel;

        public ScoreEditor()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            selectFaceDialog = new SelectFaceDialog();

            buttons = new Button[]
            {
                B_Stg1, B_Stg2, B_Stg3,
                B_Stg4, B_StgBonus, B_StgExtra,
                B_SAF_Stg1, B_SAF_Stg2, B_SAF_StgBonus,
            };

            img_unsel = new Bitmap[]
            {
                Resources.Stage1,Resources.Stage2,Resources.Stage3,
                Resources.Stage4,Resources.BonusStage,Resources.ExtraStage,
                Resources.Stage1,Resources.OtherStage,Resources.BonusStage,
            };

            img_sel = new Bitmap[]
            {
                Resources.Stage1Select,Resources.Stage2Select,Resources.Stage3Select,
                Resources.Stage4Select,Resources.BonusStageSelect,Resources.ExtraStageSelect,
                Resources.Stage1Select,Resources.OtherStageSelect,Resources.BonusStageSelect,
            };
        }

        enum StgID
        {
            stg1,
            stg2,
            stg3,
            stg4,
            stgbonus,
            stgextra,
            safstg1,
            safstg2,
            safstgbonus,
            tutstg,
            NONE = -1
        }
        StgID sel_stg = StgID.NONE;

        void Form1_Load(object? sender, EventArgs e)
        {
            PB_Record1Face.Image = Resources.NoFace;
            PB_Record2Face.Image = Resources.NoFace;
            PB_Record3Face.Image = Resources.NoFace;
            PB_Record4Face.Image = Resources.NoFace;
            PB_Record5Face.Image = Resources.NoFace;
        }

        void EnableControls()
        {
            NUD_Record1.Enabled = true;
            NUD_Record2.Enabled = true;
            NUD_Record3.Enabled = true;
            NUD_Record4.Enabled = true;
            NUD_Record5.Enabled = true;
            NUD_MaxCombo.Enabled = true;

            PB_Record1Face.Enabled = true;
            PB_Record2Face.Enabled = true;
            PB_Record3Face.Enabled = true;
            PB_Record4Face.Enabled = true;
            PB_Record5Face.Enabled = true;
        }

        void SetButtonAppearances(StgID stg)
        {
            int stgnum = (int)stg;
            for (int i = 0; i < 9; i++)
            {
                buttons[i].Image = i == stgnum ? img_sel[i] : img_unsel[i];
            }
        }

        void LoadRecords(StgID stg)
        {
            sel_stg = stg;
            int stgnum = (int)stg;
            SetButtonAppearances(stg);

            // Get record for this stage.
            Globals.LvlScoreRecord stg_record = Globals.kbbfile.stg_records[stgnum];

            // Load score records
            NUD_Record1.Value = Math.Min(999999U, stg_record.r1_score);
            NUD_Record2.Value = Math.Min(999999U, stg_record.r2_score);
            NUD_Record3.Value = Math.Min(999999U, stg_record.r3_score);
            NUD_Record4.Value = Math.Min(999999U, stg_record.r4_score);
            NUD_Record5.Value = Math.Min(999999U, stg_record.r5_score);
            NUD_MaxCombo.Value = Math.Min((ushort)99, stg_record.maxcombo);

            // Get 1st face ID
            if (stg_record.r1_face != -1)
            {
                PB_Record1Face.BackgroundImage = Globals.GetFaceImg(stg_record.r1_face);
                PB_Record1Face.Image = Resources.FaceHole;
            }
            else
            {
                PB_Record1Face.Image = Resources.NoFace;
            }

            // Get 2nd face ID
            if (stg_record.r2_face != -1)
            {
                PB_Record2Face.BackgroundImage = Globals.GetFaceImg(stg_record.r2_face);
                PB_Record2Face.Image = Resources.FaceHole;
            }
            else
            {
                PB_Record2Face.Image = Resources.NoFace;
            }

            // Get 3rd face ID
            if (stg_record.r3_face != -1)
            {
                PB_Record3Face.BackgroundImage = Globals.GetFaceImg(stg_record.r3_face);
                PB_Record3Face.Image = Resources.FaceHole;
            }
            else
            {
                PB_Record3Face.Image = Resources.NoFace;
            }

            // Get 4th face ID
            if (stg_record.r4_face != -1)
            {
                PB_Record4Face.BackgroundImage = Globals.GetFaceImg(stg_record.r4_face);
                PB_Record4Face.Image = Resources.FaceHole;
            }
            else
            {
                PB_Record4Face.Image = Resources.NoFace;
            }

            // Get 5th face ID
            if (stg_record.r5_face != -1)
            {
                PB_Record5Face.BackgroundImage = Globals.GetFaceImg(stg_record.r5_face);
                PB_Record5Face.Image = Resources.FaceHole;
            }
            else
            {
                PB_Record5Face.Image = Resources.NoFace;
            }

            // Update check boxes
            CB_BeatLvl.Enabled = true;
            CB_BeatLvl.Checked = stg_record.beatstg;

            // Stage 1 and "Tutorial Stage" cannot be locked
            CB_LvlUnlock.Enabled = (stg != StgID.stg1) && (stg != StgID.tutstg);
            CB_LvlUnlock.CheckState = CheckState.Unchecked;
            switch (stg)
            {
                case StgID.stg1:
                case StgID.tutstg:
                    CB_LvlUnlock.CheckState = CheckState.Indeterminate;
                    break;
                case StgID.stg2: CB_LvlUnlock.Checked = Globals.kbbfile.globals.stg2_unlock; break;
                case StgID.stg3: CB_LvlUnlock.Checked = Globals.kbbfile.globals.stg3_unlock; break;
                case StgID.stg4: CB_LvlUnlock.Checked = Globals.kbbfile.globals.stg4_unlock; break;
                case StgID.stgbonus: CB_LvlUnlock.Checked = Globals.kbbfile.globals.stgbonus_unlock; break;
                case StgID.stgextra: CB_LvlUnlock.Checked = Globals.kbbfile.globals.stgextra_unlock; break;
                case StgID.safstg1: CB_LvlUnlock.Checked = Globals.kbbfile.globals.saf_stg1_unlock; break;
                case StgID.safstg2: CB_LvlUnlock.Checked = Globals.kbbfile.globals.saf_stg2_unlock; break;
                case StgID.safstgbonus: CB_LvlUnlock.Checked = Globals.kbbfile.globals.saf_stgbonus_unlock; break;
                default: break;
            }

            // "Tutorial Stage" cannot be accessed and does not have a field for that
            CB_LvlUnlockAnim.Enabled = stg != StgID.tutstg;
            CB_LvlUnlockAnim.CheckState = CheckState.Unchecked;
            switch (stg)
            {
                case StgID.stg1: CB_LvlUnlockAnim.Checked = !Globals.kbbfile.globals.stg1_unlock_anim; break;
                case StgID.stg2: CB_LvlUnlockAnim.Checked = !Globals.kbbfile.globals.stg2_unlock_anim; break;
                case StgID.stg3: CB_LvlUnlockAnim.Checked = !Globals.kbbfile.globals.stg3_unlock_anim; break;
                case StgID.stg4: CB_LvlUnlockAnim.Checked = !Globals.kbbfile.globals.stg4_unlock_anim; break;
                case StgID.stgbonus: CB_LvlUnlockAnim.Checked = !Globals.kbbfile.globals.stgbonus_unlock_anim; break;
                case StgID.stgextra: CB_LvlUnlockAnim.Checked = !Globals.kbbfile.globals.stgextra_unlock_anim; break;
                case StgID.safstg1: CB_LvlUnlockAnim.Checked = !Globals.kbbfile.globals.saf_stg1_unlock_anim; break;
                case StgID.safstg2: CB_LvlUnlockAnim.Checked = !Globals.kbbfile.globals.saf_stg2_unlock_anim; break;
                case StgID.safstgbonus: CB_LvlUnlockAnim.Checked = !Globals.kbbfile.globals.saf_stgbonus_unlock_anim; break;
                case StgID.tutstg: CB_LvlUnlockAnim.CheckState = CheckState.Indeterminate; break;
                default: break;
            }

            EnableControls();
        }

        void ChangeRecordFaceID(StgID stg, int slot)
        {
            DialogResult res = selectFaceDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                int stgnum = (int)sel_stg;
                int faceid = selectFaceDialog.sel_face_id;
                switch (slot)
                {
                    case 1: Globals.kbbfile.stg_records[stgnum].r1_face = faceid; break;
                    case 2: Globals.kbbfile.stg_records[stgnum].r2_face = faceid; break;
                    case 3: Globals.kbbfile.stg_records[stgnum].r3_face = faceid; break;
                    case 4: Globals.kbbfile.stg_records[stgnum].r4_face = faceid; break;
                    case 5: Globals.kbbfile.stg_records[stgnum].r5_face = faceid; break;
                    default: break;
                }
                Globals.kbb_valid_flag = false;
                LoadRecords(stg); // reload picture boxes.
            }
        }

        void ClearRecordFaceID(StgID stg, int slot)
        {
            int stgnum = (int)sel_stg;
            int faceid = -1;
            switch (slot)
            {
                case 1: Globals.kbbfile.stg_records[stgnum].r1_face = faceid; break;
                case 2: Globals.kbbfile.stg_records[stgnum].r2_face = faceid; break;
                case 3: Globals.kbbfile.stg_records[stgnum].r3_face = faceid; break;
                case 4: Globals.kbbfile.stg_records[stgnum].r4_face = faceid; break;
                case 5: Globals.kbbfile.stg_records[stgnum].r5_face = faceid; break;
                default: break;
            }
            Globals.kbb_valid_flag = false;
            LoadRecords(stg); // reload picture boxes.
        }

        private void B_Stg1_Click(object sender, EventArgs e) { LoadRecords(StgID.stg1); }
        private void B_Stg2_Click(object sender, EventArgs e) { LoadRecords(StgID.stg2); }
        private void B_Stg3_Click(object sender, EventArgs e) { LoadRecords(StgID.stg3); }
        private void B_Stg4_Click(object sender, EventArgs e) { LoadRecords(StgID.stg4); }
        private void B_StgBonus_Click(object sender, EventArgs e) { LoadRecords(StgID.stgbonus); }
        private void B_StgExtra_Click(object sender, EventArgs e) { LoadRecords(StgID.stgextra); }
        private void B_SAF_Stg1_Click(object sender, EventArgs e) { LoadRecords(StgID.safstg1); }
        private void B_SAF_StgBonus_Click(object sender, EventArgs e) { LoadRecords(StgID.safstgbonus); }
        private void B_SAF_Stg2_Click(object sender, EventArgs e) { LoadRecords(StgID.safstg2); }
        private void B_TutorialStg_Click(object sender, EventArgs e) { LoadRecords(StgID.tutstg); }

        private void NUD_Record1_ValueChanged(object sender, EventArgs e) { int stgnum = (int)sel_stg; Globals.kbbfile.stg_records[stgnum].r1_score = (uint)NUD_Record1.Value; Globals.kbb_valid_flag = false; }
        private void NUD_Record2_ValueChanged(object sender, EventArgs e) { int stgnum = (int)sel_stg; Globals.kbbfile.stg_records[stgnum].r2_score = (uint)NUD_Record2.Value; Globals.kbb_valid_flag = false; }
        private void NUD_Record3_ValueChanged(object sender, EventArgs e) { int stgnum = (int)sel_stg; Globals.kbbfile.stg_records[stgnum].r3_score = (uint)NUD_Record3.Value; Globals.kbb_valid_flag = false; }
        private void NUD_Record4_ValueChanged(object sender, EventArgs e) { int stgnum = (int)sel_stg; Globals.kbbfile.stg_records[stgnum].r4_score = (uint)NUD_Record4.Value; Globals.kbb_valid_flag = false; }
        private void NUD_Record5_ValueChanged(object sender, EventArgs e) { int stgnum = (int)sel_stg; Globals.kbbfile.stg_records[stgnum].r5_score = (uint)NUD_Record5.Value; Globals.kbb_valid_flag = false; }
        private void NUD_MaxCombo_ValueChanged(object sender, EventArgs e) { int stgnum = (int)sel_stg; Globals.kbbfile.stg_records[stgnum].maxcombo = (ushort)NUD_MaxCombo.Value; Globals.kbb_valid_flag = false; }

        private void PB_Record1Face_Click(object sender, EventArgs e) { ChangeRecordFaceID(sel_stg, 1); }
        private void PB_Record2Face_Click(object sender, EventArgs e) { ChangeRecordFaceID(sel_stg, 2); }
        private void PB_Record3Face_Click(object sender, EventArgs e) { ChangeRecordFaceID(sel_stg, 3); }
        private void PB_Record4Face_Click(object sender, EventArgs e) { ChangeRecordFaceID(sel_stg, 4); }
        private void PB_Record5Face_Click(object sender, EventArgs e) { ChangeRecordFaceID(sel_stg, 5); }

        private void ScoreEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void CB_BeatLvl_Click(object sender, EventArgs e)
        {
            int stgnum = (int)sel_stg;
            Globals.kbbfile.stg_records[stgnum].beatstg = CB_BeatLvl.Checked;
            Globals.kbb_valid_flag = false;
        }

        private void CB_LvlUnlock_Click(object sender, EventArgs e)
        {
            switch (sel_stg)
            {
                case StgID.stg2: Globals.kbbfile.globals.stg2_unlock = CB_LvlUnlock.Checked; break;
                case StgID.stg3: Globals.kbbfile.globals.stg3_unlock = CB_LvlUnlock.Checked; break;
                case StgID.stg4: Globals.kbbfile.globals.stg4_unlock = CB_LvlUnlock.Checked; break;
                case StgID.stgbonus: Globals.kbbfile.globals.stgbonus_unlock = CB_LvlUnlock.Checked; break;
                case StgID.stgextra: Globals.kbbfile.globals.stgextra_unlock = CB_LvlUnlock.Checked; break;
                case StgID.safstg1: Globals.kbbfile.globals.saf_stg1_unlock = CB_LvlUnlock.Checked; break;
                case StgID.safstg2: Globals.kbbfile.globals.saf_stg2_unlock = CB_LvlUnlock.Checked; break;
                case StgID.safstgbonus: Globals.kbbfile.globals.saf_stgbonus_unlock = CB_LvlUnlock.Checked; break;
                default: break;
            }
            Globals.kbb_valid_flag = false;
        }

        private void CB_LvlUnlockAnim_Click(object sender, EventArgs e)
        {
            switch (sel_stg)
            {
                case StgID.stg1: Globals.kbbfile.globals.stg1_unlock_anim = !CB_LvlUnlockAnim.Checked; break;
                case StgID.stg2: Globals.kbbfile.globals.stg2_unlock_anim = !CB_LvlUnlockAnim.Checked; break;
                case StgID.stg3: Globals.kbbfile.globals.stg3_unlock_anim = !CB_LvlUnlockAnim.Checked; break;
                case StgID.stg4: Globals.kbbfile.globals.stg4_unlock_anim = !CB_LvlUnlockAnim.Checked; break;
                case StgID.stgbonus: Globals.kbbfile.globals.stgbonus_unlock_anim = !CB_LvlUnlockAnim.Checked; break;
                case StgID.stgextra: Globals.kbbfile.globals.stgextra_unlock_anim = !CB_LvlUnlockAnim.Checked; break;
                case StgID.safstg1: Globals.kbbfile.globals.saf_stg1_unlock_anim = !CB_LvlUnlockAnim.Checked; break;
                case StgID.safstg2: Globals.kbbfile.globals.saf_stg2_unlock_anim = !CB_LvlUnlockAnim.Checked; break;
                case StgID.safstgbonus: Globals.kbbfile.globals.saf_stgbonus_unlock_anim = !CB_LvlUnlockAnim.Checked; break;
                default: break;
            }
            Globals.kbb_valid_flag = false;
        }

        private void PB_Record1Face_MouseClick(object sender, MouseEventArgs e)
        {
            MouseButtons b = e.Button;
            if (b == MouseButtons.Left)
            {
                ChangeRecordFaceID(sel_stg, 1);
            }
            else if (b == MouseButtons.Right)
            {
                ClearRecordFaceID(sel_stg, 1);
            }
        }

        private void PB_Record2Face_MouseClick(object sender, MouseEventArgs e)
        {
            MouseButtons b = e.Button;
            if (b == MouseButtons.Left)
            {
                ChangeRecordFaceID(sel_stg, 2);
            }
            else if (b == MouseButtons.Right)
            {
                ClearRecordFaceID(sel_stg, 2);
            }
        }

        private void PB_Record3Face_MouseClick(object sender, MouseEventArgs e)
        {
            MouseButtons b = e.Button;
            if (b == MouseButtons.Left)
            {
                ChangeRecordFaceID(sel_stg, 3);
            }
            else if (b == MouseButtons.Right)
            {
                ClearRecordFaceID(sel_stg, 3);
            }
        }

        private void PB_Record4Face_MouseClick(object sender, MouseEventArgs e)
        {
            MouseButtons b = e.Button;
            if (b == MouseButtons.Left)
            {
                ChangeRecordFaceID(sel_stg, 4);
            }
            else if (b == MouseButtons.Right)
            {
                ClearRecordFaceID(sel_stg, 4);
            }
        }

        private void PB_Record5Face_MouseClick(object sender, MouseEventArgs e)
        {
            MouseButtons b = e.Button;
            if (b == MouseButtons.Left)
            {
                ChangeRecordFaceID(sel_stg, 5);
            }
            else if (b == MouseButtons.Right)
            {
                ClearRecordFaceID(sel_stg, 5);
            }
        }
    }
}
