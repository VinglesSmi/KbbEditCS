using System.Runtime.InteropServices;

namespace KbbEditCS
{
    public partial class HexEditor : Form
    {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vKey);

        int fileindex = -1;
        int sel_addr = -1;
        bool highnybble = true;

        int vscroll = 0;
        int vscrollmax = 0;

        public HexEditor()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HexEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        string GetRegionName(int addr)
        {
            if (sel_addr == -1) return "";

            if (fileindex == 0) // Kbb.dat
            {
                // FACE
                if (addr < 0xC40) return string.Format("FACE #{0}", addr / 0x40);

                // STAGE RECORDS
                if (addr < 0xDF8)
                {
                    int slot = (addr - 0xC40) / 0x2C;
                    switch (slot)
                    {
                        case 0: return "STAGE 1 RECORDS";
                        case 1: return "STAGE 2 RECORDS";
                        case 2: return "STAGE 3 RECORDS";
                        case 3: return "FINAL STAGE RECORDS";
                        case 4: return "BONUS STAGE RECORDS";
                        case 5: return "EXTRA STAGE RECORDS";
                        case 6: return "SAF STAGE 1 RECORDS";
                        case 7: return "SAF STAGE 2 RECORDS";
                        case 8: return "SAF BONUS STAGE RECORDS";
                        case 9: return "TUTORIAL STAGE RECORDS";
                        default: return "";
                    }
                }

                // UFO CREW FACE
                if (addr < 0xF88) return string.Format("UFO CREW FACE #{0}", (addr - 0xDF8) / 0x28);

                // DELETED UFO CREW FACE
                if (addr < 0x10C8) return string.Format("DELETED UFO CREW FACE #{0}", (addr - 0xF88) / 0x20);

                // GLOBALS
                if (addr < 0x1180) return "GLOBALS";

                if (addr < 0x1580) return "SCRATCHPAD";

                if ((addr&0x1FFC) == 0x1580) return "FILE MAGIC";
                if ((addr&0x1FFC) == 0x1588) return "CHECKSUM";

                return "";
            }
            else
            {
                if (fileindex < 50) return string.Format("PhotoF{0:D2}.dat", fileindex - 1);
                else return string.Format("PhotoP{0:D2}.dat", fileindex - 50);
            }
        }

        string GetFieldName(int addr)
        {
            if (sel_addr == -1) return "";

            string s = "Field: ";

            if (fileindex == 0) // Kbb.dat
            {
                // face slots
                if (addr < 0xC40)
                {
                    int offs = addr % 0x40;

                    int o2 = offs & 0x3E;
                    int o4 = offs & 0x3C;
                    int o8 = offs & 0x38;

                    if (o4 == 0) return s+"Face ID";

                    if (o2 == 0x4)   return s+"Face meet date year";
                    if (offs == 0x6) return s+"Face meet date month";
                    if (offs == 0x7) return s+"Face meet date day";

                    if (o2 == 0x8) return s+"Times chosen";
                    if (o2 == 0xA) return s+"0Ah";
                    if (o2 == 0xC) return s+"Face age";
                    if (o2 == 0xE) return s+"Face gender";

                    if (o4 == 0x10) return s+"Texture horizontal translation";
                    if (o4 == 0x14) return s+"Texture vertical translation";
                    if (o4 == 0x18) return s+"Texture horizontal scale";
                    if (o4 == 0x1C) return s+"Texture vertical scale";
                    if (o4 == 0x20) return s+"Texture rotaton";

                    if (o4 == 0x28) return s+"Maker note: console hash";
                    if (o4 == 0x2C) return s+"Maker note: 04h";
                    if (o8 == 0x30) return s+"Maker note: capture date";
                    if (o4 == 0x38) return s+"Maker note: face number in source image";
                    if (o4 == 0x3C) return s+"Maker note: 14h";

                    return "";
                }

                // score records
                if (addr < 0xDF8)
                {
                    int offs = (addr - 0xC40) % 0x2C;

                    int o2 = offs & 0xFE;
                    int o4 = offs & 0xFC;
                    int o8 = offs & 0xF8;

                    if (o4 == 0x00)   return s+"Record #1 Face ID";
                    if (o4 == 0x04)   return s+"Record #1 Score";
                    if (o4 == 0x08)   return s+"Record #2 Face ID";
                    if (o4 == 0x0C)   return s+"Record #2 Score";
                    if (o4 == 0x10)   return s+"Record #3 Face ID";
                    if (o4 == 0x14)   return s+"Record #3 Score";
                    if (o4 == 0x18)   return s+"Record #4 Face ID";
                    if (o4 == 0x1C)   return s+"Record #4 Score";
                    if (o4 == 0x20)   return s+"Record #5 Face ID";
                    if (o4 == 0x24)   return s+"Record #5 Score";
                    if (o2 == 0x28)   return s+"Max combo";
                    if (o2 == 0x2A)   return s+"Stage completed";

                    return "";
                }

                // ufo crew faces
                if (addr < 0xF88)
                {
                    int offs = (addr - 0xDF8) % 0x28;

                    int o2 = offs & 0xFE;
                    int o4 = offs & 0xFC;
                    int o8 = offs & 0xF8;

                    if (o4 == 0) return s+"Face ID";

                    if (o4 == 0x08) return s+"Maker note: console hash";
                    if (o4 == 0x0C) return s+"Maker note: 04h";
                    if (o8 == 0x10) return s+"Maker note: capture date";
                    if (o4 == 0x18) return s+"Maker note: face number in source image";
                    if (o4 == 0x1C) return s+"Maker note: 14h";

                    if (o2 == 0x20) return s+"Face age";
                    if (o2 == 0x22) return s+"Face gender";

                    if (o4 == 0x24) return s+"\"NEW\" bubble";

                    return "";
                }
                
                // deleted ufo crew faces
                if (addr < 0x10C8)
                {
                    int offs = (addr - 0xF88) % 0x20;

                    int o2 = offs & 0xFE;
                    int o4 = offs & 0xFC;
                    int o8 = offs & 0xF8;
                    
                    if (o4 == 0) return s+"Face ID";

                    if (o4 == 0x08) return s+"Maker note: console hash";
                    if (o4 == 0x0C) return s+"Maker note: 04h";
                    if (o8 == 0x10) return s+"Maker note: capture date";
                    if (o4 == 0x18) return s+"Maker note: face number in source image";
                    if (o4 == 0x1C) return s+"Maker note: 14h";

                    return "";
                }

                // globals
                if (addr < 0x1100)
                {
                    int o2 = addr & 0xFFFE;
                    int o4 = addr & 0xFFFC;

                    if (addr == 0x10C8) return s+"UFO Active";
                    if (addr == 0x10C9) return s+"UFO Stage";
                    if (addr == 0x10CA) return s+"UFO Counter";

                    if (o4 == 0x10CC) return s+"Next Face ID";
                    if (o4 == 0x10D0) return s+"Next UFO Crew Face ID";
                    if (o4 == 0x10D4) return s+"Next Deleted UFO Crew Face ID";

                    if (o4 == 0x10D8) return s+"10D8h";
                    if (o4 == 0x10DC) return s+"10DCh";
                    if (o4 == 0x10E0) return s+"10E0h";
                    if (o4 == 0x10E4) return s+"10E4h";

                    if (o4 == 0x10E8) return s+"Friend Faces";
                    if (o4 == 0x10EC) return s+"Title scenes unlocked";
                    if (o4 == 0x10F0) return s+"Last viewed title scene";

                    if (o2 == 0x10F4) return s+"10F4h";
                    if (o2 == 0x10F6) return s+"10F6h";
                    if (o2 == 0x10F8) return s+"10F8h";

                    if (addr == 0x10FA) return s+"Campaign advice tip counter";
                    if (addr == 0x10FB) return s+"SAF advice tip counter";
                    if (addr == 0x10FC) return s+"Sneaky Snaps enable";
                    if (addr == 0x10FD) return s+"10FDh";

                    return "";
                }

                // game flags
                if (addr < 0x1180)
                {
                    switch (addr)
                    {
                        case 0x1100: return s+"Face Collection unlocked";
                        case 0x1101: return s+"1101h";
                        case 0x1102: return s+"1102h";

                        case 0x1103: return s+"Stage 2 unlocked";
                        case 0x1104: return s+"1104h";
                        case 0x1105: return s+"Stage 3 unlocked";
                        case 0x1106: return s+"Final Stage unlocked";
                        case 0x1107: return s+"Bonus Stage unlocked";
                        case 0x1108: return s+"Extra Stage unlocked";
                        case 0x1109: return s+"SAF Stage 2 unlocked";
                        case 0x110A: return s+"SAF Bonus Stage unlocked";
                        case 0x110B: return s+"SAF Stage 1 unlocked";

                        case 0x110C: return s+"110Ch";

                        case 0x110D: return s+"Face selection in Stage 1 enable";
                        case 0x110E: return s+"Face selection in Stage 2 enable";
                        case 0x110F: return s+"Face selection in Stage 3 enable";
                        case 0x1110: return s+"Face selection in Final Stage enable";

                        case 0x1111: return s+"1111h";
                        case 0x1112: return s+"UFO unlocked";
                        case 0x1113: return s+"1113h";
                        case 0x1114: return s+"1114h";
                        case 0x1115: return s+"1115h";
                        case 0x1116: return s+"1116h";
                        case 0x1117: return s+"1117h";
                        case 0x1118: return s+"1118h";
                        case 0x1119: return s+"1119h";
                        case 0x111A: return s+"111Ah";
                        case 0x111B: return s+"111Bh";
                        case 0x111C: return s+"111Ch";
                        case 0x111D: return s+"111Dh";
                        case 0x111E: return s+"111Eh";
                        case 0x111F: return s+"111Fh";

                        case 0x1120: return s+"1120h";
                        case 0x1121: return s+"1121h";
                        case 0x1122: return s+"1122h";
                        case 0x1123: return s+"1123h";
                        case 0x1124: return s+"1124h";
                        case 0x1125: return s+"1125h";
                        case 0x1126: return s+"1126h";
                        case 0x1127: return s+"1127h";
                        case 0x1128: return s+"1128h";
                        case 0x1129: return s+"1129h";
                        case 0x112A: return s+"112Ah";

                        case 0x112B: return s+"Stage 2 unlock animation";
                        case 0x112C: return s+"Stage 3 unlock animation";
                        case 0x112D: return s+"Final Stage unlock animation";
                        case 0x112E: return s+"Bonus Stage unlock animation";
                        case 0x112F: return s+"Extra Stage unlock animation";
                        case 0x1130: return s+"SAF Stage 2 unlock animation";
                        case 0x1131: return s+"SAF Bonus Stage unlock animation";

                        case 0x1132: return s+"UFO first encounter";

                        case 0x1133: return s+"1133h";

                        case 0x1134: return s+"SAF Stage 1 unlock animation";
                        case 0x1135: return s+"Enable showing a crown on the most chosen Face";

                        case 0x1136: return s+"1136h";
                        case 0x1137: return s+"1137h";
                        case 0x1138: return s+"1138h";
                        case 0x1139: return s+"1139h";

                        case 0x113A: return s+"Slide button unlock animation";
                        case 0x113B: return s+"113Bh";
                        case 0x113C: return s+"Stage 1 unlock animation";

                        case 0x113D: return s+"113Dh";
                        case 0x113E: return s+"113Eh";
                        case 0x113F: return s+"113Fh";
                        case 0x1140: return s+"1140h";
                        case 0x1141: return s+"1141h";
                        case 0x1142: return s+"1142h";
                        case 0x1143: return s+"1143h";
                        case 0x1144: return s+"1144h";
                        case 0x1145: return s+"1145h";
                        case 0x1146: return s+"1146h";
                        case 0x1147: return s+"1147h";
                        case 0x1148: return s+"1148h";

                        case 0x1149: return s+"1149h";
                        case 0x114A: return s+"114Ah";
                        case 0x114B: return s+"114Bh";
                        case 0x114C: return s+"114Ch";
                        case 0x114D: return s+"114Dh";
                        case 0x114E: return s+"114Eh";
                        case 0x114F: return s+"114Fh";

                        case 0x1150: return s+"1150h";
                        case 0x1151: return s+"1151h";
                        case 0x1152: return s+"1152h";
                        case 0x1153: return s+"1153h";
                        case 0x1154: return s+"1154h";
                        case 0x1155: return s+"1155h";
                        case 0x1156: return s+"1156h";
                        case 0x1157: return s+"1157h";
                        case 0x1158: return s+"1158h";
                        case 0x1159: return s+"1159h";
                        case 0x115A: return s+"115Ah";
                        case 0x115B: return s+"115Bh";
                        case 0x115C: return s+"115Ch";
                        case 0x115D: return s+"115Dh";
                        case 0x115E: return s+"115Eh";
                        case 0x115F: return s+"115Fh";

                        case 0x1160: return s+"Advice Tip #01 seen";
                        case 0x1161: return s+"Advice Tip #02 seen";
                        case 0x1162: return s+"Advice Tip #03 seen";
                        case 0x1163: return s+"Advice Tip #04 seen";
                        case 0x1164: return s+"Advice Tip #05 seen";
                        case 0x1165: return s+"Advice Tip #06 seen";
                        case 0x1166: return s+"Advice Tip #07 seen";
                        case 0x1167: return s+"Advice Tip #08 seen";
                        case 0x1168: return s+"Advice Tip #09 seen";
                        case 0x1169: return s+"Advice Tip #10 seen";
                        case 0x116A: return s+"Advice Tip #11 seen";
                        case 0x116B: return s+"Advice Tip #12 seen";
                        case 0x116C: return s+"Advice Tip #13 seen";
                        case 0x116D: return s+"Advice Tip #14 seen";
                        case 0x116E: return s+"Advice Tip #15 seen";
                        case 0x116F: return s+"Advice Tip #16 seen";
                        case 0x1170: return s+"Advice Tip #17 seen";
                        case 0x1171: return s+"Advice Tip #18 seen";
                        case 0x1172: return s+"Advice Tip #19 seen";
                        case 0x1173: return s+"Advice Tip #20 seen";
                        case 0x1174: return s+"Advice Tip #21 seen";
                        case 0x1175: return s+"Advice Tip #22 seen";
                        case 0x1176: return s+"Advice Tip #23 seen";
                        case 0x1177: return s+"Advice Tip #24 seen";
                        case 0x1178: return s+"Advice Tip #25 seen";
                        case 0x1179: return s+"Advice Tip #26 seen";
                        case 0x117A: return s+"Advice Tip #27 seen";
                        case 0x117B: return s+"Advice Tip #28 seen";

                        case 0x117C: return s+"117Ch";
                        case 0x117D: return s+"117Dh";
                        case 0x117E: return s+"117Eh";
                        case 0x117F: return s+"117Fh";

                        default: return "";
                    }
                }

                return "";
            }
            else
            {
                if (addr < 4) return s+"Marker";
                if (addr < 0x8004)
                {
                    int cx = (((addr - 4) >> 4) & 0x7F) >> 3;
                    int cy = (addr-4) >> 11;
                    int index = ((addr-4-(addr&1)) >> 1) & 0x3F;
                    int px = Globals.picapxorder[index] & 7;
                    int py = (Globals.picapxorder[index] - px) >> 3;
                    int x = (cx << 3) + px;
                    int y = (cy << 3) + py;

                    return s+string.Format("Pixel data: X:{0}, Y:{1}",x,y);
                }
                if (addr < 0x8008) return s+"Checksum";
                return "";
            }
        }

