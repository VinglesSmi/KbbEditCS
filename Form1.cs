using Microsoft.VisualBasic;

namespace KbbEditCS
{
    public partial class Form1 : Form
    {
        string CurrentDir;

        ScoreEditor F_ScoreEdit;
        FaceEditor F_FaceEdit;
        GlobalsEditor F_GlobalsEdit;

        HexEditor F_HexEdit;
        bool HexWarnFlag = false;

        public Form1()
        {
            InitializeComponent();

            F_ScoreEdit = new ScoreEditor();
            F_FaceEdit = new FaceEditor();
            F_GlobalsEdit = new GlobalsEditor();

            F_HexEdit = new HexEditor();

#if DEBUG
            Text = "KbbEdit [DEBUG]";
#else
            menuStrip1.Items.RemoveByKey("hexEditorToolStripMenuItem");
#endif

            CurrentDir = "";
        }

        private void B_OpenScoreEdit_Click(object sender, EventArgs e)
        {
            F_ScoreEdit.Show();
        }

        private void B_OpenFaceEdit_Click(object sender, EventArgs e)
        {
            F_FaceEdit.Show();
        }

        private void B_OpenGameFlagsEdit_Click(object sender, EventArgs e)
        {
            F_GlobalsEdit.Show();
        }

        private void newSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Globals.kbb_valid_flag && Globals.file_loaded)
            {
                MsgBoxResult res = Interaction.MsgBox("Discard changes to current file?", MsgBoxStyle.YesNo, "");
                if (res != MsgBoxResult.Yes) return;
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Save the current directory for later
                CurrentDir = string.Concat(Path.GetDirectoryName(saveFileDialog1.FileName), "\\");

                bool res = Globals.NewKbbFile(CurrentDir);
                if (res)
                {
                    // If the save file was successfully created, unlock access to the other forms

                    F_ScoreEdit?.Dispose();
                    F_ScoreEdit = new ScoreEditor();
                    B_OpenScoreEdit.Enabled = true;

                    F_FaceEdit?.Dispose();
                    F_FaceEdit = new FaceEditor();
                    B_OpenFaceEdit.Enabled = true;

                    F_GlobalsEdit?.Dispose();
                    F_GlobalsEdit = new GlobalsEditor();
                    B_OpenGameFlagsEdit.Enabled = true;

#if DEBUG
                    F_HexEdit?.Dispose();
                    F_HexEdit = new HexEditor();
                    hexEditorToolStripMenuItem.Enabled = true;
#endif
                }
            }
        }

        private void loadSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Globals.kbb_valid_flag && Globals.file_loaded)
            {
                MsgBoxResult res = Interaction.MsgBox("Discard changes to current file?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, "");
                if (res != MsgBoxResult.Yes) return;
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Save the current directory for later
                CurrentDir = string.Concat(Path.GetDirectoryName(openFileDialog1.FileName), "\\");

                bool res = Globals.LoadKbb(CurrentDir);
                if (res)
                {
                    // If the save file was properly loaded, unlock access to the other forms

                    F_ScoreEdit?.Dispose();
                    F_ScoreEdit = new ScoreEditor();
                    B_OpenScoreEdit.Enabled = true;

                    F_FaceEdit?.Dispose();
                    F_FaceEdit = new FaceEditor();
                    B_OpenFaceEdit.Enabled = true;

                    F_GlobalsEdit?.Dispose();
                    F_GlobalsEdit = new GlobalsEditor();
                    B_OpenGameFlagsEdit.Enabled = true;

#if DEBUG
                    F_HexEdit?.Dispose();
                    F_HexEdit = new HexEditor();
                    hexEditorToolStripMenuItem.Enabled = true;
#endif
                }
            }
        }

        private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.file_loaded)
            {
                Globals.kbb_valid_flag = true;
                bool res = Globals.SaveKbb(CurrentDir);

                if (res)
                {
                    Interaction.MsgBox("Changes applied to file.", MsgBoxStyle.Information, "");
                }
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Handle user closing form
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !Globals.kbb_valid_flag && Globals.file_loaded)
            {
                MsgBoxResult res = Interaction.MsgBox("Quit without saving changes?", MsgBoxStyle.OkCancel | MsgBoxStyle.Question, "");
                if (res != MsgBoxResult.Ok)
                {
                    e.Cancel = true;
                }
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: show help dialog
            Interaction.MsgBox("Unimplemented");
        }

        private void linksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: show links form
            Interaction.MsgBox("Unimplemented");
        }

        private void hexEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (HexWarnFlag)
            {
                F_HexEdit.Show();
            }
            else
            {
                MsgBoxResult res = Interaction.MsgBox("Tread carefully...", MsgBoxStyle.OkCancel | MsgBoxStyle.Information, "");
                if (res == MsgBoxResult.Ok)
                {
                    HexWarnFlag = true;
                    F_HexEdit.Show();
                }
            }
        }
    }
}
