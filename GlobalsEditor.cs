using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KbbEditCS
{
    public partial class GlobalsEditor : Form
    {
        public GlobalsEditor()
        {
            InitializeComponent();
        }

        private void GlobalsEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void GlobalsEditor_Load(object sender, EventArgs e)
        {
            CB_UfoActive.Checked = Globals.kbbfile.globals.ufo_active;
            NUD_UfoCounter.Maximum = Globals.kbbfile.globals.ufo_active ? 2 : 1;
            NUD_UfoCounter.Value = Math.Min((byte)(Globals.kbbfile.globals.ufo_active ? 2 : 1), Globals.kbbfile.globals.ufo_counter);

            switch (Globals.kbbfile.globals.ufo_stg)
            {
                case 0: DROP_UfoStg.SelectedIndex = 0; break;
                case 1: DROP_UfoStg.SelectedIndex = 1; break;
                case 2: DROP_UfoStg.SelectedIndex = 4; break;
                case 3: DROP_UfoStg.SelectedIndex = 2; break;
                case 4: DROP_UfoStg.SelectedIndex = 3; break;
                default: break;
            }

            CB_SlideBtnStg1.Checked = Globals.kbbfile.globals.facesel_stg1;
            CB_SlideBtnStg2.Checked = Globals.kbbfile.globals.facesel_stg2;
            CB_SlideBtnStg3.Checked = Globals.kbbfile.globals.facesel_stg3;
            CB_SlideBtnStg4.Checked = Globals.kbbfile.globals.facesel_stg4;

            CB_SneakySnapsUnlocked.Checked = Globals.kbbfile.globals.sneaky_snaps_unlocked;
            CB_SneakySnapsIntroduced.Checked = Globals.kbbfile.globals.sneaky_snaps_introduced;
            CB_SneakySnapsEnabled.Checked = Globals.kbbfile.globals.sneaky_snaps_en;

            CB_FaceCollectionUnlocked.Checked = Globals.kbbfile.globals.facecollection_unlock;
            CB_CrownEnable.Checked = Globals.kbbfile.globals.crown_en;

            uint m = Math.Min(20, Globals.kbbfile.globals.title_scenes_unlocked);
            NUD_ScenesUnlocked.Value = m;
            NUD_LastViewedScene.Maximum = Math.Max(0, (int)m - 1);
            NUD_LastViewedScene.Value = Math.Min(m - 1, Globals.kbbfile.globals.title_scenes_current);

            NUD_FriendFacesCounter.Value = Math.Min(99,Globals.kbbfile.globals.friend_faces);
        }

        private void CB_UfoActive_Click(object sender, EventArgs e)
        {
            Globals.kbbfile.globals.ufo_active = CB_UfoActive.Checked;
            NUD_UfoCounter.Maximum = Globals.kbbfile.globals.ufo_active ? 2 : 1;
            Globals.kbb_valid_flag = false;
        }

        private void NUD_UfoCounter_ValueChanged(object sender, EventArgs e)
        {
            Globals.kbbfile.globals.ufo_counter = (byte)NUD_UfoCounter.Value;
            Globals.kbb_valid_flag = false;
        }

        private void DROP_UfoStg_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DROP_UfoStg.SelectedIndex)
            {
                case 0: Globals.kbbfile.globals.ufo_stg = 0; break;
                case 1: Globals.kbbfile.globals.ufo_stg = 1; break;
                case 2: Globals.kbbfile.globals.ufo_stg = 3; break;
                case 3: Globals.kbbfile.globals.ufo_stg = 4; break;
                case 4: Globals.kbbfile.globals.ufo_stg = 2; break;
                default: break;
            }
            Globals.kbb_valid_flag = false;
        }

        private void CB_SlideBtnStg1_Click(object sender, EventArgs e)
        {
            Globals.kbbfile.globals.facesel_stg1 = CB_SlideBtnStg1.Checked;
            Globals.kbb_valid_flag = false;
        }

        private void CB_SlideBtnStg2_Click(object sender, EventArgs e)
        {
            Globals.kbbfile.globals.facesel_stg2 = CB_SlideBtnStg2.Checked;
            Globals.kbb_valid_flag = false;
        }

        private void CB_SlideBtnStg3_Click(object sender, EventArgs e)
        {
            Globals.kbbfile.globals.facesel_stg3 = CB_SlideBtnStg3.Checked;
            Globals.kbb_valid_flag = false;
        }

        private void CB_SlideBtnStg4_Click(object sender, EventArgs e)
        {
            Globals.kbbfile.globals.facesel_stg4 = CB_SlideBtnStg4.Checked;
            Globals.kbb_valid_flag = false;
        }

        private void CB_SneakySnapsUnlocked_Click(object sender, EventArgs e)
        {
            Globals.kbbfile.globals.sneaky_snaps_unlocked = CB_SneakySnapsUnlocked.Checked;
            Globals.kbb_valid_flag = false;
        }

        private void CB_SneakySnapsIntroduced_Click(object sender, EventArgs e)
        {
            Globals.kbbfile.globals.sneaky_snaps_introduced = CB_SneakySnapsIntroduced.Checked;
            Globals.kbb_valid_flag = false;
        }

        private void CB_SneakySnapsEnabled_Click(object sender, EventArgs e)
        {
            Globals.kbbfile.globals.sneaky_snaps_en = CB_SneakySnapsEnabled.Checked;
            Globals.kbb_valid_flag = false;
        }

        private void CB_FaceCollectionUnlocked_Click(object sender, EventArgs e)
        {
            Globals.kbbfile.globals.facecollection_unlock = CB_FaceCollectionUnlocked.Checked;
            Globals.kbb_valid_flag = false;
        }

        private void CB_CrownEnable_Click(object sender, EventArgs e)
        {
            Globals.kbbfile.globals.crown_en = CB_CrownEnable.Checked;
            Globals.kbb_valid_flag = false;
        }

        private void NUD_ScenesUnlocked_ValueChanged(object sender, EventArgs e)
        {
            Globals.kbbfile.globals.title_scenes_unlocked = (uint)NUD_ScenesUnlocked.Value;
            NUD_LastViewedScene.Maximum = Math.Max(0, NUD_ScenesUnlocked.Value - 1);
            Globals.kbb_valid_flag = false;
        }

        private void NUD_LastViewedScene_ValueChanged(object sender, EventArgs e)
        {
            Globals.kbbfile.globals.title_scenes_current = (uint)NUD_LastViewedScene.Value;
            Globals.kbb_valid_flag = false;
        }

        private void NUD_FriendFacesCounter_ValueChanged(object sender, EventArgs e)
        {
            Globals.kbbfile.globals.friend_faces = (uint)NUD_FriendFacesCounter.Value;
            Globals.kbb_valid_flag = false;
        }
    }
}