        void PrintValue(Graphics g, Brush b, int addr, float x, float y)
        {
            if (sel_addr == -1) return;

            string s = "Value: ";
            string v = "";
            string h = "";

            if (fileindex == 0) // Kbb.dat
            {
                if (addr >= 0x1590) return;

                // face slots
                if (addr < 0xC40)
                {
                    int slot = addr / 0x40;
                    int offs = addr % 0x40;

                    int o2 = offs & 0x3E;
                    int o4 = offs & 0x3C;
                    int o8 = offs & 0x38;

                    Globals.FaceRecord face = Globals.kbbfile.face_records[slot];

                    if (o4 == 0) { v = face.faceid.ToString(); h = face.faceid.ToString("X8"); }

                    if (o2 == 0x4) { v = face.met_year.ToString(); h = face.met_year.ToString("X4"); }
                    if (offs == 0x6) { v = face.met_month.ToString(); h = face.met_month.ToString("X2"); }
                    if (offs == 0x7) { v = face.met_day.ToString(); h = face.met_day.ToString("X2"); }

                    if (o2 == 0x8) { v = face.selections.ToString(); h = face.selections.ToString("X4"); }
                    if (o2 == 0xA) { v = face.field_0Ah.ToString(); h = face.field_0Ah.ToString("X4"); }
                    if (o2 == 0xC) { v = face.age.ToString(); h = face.age.ToString("X4"); }
                    if (o2 == 0xE) { v = face.gender.ToString(); h = face.gender.ToString("X4"); }

                    if (o4 == 0x10) { v = face.tx_move_x.ToString(); h = BitConverter.SingleToInt32Bits(face.tx_move_x).ToString("X8"); }
                    if (o4 == 0x14) { v = face.tx_move_y.ToString(); h = BitConverter.SingleToInt32Bits(face.tx_move_y).ToString("X8"); }
                    if (o4 == 0x18) { v = face.tx_stretch_x.ToString(); h = BitConverter.SingleToInt32Bits(face.tx_stretch_x).ToString("X8"); }
                    if (o4 == 0x1C) { v = face.tx_stretch_y.ToString(); h = BitConverter.SingleToInt32Bits(face.tx_stretch_y).ToString("X8"); }
                    if (o4 == 0x20) { v = face.tx_rot.ToString(); h = BitConverter.SingleToInt32Bits(face.tx_rot).ToString("X8"); }

                    if (o4 == 0x24) return;

                    if (o4 == 0x28) { v = face.makernote.conhashunique.ToString(); h = face.makernote.conhashunique.ToString("X8"); }
                    if (o4 == 0x2C) { v = face.makernote.field_04h.ToString(); h = face.makernote.field_04h.ToString("X8"); }
                    if (o8 == 0x30) { v = face.makernote.capturedate.ToString(); h = face.makernote.capturedate.ToString("X16"); }
                    if (o4 == 0x38) { v = face.makernote.src_facenum.ToString(); h = face.makernote.src_facenum.ToString("X8"); }
                    if (o4 == 0x3C) { v = face.makernote.field_14h.ToString(); h = face.makernote.field_14h.ToString("X8"); }
                }

                // score records
                else if (addr < 0xDF8)
                {
                    int slot = (addr - 0xC40) / 0x2C;
                    int offs = (addr - 0xC40) % 0x2C;

                    int o2 = offs & 0xFE;
                    int o4 = offs & 0xFC;

                    Globals.LvlScoreRecord record = Globals.kbbfile.stg_records[slot];

                    if (o4 == 0x00) { v = record.r1_face.ToString(); h = record.r1_face.ToString("X8"); }
                    if (o4 == 0x04) { v = record.r1_score.ToString(); h = record.r1_score.ToString("X8"); }
                    if (o4 == 0x08) { v = record.r2_face.ToString(); h = record.r2_face.ToString("X8"); }
                    if (o4 == 0x0C) { v = record.r2_score.ToString(); h = record.r2_score.ToString("X8"); }
                    if (o4 == 0x10) { v = record.r3_face.ToString(); h = record.r3_face.ToString("X8"); }
                    if (o4 == 0x14) { v = record.r3_score.ToString(); h = record.r3_score.ToString("X8"); }
                    if (o4 == 0x18) { v = record.r4_face.ToString(); h = record.r4_face.ToString("X8"); }
                    if (o4 == 0x1C) { v = record.r4_score.ToString(); h = record.r4_score.ToString("X8"); }
                    if (o4 == 0x20) { v = record.r5_face.ToString(); h = record.r5_face.ToString("X8"); }
                    if (o4 == 0x24) { v = record.r5_score.ToString(); h = record.r5_score.ToString("X8"); }
                    if (o2 == 0x28) { v = record.maxcombo.ToString(); h = record.maxcombo.ToString("X4"); }
                    if (o2 == 0x2A) v = record.beatstg.ToString();
                }

                // ufo crew faces
                else if (addr < 0xF88)
                {
                    int slot = (addr - 0xDF8) / 0x28;
                    int offs = (addr - 0xDF8) % 0x28;

                    int o2 = offs & 0xFE;
                    int o4 = offs & 0xFC;
                    int o8 = offs & 0xF8;

                    Globals.UFORecord face = Globals.kbbfile.ufo_records[slot];

                    if (o4 == 0) { v = face.faceid.ToString(); h = face.faceid.ToString("X8"); }

                    if (o4 == 0x4) return;

                    if (o4 == 0x08) { v = face.makernote.conhashunique.ToString(); h = face.makernote.conhashunique.ToString("X8"); }
                    if (o4 == 0x0C) { v = face.makernote.field_04h.ToString(); h = face.makernote.field_04h.ToString("X8"); }
                    if (o8 == 0x10) { v = face.makernote.capturedate.ToString(); h = face.makernote.capturedate.ToString("X16"); }
                    if (o4 == 0x18) { v = face.makernote.src_facenum.ToString(); h = face.makernote.src_facenum.ToString("X8"); }
                    if (o4 == 0x1C) { v = face.makernote.field_14h.ToString(); h = face.makernote.field_14h.ToString("X8"); }

                    if (o2 == 0x20) { v = face.age.ToString(); h = face.age.ToString("X4"); }
                    if (o2 == 0x22) { v = face.gender.ToString(); h = face.gender.ToString("X4"); }

                    if (o4 == 0x24) v = face.field_NEW.ToString();
                }

                // deleted ufo crew faces
                else if (addr < 0x10C8)
                {
                    int slot = (addr - 0xF88) / 0x20;
                    int offs = (addr - 0xF88) % 0x20;

                    int o2 = offs & 0xFE;
                    int o4 = offs & 0xFC;
                    int o8 = offs & 0xF8;

                    Globals.UFODeletedRecord face = Globals.kbbfile.ufo_old_records[slot];

                    if (o4 == 0) { v = face.faceid.ToString(); h = face.faceid.ToString("X8"); }

                    if (o4 == 0x4) return;

                    if (o4 == 0x08) { v = face.makernote.conhashunique.ToString(); h = face.makernote.conhashunique.ToString("X8"); }
                    if (o4 == 0x0C) { v = face.makernote.field_04h.ToString(); h = face.makernote.field_04h.ToString("X8"); }
                    if (o8 == 0x10) { v = face.makernote.capturedate.ToString(); h = face.makernote.capturedate.ToString("X16"); }
                    if (o4 == 0x18) { v = face.makernote.src_facenum.ToString(); h = face.makernote.src_facenum.ToString("X8"); }
                    if (o4 == 0x1C) { v = face.makernote.field_14h.ToString(); h = face.makernote.field_14h.ToString("X8"); }
                }

                // globals
                else if (addr < 0x1100)
                {
                    int o2 = addr & 0xFFFE;
                    int o4 = addr & 0xFFFC;
                    int o8 = addr & 0xFFF8;

                    if (addr == 0x10C8) v = Globals.kbbfile.globals.ufo_active.ToString();
                    if (addr == 0x10C9) { v = Globals.kbbfile.globals.ufo_stg.ToString(); h = Globals.kbbfile.globals.ufo_stg.ToString("X2"); }
                    if (addr == 0x10CA) { v = Globals.kbbfile.globals.ufo_counter.ToString(); h = Globals.kbbfile.globals.ufo_counter.ToString("X2"); }
                    if (addr == 0x10CB) return;

                    if (o4 == 0x10CC) { v = Globals.kbbfile.globals.faceid_next.ToString(); h = Globals.kbbfile.globals.faceid_next.ToString("X8"); }
                    if (o4 == 0x10D0) { v = Globals.kbbfile.globals.ufo_faceid_next.ToString(); h = Globals.kbbfile.globals.ufo_faceid_next.ToString("X8"); }
                    if (o4 == 0x10D4) { v = Globals.kbbfile.globals.delufo_faceid_next.ToString(); h = Globals.kbbfile.globals.delufo_faceid_next.ToString("X8"); }

                    if (o4 == 0x10D8) { v = Globals.kbbfile.globals.field_10D8h.ToString(); h = Globals.kbbfile.globals.field_10D8h.ToString("X8"); }
                    if (o4 == 0x10DC) { v = Globals.kbbfile.globals.field_10DCh.ToString(); h = Globals.kbbfile.globals.field_10DCh.ToString("X8"); }
                    if (o4 == 0x10E0) { v = Globals.kbbfile.globals.field_10E0h.ToString(); h = Globals.kbbfile.globals.field_10E0h.ToString("X8"); }
                    if (o4 == 0x10E4) { v = Globals.kbbfile.globals.field_10E4h.ToString(); h = Globals.kbbfile.globals.field_10E4h.ToString("X8"); }

                    if (o4 == 0x10E8) { v = Globals.kbbfile.globals.friend_faces.ToString(); h = Globals.kbbfile.globals.friend_faces.ToString("X8"); }
                    if (o4 == 0x10EC) { v = Globals.kbbfile.globals.title_scenes_unlocked.ToString(); h = Globals.kbbfile.globals.title_scenes_unlocked.ToString("X8"); }
                    if (o4 == 0x10F0) { v = Globals.kbbfile.globals.title_scenes_current.ToString(); h = Globals.kbbfile.globals.title_scenes_current.ToString("X8"); }

                    if (o2 == 0x10F4) { v = Globals.kbbfile.globals.field_10F4h.ToString(); h = Globals.kbbfile.globals.field_10F4h.ToString("X4"); }
                    if (o2 == 0x10F6) { v = Globals.kbbfile.globals.field_10F6h.ToString(); h = Globals.kbbfile.globals.field_10F6h.ToString("X4"); }
                    if (o2 == 0x10F8) { v = Globals.kbbfile.globals.field_10F8h.ToString(); h = Globals.kbbfile.globals.field_10F8h.ToString("X4"); }

                    if (addr == 0x10FA) { v = Globals.kbbfile.globals.camp_adv_counter.ToString(); h = Globals.kbbfile.globals.camp_adv_counter.ToString("X2"); }
                    if (addr == 0x10FB) { v = Globals.kbbfile.globals.saf_adv_counter.ToString(); h = Globals.kbbfile.globals.saf_adv_counter.ToString("X2"); }
                    if (addr == 0x10FC) v = Globals.kbbfile.globals.sneaky_snaps_en.ToString();
                    if (addr == 0x10FD) { v = Globals.kbbfile.globals.field_10FDh.ToString(); }
                    if (o2 == 0x10FE) return;
                }

                // game flags
                else if (addr < 0x1180)
                {
                    switch (addr)
                    {
                        case 0x1100: v = Globals.kbbfile.globals.facecollection_unlock.ToString(); break;
                        case 0x1101: v = Globals.kbbfile.globals.field_1101h.ToString(); break;
                        case 0x1102: v = Globals.kbbfile.globals.field_1102h.ToString(); break;

                        case 0x1103: v = Globals.kbbfile.globals.stg2_unlock.ToString(); break;
                        case 0x1104: v = Globals.kbbfile.globals.field_1104h.ToString(); break;
                        case 0x1105: v = Globals.kbbfile.globals.stg3_unlock.ToString(); break;
                        case 0x1106: v = Globals.kbbfile.globals.stg4_unlock.ToString(); break;
                        case 0x1107: v = Globals.kbbfile.globals.stgbonus_unlock.ToString(); break;
                        case 0x1108: v = Globals.kbbfile.globals.stgextra_unlock.ToString(); break;
                        case 0x1109: v = Globals.kbbfile.globals.saf_stg2_unlock.ToString(); break;
                        case 0x110A: v = Globals.kbbfile.globals.saf_stgbonus_unlock.ToString(); break;
                        case 0x110B: v = Globals.kbbfile.globals.saf_stg1_unlock.ToString(); break;

                        case 0x110C: v = Globals.kbbfile.globals.field_110Ch.ToString(); break;

                        case 0x110D: v = Globals.kbbfile.globals.facesel_stg1.ToString(); break;
                        case 0x110E: v = Globals.kbbfile.globals.facesel_stg2.ToString(); break;
                        case 0x110F: v = Globals.kbbfile.globals.facesel_stg3.ToString(); break;
                        case 0x1110: v = Globals.kbbfile.globals.facesel_stg4.ToString(); break;

                        case 0x1111: v = Globals.kbbfile.globals.field_1111h.ToString(); break;
                        case 0x1112: v = Globals.kbbfile.globals.field_1112h.ToString(); break;
                        case 0x1113: v = Globals.kbbfile.globals.field_1113h.ToString(); break;
                        case 0x1114: v = Globals.kbbfile.globals.field_1114h.ToString(); break;
                        case 0x1115: v = Globals.kbbfile.globals.field_1115h.ToString(); break;
                        case 0x1116: v = Globals.kbbfile.globals.field_1116h.ToString(); break;
                        case 0x1117: v = Globals.kbbfile.globals.field_1117h.ToString(); break;
                        case 0x1118: v = Globals.kbbfile.globals.field_1118h.ToString(); break;
                        case 0x1119: v = Globals.kbbfile.globals.field_1119h.ToString(); break;
                        case 0x111A: v = Globals.kbbfile.globals.field_111Ah.ToString(); break;
                        case 0x111B: v = Globals.kbbfile.globals.field_111Bh.ToString(); break;
                        case 0x111C: v = Globals.kbbfile.globals.field_111Ch.ToString(); break;
                        case 0x111D: v = Globals.kbbfile.globals.field_111Dh.ToString(); break;
                        case 0x111E: v = Globals.kbbfile.globals.field_111Eh.ToString(); break;
                        case 0x111F: v = Globals.kbbfile.globals.field_111Fh.ToString(); break;

                        case 0x1120: v = Globals.kbbfile.globals.field_1120h.ToString(); break;
                        case 0x1121: v = Globals.kbbfile.globals.field_1121h.ToString(); break;
                        case 0x1122: v = Globals.kbbfile.globals.field_1122h.ToString(); break;
                        case 0x1123: v = Globals.kbbfile.globals.field_1123h.ToString(); break;
                        case 0x1124: v = Globals.kbbfile.globals.field_1124h.ToString(); break;
                        case 0x1125: v = Globals.kbbfile.globals.field_1125h.ToString(); break;
                        case 0x1126: v = Globals.kbbfile.globals.field_1126h.ToString(); break;
                        case 0x1127: v = Globals.kbbfile.globals.field_1127h.ToString(); break;
                        case 0x1128: v = Globals.kbbfile.globals.field_1128h.ToString(); break;
                        case 0x1129: v = Globals.kbbfile.globals.field_1129h.ToString(); break;
                        case 0x112A: v = Globals.kbbfile.globals.field_112Ah.ToString(); break;

                        case 0x112B: v = Globals.kbbfile.globals.stg2_unlock_anim.ToString(); break;
                        case 0x112C: v = Globals.kbbfile.globals.stg3_unlock_anim.ToString(); break;
                        case 0x112D: v = Globals.kbbfile.globals.stg4_unlock_anim.ToString(); break;
                        case 0x112E: v = Globals.kbbfile.globals.stgbonus_unlock_anim.ToString(); break;
                        case 0x112F: v = Globals.kbbfile.globals.stgextra_unlock_anim.ToString(); break;
                        case 0x1130: v = Globals.kbbfile.globals.saf_stg2_unlock_anim.ToString(); break;
                        case 0x1131: v = Globals.kbbfile.globals.saf_stgbonus_unlock_anim.ToString(); break;

                        case 0x1132: v = Globals.kbbfile.globals.ufo_landed.ToString(); break;

                        case 0x1133: v = Globals.kbbfile.globals.field_1133h.ToString(); break;

                        case 0x1134: v = Globals.kbbfile.globals.saf_stg1_unlock_anim.ToString(); break;
                        case 0x1135: v = Globals.kbbfile.globals.crown_en.ToString(); break;

                        case 0x1136: v = Globals.kbbfile.globals.field_1136h.ToString(); break;
                        case 0x1137: v = Globals.kbbfile.globals.field_1137h.ToString(); break;
                        case 0x1138: v = Globals.kbbfile.globals.field_1138h.ToString(); break;
                        case 0x1139: v = Globals.kbbfile.globals.field_1139h.ToString(); break;

                        case 0x113A: v = Globals.kbbfile.globals.slidebtn_unlock_anim.ToString(); break;
                        case 0x113B: v = Globals.kbbfile.globals.field_113Bh.ToString(); break;
                        case 0x113C: v = Globals.kbbfile.globals.stg1_unlock_anim.ToString(); break;

                        case 0x113D: v = Globals.kbbfile.globals.field_113Dh.ToString(); break;
                        case 0x113E: v = Globals.kbbfile.globals.field_113Eh.ToString(); break;
                        case 0x113F: v = Globals.kbbfile.globals.field_113Fh.ToString(); break;
                        case 0x1140: v = Globals.kbbfile.globals.field_1140h.ToString(); break;
                        case 0x1141: v = Globals.kbbfile.globals.field_1141h.ToString(); break;
                        case 0x1142: v = Globals.kbbfile.globals.field_1142h.ToString(); break;
                        case 0x1143: v = Globals.kbbfile.globals.field_1143h.ToString(); break;
                        case 0x1144: v = Globals.kbbfile.globals.field_1144h.ToString(); break;
                        case 0x1145: v = Globals.kbbfile.globals.sneaky_snaps_introduced.ToString(); break;
                        case 0x1146: v = Globals.kbbfile.globals.field_1146h.ToString(); break;
                        case 0x1147: v = Globals.kbbfile.globals.sneaky_snaps_unlocked.ToString(); break;
                        case 0x1148: v = Globals.kbbfile.globals.field_1148h.ToString(); break;

                        case 0x1149: v = Globals.kbbfile.globals.field_1149h.ToString(); break;
                        case 0x114A: v = Globals.kbbfile.globals.field_114Ah.ToString(); break;
                        case 0x114B: v = Globals.kbbfile.globals.field_114Bh.ToString(); break;
                        case 0x114C: v = Globals.kbbfile.globals.field_114Ch.ToString(); break;
                        case 0x114D: v = Globals.kbbfile.globals.field_114Dh.ToString(); break;
                        case 0x114E: v = Globals.kbbfile.globals.field_114Eh.ToString(); break;
                        case 0x114F: v = Globals.kbbfile.globals.field_114Fh.ToString(); break;

                        case 0x1150: v = Globals.kbbfile.globals.field_1150h.ToString(); break;
                        case 0x1151: v = Globals.kbbfile.globals.field_1151h.ToString(); break;
                        case 0x1152: v = Globals.kbbfile.globals.field_1152h.ToString(); break;
                        case 0x1153: v = Globals.kbbfile.globals.field_1153h.ToString(); break;
                        case 0x1154: v = Globals.kbbfile.globals.field_1154h.ToString(); break;
                        case 0x1155: v = Globals.kbbfile.globals.field_1155h.ToString(); break;
                        case 0x1156: v = Globals.kbbfile.globals.field_1156h.ToString(); break;
                        case 0x1157: v = Globals.kbbfile.globals.field_1157h.ToString(); break;
                        case 0x1158: v = Globals.kbbfile.globals.field_1158h.ToString(); break;
                        case 0x1159: v = Globals.kbbfile.globals.field_1159h.ToString(); break;
                        case 0x115A: v = Globals.kbbfile.globals.field_115Ah.ToString(); break;
                        case 0x115B: v = Globals.kbbfile.globals.field_115Bh.ToString(); break;
                        case 0x115C: v = Globals.kbbfile.globals.field_115Ch.ToString(); break;
                        case 0x115D: v = Globals.kbbfile.globals.field_115Dh.ToString(); break;
                        case 0x115E: v = Globals.kbbfile.globals.field_115Eh.ToString(); break;
                        case 0x115F: v = Globals.kbbfile.globals.field_115Fh.ToString(); break;

                        case 0x1160: v = Globals.kbbfile.globals.infomsg01.ToString(); break;
                        case 0x1161: v = Globals.kbbfile.globals.infomsg02.ToString(); break;
                        case 0x1162: v = Globals.kbbfile.globals.infomsg03.ToString(); break;
                        case 0x1163: v = Globals.kbbfile.globals.infomsg04.ToString(); break;
                        case 0x1164: v = Globals.kbbfile.globals.infomsg05.ToString(); break;
                        case 0x1165: v = Globals.kbbfile.globals.infomsg06.ToString(); break;
                        case 0x1166: v = Globals.kbbfile.globals.infomsg07.ToString(); break;
                        case 0x1167: v = Globals.kbbfile.globals.infomsg08.ToString(); break;
                        case 0x1168: v = Globals.kbbfile.globals.infomsg09.ToString(); break;
                        case 0x1169: v = Globals.kbbfile.globals.infomsg10.ToString(); break;
                        case 0x116A: v = Globals.kbbfile.globals.infomsg11.ToString(); break;
                        case 0x116B: v = Globals.kbbfile.globals.infomsg12.ToString(); break;
                        case 0x116C: v = Globals.kbbfile.globals.infomsg13.ToString(); break;
                        case 0x116D: v = Globals.kbbfile.globals.infomsg14.ToString(); break;
                        case 0x116E: v = Globals.kbbfile.globals.infomsg15.ToString(); break;
                        case 0x116F: v = Globals.kbbfile.globals.infomsg16.ToString(); break;
                        case 0x1170: v = Globals.kbbfile.globals.infomsg17.ToString(); break;
                        case 0x1171: v = Globals.kbbfile.globals.infomsg18.ToString(); break;
                        case 0x1172: v = Globals.kbbfile.globals.infomsg19.ToString(); break;
                        case 0x1173: v = Globals.kbbfile.globals.infomsg20.ToString(); break;
                        case 0x1174: v = Globals.kbbfile.globals.infomsg21.ToString(); break;
                        case 0x1175: v = Globals.kbbfile.globals.infomsg22.ToString(); break;
                        case 0x1176: v = Globals.kbbfile.globals.infomsg23.ToString(); break;
                        case 0x1177: v = Globals.kbbfile.globals.infomsg24.ToString(); break;
                        case 0x1178: v = Globals.kbbfile.globals.infomsg25.ToString(); break;
                        case 0x1179: v = Globals.kbbfile.globals.infomsg26.ToString(); break;
                        case 0x117A: v = Globals.kbbfile.globals.infomsg27.ToString(); break;
                        case 0x117B: v = Globals.kbbfile.globals.infomsg28.ToString(); break;

                        case 0x117C: v = Globals.kbbfile.globals.field_117Ch.ToString(); break;
                        case 0x117D: v = Globals.kbbfile.globals.field_117Dh.ToString(); break;
                        case 0x117E: v = Globals.kbbfile.globals.field_117Eh.ToString(); break;
                        case 0x117F: v = Globals.kbbfile.globals.field_117Fh.ToString(); break;

                        default: return;
                    }
                }

                else return;
            }
            else
            {
                if (fileindex < 50) { if (!Globals.photof_loaded_flags[fileindex - 1]) return; }
                else { if (!Globals.photof_loaded_flags[fileindex - 50]) return; }
                Globals.KbbPhoto file = fileindex < 50 ? Globals.photof[fileindex - 1] : Globals.photop[fileindex - 50];

                // marker field
                if (addr < 0x4) { v = file.marker.ToString(); h = file.marker.ToString("X4"); }

                // pixel data
                else if (addr < 0x8004)
                {
                    int p = file.pxdata[(addr - 4) >> 1];
                    v = p.ToString();
                    h = p.ToString("X4");
                    g.DrawString(s + v + String.Format(" (Hex: {0}h)", h), Font, b, x, y);

                    int R = (p >> 8) & 0xF8;
                    int G = (p >> 3) & 0xFC;
                    int B = (p & 0x1F) << 3;
                    g.DrawString(string.Format("Color: R:{0}, G:{1}, B:{2}", R, G, B), Font, b, x + 12.0f, y + 12.0f);

                    g.FillRectangle(new SolidBrush(Color.FromArgb(R, G, B)), x, y + 12.0f, 12.0f, 12.0f);
                    g.DrawRectangle(new Pen(Color.White), x, y + 12.0f, 12.0f, 12.0f);
                }

                // checksum
                else return; // unimplemented
            }

            if (h == "") g.DrawString(s + v, Font, b, x, y);
            else g.DrawString(s + v + String.Format(" (Hex: {0}h)", h), Font, b, x, y);
        }

        byte GetByte(int addr)
        {
            if (fileindex == 0) // Kbb.dat
            {
                if (addr >= 0x1590) return 0;

                // face slots
                if (addr < 0xC40)
                {
                    int slot = addr / 0x40;
                    int offs = addr % 0x40;

                    int o2 = offs & 0x3E;
                    int o4 = offs & 0x3C;
                    int o8 = offs & 0x38;

                    int s2 = (offs & 0b1) * 8;
                    int s4 = (offs & 0b11) * 8;
                    int s8 = (offs & 0b111) * 8;

                    Globals.FaceRecord face = Globals.kbbfile.face_records[slot];

                    if (o4 == 0) return (byte)(face.faceid >> s4);

                    if (o2 == 0x4) return (byte)(face.met_year >> s2);
                    if (offs == 0x6) return (byte)(face.met_month);
                    if (offs == 0x7) return (byte)(face.met_day);

                    if (o2 == 0x8) return (byte)(face.selections >> s2);
                    if (o2 == 0xA) return (byte)(face.field_0Ah >> s2);
                    if (o2 == 0xC) return (byte)(face.age >> s2);
                    if (o2 == 0xE) return (byte)(face.gender >> s2);

                    if (o4 == 0x10) return (byte)(BitConverter.SingleToInt32Bits(face.tx_move_x) >> s4);
                    if (o4 == 0x14) return (byte)(BitConverter.SingleToInt32Bits(face.tx_move_y) >> s4);
                    if (o4 == 0x18) return (byte)(BitConverter.SingleToInt32Bits(face.tx_stretch_x) >> s4);
                    if (o4 == 0x1C) return (byte)(BitConverter.SingleToInt32Bits(face.tx_stretch_y) >> s4);
                    if (o4 == 0x20) return (byte)(BitConverter.SingleToInt32Bits(face.tx_rot) >> s4);

                    if (o4 == 0x28) return (byte)(face.makernote.conhashunique >> s4);
                    if (o4 == 0x2C) return (byte)(face.makernote.field_04h >> s4);
                    if (o8 == 0x30) return (byte)(face.makernote.capturedate >> s8);
                    if (o4 == 0x38) return (byte)(face.makernote.src_facenum >> s4);
                    if (o4 == 0x3C) return (byte)(face.makernote.field_14h >> s4);

                    return 0;
                }

                // score records
                if (addr < 0xDF8)
                {
                    int slot = (addr - 0xC40) / 0x2C;
                    int offs = (addr - 0xC40) % 0x2C;

                    int o2 = offs & 0xFE;
                    int o4 = offs & 0xFC;

                    int s2 = (offs & 0b1) * 8;
                    int s4 = (offs & 0b11) * 8;

                    Globals.LvlScoreRecord record = Globals.kbbfile.stg_records[slot];

                    if (o4 == 0x00) return (byte)(record.r1_face >> s4);
                    if (o4 == 0x04) return (byte)(record.r1_score >> s4);
                    if (o4 == 0x08) return (byte)(record.r2_face >> s4);
                    if (o4 == 0x0C) return (byte)(record.r2_score >> s4);
                    if (o4 == 0x10) return (byte)(record.r3_face >> s4);
                    if (o4 == 0x14) return (byte)(record.r3_score >> s4);
                    if (o4 == 0x18) return (byte)(record.r4_face >> s4);
                    if (o4 == 0x1C) return (byte)(record.r4_score >> s4);
                    if (o4 == 0x20) return (byte)(record.r5_face >> s4);
                    if (o4 == 0x24) return (byte)(record.r5_score >> s4);
                    if (o2 == 0x28) return (byte)(record.maxcombo >> s2);
                    if (offs == 0x2A) return (byte)(record.beatstg ? 1 : 0);

                    return 0;
                }

                // ufo crew faces
                if (addr < 0xF88)
                {
                    int slot = (addr - 0xDF8) / 0x28;
                    int offs = (addr - 0xDF8) % 0x28;

                    int o2 = offs & 0xFE;
                    int o4 = offs & 0xFC;
                    int o8 = offs & 0xF8;

                    int s2 = (offs & 0b1) * 8;
                    int s4 = (offs & 0b11) * 8;
                    int s8 = (offs & 0b111) * 8;

                    Globals.UFORecord face = Globals.kbbfile.ufo_records[slot];

                    if (o4 == 0) return (byte)(face.faceid >> s4);

                    if (o4 == 0x08) return (byte)(face.makernote.conhashunique >> s4);
                    if (o4 == 0x0C) return (byte)(face.makernote.field_04h >> s4);
                    if (o8 == 0x10) return (byte)(face.makernote.capturedate >> s8);
                    if (o4 == 0x18) return (byte)(face.makernote.src_facenum >> s4);
                    if (o4 == 0x1C) return (byte)(face.makernote.field_14h >> s4);

                    if (o2 == 0x20) return (byte)(face.age >> s2);
                    if (o2 == 0x22) return (byte)(face.gender >> s2);

                    if (offs == 0x24) return (byte)(face.field_NEW ? 1 : 0);

                    return 0;
                }

                // deleted ufo crew faces
                if (addr < 0x10C8)
                {
                    int slot = (addr - 0xF88) / 0x20;
                    int offs = (addr - 0xF88) % 0x20;

                    int o2 = offs & 0xFE;
                    int o4 = offs & 0xFC;
                    int o8 = offs & 0xF8;

                    int s2 = (offs & 0b1) * 8;
                    int s4 = (offs & 0b11) * 8;
                    int s8 = (offs & 0b111) * 8;

                    Globals.UFODeletedRecord face = Globals.kbbfile.ufo_old_records[slot];

                    if (o4 == 0) return (byte)(face.faceid >> s4);

                    if (o4 == 0x08) return (byte)(face.makernote.conhashunique >> s4);
                    if (o4 == 0x0C) return (byte)(face.makernote.field_04h >> s4);
                    if (o8 == 0x10) return (byte)(face.makernote.capturedate >> s8);
                    if (o4 == 0x18) return (byte)(face.makernote.src_facenum >> s4);
                    if (o4 == 0x1C) return (byte)(face.makernote.field_14h >> s4);

                    return 0;
                }

                // globals
                if (addr < 0x1100)
                {
                    int o2 = addr & 0xFFFE;
                    int o4 = addr & 0xFFFC;
                    int o8 = addr & 0xFFF8;

                    int s2 = (addr & 0b1) * 8;
                    int s4 = (addr & 0b11) * 8;
                    int s8 = (addr & 0b111) * 8;

                    if (addr == 0x10C8) return (byte)(Globals.kbbfile.globals.ufo_active ? 1 : 0);
                    if (addr == 0x10C9) return Globals.kbbfile.globals.ufo_stg;
                    if (addr == 0x10CA) return Globals.kbbfile.globals.ufo_counter;

                    if (o4 == 0x10CC) return (byte)(Globals.kbbfile.globals.faceid_next >> s4);
                    if (o4 == 0x10D0) return (byte)(Globals.kbbfile.globals.ufo_faceid_next >> s4);
                    if (o4 == 0x10D4) return (byte)(Globals.kbbfile.globals.delufo_faceid_next >> s4);

                    if (o4 == 0x10D8) return (byte)(Globals.kbbfile.globals.field_10D8h >> s4);
                    if (o4 == 0x10DC) return (byte)(Globals.kbbfile.globals.field_10DCh >> s4);
                    if (o4 == 0x10E0) return (byte)(Globals.kbbfile.globals.field_10E0h >> s4);
                    if (o4 == 0x10E4) return (byte)(Globals.kbbfile.globals.field_10E4h >> s4);

                    if (o4 == 0x10E8) return (byte)(Globals.kbbfile.globals.friend_faces >> s4);
                    if (o4 == 0x10EC) return (byte)(Globals.kbbfile.globals.title_scenes_unlocked >> s4);
                    if (o4 == 0x10F0) return (byte)(Globals.kbbfile.globals.title_scenes_current >> s4);

                    if (o2 == 0x10F4) return (byte)(Globals.kbbfile.globals.field_10F4h >> s2);
                    if (o2 == 0x10F6) return (byte)(Globals.kbbfile.globals.field_10F6h >> s2);
                    if (o2 == 0x10F8) return (byte)(Globals.kbbfile.globals.field_10F8h >> s2);

                    if (addr == 0x10FA) return Globals.kbbfile.globals.camp_adv_counter;
                    if (addr == 0x10FB) return Globals.kbbfile.globals.saf_adv_counter;
                    if (addr == 0x10FC) return (byte)(Globals.kbbfile.globals.sneaky_snaps_en ? 1 : 0);
                    if (addr == 0x10FD) return (byte)(Globals.kbbfile.globals.field_10FDh ? 1 : 0);

                    return 0;
                }

                // game flags
                if (addr < 0x1180)
                {
                    switch (addr)
                    {
                        case 0x1100: return (byte)(Globals.kbbfile.globals.facecollection_unlock ? 1 : 0);
                        case 0x1101: return (byte)(Globals.kbbfile.globals.field_1101h ? 1 : 0);
                        case 0x1102: return (byte)(Globals.kbbfile.globals.field_1102h ? 1 : 0);

                        case 0x1103: return (byte)(Globals.kbbfile.globals.stg2_unlock ? 1 : 0);
                        case 0x1104: return (byte)(Globals.kbbfile.globals.field_1104h ? 1 : 0);
                        case 0x1105: return (byte)(Globals.kbbfile.globals.stg3_unlock ? 1 : 0);
                        case 0x1106: return (byte)(Globals.kbbfile.globals.stg4_unlock ? 1 : 0);
                        case 0x1107: return (byte)(Globals.kbbfile.globals.stgbonus_unlock ? 1 : 0);
                        case 0x1108: return (byte)(Globals.kbbfile.globals.stgextra_unlock ? 1 : 0);
                        case 0x1109: return (byte)(Globals.kbbfile.globals.saf_stg2_unlock ? 1 : 0);
                        case 0x110A: return (byte)(Globals.kbbfile.globals.saf_stgbonus_unlock ? 1 : 0);
                        case 0x110B: return (byte)(Globals.kbbfile.globals.saf_stg1_unlock ? 1 : 0);

                        case 0x110C: return (byte)(Globals.kbbfile.globals.field_110Ch ? 1 : 0);

                        case 0x110D: return (byte)(Globals.kbbfile.globals.facesel_stg1 ? 1 : 0);
                        case 0x110E: return (byte)(Globals.kbbfile.globals.facesel_stg2 ? 1 : 0);
                        case 0x110F: return (byte)(Globals.kbbfile.globals.facesel_stg3 ? 1 : 0);
                        case 0x1110: return (byte)(Globals.kbbfile.globals.facesel_stg4 ? 1 : 0);

                        case 0x1111: return (byte)(Globals.kbbfile.globals.field_1111h ? 1 : 0);
                        case 0x1112: return (byte)(Globals.kbbfile.globals.field_1112h ? 1 : 0);
                        case 0x1113: return (byte)(Globals.kbbfile.globals.field_1113h ? 1 : 0);
                        case 0x1114: return (byte)(Globals.kbbfile.globals.field_1114h ? 1 : 0);
                        case 0x1115: return (byte)(Globals.kbbfile.globals.field_1115h ? 1 : 0);
                        case 0x1116: return (byte)(Globals.kbbfile.globals.field_1116h ? 1 : 0);
                        case 0x1117: return (byte)(Globals.kbbfile.globals.field_1117h ? 1 : 0);
                        case 0x1118: return (byte)(Globals.kbbfile.globals.field_1118h ? 1 : 0);
                        case 0x1119: return (byte)(Globals.kbbfile.globals.field_1119h ? 1 : 0);
                        case 0x111A: return (byte)(Globals.kbbfile.globals.field_111Ah ? 1 : 0);
                        case 0x111B: return (byte)(Globals.kbbfile.globals.field_111Bh ? 1 : 0);
                        case 0x111C: return (byte)(Globals.kbbfile.globals.field_111Ch ? 1 : 0);
                        case 0x111D: return (byte)(Globals.kbbfile.globals.field_111Dh ? 1 : 0);
                        case 0x111E: return (byte)(Globals.kbbfile.globals.field_111Eh ? 1 : 0);
                        case 0x111F: return (byte)(Globals.kbbfile.globals.field_111Fh ? 1 : 0);

                        case 0x1120: return (byte)(Globals.kbbfile.globals.field_1120h ? 1 : 0);
                        case 0x1121: return (byte)(Globals.kbbfile.globals.field_1121h ? 1 : 0);
                        case 0x1122: return (byte)(Globals.kbbfile.globals.field_1122h ? 1 : 0);
                        case 0x1123: return (byte)(Globals.kbbfile.globals.field_1123h ? 1 : 0);
                        case 0x1124: return (byte)(Globals.kbbfile.globals.field_1124h ? 1 : 0);
                        case 0x1125: return (byte)(Globals.kbbfile.globals.field_1125h ? 1 : 0);
                        case 0x1126: return (byte)(Globals.kbbfile.globals.field_1126h ? 1 : 0);
                        case 0x1127: return (byte)(Globals.kbbfile.globals.field_1127h ? 1 : 0);
                        case 0x1128: return (byte)(Globals.kbbfile.globals.field_1128h ? 1 : 0);
                        case 0x1129: return (byte)(Globals.kbbfile.globals.field_1129h ? 1 : 0);
                        case 0x112A: return (byte)(Globals.kbbfile.globals.field_112Ah ? 1 : 0);

                        case 0x112B: return (byte)(Globals.kbbfile.globals.stg2_unlock_anim ? 1 : 0);
                        case 0x112C: return (byte)(Globals.kbbfile.globals.stg3_unlock_anim ? 1 : 0);
                        case 0x112D: return (byte)(Globals.kbbfile.globals.stg4_unlock_anim ? 1 : 0);
                        case 0x112E: return (byte)(Globals.kbbfile.globals.stgbonus_unlock_anim ? 1 : 0);
                        case 0x112F: return (byte)(Globals.kbbfile.globals.stgextra_unlock_anim ? 1 : 0);
                        case 0x1130: return (byte)(Globals.kbbfile.globals.saf_stg2_unlock_anim ? 1 : 0);
                        case 0x1131: return (byte)(Globals.kbbfile.globals.saf_stgbonus_unlock_anim ? 1 : 0);

                        case 0x1132: return (byte)(Globals.kbbfile.globals.ufo_landed ? 1 : 0);

                        case 0x1133: return (byte)(Globals.kbbfile.globals.field_1133h ? 1 : 0);

                        case 0x1134: return (byte)(Globals.kbbfile.globals.saf_stg1_unlock_anim ? 1 : 0);
                        case 0x1135: return (byte)(Globals.kbbfile.globals.crown_en ? 1 : 0);

                        case 0x1136: return (byte)(Globals.kbbfile.globals.field_1136h ? 1 : 0);
                        case 0x1137: return (byte)(Globals.kbbfile.globals.field_1137h ? 1 : 0);
                        case 0x1138: return (byte)(Globals.kbbfile.globals.field_1138h ? 1 : 0);
                        case 0x1139: return (byte)(Globals.kbbfile.globals.field_1139h ? 1 : 0);

                        case 0x113A: return (byte)(Globals.kbbfile.globals.slidebtn_unlock_anim ? 1 : 0);
                        case 0x113B: return (byte)(Globals.kbbfile.globals.field_113Bh ? 1 : 0);
                        case 0x113C: return (byte)(Globals.kbbfile.globals.stg1_unlock_anim ? 1 : 0);

                        case 0x113D: return (byte)(Globals.kbbfile.globals.field_113Dh ? 1 : 0);
                        case 0x113E: return (byte)(Globals.kbbfile.globals.field_113Eh ? 1 : 0);
                        case 0x113F: return (byte)(Globals.kbbfile.globals.field_113Fh ? 1 : 0);
                        case 0x1140: return (byte)(Globals.kbbfile.globals.field_1140h ? 1 : 0);
                        case 0x1141: return (byte)(Globals.kbbfile.globals.field_1141h ? 1 : 0);
                        case 0x1142: return (byte)(Globals.kbbfile.globals.field_1142h ? 1 : 0);
                        case 0x1143: return (byte)(Globals.kbbfile.globals.field_1143h ? 1 : 0);
                        case 0x1144: return (byte)(Globals.kbbfile.globals.field_1144h ? 1 : 0);
                        case 0x1145: return (byte)(Globals.kbbfile.globals.sneaky_snaps_introduced ? 1 : 0);
                        case 0x1146: return (byte)(Globals.kbbfile.globals.field_1146h ? 1 : 0);
                        case 0x1147: return (byte)(Globals.kbbfile.globals.sneaky_snaps_unlocked ? 1 : 0);
                        case 0x1148: return (byte)(Globals.kbbfile.globals.field_1148h ? 1 : 0);

                        case 0x1149: return (byte)(Globals.kbbfile.globals.field_1149h ? 1 : 0);
                        case 0x114A: return (byte)(Globals.kbbfile.globals.field_114Ah ? 1 : 0);
                        case 0x114B: return (byte)(Globals.kbbfile.globals.field_114Bh ? 1 : 0);
                        case 0x114C: return (byte)(Globals.kbbfile.globals.field_114Ch ? 1 : 0);
                        case 0x114D: return (byte)(Globals.kbbfile.globals.field_114Dh ? 1 : 0);
                        case 0x114E: return (byte)(Globals.kbbfile.globals.field_114Eh ? 1 : 0);
                        case 0x114F: return (byte)(Globals.kbbfile.globals.field_114Fh ? 1 : 0);

                        case 0x1150: return (byte)(Globals.kbbfile.globals.field_1150h ? 1 : 0);
                        case 0x1151: return (byte)(Globals.kbbfile.globals.field_1151h ? 1 : 0);
                        case 0x1152: return (byte)(Globals.kbbfile.globals.field_1152h ? 1 : 0);
                        case 0x1153: return (byte)(Globals.kbbfile.globals.field_1153h ? 1 : 0);
                        case 0x1154: return (byte)(Globals.kbbfile.globals.field_1154h ? 1 : 0);
                        case 0x1155: return (byte)(Globals.kbbfile.globals.field_1155h ? 1 : 0);
                        case 0x1156: return (byte)(Globals.kbbfile.globals.field_1156h ? 1 : 0);
                        case 0x1157: return (byte)(Globals.kbbfile.globals.field_1157h ? 1 : 0);
                        case 0x1158: return (byte)(Globals.kbbfile.globals.field_1158h ? 1 : 0);
                        case 0x1159: return (byte)(Globals.kbbfile.globals.field_1159h ? 1 : 0);
                        case 0x115A: return (byte)(Globals.kbbfile.globals.field_115Ah ? 1 : 0);
                        case 0x115B: return (byte)(Globals.kbbfile.globals.field_115Bh ? 1 : 0);
                        case 0x115C: return (byte)(Globals.kbbfile.globals.field_115Ch ? 1 : 0);
                        case 0x115D: return (byte)(Globals.kbbfile.globals.field_115Dh ? 1 : 0);
                        case 0x115E: return (byte)(Globals.kbbfile.globals.field_115Eh ? 1 : 0);
                        case 0x115F: return (byte)(Globals.kbbfile.globals.field_115Fh ? 1 : 0);

                        case 0x1160: return (byte)(Globals.kbbfile.globals.infomsg01 ? 1 : 0);
                        case 0x1161: return (byte)(Globals.kbbfile.globals.infomsg02 ? 1 : 0);
                        case 0x1162: return (byte)(Globals.kbbfile.globals.infomsg03 ? 1 : 0);
                        case 0x1163: return (byte)(Globals.kbbfile.globals.infomsg04 ? 1 : 0);
                        case 0x1164: return (byte)(Globals.kbbfile.globals.infomsg05 ? 1 : 0);
                        case 0x1165: return (byte)(Globals.kbbfile.globals.infomsg06 ? 1 : 0);
                        case 0x1166: return (byte)(Globals.kbbfile.globals.infomsg07 ? 1 : 0);
                        case 0x1167: return (byte)(Globals.kbbfile.globals.infomsg08 ? 1 : 0);
                        case 0x1168: return (byte)(Globals.kbbfile.globals.infomsg09 ? 1 : 0);
                        case 0x1169: return (byte)(Globals.kbbfile.globals.infomsg10 ? 1 : 0);
                        case 0x116A: return (byte)(Globals.kbbfile.globals.infomsg11 ? 1 : 0);
                        case 0x116B: return (byte)(Globals.kbbfile.globals.infomsg12 ? 1 : 0);
                        case 0x116C: return (byte)(Globals.kbbfile.globals.infomsg13 ? 1 : 0);
                        case 0x116D: return (byte)(Globals.kbbfile.globals.infomsg14 ? 1 : 0);
                        case 0x116E: return (byte)(Globals.kbbfile.globals.infomsg15 ? 1 : 0);
                        case 0x116F: return (byte)(Globals.kbbfile.globals.infomsg16 ? 1 : 0);
                        case 0x1170: return (byte)(Globals.kbbfile.globals.infomsg17 ? 1 : 0);
                        case 0x1171: return (byte)(Globals.kbbfile.globals.infomsg18 ? 1 : 0);
                        case 0x1172: return (byte)(Globals.kbbfile.globals.infomsg19 ? 1 : 0);
                        case 0x1173: return (byte)(Globals.kbbfile.globals.infomsg20 ? 1 : 0);
                        case 0x1174: return (byte)(Globals.kbbfile.globals.infomsg21 ? 1 : 0);
                        case 0x1175: return (byte)(Globals.kbbfile.globals.infomsg22 ? 1 : 0);
                        case 0x1176: return (byte)(Globals.kbbfile.globals.infomsg23 ? 1 : 0);
                        case 0x1177: return (byte)(Globals.kbbfile.globals.infomsg24 ? 1 : 0);
                        case 0x1178: return (byte)(Globals.kbbfile.globals.infomsg25 ? 1 : 0);
                        case 0x1179: return (byte)(Globals.kbbfile.globals.infomsg26 ? 1 : 0);
                        case 0x117A: return (byte)(Globals.kbbfile.globals.infomsg27 ? 1 : 0);
                        case 0x117B: return (byte)(Globals.kbbfile.globals.infomsg28 ? 1 : 0);

                        case 0x117C: return (byte)(Globals.kbbfile.globals.field_117Ch ? 1 : 0);
                        case 0x117D: return (byte)(Globals.kbbfile.globals.field_117Dh ? 1 : 0);
                        case 0x117E: return (byte)(Globals.kbbfile.globals.field_117Eh ? 1 : 0);
                        case 0x117F: return (byte)(Globals.kbbfile.globals.field_117Fh ? 1 : 0);

                        default: return 0;
                    }
                }

                if (addr >= 0x1580)
                {
                    int o4 = addr & 0xFFFC;
                    int s4 = (addr & 0b11) * 8;

                    if (o4 == 0x1580) return (byte)(0x26 >> s4);
                    if (o4 == 0x1588) return 0xFF; // unimplemented
                }
            }
            else // Photo___.dat
            {
                if (addr >= 0x8008) return 0;

                if (fileindex < 50) { if (!Globals.photof_loaded_flags[fileindex - 1]) return 0; }
                else { if (!Globals.photof_loaded_flags[fileindex - 50]) return 0; }
                Globals.KbbPhoto file = fileindex < 50 ? Globals.photof[fileindex - 1] : Globals.photop[fileindex - 50];

                // marker field
                if (addr < 0x4) return (byte)(file.marker >> (addr * 8));

                // pixel data
                if (addr < 0x8004) return (byte)(file.pxdata[(addr - 4) >> 1] >> ((addr & 1) * 8));

                // checksum
                if (addr < 0x8008) return 0xFF; // unimplemented
            }

            return 0;
        }

        short SetInt16(short value, int addr, byte newbyte)
        {
            addr &= 0b1;
            switch (addr)
            {
                case 0: return (short)((value & 0xFF00) + newbyte);
                case 1: return (short)((value & 0x00FF) + (newbyte << 8));
                default: return 0;
            }
        }
        ushort SetUInt16(ushort value, int addr, byte newbyte)
        {
            addr &= 0b1;
            switch (addr)
            {
                case 0: return (ushort)((value & 0xFF00) + newbyte);
                case 1: return (ushort)((value & 0x00FF) + (newbyte << 8));
                default: return 0;
            }
        }
        int SetInt32(int value, int addr, byte newbyte)
        {
            addr &= 0b11;
            switch (addr)
            {
                case 0: return (int)((value & 0xFFFFFF00) + newbyte);
                case 1: return (int)((value & 0xFFFF00FF) + (newbyte << 8));
                case 2: return (int)((value & 0xFF00FFFF) + (newbyte << 16));
                case 3: return (int)((value & 0x00FFFFFF) + (newbyte << 24));
                default: return 0;
            }
        }
        uint SetUInt32(uint value, int addr, byte newbyte)
        {
            addr &= 0b11;
            switch (addr)
            {
                case 0: return (uint)((value & 0xFFFFFF00) + newbyte);
                case 1: return (uint)((value & 0xFFFF00FF) + (newbyte << 8));
                case 2: return (uint)((value & 0xFF00FFFF) + (newbyte << 16));
                case 3: return (uint)((value & 0x00FFFFFF) + (newbyte << 24));
                default: return 0;
            }
        }
        long SetInt64(long value, int addr, byte newbyte)
        {
            addr &= 0b111;
            switch (addr)
            {
                case 0: return (long)(((ulong)value & 0xFFFFFFFFFFFFFF00) + (ulong)newbyte);
                case 1: return (long)(((ulong)value & 0xFFFFFFFFFFFF00FF) + ((ulong)newbyte << 8));
                case 2: return (long)(((ulong)value & 0xFFFFFFFFFF00FFFF) + ((ulong)newbyte << 16));
                case 3: return (long)(((ulong)value & 0xFFFFFFFF00FFFFFF) + ((ulong)newbyte << 24));
                case 4: return (long)(((ulong)value & 0xFFFFFF00FFFFFFFF) + ((ulong)newbyte << 32));
                case 5: return (long)(((ulong)value & 0xFFFF00FFFFFFFFFF) + ((ulong)newbyte << 40));
                case 6: return (long)(((ulong)value & 0xFF00FFFFFFFFFFFF) + ((ulong)newbyte << 48));
                case 7: return (long)(((ulong)value & 0x00FFFFFFFFFFFFFF) + ((ulong)newbyte << 56));
                default: return 0;
            }
        }
        ulong SetUInt64(ulong value, int addr, byte newbyte)
        {
            addr &= 0b111;
            switch (addr)
            {
                case 0: return (ulong)((value & 0xFFFFFFFFFFFFFF00) + (ulong)newbyte);
                case 1: return (ulong)((value & 0xFFFFFFFFFFFF00FF) + ((ulong)newbyte << 8));
                case 2: return (ulong)((value & 0xFFFFFFFFFF00FFFF) + ((ulong)newbyte << 16));
                case 3: return (ulong)((value & 0xFFFFFFFF00FFFFFF) + ((ulong)newbyte << 24));
                case 4: return (ulong)((value & 0xFFFFFF00FFFFFFFF) + ((ulong)newbyte << 32));
                case 5: return (ulong)((value & 0xFFFF00FFFFFFFFFF) + ((ulong)newbyte << 40));
                case 6: return (ulong)((value & 0xFF00FFFFFFFFFFFF) + ((ulong)newbyte << 48));
                case 7: return (ulong)((value & 0x00FFFFFFFFFFFFFF) + ((ulong)newbyte << 56));
                default: return 0;
            }
        }
        float SetFloat(float value, int addr, byte newbyte)
        {
            addr &= 0b11;
            int value2 = BitConverter.SingleToInt32Bits(value);
            switch (addr)
            {
                case 0: return BitConverter.Int32BitsToSingle((int)(value2 & 0xFFFFFF00) + newbyte);
                case 1: return BitConverter.Int32BitsToSingle((int)(value2 & 0xFFFF00FF) + (newbyte << 8));
                case 2: return BitConverter.Int32BitsToSingle((int)(value2 & 0xFF00FFFF) + (newbyte << 16));
                case 3: return BitConverter.Int32BitsToSingle((int)(value2 & 0x00FFFFFF) + (newbyte << 24));
                default: return 0;
            }
        }
        bool SetBool(byte newbyte)
        {
            return (newbyte & 1) == 1;
        }
        void SetByte(int addr, byte newbyte)
        {
            Globals.kbb_valid_flag = false;
            if (fileindex == 0) // Kbb.dat
            {
                if (addr >= 0x1590) return;

                // face slots
                if (addr < 0xC40)
                {
                    int slot = addr / 0x40;
                    int offs = addr % 0x40;

                    int o2 = offs & 0x3E;
                    int o4 = offs & 0x3C;
                    int o8 = offs & 0x38;

                    Globals.FaceRecord face = Globals.kbbfile.face_records[slot];

                    if (o4 == 0) { Globals.kbbfile.face_records[slot].faceid = SetInt32(face.faceid, addr, newbyte); return; }

                    if (o2 == 0x4) { Globals.kbbfile.face_records[slot].met_year = SetInt16(face.met_year, addr, newbyte); return; }
                    if (offs == 0x6) { Globals.kbbfile.face_records[slot].met_month = (sbyte)newbyte; return; }
                    if (offs == 0x7) { Globals.kbbfile.face_records[slot].met_day = (sbyte)newbyte; return; }

                    if (o2 == 0x8) { Globals.kbbfile.face_records[slot].selections = SetUInt16(face.selections, addr, newbyte); return; }
                    if (o2 == 0xA) { Globals.kbbfile.face_records[slot].field_0Ah = SetUInt16(face.field_0Ah, addr, newbyte); return; }
                    if (o2 == 0xC) { Globals.kbbfile.face_records[slot].age = SetInt16(face.age, addr, newbyte); return; }
                    if (o2 == 0xE) { Globals.kbbfile.face_records[slot].gender = SetInt16(face.gender, addr, newbyte); return; }

                    if (o4 == 0x10) { Globals.kbbfile.face_records[slot].tx_move_x = SetFloat(face.tx_move_x, addr, newbyte); return; }
                    if (o4 == 0x14) { Globals.kbbfile.face_records[slot].tx_move_y = SetFloat(face.tx_move_y, addr, newbyte); return; }
                    if (o4 == 0x18) { Globals.kbbfile.face_records[slot].tx_stretch_x = SetFloat(face.tx_stretch_x, addr, newbyte); return; }
                    if (o4 == 0x1C) { Globals.kbbfile.face_records[slot].tx_stretch_y = SetFloat(face.tx_stretch_y, addr, newbyte); return; }
                    if (o4 == 0x20) { Globals.kbbfile.face_records[slot].tx_rot = SetFloat(face.tx_rot, addr, newbyte); return; }

                    if (o4 == 0x28) { Globals.kbbfile.face_records[slot].makernote.conhashunique = SetUInt32(face.makernote.conhashunique, addr, newbyte); return; }
                    if (o4 == 0x2C) { Globals.kbbfile.face_records[slot].makernote.field_04h = SetUInt32(face.makernote.field_04h, addr, newbyte); return; }
                    if (o8 == 0x30) { Globals.kbbfile.face_records[slot].makernote.capturedate = SetInt64(face.makernote.capturedate, addr, newbyte); return; }
                    if (o4 == 0x38) { Globals.kbbfile.face_records[slot].makernote.src_facenum = SetUInt32(face.makernote.src_facenum, addr, newbyte); return; }
                    if (o4 == 0x3C) { Globals.kbbfile.face_records[slot].makernote.field_14h = SetUInt32(face.makernote.field_14h, addr, newbyte); return; }

                    return;
                }

                // score records
                if (addr < 0xDF8)
                {
                    int slot = (addr - 0xC40) / 0x2C;
                    int offs = (addr - 0xC40) % 0x2C;

                    int o2 = offs & 0xFE;
                    int o4 = offs & 0xFC;
                    int o8 = offs & 0xF8;

                    Globals.LvlScoreRecord record = Globals.kbbfile.stg_records[slot];

                    if (o4 == 0x00) { Globals.kbbfile.stg_records[slot].r1_face = SetInt32(record.r1_face, addr, newbyte); return; }
                    if (o4 == 0x04) { Globals.kbbfile.stg_records[slot].r1_score = SetUInt32(record.r1_score, addr, newbyte); return; }
                    if (o4 == 0x08) { Globals.kbbfile.stg_records[slot].r2_face = SetInt32(record.r2_face, addr, newbyte); return; }
                    if (o4 == 0x0C) { Globals.kbbfile.stg_records[slot].r2_score = SetUInt32(record.r2_score, addr, newbyte); return; }
                    if (o4 == 0x10) { Globals.kbbfile.stg_records[slot].r3_face = SetInt32(record.r3_face, addr, newbyte); return; }
                    if (o4 == 0x14) { Globals.kbbfile.stg_records[slot].r3_score = SetUInt32(record.r3_score, addr, newbyte); return; }
                    if (o4 == 0x18) { Globals.kbbfile.stg_records[slot].r4_face = SetInt32(record.r4_face, addr, newbyte); return; }
                    if (o4 == 0x1C) { Globals.kbbfile.stg_records[slot].r4_score = SetUInt32(record.r4_score, addr, newbyte); return; }
                    if (o4 == 0x20) { Globals.kbbfile.stg_records[slot].r5_face = SetInt32(record.r5_face, addr, newbyte); return; }
                    if (o4 == 0x24) { Globals.kbbfile.stg_records[slot].r5_score = SetUInt32(record.r5_score, addr, newbyte); return; }
                    if (o2 == 0x28) { Globals.kbbfile.stg_records[slot].maxcombo = SetUInt16(record.maxcombo, addr, newbyte); return; }
                    if (offs == 0x2A) { Globals.kbbfile.stg_records[slot].beatstg = SetBool(newbyte); return; }

                    return;
                }

                // ufo crew faces
                if (addr < 0xF88)
                {
                    int slot = (addr - 0xDF8) / 0x28;
                    int offs = (addr - 0xDF8) % 0x28;

                    int o2 = offs & 0xFE;
                    int o4 = offs & 0xFC;
                    int o8 = offs & 0xF8;

                    Globals.UFORecord face = Globals.kbbfile.ufo_records[slot];

                    if (o4 == 0) { Globals.kbbfile.ufo_records[slot].faceid = SetInt32(face.faceid, addr, newbyte); return; }

                    if (o4 == 0x08) { Globals.kbbfile.ufo_records[slot].makernote.conhashunique = SetUInt32(face.makernote.conhashunique, addr, newbyte); return; }
                    if (o4 == 0x0C) { Globals.kbbfile.ufo_records[slot].makernote.field_04h = SetUInt32(face.makernote.field_04h, addr, newbyte); return; }
                    if (o8 == 0x10) { Globals.kbbfile.ufo_records[slot].makernote.capturedate = SetInt64(face.makernote.capturedate, addr, newbyte); return; }
                    if (o4 == 0x18) { Globals.kbbfile.ufo_records[slot].makernote.src_facenum = SetUInt32(face.makernote.src_facenum, addr, newbyte); return; }
                    if (o4 == 0x1C) { Globals.kbbfile.ufo_records[slot].makernote.field_14h = SetUInt32(face.makernote.field_14h, addr, newbyte); return; }

                    if (o2 == 0x20) { Globals.kbbfile.ufo_records[slot].age = SetInt16(face.age, addr, newbyte); return; }
                    if (o2 == 0x22) { Globals.kbbfile.ufo_records[slot].gender = SetInt16(face.gender, addr, newbyte); return; }

                    if (offs == 0x24) { Globals.kbbfile.ufo_records[slot].field_NEW = SetBool(newbyte); return; }

                    return;
                }

                // deleted ufo crew faces
                if (addr < 0x10C8)
                {
                    int slot = (addr - 0xF88) / 0x20;
                    int offs = (addr - 0xF88) % 0x20;

                    int o2 = offs & 0xFE;
                    int o4 = offs & 0xFC;
                    int o8 = offs & 0xF8;

                    Globals.UFODeletedRecord face = Globals.kbbfile.ufo_old_records[slot];

                    if (o4 == 0) { Globals.kbbfile.ufo_old_records[slot].faceid = SetInt32(face.faceid, addr, newbyte); return; }

                    if (o4 == 0x08) { Globals.kbbfile.ufo_old_records[slot].makernote.conhashunique = SetUInt32(face.makernote.conhashunique, addr, newbyte); return; }
                    if (o4 == 0x0C) { Globals.kbbfile.ufo_old_records[slot].makernote.field_04h = SetUInt32(face.makernote.field_04h, addr, newbyte); return; }
                    if (o8 == 0x10) { Globals.kbbfile.ufo_old_records[slot].makernote.capturedate = SetInt64(face.makernote.capturedate, addr, newbyte); return; }
                    if (o4 == 0x18) { Globals.kbbfile.ufo_old_records[slot].makernote.src_facenum = SetUInt32(face.makernote.src_facenum, addr, newbyte); return; }
                    if (o4 == 0x1C) { Globals.kbbfile.ufo_old_records[slot].makernote.field_14h = SetUInt32(face.makernote.field_14h, addr, newbyte); return; }

                    return;
                }

                // globals
                if (addr < 0x1100)
                {
                    int o2 = addr & 0xFFFE;
                    int o4 = addr & 0xFFFC;
                    int o8 = addr & 0xFFF8;

                    if (addr == 0x10C8) { Globals.kbbfile.globals.ufo_active = SetBool(newbyte); return; }
                    if (addr == 0x10C9) { Globals.kbbfile.globals.ufo_stg = newbyte; return; }
                    if (addr == 0x10CA) { Globals.kbbfile.globals.ufo_counter = newbyte; return; }

                    if (o4 == 0x10CC) { Globals.kbbfile.globals.faceid_next = SetInt32(Globals.kbbfile.globals.faceid_next, addr, newbyte); return; }
                    if (o4 == 0x10D0) { Globals.kbbfile.globals.ufo_faceid_next = SetInt32(Globals.kbbfile.globals.ufo_faceid_next, addr, newbyte); return; }
                    if (o4 == 0x10D4) { Globals.kbbfile.globals.delufo_faceid_next = SetInt32(Globals.kbbfile.globals.delufo_faceid_next, addr, newbyte); return; }

                    if (o4 == 0x10D8) { Globals.kbbfile.globals.field_10D8h = SetUInt32(Globals.kbbfile.globals.field_10D8h, addr, newbyte); return; }
                    if (o4 == 0x10DC) { Globals.kbbfile.globals.field_10DCh = SetUInt32(Globals.kbbfile.globals.field_10DCh, addr, newbyte); return; }
                    if (o4 == 0x10E0) { Globals.kbbfile.globals.field_10E0h = SetUInt32(Globals.kbbfile.globals.field_10E0h, addr, newbyte); return; }
                    if (o4 == 0x10E4) { Globals.kbbfile.globals.field_10E4h = SetUInt32(Globals.kbbfile.globals.field_10E4h, addr, newbyte); return; }

                    if (o4 == 0x10E8) { Globals.kbbfile.globals.friend_faces = SetUInt32(Globals.kbbfile.globals.friend_faces, addr, newbyte); return; }
                    if (o4 == 0x10EC) { Globals.kbbfile.globals.title_scenes_unlocked = SetUInt32(Globals.kbbfile.globals.title_scenes_unlocked, addr, newbyte); return; }
                    if (o4 == 0x10F0) { Globals.kbbfile.globals.title_scenes_current = SetUInt32(Globals.kbbfile.globals.title_scenes_current, addr, newbyte); return; }

                    if (o2 == 0x10F4) { Globals.kbbfile.globals.field_10F4h = SetUInt16(Globals.kbbfile.globals.field_10F4h, addr, newbyte); return; }
                    if (o2 == 0x10F6) { Globals.kbbfile.globals.field_10F6h = SetUInt16(Globals.kbbfile.globals.field_10F6h, addr, newbyte); return; }
                    if (o2 == 0x10F8) { Globals.kbbfile.globals.field_10F8h = SetUInt16(Globals.kbbfile.globals.field_10F8h, addr, newbyte); return; }

                    if (addr == 0x10FA) { Globals.kbbfile.globals.camp_adv_counter = newbyte; return; }
                    if (addr == 0x10FB) { Globals.kbbfile.globals.saf_adv_counter = newbyte; return; }
                    if (addr == 0x10FC) { Globals.kbbfile.globals.sneaky_snaps_en = SetBool(newbyte); return; }
                    if (addr == 0x10FD) { Globals.kbbfile.globals.field_10FDh = SetBool(newbyte); return; }

                    return;
                }

                // game flags
                if (addr < 0x1180)
                {
                    bool b = SetBool(newbyte);
                    switch (addr)
                    {
                        case 0x1100: { Globals.kbbfile.globals.facecollection_unlock = b; return; }
                        case 0x1101: { Globals.kbbfile.globals.field_1101h = b; return; }
                        case 0x1102: { Globals.kbbfile.globals.field_1102h = b; return; }

                        case 0x1103: { Globals.kbbfile.globals.stg2_unlock = b; return; }
                        case 0x1104: { Globals.kbbfile.globals.field_1104h = b; return; }
                        case 0x1105: { Globals.kbbfile.globals.stg3_unlock = b; return; }
                        case 0x1106: { Globals.kbbfile.globals.stg4_unlock = b; return; }
                        case 0x1107: { Globals.kbbfile.globals.stgbonus_unlock = b; return; }
                        case 0x1108: { Globals.kbbfile.globals.stgextra_unlock = b; return; }
                        case 0x1109: { Globals.kbbfile.globals.saf_stg2_unlock = b; return; }
                        case 0x110A: { Globals.kbbfile.globals.saf_stgbonus_unlock = b; return; }
                        case 0x110B: { Globals.kbbfile.globals.saf_stg1_unlock = b; return; }

                        case 0x110C: { Globals.kbbfile.globals.field_110Ch = b; return; }

                        case 0x110D: { Globals.kbbfile.globals.facesel_stg1 = b; return; }
                        case 0x110E: { Globals.kbbfile.globals.facesel_stg2 = b; return; }
                        case 0x110F: { Globals.kbbfile.globals.facesel_stg3 = b; return; }
                        case 0x1110: { Globals.kbbfile.globals.facesel_stg4 = b; return; }

                        case 0x1111: { Globals.kbbfile.globals.field_1111h = b; return; }
                        case 0x1112: { Globals.kbbfile.globals.field_1112h = b; return; }
                        case 0x1113: { Globals.kbbfile.globals.field_1113h = b; return; }
                        case 0x1114: { Globals.kbbfile.globals.field_1114h = b; return; }
                        case 0x1115: { Globals.kbbfile.globals.field_1115h = b; return; }
                        case 0x1116: { Globals.kbbfile.globals.field_1116h = b; return; }
                        case 0x1117: { Globals.kbbfile.globals.field_1117h = b; return; }
                        case 0x1118: { Globals.kbbfile.globals.field_1118h = b; return; }
                        case 0x1119: { Globals.kbbfile.globals.field_1119h = b; return; }
                        case 0x111A: { Globals.kbbfile.globals.field_111Ah = b; return; }
                        case 0x111B: { Globals.kbbfile.globals.field_111Bh = b; return; }
                        case 0x111C: { Globals.kbbfile.globals.field_111Ch = b; return; }
                        case 0x111D: { Globals.kbbfile.globals.field_111Dh = b; return; }
                        case 0x111E: { Globals.kbbfile.globals.field_111Eh = b; return; }
                        case 0x111F: { Globals.kbbfile.globals.field_111Fh = b; return; }

                        case 0x1120: { Globals.kbbfile.globals.field_1120h = b; return; }
                        case 0x1121: { Globals.kbbfile.globals.field_1121h = b; return; }
                        case 0x1122: { Globals.kbbfile.globals.field_1122h = b; return; }
                        case 0x1123: { Globals.kbbfile.globals.field_1123h = b; return; }
                        case 0x1124: { Globals.kbbfile.globals.field_1124h = b; return; }
                        case 0x1125: { Globals.kbbfile.globals.field_1125h = b; return; }
                        case 0x1126: { Globals.kbbfile.globals.field_1126h = b; return; }
                        case 0x1127: { Globals.kbbfile.globals.field_1127h = b; return; }
                        case 0x1128: { Globals.kbbfile.globals.field_1128h = b; return; }
                        case 0x1129: { Globals.kbbfile.globals.field_1129h = b; return; }
                        case 0x112A: { Globals.kbbfile.globals.field_112Ah = b; return; }

                        case 0x112B: { Globals.kbbfile.globals.stg2_unlock_anim = b; return; }
                        case 0x112C: { Globals.kbbfile.globals.stg3_unlock_anim = b; return; }
                        case 0x112D: { Globals.kbbfile.globals.stg4_unlock_anim = b; return; }
                        case 0x112E: { Globals.kbbfile.globals.stgbonus_unlock_anim = b; return; }
                        case 0x112F: { Globals.kbbfile.globals.stgextra_unlock_anim = b; return; }
                        case 0x1130: { Globals.kbbfile.globals.saf_stg2_unlock_anim = b; return; }
                        case 0x1131: { Globals.kbbfile.globals.saf_stgbonus_unlock_anim = b; return; }

                        case 0x1132: { Globals.kbbfile.globals.ufo_landed = b; return; }

                        case 0x1133: { Globals.kbbfile.globals.field_1133h = b; return; }

                        case 0x1134: { Globals.kbbfile.globals.saf_stg1_unlock_anim = b; return; }
                        case 0x1135: { Globals.kbbfile.globals.crown_en = b; return; }

                        case 0x1136: { Globals.kbbfile.globals.field_1136h = b; return; }
                        case 0x1137: { Globals.kbbfile.globals.field_1137h = b; return; }
                        case 0x1138: { Globals.kbbfile.globals.field_1138h = b; return; }
                        case 0x1139: { Globals.kbbfile.globals.field_1139h = b; return; }

                        case 0x113A: { Globals.kbbfile.globals.slidebtn_unlock_anim = b; return; }
                        case 0x113B: { Globals.kbbfile.globals.field_113Bh = b; return; }
                        case 0x113C: { Globals.kbbfile.globals.stg1_unlock_anim = b; return; }

                        case 0x113D: { Globals.kbbfile.globals.field_113Dh = b; return; }
                        case 0x113E: { Globals.kbbfile.globals.field_113Eh = b; return; }
                        case 0x113F: { Globals.kbbfile.globals.field_113Fh = b; return; }
                        case 0x1140: { Globals.kbbfile.globals.field_1140h = b; return; }
                        case 0x1141: { Globals.kbbfile.globals.field_1141h = b; return; }
                        case 0x1142: { Globals.kbbfile.globals.field_1142h = b; return; }
                        case 0x1143: { Globals.kbbfile.globals.field_1143h = b; return; }
                        case 0x1144: { Globals.kbbfile.globals.field_1144h = b; return; }
                        case 0x1145: { Globals.kbbfile.globals.sneaky_snaps_introduced = b; return; }
                        case 0x1146: { Globals.kbbfile.globals.field_1146h = b; return; }
                        case 0x1147: { Globals.kbbfile.globals.sneaky_snaps_unlocked = b; return; }
                        case 0x1148: { Globals.kbbfile.globals.field_1148h = b; return; }

                        case 0x1149: { Globals.kbbfile.globals.field_1149h = b; return; }
                        case 0x114A: { Globals.kbbfile.globals.field_114Ah = b; return; }
                        case 0x114B: { Globals.kbbfile.globals.field_114Bh = b; return; }
                        case 0x114C: { Globals.kbbfile.globals.field_114Ch = b; return; }
                        case 0x114D: { Globals.kbbfile.globals.field_114Dh = b; return; }
                        case 0x114E: { Globals.kbbfile.globals.field_114Eh = b; return; }
                        case 0x114F: { Globals.kbbfile.globals.field_114Fh = b; return; }

                        case 0x1150: { Globals.kbbfile.globals.field_1150h = b; return; }
                        case 0x1151: { Globals.kbbfile.globals.field_1151h = b; return; }
                        case 0x1152: { Globals.kbbfile.globals.field_1152h = b; return; }
                        case 0x1153: { Globals.kbbfile.globals.field_1153h = b; return; }
                        case 0x1154: { Globals.kbbfile.globals.field_1154h = b; return; }
                        case 0x1155: { Globals.kbbfile.globals.field_1155h = b; return; }
                        case 0x1156: { Globals.kbbfile.globals.field_1156h = b; return; }
                        case 0x1157: { Globals.kbbfile.globals.field_1157h = b; return; }
                        case 0x1158: { Globals.kbbfile.globals.field_1158h = b; return; }
                        case 0x1159: { Globals.kbbfile.globals.field_1159h = b; return; }
                        case 0x115A: { Globals.kbbfile.globals.field_115Ah = b; return; }
                        case 0x115B: { Globals.kbbfile.globals.field_115Bh = b; return; }
                        case 0x115C: { Globals.kbbfile.globals.field_115Ch = b; return; }
                        case 0x115D: { Globals.kbbfile.globals.field_115Dh = b; return; }
                        case 0x115E: { Globals.kbbfile.globals.field_115Eh = b; return; }
                        case 0x115F: { Globals.kbbfile.globals.field_115Fh = b; return; }

                        case 0x1160: { Globals.kbbfile.globals.infomsg01 = b; return; }
                        case 0x1161: { Globals.kbbfile.globals.infomsg02 = b; return; }
                        case 0x1162: { Globals.kbbfile.globals.infomsg03 = b; return; }
                        case 0x1163: { Globals.kbbfile.globals.infomsg04 = b; return; }
                        case 0x1164: { Globals.kbbfile.globals.infomsg05 = b; return; }
                        case 0x1165: { Globals.kbbfile.globals.infomsg06 = b; return; }
                        case 0x1166: { Globals.kbbfile.globals.infomsg07 = b; return; }
                        case 0x1167: { Globals.kbbfile.globals.infomsg08 = b; return; }
                        case 0x1168: { Globals.kbbfile.globals.infomsg09 = b; return; }
                        case 0x1169: { Globals.kbbfile.globals.infomsg10 = b; return; }
                        case 0x116A: { Globals.kbbfile.globals.infomsg11 = b; return; }
                        case 0x116B: { Globals.kbbfile.globals.infomsg12 = b; return; }
                        case 0x116C: { Globals.kbbfile.globals.infomsg13 = b; return; }
                        case 0x116D: { Globals.kbbfile.globals.infomsg14 = b; return; }
                        case 0x116E: { Globals.kbbfile.globals.infomsg15 = b; return; }
                        case 0x116F: { Globals.kbbfile.globals.infomsg16 = b; return; }
                        case 0x1170: { Globals.kbbfile.globals.infomsg17 = b; return; }
                        case 0x1171: { Globals.kbbfile.globals.infomsg18 = b; return; }
                        case 0x1172: { Globals.kbbfile.globals.infomsg19 = b; return; }
                        case 0x1173: { Globals.kbbfile.globals.infomsg20 = b; return; }
                        case 0x1174: { Globals.kbbfile.globals.infomsg21 = b; return; }
                        case 0x1175: { Globals.kbbfile.globals.infomsg22 = b; return; }
                        case 0x1176: { Globals.kbbfile.globals.infomsg23 = b; return; }
                        case 0x1177: { Globals.kbbfile.globals.infomsg24 = b; return; }
                        case 0x1178: { Globals.kbbfile.globals.infomsg25 = b; return; }
                        case 0x1179: { Globals.kbbfile.globals.infomsg26 = b; return; }
                        case 0x117A: { Globals.kbbfile.globals.infomsg27 = b; return; }
                        case 0x117B: { Globals.kbbfile.globals.infomsg28 = b; return; }

                        case 0x117C: { Globals.kbbfile.globals.field_117Ch = b; return; }
                        case 0x117D: { Globals.kbbfile.globals.field_117Dh = b; return; }
                        case 0x117E: { Globals.kbbfile.globals.field_117Eh = b; return; }
                        case 0x117F: { Globals.kbbfile.globals.field_117Fh = b; return; }

                        default: return;
                    }
                }
            }
            else // Photo___.dat
            {
                if (addr >= 0x8008) return;

                if (fileindex < 50) { if (!Globals.photof_loaded_flags[fileindex - 1]) return; }
                else { if (!Globals.photof_loaded_flags[fileindex - 50]) return; }
                Globals.KbbPhoto file = fileindex < 50 ? Globals.photof[fileindex - 1] : Globals.photop[fileindex - 50];

                // marker field
                if (addr < 0x4)
                {
                    if (fileindex < 50)
                    {
                        Globals.photof[fileindex - 1].marker = SetUInt32(file.marker, addr, newbyte);
                    }
                    else
                    {
                        Globals.photop[fileindex - 50].marker = SetUInt32(file.marker, addr, newbyte);
                    }
                    return;
                }

                // pixel data
                if (addr < 0x8004)
                {
                    int addr2 = addr - 4;
                    int addr3 = addr2 >> 1;
                    ushort b = file.pxdata[addr3];
                    file.pxdata[addr3] = SetUInt16(b, addr2, newbyte);

                    if (fileindex < 50)
                    {
                        Globals.ConvertOnePhotoF(fileindex-1);
                    }
                    else
                    {
                        Globals.ConvertOnePhotoP(fileindex - 50);
                    }
                    
                    return;
                }
            }
        }

        void FixCursorBounds()
        {
            int w = PB_Draw.Width;
            int h = PB_Draw.Height;

            int lc = (int)((h - 8.0f) / 16.0f); // line count
            int filesize = fileindex == 0 ? 0x1590 : 0x8008;

            int lineoffsmin = (vscroll) << 4;
            int lineoffsmax = (vscroll + lc) << 4;

            if (sel_addr < lineoffsmin) vscroll = Math.Max(0, sel_addr >> 4);
            if (sel_addr >= lineoffsmax) vscroll = Math.Min((sel_addr >> 4) - lc + 1, vscrollmax);
        }

        void DrawLabels(Graphics g)
        {
            Brush b = new SolidBrush(Color.White);
            g.DrawString(GetRegionName(sel_addr), Font, b, 500.0f, 8.0f);
            g.DrawString(GetFieldName(sel_addr), Font, b, 500.0f, 20.0f);
            PrintValue(g,b,sel_addr,500.0f,32.0f);

            if (fileindex != 0)
            {
                if (fileindex < 50) { if (!Globals.photof_loaded_flags[fileindex - 1]) return; }
                else { if (!Globals.photof_loaded_flags[fileindex - 50]) return; }
                Globals.KbbPhoto file = fileindex < 50 ? Globals.photof[fileindex - 1] : Globals.photop[fileindex - 50];

                Bitmap img = Globals.DecodeTX(file.pxdata);
                g.DrawImage(img, 500, 64);

                img.Dispose();
            }
        }

        private void Draw()
        {
            if (fileindex == -1) return;

            int w = PB_Draw.Width;
            int h = PB_Draw.Height;

            Bitmap bb = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(bb);

            g.Clear(Color.Black);

            SolidBrush b1 = new SolidBrush(Color.DarkTurquoise);
            SolidBrush b2 = new SolidBrush(Color.Teal);
            SolidBrush b3 = new SolidBrush(Color.FromArgb(80, 170, 120));
            SolidBrush b4 = new SolidBrush(Color.FromArgb(50, 100, 68));

            SolidBrush bs = new SolidBrush(Color.Red);
            Font fnt = new Font(Font.FontFamily, 12.0f, FontStyle.Bold);

            int lc = (int)((h - 8.0f) / 16.0f); // line count
            int filesize = fileindex == 0 ? 0x1590 : 0x8008;
            for (int i = 0; i <= lc; i++)
            {
                int lineoffs = (vscroll + i) << 4;
                int bc = Math.Max(0, Math.Min(16, filesize - lineoffs));
                if (bc == 0) break;

                g.DrawString(lineoffs.ToString("X4"), fnt, (lineoffs & 0x10) == 0 ? b1 : b3, 4.0f, 4.0f + 16.0f * (float)i);

                for (int j = 0; j < bc; j++)
                {
                    int addr = lineoffs | j;
                    byte v = GetByte(addr);
                    SolidBrush b = (addr & 0x10) == 0 ? ((addr & 0x1) == 0 ? b1 : b2) : ((addr & 0x1) == 0 ? b3 : b4);

                    if (sel_addr == addr)
                    {
                        if (highnybble)
                        {
                            g.DrawString(((v & 0xF0) >> 4).ToString("X1"), fnt, bs, 80.0f + 24.0f * (float)j, 4.0f + 16.0f * (float)i);
                            g.DrawString(" " + (v & 0x0F).ToString("X1"), fnt, b, 80.0f + 24.0f * (float)j, 4.0f + 16.0f * (float)i);
                        }
                        else
                        {
                            g.DrawString(((v & 0xF0) >> 4).ToString("X1"), fnt, b, 80.0f + 24.0f * (float)j, 4.0f + 16.0f * (float)i);
                            g.DrawString(" " + (v & 0x0F).ToString("X1"), fnt, bs, 80.0f + 24.0f * (float)j, 4.0f + 16.0f * (float)i);
                        }
                    }
                    else
                    {
                        g.DrawString(v.ToString("X2"), fnt, b, 80.0f + 24.0f * (float)j, 4.0f + 16.0f * (float)i);
                    }
                }
            }

            DrawLabels(g);

            PB_Draw.Image?.Dispose();
            PB_Draw.Image = bb;

            g.Dispose();
        }

        private void CB_FileSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            fileindex = CB_FileSelect.SelectedIndex;
            vscroll = 0;
            sel_addr = -1;
            highnybble = true;
            if (fileindex == 0)
            {
                vscrollmax = 344;
            }
            else
            {
                vscrollmax = 2048;
            }
            Draw();
        }

        private void HexEditor_SizeChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void PB_Draw_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.X >= 80) && (e.X < 464) && (e.Y > 4))
            {
                int X = (e.X - 80) / 24;
                int Y = (e.Y - 4) / 16;
                int V = Math.Min(vscrollmax * 16, (Y * 16) + (vscroll * 16));
                sel_addr = Math.Min(fileindex == 0 ? 0x158F : 0x8007, X + V);
                highnybble = true;
                FixCursorBounds();
            }
            Draw();
        }

        private void HexEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            char kc = e.KeyChar;
            byte v;
            switch (kc)
            {
                case '0': v = 0; break;
                case '1': v = 1; break;
                case '2': v = 2; break;
                case '3': v = 3; break;
                case '4': v = 4; break;
                case '5': v = 5; break;
                case '6': v = 6; break;
                case '7': v = 7; break;
                case '8': v = 8; break;
                case '9': v = 9; break;
                case 'A': case 'a': v = 0xA; break;
                case 'B': case 'b': v = 0xB; break;
                case 'C': case 'c': v = 0xC; break;
                case 'D': case 'd': v = 0xD; break;
                case 'E': case 'e': v = 0xE; break;
                case 'F': case 'f': v = 0xF; break;
                default: return;
            }
            if ((fileindex != -1) && (sel_addr != -1))
            {
                byte b = GetByte(sel_addr);
                if (highnybble)
                {
                    b = (byte)((b & 0x0F) | (v << 4));
                    SetByte(sel_addr, b);
                    highnybble = false;
                }
                else
                {
                    b = (byte)((b & 0xF0) | v);
                    SetByte(sel_addr, b);
                    highnybble = true;
                    sel_addr = Math.Min(fileindex == 0 ? 0x158F : 0x8007, sel_addr + 1);
                }
            }
            FixCursorBounds();
            Draw();
        }

        private bool IsKeyDown(Keys key) { return (GetAsyncKeyState((int)key) & 0x8000) != 0; }

        private void PB_Draw_MouseWheel(object sender, MouseEventArgs e)
        {
            int move = e.Delta / -40;
            if (IsKeyDown(Keys.ShiftKey)) move *= (fileindex == 0 ? 0x8 : 0x10);
            vscroll = Math.Min(vscrollmax, Math.Max(0, vscroll + move));
            Draw();
        }
    }
}
