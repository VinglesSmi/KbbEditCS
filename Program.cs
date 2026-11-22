using KbbEditCS.Properties;
using Microsoft.VisualBasic;
using System.Globalization;
using FileSystem = Microsoft.VisualBasic.FileIO.FileSystem;

namespace KbbEditCS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            Application.Run(new Form1());
        }
    }

    public static class Globals
    {
        public static bool file_loaded = false;
        public static bool kbb_valid_flag = true;
        public static bool[] photof_loaded_flags = new bool[49];
        public static bool[] photop_loaded_flags = new bool[10];

        public static KbbFile kbbfile;
        public static KbbPhoto[] photof = new KbbPhoto[49];
        public static KbbPhoto[] photop = new KbbPhoto[10];

        public static Bitmap[] img_photof = new Bitmap[49];
        public static Bitmap[] img_photop = new Bitmap[10];

        public static int[] ordered_faces = new int[49];
        public static int[] ordered_ufo_faces = new int[10];

        public struct KbbFile
        {
            public FaceRecord[]       face_records;    // 0000h (49 entries, total size: C40h (3,136) bytes)
            public LvlScoreRecord[]   stg_records;     // 0C40h (10 entries, total size: 1B8h (440) bytes)
            public UFORecord[]        ufo_records;     // 0DF8h (10 entries, total size: 190h (400) bytes)
            public UFODeletedRecord[] ufo_old_records; // 0F88h (10 entries, total size: 140h (320) bytes)
            public KbbGlobals         globals;         // 10C8h
        }

        public struct FaceRecord // size: 40h (64 bytes)
        {
            public int    faceid;       // 00h
            public short  met_year;     // 04h
            public sbyte  met_month;    // 06h
            public sbyte  met_day;      // 07h
            public ushort selections;   // 08h
            public ushort field_0Ah;    // 0Ah
            public short  age;          // 0Ch
            public short  gender;       // 0Eh
            public float  tx_move_x;    // 10h
            public float  tx_move_y;    // 14h
            public float  tx_stretch_x; // 18h
            public float  tx_stretch_y; // 1Ch
            public float  tx_rot;       // 20h
            public MakerNote makernote; // 28h
        }

        public struct UFORecord // size: 28h (40 bytes)
        {
            public int       faceid;    // 00h
            public MakerNote makernote; // 08h
            public short     age;       // 20h
            public short     gender;    // 22h
            public bool      field_NEW; // 24h
        }

        public struct UFODeletedRecord // size: 20h (32 bytes)
        {
            public int       faceid;    // 00h
            public MakerNote makernote; // 08h
        }

        public struct KbbPhoto // size: 8008h (32,776 bytes)
        {
            public uint     marker; // 0000h
            public ushort[] pxdata; // 0004h
        }

        public struct MakerNote // size: 18h (24 bytes)
        {
            public uint conhashunique; // 00h (Lower word of Cfg:GenHashConsoleUnique)
            public uint field_04h;     // 04h
            public long capturedate;   // 08h (seconds since January 1st 2000)
            public uint src_facenum;   // 10h (identifier for face in source image)
            public uint field_14h;     // 14h
        }

        public struct LvlScoreRecord // size: 2Ch (44 bytes)
        {
            public int    r1_face;  // 00h
            public uint   r1_score; // 04h
            public int    r2_face;  // 08h
            public uint   r2_score; // 0Ch
            public int    r3_face;  // 10h
            public uint   r3_score; // 14h
            public int    r4_face;  // 18h
            public uint   r4_score; // 1Ch
            public int    r5_face;  // 20h
            public uint   r5_score; // 24h
            public ushort maxcombo; // 28h
            public bool   beatstg;  // 2Ah
        }

        public struct KbbGlobals
        {
            public bool ufo_active;  // 10C8h - whether UFOs are currently inside a stage
            public byte ufo_stg;     // 10C9h - stage where the UFOs will appear
            public byte ufo_counter; // 10CAh - counter before the UFOs disappear/reappear

            public int  faceid_next;        // 10CCh - next id to give to a face in Face Collection
            public int  ufo_faceid_next;    // 10D0h - next id to give to a face in UFO crew
            public int  delufo_faceid_next; // 10D4h - next id to give to a deleted UFO crew face

            public uint field_10D8h; // 10D8h
            public uint field_10DCh; // 10DCh
            public uint field_10E0h; // 10E0h
            public uint field_10E4h; // 10E4h

            public uint friend_faces;          // 10E8h - Faces collected in SAF
            public uint title_scenes_unlocked; // 10ECh - Cutscenes unlocked on title screen
            public uint title_scenes_current;  // 10F0h - Last viewed cutscene on title screen

            public ushort field_10F4h;      // 10F4h
            public ushort field_10F6h;      // 10F6h
            public ushort field_10F8h;      // 10F8h
            public byte   camp_adv_counter; // 10FAh
            public byte   saf_adv_counter;  // 10FBh
            public bool   sneaky_snaps_en;  // 10FCh - enable sneaky snaps
            public bool   field_10FDh;      // 10FDh

            public bool facecollection_unlock; // 1100h - unlocks the button to access Face Collection
            public bool field_1101h;           // 1101h
            public bool field_1102h;           // 1102h
            public bool stg2_unlock;           // 1103h - Stage 2 can be played
            public bool field_1104h;           // 1104h
            public bool stg3_unlock;           // 1105h - Stage 3 can be played
            public bool stg4_unlock;           // 1106h - Final Stage can be played
            public bool stgbonus_unlock;       // 1107h - Bonus Stage can be played
            public bool stgextra_unlock;       // 1108h - Extra Stage can be played

            public bool saf_stg2_unlock;     // 1109h - SAF Stage 2 can be played
            public bool saf_stgbonus_unlock; // 110Ah - SAF Bonus Stage can be played
            public bool saf_stg1_unlock;     // 110Bh - SAF Stage 1 can be played

            public bool field_110Ch;  // 110Ch

            public bool facesel_stg1; // 110Dh - Ability to choose which face to show in Stage 1.
            public bool facesel_stg2; // 110Eh - Ability to choose which face to show in Stage 2.
            public bool facesel_stg3; // 110Fh - Ability to choose which face to show in Stage 3.
            public bool facesel_stg4; // 1110h - Ability to choose which face to show in Stage 4.

            public bool field_1111h; // 1111h
            public bool field_1112h; // 1112h
            public bool field_1113h; // 1113h

            public bool field_1114h; // 1114h
            public bool field_1115h; // 1115h
            public bool field_1116h; // 1116h
            public bool field_1117h; // 1117h
            public bool field_1118h; // 1118h
            public bool field_1119h; // 1119h
            public bool field_111Ah; // 111Ah
            public bool field_111Bh; // 111Bh
            public bool field_111Ch; // 111Ch
            public bool field_111Dh; // 111Dh
            public bool field_111Eh; // 111Eh
            public bool field_111Fh; // 111Fh

            public bool field_1120h; // 1120h
            public bool field_1121h; // 1121h
            public bool field_1122h; // 1122h
            public bool field_1123h; // 1123h
            public bool field_1124h; // 1124h
            public bool field_1125h; // 1125h
            public bool field_1126h; // 1126h
            public bool field_1127h; // 1127h
            public bool field_1128h; // 1128h
            public bool field_1129h; // 1129h
            public bool field_112Ah; // 112Ah

            public bool stg2_unlock_anim;         // 112Bh - Cleared: shows unlocking anim for Stage 2
            public bool stg3_unlock_anim;         // 112Ch - Cleared: shows unlocking anim for Stage 3
            public bool stg4_unlock_anim;         // 112Dh - Cleared: shows unlocking anim for Final Stage
            public bool stgbonus_unlock_anim;     // 112Eh - Cleared: shows unlocking anim for Bonus Stage
            public bool stgextra_unlock_anim;     // 112Fh - Cleared: shows unlocking anim for Extra Stage
            public bool saf_stg2_unlock_anim;     // 1130h - Cleared: shows unlocking anim for SAF Stage 2
            public bool saf_stgbonus_unlock_anim; // 1131h - Cleared: shows unlocking anim for SAF Bonus Stage

            public bool ufo_landed;           // 1132h - Whether it's the first time you're seeing the UFO or not
            public bool field_1133h;          // 1133h
            public bool saf_stg1_unlock_anim; // 1134h - Cleared: shows unlocking anim for SAF Stage 1
            public bool crown_en;             // 1135h - Whether the most chosen face is shown with a crown in game
            public bool field_1136h;          // 1136h
            public bool field_1137h;          // 1137h
            public bool field_1138h;          // 1138h
            public bool field_1139h;          // 1139h
            public bool slidebtn_unlock_anim; // 113Ah - Cleared: shows slide button unlocking anim upon selecting a stage
            public bool field_113Bh;          // 113Bh
            public bool stg1_unlock_anim;     // 113Ch - Cleared: shows unlocking anim for Stage 1
            public bool field_113Dh;          // 113Dh
            public bool field_113Eh;          // 113Eh
            public bool field_113Fh;          // 113Fh

            public bool field_1140h; // 1140h
            public bool field_1141h; // 1141h
            public bool field_1142h; // 1142h
            public bool field_1143h; // 1143h
            public bool field_1144h; // 1144h
            public bool sneaky_snaps_introduced; // 1145h
            public bool field_1146h; // 1146h
            public bool sneaky_snaps_unlocked;   // 1147h
            public bool field_1148h; // 1148h
            public bool field_1149h; // 1149h
            public bool field_114Ah; // 114Ah
            public bool field_114Bh; // 114Bh
            public bool field_114Ch; // 114Ch
            public bool field_114Dh; // 114Dh
            public bool field_114Eh; // 114Eh
            public bool field_114Fh; // 114Fh

            public bool field_1150h; // 1150h
            public bool field_1151h; // 1151h
            public bool field_1152h; // 1152h
            public bool field_1153h; // 1153h
            public bool field_1154h; // 1154h
            public bool field_1155h; // 1155h
            public bool field_1156h; // 1156h
            public bool field_1157h; // 1157h
            public bool field_1158h; // 1158h
            public bool field_1159h; // 1159h
            public bool field_115Ah; // 115Ah
            public bool field_115Bh; // 115Bh
            public bool field_115Ch; // 115Ch
            public bool field_115Dh; // 115Dh
            public bool field_115Eh; // 115Eh
            public bool field_115Fh; // 115Fh
            
            // 1160h~117Bh : Advice tips seen

            public bool infomsg01; // 1160h - StgFace_Information_message01
            public bool infomsg02; // 1161h - StgFace_Information_message02
            public bool infomsg03; // 1162h - StgFace_Information_message03
            public bool infomsg04; // 1163h - StgFace_Information_message04
            public bool infomsg05; // 1164h - StgFace_Information_message05
            public bool infomsg06; // 1165h - StgFace_Information_message06
            public bool infomsg07; // 1166h - StgFace_Information_message07
            public bool infomsg08; // 1167h - StgFace_Information_message08
            public bool infomsg09; // 1168h - StgFace_Information_message09
            public bool infomsg10; // 1169h - StgFace_Information_message10
            public bool infomsg11; // 116Ah - StgFace_Information_message11
            public bool infomsg12; // 116Bh - StgFace_Information_message12
            public bool infomsg13; // 116Ch - StgFace_Information_message13
            public bool infomsg14; // 116Dh - StgFace_Information_message14
            public bool infomsg15; // 116Eh - StgFace_Information_message15
            public bool infomsg16; // 116Fh - StgFace_Information_message16
            public bool infomsg17; // 1170h - StgFace_Information_message17
            public bool infomsg18; // 1171h - StgFace_Information_message18
            public bool infomsg19; // 1172h - StgFace_Information_message19
            public bool infomsg20; // 1173h - StgFace_Information_message20
            public bool infomsg21; // 1174h - StgFace_Information_message21
            public bool infomsg22; // 1175h - StgFace_Information_message22
            public bool infomsg23; // 1176h - StgFace_Information_message23
            public bool infomsg24; // 1177h - StgFace_Information_message24
            public bool infomsg25; // 1178h - StgFace_Information_message25
            public bool infomsg26; // 1179h - StgFace_Information_message26
            public bool infomsg27; // 117Ah - StgFace_Information_message27
            public bool infomsg28; // 117Bh - StgFace_Information_message28

            public bool field_117Ch; // 117Ch
            public bool field_117Dh; // 117Dh
            public bool field_117Eh; // 117Eh
            public bool field_117Fh; // 117Fh
        }

        public static class Checksum
        {
            private static readonly uint[] table = new uint[256];

            static Checksum()
            {
                const uint polynomial = 0xEDB88320;

                for (uint i = 0; i < 256; i++)
                {
                    uint crc = i;

                    for (int j = 0; j < 8; j++)
                    {
                        if ((crc & 1) == 1) crc = (crc >> 1) ^ polynomial;
                        else crc >>= 1;
                    }
                    table[i] = crc;
                }
            }
            public static uint Run(byte[] data, int size)
            {
                uint crc = 0xFFFFFFFF;

                for (int i = 0; i < size; i++)
                {
                    byte index = (byte)(crc ^ data[i]);
                    crc = (crc >> 8) ^ table[index];
                }

                return crc ^ 0xFFFFFFFF;
            }
        }

        public static readonly int[] picapxorder = {
             0,  1,  8,  9,  2,  3, 10, 11,
            16, 17, 24, 25, 18, 19, 26, 27,
             4,  5, 12, 13,  6,  7, 14, 15,
            20, 21, 28, 29, 22, 23, 30, 31,
            32, 33, 40, 41, 34, 35, 42, 43,
            48, 49, 56, 57, 50, 51, 58, 59,
            36, 37, 44, 45, 38, 39, 46, 47,
            52, 53, 60, 61, 54, 55, 62, 63
        };

        // This turns the texture encoded for the PICA into a texture a computer can display
        public static Bitmap DecodeTX(ushort[] pxdata)
        {
            Bitmap decoded = new Bitmap(128, 128);

            /*
            
            The PICA-encoded textures have their pixels processed in a specific order
            such that textures are split into 8x8 cells.
            
            */

            int i = 0;
            for (int cy = 0; cy < 16; cy++)
            {
                for (int cx = 0; cx < 16; cx++)
                {
                    /*
                    
                    One cell has a specific order that looks like "Z" shapes:

                     0 -  1    2 -  3    4    5    6    7
                        /    /    /     /
                      /    /    /     /
                     8 -  9   10 - 11 | 12   13   14   15
                             ------/  |
                      -----/          |
                    16 - 17   18 - 19 | 20   21   22   23
                        /    /    /   |
                      /    /    /    /
                    24 - 25   26 - 27   28   29   30   31

                    This is called the "Z-order curve", or "Morton order"

                    */

                    for (int px = 0; px < 64; px++)
                    {
                        int x = picapxorder[px] % 8;
                        int y = (picapxorder[px] - x) >> 3;

                        ushort p = pxdata[i];

                        /*
                         
                        One pixel is a 16-bit value encoded like this:
                        RRRRRGGG GGGBBBBB - also known as RGB565

                        As such, we have to adjust the bit placement to ensure that
                        the white point is more or less the same

                        RRRRR... ........
                        |||||
                        --------------
                                 vvvvv
                                 RRRRR000

                        Bits get shifted to the right 8 places

                        .....GGG GGG.....
                             ||| |||
                             ----------
                                 vvvvvv
                                 GGGGGG00

                        Bits get shifted to the right 3 places

                        ........ ...BBBBB
                                    |||||
                                 --------
                                 vvvvv
                                 BBBBB000

                        Bits get shifted to the left 3 places

                        We'll also apply proper bitmasks to avoid
                        other color channels to spill into one

                        By doing this, we extracted all three channels of one pixel
                         
                        */
                        int r = (p >> 8) & 0xF8;
                        int g = (p >> 3) & 0xFC;
                        int b = (p & 0x1F) << 3;

                        decoded.SetPixel(cx * 8 + x, cy * 8 + y, Color.FromArgb(255, r, g, b));

                        i++;
                    }
                }
            }

            return decoded;
        }

        // This does exactly the process described in "DecodeTX" in reverse.
        public static ushort[] EncodeTX(Bitmap img)
        {
            ushort[] encoded = new ushort[0x4000];

            int i = 0;
            for (int cy = 0; cy < 16; cy++)
            {
                for (int cx = 0; cx < 16; cx++)
                {
                    for (int px = 0; px < 64; px++)
                    {
                        int x = picapxorder[px] % 8;
                        int y = (picapxorder[px] - x) >> 3;

                        ushort p = 0;

                        p += (ushort)((img.GetPixel(cx * 8 + x, cy * 8 + y).B & 0xF8) >> 3);
                        p += (ushort)((img.GetPixel(cx * 8 + x, cy * 8 + y).G & 0xFC) << 3);
                        p += (ushort)((img.GetPixel(cx * 8 + x, cy * 8 + y).R & 0xF8) << 8);

                        encoded[i] = p;

                        i++;
                    }
                }
            }

            return encoded;
        }

        // Find which Face record slot uses "faceid"
        public static int GetImgSlot(int faceid)
        {
            for (int i = 0; i < 49; i++)
            {
                if (kbbfile.face_records[i].faceid == faceid)
                {
                    return i;
                }
            }

            return -1;
        }

        // Find where in "ordered_faces" the "faceid" is
        public static int GetOrderedSlot(int faceid)
        {
            for (int i = 0; i < 49; i++)
            {
                if (ordered_faces[i] == faceid)
                {
                    return i;
                }
            }

            return -1;
        }

        // Find where in "ordered_ufo_faces" the "faceid" is
        public static int GetOrderedUFOCrewSlot(int faceid)
        {
            for (int i = 0; i < 10; i++)
            {
                if (ordered_ufo_faces[i] == faceid)
                {
                    return i;
                }
            }

            return -1;
        }

        // This is used in case a calculation goes horribly wrong
        // (This should never happen with legit save files)
        static PointF[] fallback_corners =
        {
            new PointF(0.0f,0.0f),
            new PointF(128.0f,0.0f),
            new PointF(0.0f,128.0f)
        };

        // Get corners representing the transform of a Face.
        public static PointF[] GetTransform(FaceRecord rec_face)
        {
            PointF[] corners = new PointF[3];

            // First step: apply scaling

            float cx = 64.0f; // Center X
            float cy = 64.0f; // Center Y

            corners[0] = new PointF(cx-(64.0f/rec_face.tx_stretch_x),cy-(64.0f/rec_face.tx_stretch_y));
            corners[1] = new PointF(cx+(64.0f/rec_face.tx_stretch_x),cy-(64.0f/rec_face.tx_stretch_y));
            corners[2] = new PointF(cx-(64.0f/rec_face.tx_stretch_x),cy+(64.0f/rec_face.tx_stretch_y));

            // Second step: apply rotation

            for (int i = 0; i < 3; i++)
            {
                float X = corners[i].X;
                corners[i].X = corners[i].X * MathF.Cos(-rec_face.tx_rot) + corners[i].Y * MathF.Sin(-rec_face.tx_rot);
                corners[i].Y = corners[i].Y * MathF.Cos(-rec_face.tx_rot) - X * MathF.Sin(-rec_face.tx_rot);
            }

            // Third step: apply translation

            float nx = corners[2].X + (corners[1].X - corners[2].X) / 2.0f; // New Center X
            float ny = corners[2].Y + (corners[1].Y - corners[2].Y) / 2.0f; // New Center Y

            for (int i = 0; i < 3; i++)
            {
                corners[i].X = corners[i].X + (cx - nx - (128.0f * rec_face.tx_move_x));
                corners[i].Y = corners[i].Y + (cy - ny - (128.0f * rec_face.tx_move_y));
            }

            // Ensure the calculation went correctly
            for (int i = 0; i < 3; i++)
            {
                bool valid = true;
                valid &= corners[i].X < 9999.9f;
                valid &= corners[i].Y < 9999.9f;
                valid &= corners[i].X > -9999.9f;
                valid &= corners[i].Y > -9999.9f;
                valid &= float.IsFinite(corners[i].X);
                valid &= float.IsFinite(corners[i].Y);

                if (!valid)
                {
                    Console.WriteLine(string.Format("Warning: Face with ID {0} has an invalid transform", rec_face.faceid));
                    return fallback_corners;
                }
            }

            return corners;
        }

        // Converts one "PhotoF__.dat" file to a bitmap image.
        public static void ConvertOnePhotoF(int slot)
        {
            if (photof_loaded_flags[slot])
            {
                Bitmap b = new Bitmap(128, 128);
                using (Graphics g = Graphics.FromImage(b)) {
                    g.Clear(Color.Black);

                    PointF[] corners = GetTransform(kbbfile.face_records[slot]);
                    Bitmap tx = DecodeTX(photof[slot].pxdata);
                    g.DrawImage(tx, corners);

                    // avoid memory leaks
                    tx.Dispose();
                    img_photof[slot]?.Dispose();
                    g.Dispose();
                }
                img_photof[slot] = b;
            }
        }

        // Converts all "PhotoF__.dat" files to a bitmap image.
        public static void ConvertAllPhotoF()
        {
            for (int i = 0; i < 49; i++)
            {
                if (photof_loaded_flags[i])
                {
                    Bitmap b = new Bitmap(128,128);
                    using (Graphics g = Graphics.FromImage(b))
                    {
                        g.Clear(Color.Black);

                        PointF[] corners = GetTransform(kbbfile.face_records[i]);
                        Bitmap tx = DecodeTX(photof[i].pxdata);
                        g.DrawImage(tx, corners);

                        // avoid memory leaks
                        tx.Dispose();
                        img_photof[i]?.Dispose();
                        g.Dispose();
                    }
                    img_photof[i] = b;
                }
            }
        }

        // Converts one "PhotoP__.dat" files to a bitmap image.
        public static void ConvertOnePhotoP(int slot)
        {
            if (photop_loaded_flags[slot])
            {
                img_photop[slot]?.Dispose();
                img_photop[slot] = DecodeTX(photop[slot].pxdata);
            }
        }

        // Converts all "PhotoP__.dat" files to a bitmap image.
        public static void ConvertAllPhotoP()
        {
            for (int i = 0; i < 10; i++)
            {
                if (photop_loaded_flags[i])
                {
                    img_photop[i]?.Dispose();
                    img_photop[i] = DecodeTX(photop[i].pxdata);
                }
            }
        }

        // Get the Face image for the corresponding ID.
        public static Bitmap GetFaceImg(int faceid)
        {
            int slot = GetImgSlot(faceid);
            if (slot != -1) return img_photof[slot];
            return Resources.UnknownFace;
        }

        // Get the UFO Crew Face image for the corresponding ID.
        public static Bitmap GetUFOCrewFaceImg(int faceid)
        {
            int slot = GetUFOImgSlot(faceid);
            if (slot != -1) return img_photop[slot];
            return Resources.UnknownFace;
        }

        // Get the thumbnail image for the UFO Crew.
        public static Bitmap GetUFOCrewThumb()
        {
            Bitmap UFOThumb = new Bitmap(128,128);
            using (Graphics g = Graphics.FromImage(UFOThumb)) {
                g.Clear(Color.Black);

                g.ScaleTransform(.59375f,.59375f);
                g.DrawImage(img_photop[GetUFOImgSlot(ordered_ufo_faces[0])],38,69);

                g.ResetTransform();
                g.DrawImage(Resources.FaceUFO,0,0);

                g.Dispose();
            }

            return UFOThumb;
        }

        // Find which UFO Crew Face record slot uses "faceid"
        public static int GetUFOImgSlot(int faceid)
        {
            for (int i = 0; i < 10; i++)
            {
                if (kbbfile.ufo_records[i].faceid == faceid)
                {
                    return i;
                }
            }

            return -1;
        }

        public static void SortFacesByID()
        {
            uint[] uintarray = new uint[49];
            for (int i = 0; i < 49; i++)
            {
                uintarray[i] = (uint)kbbfile.face_records[i].faceid;
            }

            Array.Sort(uintarray);

            for (int i = 0; i < 49; i++)
            {
                ordered_faces[i] = (int)uintarray[i];
            }
        }

        public static void SortUFOFacesByID()
        {
            uint[] uintarray = new uint[10];
            for (int i = 0; i < 10; i++)
            {
                uintarray[i] = (uint)kbbfile.ufo_records[i].faceid;
            }

            Array.Sort(uintarray);

            for (int i = 0; i < 10; i++)
            {
                ordered_ufo_faces[i] = (int)uintarray[i];
            }
        }

        public static int CountFaces()
        {
            int FaceCount = 0;

            for (int i = 0; i < 49; i++)
            {
                if (kbbfile.face_records[i].faceid != -1) FaceCount++;
            }

            return FaceCount;
        }

        public static int CountUFOFaces()
        {
            int FaceCount = 0;

            for (int i = 0; i < 10; i++)
            {
                if (kbbfile.face_records[i].faceid != -1) FaceCount++;
            }

            return FaceCount;
        }

        public static int FindFirstFreeFaceSlot()
        {
            for (int i = 0; i < 49; i++)
            {
                if (kbbfile.face_records[i].faceid == -1) return i;
            }

            return -1;
        }

        public static int FindFirstFreeUFOCrewSlot()
        {
            for (int i = 0; i < 10; i++)
            {
                if (kbbfile.ufo_records[i].faceid == -1) return i;
            }

            return -1;
        }

        public static int CountDeletedFaces()
        {
            int c = 0;
            for (int i = 0; i < 49; i++)
            {
                if ((kbbfile.face_records[i].faceid == -1) && photof_loaded_flags[i]) c++;
            }
            return c;
        }

        public static int CountDeletedUFOFaces()
        {
            int c = 0;
            for (int i = 0; i < 10; i++)
            {
                if ((kbbfile.ufo_records[i].faceid == -1) && photop_loaded_flags[i]) c++;
            }
            return c;
        }

        public static int AddNewFace(Bitmap img)
        {
            int slot = FindFirstFreeFaceSlot();

            // create record
            kbbfile.face_records[slot].faceid = kbbfile.globals.faceid_next++;

            // face encounter date
            DateTime now = DateTime.Now;
            kbbfile.face_records[slot].met_year = (short)now.Year;
            kbbfile.face_records[slot].met_month = (sbyte)now.Month;
            kbbfile.face_records[slot].met_day = (sbyte)now.Day;

            // how many times used in a level
            kbbfile.face_records[slot].selections = 0;

            // tbd
            kbbfile.face_records[slot].field_0Ah = 0;

            // face identity attributes
            kbbfile.face_records[slot].age = -1;
            kbbfile.face_records[slot].gender = -1;

            // face texture attributes
            kbbfile.face_records[slot].tx_move_x = 0.0f;
            kbbfile.face_records[slot].tx_move_y = 0.0f;
            kbbfile.face_records[slot].tx_stretch_x = 1.0f;
            kbbfile.face_records[slot].tx_stretch_y = 1.0f;
            kbbfile.face_records[slot].tx_rot = 0.0f;

            kbbfile.face_records[slot].makernote.conhashunique = 0;
            kbbfile.face_records[slot].makernote.field_04h   = 0;
            kbbfile.face_records[slot].makernote.capturedate = 0;
            kbbfile.face_records[slot].makernote.src_facenum = 0;
            kbbfile.face_records[slot].makernote.field_14h   = 0;

            // create image
            photof[slot].marker = 0;
            photof[slot].pxdata = EncodeTX(img);

            photof_loaded_flags[slot] = true;

            ConvertOnePhotoF(slot);

            // update a few things
            SortFacesByID();
            kbb_valid_flag = false;

            return GetOrderedSlot(kbbfile.face_records[slot].faceid);
        }

        public static int AddNewUFOFace(Bitmap img, long datecurrent)
        {
            int slot = FindFirstFreeUFOCrewSlot();

            // create record
            kbbfile.ufo_records[slot].faceid = kbbfile.globals.ufo_faceid_next++;

            kbbfile.ufo_records[slot].makernote.conhashunique = 0; // GetConHashID();
            kbbfile.ufo_records[slot].makernote.field_04h   = 0;
            kbbfile.ufo_records[slot].makernote.capturedate = datecurrent;
            kbbfile.ufo_records[slot].makernote.src_facenum = 0;
            kbbfile.ufo_records[slot].makernote.field_14h   = 1;

            kbbfile.ufo_records[slot].age = -1;
            kbbfile.ufo_records[slot].gender = -1;

            kbbfile.ufo_records[slot].field_NEW = true;

            // create image
            photop[slot].marker = 0;
            photop[slot].pxdata = EncodeTX(img);

            photop_loaded_flags[slot] = true;

            ConvertOnePhotoP(slot);

            // update a few things
            SortUFOFacesByID();
            kbb_valid_flag = false;

            return GetOrderedUFOCrewSlot(kbbfile.ufo_records[slot].faceid);
        }

        public static void DeleteFace(int faceid)
        {
            int slot = GetImgSlot(faceid);

            // delete record
            kbbfile.face_records[slot].faceid = -1;

            // face encounter date
            kbbfile.face_records[slot].met_year = 0;
            kbbfile.face_records[slot].met_month = 0;
            kbbfile.face_records[slot].met_day = 0;

            // how many times used in a level
            kbbfile.face_records[slot].selections = 0;

            // tbd
            kbbfile.face_records[slot].field_0Ah = 0;

            // face identity attributes
            kbbfile.face_records[slot].age = -1;
            kbbfile.face_records[slot].gender = -1;

            // face texture attributes
            kbbfile.face_records[slot].tx_move_x = 0.0f;
            kbbfile.face_records[slot].tx_move_y = 0.0f;
            kbbfile.face_records[slot].tx_stretch_x = 1.0f;
            kbbfile.face_records[slot].tx_stretch_y = 1.0f;
            kbbfile.face_records[slot].tx_rot = 0.0f;

            kbbfile.face_records[slot].makernote.conhashunique = 0;
            kbbfile.face_records[slot].makernote.field_04h   = 0;
            kbbfile.face_records[slot].makernote.capturedate = 0;
            kbbfile.face_records[slot].makernote.src_facenum = 0;
            kbbfile.face_records[slot].makernote.field_14h   = 0;

            // update a few things
            SortFacesByID();
            kbb_valid_flag = false;
        }

        public static void DeleteUFOCrewFace(int faceid)
        {
            int slot = GetUFOImgSlot(faceid);

            // Delete record
            kbbfile.ufo_records[slot].faceid = -1;

            kbbfile.ufo_records[slot].makernote.conhashunique = 0;
            kbbfile.ufo_records[slot].makernote.field_04h   = 0;
            kbbfile.ufo_records[slot].makernote.capturedate = 0;
            kbbfile.ufo_records[slot].makernote.src_facenum = 0;
            kbbfile.ufo_records[slot].makernote.field_14h   = 0;

            kbbfile.ufo_records[slot].age = -1;
            kbbfile.ufo_records[slot].gender = -1;

            // Show "NEW" bubble
            kbbfile.ufo_records[slot].field_NEW = true;

            // update a few things
            SortUFOFacesByID();
            kbb_valid_flag = false;
        }

        public static int RecoverFace(int imgslot)
        {
            // create record
            kbbfile.face_records[imgslot].faceid = kbbfile.globals.faceid_next++;

            // face encounter date
            DateTime now = DateTime.Now;
            kbbfile.face_records[imgslot].met_year = (short)now.Year;
            kbbfile.face_records[imgslot].met_month = (sbyte)now.Month;
            kbbfile.face_records[imgslot].met_day = (sbyte)now.Day;

            // how many times used in a level
            kbbfile.face_records[imgslot].selections = 0;

            // tbd
            kbbfile.face_records[imgslot].field_0Ah = 0;

            // face identity attributes
            kbbfile.face_records[imgslot].age = -1;
            kbbfile.face_records[imgslot].gender = -1;

            // face texture attributes
            kbbfile.face_records[imgslot].tx_move_x = 0.0f;
            kbbfile.face_records[imgslot].tx_move_y = 0.0f;
            kbbfile.face_records[imgslot].tx_stretch_x = 1.0f;
            kbbfile.face_records[imgslot].tx_stretch_y = 1.0f;
            kbbfile.face_records[imgslot].tx_rot = 0.0f;

            kbbfile.face_records[imgslot].makernote.conhashunique = 0;
            kbbfile.face_records[imgslot].makernote.field_04h   = 0;
            kbbfile.face_records[imgslot].makernote.capturedate = 0;
            kbbfile.face_records[imgslot].makernote.src_facenum = 0;
            kbbfile.face_records[imgslot].makernote.field_14h   = 0;

            photof[imgslot].marker = 0;
            ConvertOnePhotoF(imgslot);

            // update a few things
            SortFacesByID();
            kbb_valid_flag = false;

            return GetOrderedSlot(kbbfile.face_records[imgslot].faceid);
        }

        public static int RecoverUFOFace(int imgslot, long datecurrent)
        {
            // create record
            kbbfile.ufo_records[imgslot].faceid = kbbfile.globals.ufo_faceid_next++;

            kbbfile.ufo_records[imgslot].makernote.conhashunique = 0; // GetConHashID();
            kbbfile.ufo_records[imgslot].makernote.field_04h   = 0;
            kbbfile.ufo_records[imgslot].makernote.capturedate = datecurrent;
            kbbfile.ufo_records[imgslot].makernote.src_facenum = 0;
            kbbfile.ufo_records[imgslot].makernote.field_14h   = 1;

            kbbfile.ufo_records[imgslot].age = -1;
            kbbfile.ufo_records[imgslot].gender = -1;

            kbbfile.ufo_records[imgslot].field_NEW = false;

            photop[imgslot].marker = 0;
            ConvertOnePhotoP(imgslot);

            // update a few things
            SortUFOFacesByID();
            kbb_valid_flag = false;

            return GetOrderedUFOCrewSlot(kbbfile.ufo_records[imgslot].faceid);
        }

        public static uint GetConHashID()
        {
            for (int i = 0; i < 10; i++)
            {
                uint h = kbbfile.ufo_records[i].makernote.conhashunique;
                if (h != 0) return h;
            }
            return 1;
        }

        // Creates a new "Kbb.dat" file with everything initialized to default values.
        public static bool NewKbbFile(string path)
        {
            kbbfile = new KbbFile();

            // Init face records
            kbbfile.face_records = new FaceRecord[49];
            for (int i = 0; i < 49; i++)
            {
                // unique face identifier
                kbbfile.face_records[i].faceid = -1;

                // face encounter date
                kbbfile.face_records[i].met_year  = 0;
                kbbfile.face_records[i].met_month = 0;
                kbbfile.face_records[i].met_day   = 0;

                // how many times used in a level
                kbbfile.face_records[i].selections = 0;

                // tbd
                kbbfile.face_records[i].field_0Ah = 0;

                // face identity attributes
                kbbfile.face_records[i].age    = -1;
                kbbfile.face_records[i].gender = -1;

                // face texture attributes
                kbbfile.face_records[i].tx_move_x    = 0.0f;
                kbbfile.face_records[i].tx_move_y    = 0.0f;
                kbbfile.face_records[i].tx_stretch_x = 1.0f;
                kbbfile.face_records[i].tx_stretch_y = 1.0f;
                kbbfile.face_records[i].tx_rot       = 0.0f;

                kbbfile.face_records[i].makernote.conhashunique = 0;
                kbbfile.face_records[i].makernote.field_04h     = 0;
                kbbfile.face_records[i].makernote.capturedate   = 0;
                kbbfile.face_records[i].makernote.src_facenum   = 0;
                kbbfile.face_records[i].makernote.field_14h     = 0;
            }

            // Init stage records
            kbbfile.stg_records = new LvlScoreRecord[10];
            for (int i = 0; i < 10; i++)
            {
                kbbfile.stg_records[i].r1_face  = -1;
                kbbfile.stg_records[i].r1_score = 0;
                kbbfile.stg_records[i].r2_face  = -1;
                kbbfile.stg_records[i].r2_score = 0;
                kbbfile.stg_records[i].r3_face  = -1;
                kbbfile.stg_records[i].r3_score = 0;
                kbbfile.stg_records[i].r4_face  = -1;
                kbbfile.stg_records[i].r4_score = 0;
                kbbfile.stg_records[i].r5_face  = -1;
                kbbfile.stg_records[i].r5_score = 0;
                kbbfile.stg_records[i].maxcombo = 0;
                kbbfile.stg_records[i].beatstg  = false;
            }

            // Init UFO face records
            kbbfile.ufo_records = new UFORecord[10];
            for (int i = 0; i < 10; i++)
            {
                kbbfile.ufo_records[i].faceid = -1;

                kbbfile.ufo_records[i].makernote.conhashunique = 0;
                kbbfile.ufo_records[i].makernote.field_04h     = 0;
                kbbfile.ufo_records[i].makernote.capturedate   = 0;
                kbbfile.ufo_records[i].makernote.src_facenum   = 0;
                kbbfile.ufo_records[i].makernote.field_14h     = 0;

                kbbfile.ufo_records[i].age    = -1;
                kbbfile.ufo_records[i].gender = -1;

                // Show "NEW" bubble
                kbbfile.ufo_records[i].field_NEW = true;
            }

            // Init Deleted UFO face records
            kbbfile.ufo_old_records = new UFODeletedRecord[10];
            for (int i = 0; i < 10; i++)
            {
                kbbfile.ufo_old_records[i].faceid = -1;

                kbbfile.ufo_old_records[i].makernote.conhashunique = 0;
                kbbfile.ufo_old_records[i].makernote.field_04h     = 0;
                kbbfile.ufo_old_records[i].makernote.capturedate   = 0;
                kbbfile.ufo_old_records[i].makernote.src_facenum   = 0;
                kbbfile.ufo_old_records[i].makernote.field_14h     = 0;
            }

            // Init globals
            kbbfile.globals = new KbbGlobals
            {
                ufo_active  = true,
                ufo_stg     = 0,
                ufo_counter = 0,
                
                faceid_next        = 10,
                ufo_faceid_next    = 0,
                delufo_faceid_next = 0,

                field_10D8h = 0,
                field_10DCh = 0,
                field_10E0h = 0,
                field_10E4h = 0,

                friend_faces          = 0,
                title_scenes_unlocked = 0,
                title_scenes_current  = 0,

                camp_adv_counter = 0,
                saf_adv_counter = 0,
                sneaky_snaps_en = false,

                field_10F4h = 0,
                field_10F6h = 0,
                field_10F8h = 0,
                field_10FDh = false,

                facecollection_unlock = false,
                field_1101h           = false,
                field_1102h           = false,
                stg2_unlock           = false,
                field_1104h           = false,
                stg3_unlock           = false,
                stg4_unlock           = false,
                stgbonus_unlock       = false,
                stgextra_unlock       = false,

                saf_stg2_unlock     = false,
                saf_stgbonus_unlock = false,
                saf_stg1_unlock     = false,

                field_110Ch  = false,
                facesel_stg1 = false,
                facesel_stg2 = false,
                facesel_stg3 = false,
                facesel_stg4 = false,

                field_1111h = false,
                field_1112h = false,
                field_1113h = false,
                field_1114h = false,
                field_1115h = false,
                field_1116h = false,
                field_1117h = false,
                field_1118h = false,
                field_1119h = false,
                field_111Ah = false,
                field_111Bh = false,
                field_111Ch = false,
                field_111Dh = false,
                field_111Eh = false,
                field_111Fh = false,

                field_1120h = false,
                field_1121h = false,
                field_1122h = false,
                field_1123h = false,
                field_1124h = false,
                field_1125h = false,
                field_1126h = false,
                field_1127h = false,
                field_1128h = false,
                field_1129h = false,
                field_112Ah = false,

                stg2_unlock_anim         = false,
                stg3_unlock_anim         = false,
                stg4_unlock_anim         = false,
                stgbonus_unlock_anim     = false,
                stgextra_unlock_anim     = false,
                saf_stg2_unlock_anim     = false,
                saf_stgbonus_unlock_anim = false,

                ufo_landed = false,
                field_1133h = false,
                saf_stg1_unlock_anim = false,
                crown_en = false,
                field_1136h = false,
                field_1137h = false,
                field_1138h = false,
                field_1139h = false,
                slidebtn_unlock_anim = false,
                field_113Bh = false,
                stg1_unlock_anim = false,
                field_113Dh = false,
                field_113Eh = false,
                field_113Fh = false,

                field_1140h = false,
                field_1141h = false,
                field_1142h = false,
                field_1143h = false,
                field_1144h = false,
                sneaky_snaps_introduced = false,
                field_1146h = false,
                sneaky_snaps_unlocked = false,
                field_1148h = false,
                field_1149h = false,
                field_114Ah = false,
                field_114Bh = false,
                field_114Ch = false,
                field_114Dh = false,
                field_114Eh = false,
                field_114Fh = false,

                field_1150h = false,
                field_1151h = false,
                field_1152h = false,
                field_1153h = false,
                field_1154h = false,
                field_1155h = false,
                field_1156h = false,
                field_1157h = false,
                field_1158h = false,
                field_1159h = false,
                field_115Ah = false,
                field_115Bh = false,
                field_115Ch = false,
                field_115Dh = false,
                field_115Eh = false,
                field_115Fh = false,

                infomsg01 = false,
                infomsg02 = false,
                infomsg03 = false,
                infomsg04 = false,
                infomsg05 = false,
                infomsg06 = false,
                infomsg07 = false,
                infomsg08 = false,
                infomsg09 = false,
                infomsg10 = false,
                infomsg11 = false,
                infomsg12 = false,
                infomsg13 = false,
                infomsg14 = false,
                infomsg15 = false,
                infomsg16 = false,
                infomsg17 = false,
                infomsg18 = false,
                infomsg19 = false,
                infomsg20 = false,
                infomsg21 = false,
                infomsg22 = false,
                infomsg23 = false,
                infomsg24 = false,
                infomsg25 = false,
                infomsg26 = false,
                infomsg27 = false,
                infomsg28 = false,

                field_117Ch = false,
                field_117Dh = false,
                field_117Eh = false,
                field_117Fh = false,
            };

            // Init "PhotoF__.dat" files
            for (int i = 0; i < 49; i++) photof_loaded_flags[i] = false;

            // Init "PhotoP__.dat" files
            for (int i = 0; i < 10; i++) photop_loaded_flags[i] = false;

            file_loaded = true;

            SortFacesByID();
            SortUFOFacesByID();

            SaveKbb(path);

            return true;
        }

        // Loads "Kbb.dat", "PhotoF__.dat" and "PhotoP__.dat" files into memory.
        public static bool LoadKbb(string path)
        {
            byte[] data = FileSystem.ReadAllBytes(string.Concat(path, "Kbb.dat"));

            // Verify file size
            if (data.Length != 0x1590)
            {
                Interaction.MsgBox(string.Format("Kbb.dat: Incorrect file size: {0} bytes (Expected {1} bytes)",data.Length,0x1590),MsgBoxStyle.Critical,"Error!");
                return false;
            }
            // Verify "version" field
            uint fileversion = BitConverter.ToUInt32(data, 0x1580);
            if (fileversion != 0x26)
            {
                Interaction.MsgBox(string.Format("Kbb.dat: Incorrect file format version: {0} (Expected {1})",fileversion,0x26),MsgBoxStyle.Critical,"Error!");
                return false;
            }

            kbbfile = new KbbFile();

            // Load face records
            kbbfile.face_records = new FaceRecord[49];
            for (int i = 0; i < 49; i++)
            {
                int offs = i * 0x40; // calculate stride

                // unique face identifier
                kbbfile.face_records[i].faceid     = BitConverter.ToInt32(data, offs + 0x0);

                // face encounter date
                kbbfile.face_records[i].met_year   = BitConverter.ToInt16 (data, offs + 0x4);
                kbbfile.face_records[i].met_month  = (sbyte)data[offs + 0x6];
                kbbfile.face_records[i].met_day    = (sbyte)data[offs + 0x7];

                // how many times used in a level
                kbbfile.face_records[i].selections = BitConverter.ToUInt16(data, offs + 0x8);

                // tbd
                kbbfile.face_records[i].field_0Ah = BitConverter.ToUInt16(data, offs + 0xA);

                // face identity attributes
                kbbfile.face_records[i].age    = BitConverter.ToInt16(data, offs + 0xC);
                kbbfile.face_records[i].gender = BitConverter.ToInt16(data, offs + 0xE);

                // face texture attributes
                kbbfile.face_records[i].tx_move_x    = BitConverter.ToSingle(data, offs + 0x10);
                kbbfile.face_records[i].tx_move_y    = BitConverter.ToSingle(data, offs + 0x14);
                kbbfile.face_records[i].tx_stretch_x = BitConverter.ToSingle(data, offs + 0x18);
                kbbfile.face_records[i].tx_stretch_y = BitConverter.ToSingle(data, offs + 0x1C);
                kbbfile.face_records[i].tx_rot       = BitConverter.ToSingle(data, offs + 0x20);

                kbbfile.face_records[i].makernote.conhashunique = BitConverter.ToUInt32(data, offs + 0x28);
                kbbfile.face_records[i].makernote.field_04h     = BitConverter.ToUInt32(data, offs + 0x2C);
                kbbfile.face_records[i].makernote.capturedate   = BitConverter.ToInt64 (data, offs + 0x30);
                kbbfile.face_records[i].makernote.src_facenum   = BitConverter.ToUInt32(data, offs + 0x38);
                kbbfile.face_records[i].makernote.field_14h     = BitConverter.ToUInt32(data, offs + 0x3C);
            }

            // Load stage records
            kbbfile.stg_records = new LvlScoreRecord[10];
            for (int i = 0; i < 10; i++)
            {
                int offs = i * 0x2C + 0xC40; // calculate stride

                kbbfile.stg_records[i].r1_face  = BitConverter.ToInt32(data, offs + 0x0);
                kbbfile.stg_records[i].r1_score = BitConverter.ToUInt32(data, offs + 0x4);
                kbbfile.stg_records[i].r2_face  = BitConverter.ToInt32(data, offs + 0x8);
                kbbfile.stg_records[i].r2_score = BitConverter.ToUInt32(data, offs + 0xC);
                kbbfile.stg_records[i].r3_face  = BitConverter.ToInt32(data, offs + 0x10);
                kbbfile.stg_records[i].r3_score = BitConverter.ToUInt32(data, offs + 0x14);
                kbbfile.stg_records[i].r4_face  = BitConverter.ToInt32(data, offs + 0x18);
                kbbfile.stg_records[i].r4_score = BitConverter.ToUInt32(data, offs + 0x1C);
                kbbfile.stg_records[i].r5_face  = BitConverter.ToInt32(data, offs + 0x20);
                kbbfile.stg_records[i].r5_score = BitConverter.ToUInt32(data, offs + 0x24);
                kbbfile.stg_records[i].maxcombo = BitConverter.ToUInt16(data, offs + 0x28);
                kbbfile.stg_records[i].beatstg = data[offs + 0x2A] != 0;

                if (kbbfile.stg_records[i].r1_score > 999999)
                {
                    Console.WriteLine(string.Format("Kbb.dat: Impossible score in Stage no. {0}: {1} (Entry 1)", i, kbbfile.stg_records[i].r1_score));
                    kbbfile.stg_records[i].r1_score = 999999;
                }
                if (kbbfile.stg_records[i].r2_score > 999999)
                {
                    Console.WriteLine(string.Format("Kbb.dat: Impossible score in Stage no. {0}: {1} (Entry 2)", i, kbbfile.stg_records[i].r1_score));
                    kbbfile.stg_records[i].r2_score = 999999;
                }
                if (kbbfile.stg_records[i].r3_score > 999999)
                {
                    Console.WriteLine(string.Format("Kbb.dat: Impossible score in Stage no. {0}: {1} (Entry 3)", i, kbbfile.stg_records[i].r1_score));
                    kbbfile.stg_records[i].r3_score = 999999;
                }
                if (kbbfile.stg_records[i].r4_score > 999999)
                {
                    Console.WriteLine(string.Format("Kbb.dat: Impossible score in Stage no. {0}: {1} (Entry 4)", i, kbbfile.stg_records[i].r1_score));
                    kbbfile.stg_records[i].r4_score = 999999;
                }
                if (kbbfile.stg_records[i].r5_score > 999999)
                {
                    Console.WriteLine(string.Format("Kbb.dat: Impossible score in Stage no. {0}: {1} (Entry 5)", i, kbbfile.stg_records[i].r1_score));
                    kbbfile.stg_records[i].r5_score = 999999;
                }
                if (kbbfile.stg_records[i].maxcombo > 99)
                {
                    Console.WriteLine(string.Format("Kbb.dat: Impossible max combo in Stage no. {0}: {1}", i, kbbfile.stg_records[i].maxcombo));
                    kbbfile.stg_records[i].maxcombo = 99;
                }
            }

            // Load UFO face records
            kbbfile.ufo_records = new UFORecord[10];
            for (int i = 0; i < 10; i++)
            {
                int offs = i * 0x28 + 0xDF8; // calculate stride

                kbbfile.ufo_records[i].faceid = BitConverter.ToInt32(data, offs + 0x0);

                kbbfile.ufo_records[i].makernote.conhashunique = BitConverter.ToUInt32(data, offs + 0x08);
                kbbfile.ufo_records[i].makernote.field_04h     = BitConverter.ToUInt32(data, offs + 0x0C);
                kbbfile.ufo_records[i].makernote.capturedate   = BitConverter.ToInt64 (data, offs + 0x10);
                kbbfile.ufo_records[i].makernote.src_facenum   = BitConverter.ToUInt32(data, offs + 0x18);
                kbbfile.ufo_records[i].makernote.field_14h     = BitConverter.ToUInt32(data, offs + 0x1C);

                kbbfile.ufo_records[i].age    = BitConverter.ToInt16(data, offs + 0x20);
                kbbfile.ufo_records[i].gender = BitConverter.ToInt16(data, offs + 0x22);

                // Show "NEW" bubble
                kbbfile.ufo_records[i].field_NEW = data[offs + 0x24] != 0;
            }

            // Load Deleted UFO face records
            kbbfile.ufo_old_records = new UFODeletedRecord[10];
            for (int i = 0; i < 10; i++)
            {
                int offs = i * 0x20 + 0xF88; // calculate stride

                kbbfile.ufo_old_records[i].faceid = BitConverter.ToInt32(data, offs + 0x0);
                
                kbbfile.ufo_old_records[i].makernote.conhashunique = BitConverter.ToUInt32(data, offs + 0x08);
                kbbfile.ufo_old_records[i].makernote.field_04h     = BitConverter.ToUInt32(data, offs + 0x0C);
                kbbfile.ufo_old_records[i].makernote.capturedate   = BitConverter.ToInt64 (data, offs + 0x10);
                kbbfile.ufo_old_records[i].makernote.src_facenum   = BitConverter.ToUInt32(data, offs + 0x18);
                kbbfile.ufo_old_records[i].makernote.field_14h     = BitConverter.ToUInt32(data, offs + 0x1C);
            }

            // Load globals
            kbbfile.globals = new KbbGlobals
            {
                ufo_active  = data[0x10C8] != 0,
                ufo_stg     = data[0x10C9],
                ufo_counter = data[0x10CA],

                faceid_next        = BitConverter.ToInt32(data, 0x10CC),
                ufo_faceid_next    = BitConverter.ToInt32(data, 0x10D0),
                delufo_faceid_next = BitConverter.ToInt32(data, 0x10D4),

                field_10D8h = BitConverter.ToUInt32(data, 0x10D8),
                field_10DCh = BitConverter.ToUInt32(data, 0x10DC),
                field_10E0h = BitConverter.ToUInt32(data, 0x10E0),
                field_10E4h = BitConverter.ToUInt32(data, 0x10E4),

                friend_faces          = BitConverter.ToUInt32(data, 0x10E8),
                title_scenes_unlocked = BitConverter.ToUInt32(data, 0x10EC),
                title_scenes_current  = BitConverter.ToUInt32(data, 0x10F0),

                field_10F4h = BitConverter.ToUInt16(data, 0x10F4),
                field_10F6h = BitConverter.ToUInt16(data, 0x10F6),
                field_10F8h = BitConverter.ToUInt16(data, 0x10F8),
                camp_adv_counter = data[0x10FA],
                saf_adv_counter = data[0x10FB],
                sneaky_snaps_en = data[0x10FC] != 0,
                field_10FDh = data[0x10FD] != 0,

                facecollection_unlock = data[0x1100] != 0,
                field_1101h     = data[0x1101] != 0,
                field_1102h     = data[0x1102] != 0,
                stg2_unlock     = data[0x1103] != 0,
                field_1104h     = data[0x1104] != 0,
                stg3_unlock     = data[0x1105] != 0,
                stg4_unlock     = data[0x1106] != 0,
                stgbonus_unlock = data[0x1107] != 0,
                stgextra_unlock = data[0x1108] != 0,
                
                saf_stg2_unlock     = data[0x1109] != 0,
                saf_stgbonus_unlock = data[0x110A] != 0,
                saf_stg1_unlock     = data[0x110B] != 0,

                field_110Ch  = data[0x110C] != 0,
                facesel_stg1 = data[0x110D] != 0,
                facesel_stg2 = data[0x110E] != 0,
                facesel_stg3 = data[0x110F] != 0,
                facesel_stg4 = data[0x1110] != 0,

                field_1111h = data[0x1111] != 0,
                field_1112h = data[0x1112] != 0,
                field_1113h = data[0x1113] != 0,
                field_1114h = data[0x1114] != 0,
                field_1115h = data[0x1115] != 0,
                field_1116h = data[0x1116] != 0,
                field_1117h = data[0x1117] != 0,
                field_1118h = data[0x1118] != 0,
                field_1119h = data[0x1119] != 0,
                field_111Ah = data[0x111A] != 0,
                field_111Bh = data[0x111B] != 0,
                field_111Ch = data[0x111C] != 0,
                field_111Dh = data[0x111D] != 0,
                field_111Eh = data[0x111E] != 0,
                field_111Fh = data[0x111F] != 0,

                field_1120h = data[0x1120] != 0,
                field_1121h = data[0x1121] != 0,
                field_1122h = data[0x1122] != 0,
                field_1123h = data[0x1123] != 0,
                field_1124h = data[0x1124] != 0,
                field_1125h = data[0x1125] != 0,
                field_1126h = data[0x1126] != 0,
                field_1127h = data[0x1127] != 0,
                field_1128h = data[0x1128] != 0,
                field_1129h = data[0x1129] != 0,
                field_112Ah = data[0x112A] != 0,

                stg2_unlock_anim         = data[0x112B] != 0,
                stg3_unlock_anim         = data[0x112C] != 0,
                stg4_unlock_anim         = data[0x112D] != 0,
                stgbonus_unlock_anim     = data[0x112E] != 0,
                stgextra_unlock_anim     = data[0x112F] != 0,
                saf_stg2_unlock_anim     = data[0x1130] != 0,
                saf_stgbonus_unlock_anim = data[0x1131] != 0,

                ufo_landed           = data[0x1132] != 0,
                field_1133h          = data[0x1133] != 0,
                saf_stg1_unlock_anim = data[0x1134] != 0,
                crown_en             = data[0x1135] != 0,
                field_1136h          = data[0x1136] != 0,
                field_1137h          = data[0x1137] != 0,
                field_1138h          = data[0x1138] != 0,
                field_1139h          = data[0x1139] != 0,
                slidebtn_unlock_anim = data[0x113A] != 0,
                field_113Bh          = data[0x113B] != 0,
                stg1_unlock_anim     = data[0x113C] != 0,
                field_113Dh          = data[0x113D] != 0,
                field_113Eh          = data[0x113E] != 0,
                field_113Fh          = data[0x113F] != 0,

                field_1140h = data[0x1140] != 0,
                field_1141h = data[0x1141] != 0,
                field_1142h = data[0x1142] != 0,
                field_1143h = data[0x1143] != 0,
                field_1144h = data[0x1144] != 0,
                sneaky_snaps_introduced = data[0x1145] != 0,
                field_1146h = data[0x1146] != 0,
                sneaky_snaps_unlocked = data[0x1147] != 0,
                field_1148h = data[0x1148] != 0,
                field_1149h = data[0x1149] != 0,
                field_114Ah = data[0x114A] != 0,
                field_114Bh = data[0x114B] != 0,
                field_114Ch = data[0x114C] != 0,
                field_114Dh = data[0x114D] != 0,
                field_114Eh = data[0x114E] != 0,
                field_114Fh = data[0x114F] != 0,

                field_1150h = data[0x1150] != 0,
                field_1151h = data[0x1151] != 0,
                field_1152h = data[0x1152] != 0,
                field_1153h = data[0x1153] != 0,
                field_1154h = data[0x1154] != 0,
                field_1155h = data[0x1155] != 0,
                field_1156h = data[0x1156] != 0,
                field_1157h = data[0x1157] != 0,
                field_1158h = data[0x1158] != 0,
                field_1159h = data[0x1159] != 0,
                field_115Ah = data[0x115A] != 0,
                field_115Bh = data[0x115B] != 0,
                field_115Ch = data[0x115C] != 0,
                field_115Dh = data[0x115D] != 0,
                field_115Eh = data[0x115E] != 0,
                field_115Fh = data[0x115F] != 0,

                infomsg01 = data[0x1160] != 0,
                infomsg02 = data[0x1161] != 0,
                infomsg03 = data[0x1162] != 0,
                infomsg04 = data[0x1163] != 0,
                infomsg05 = data[0x1164] != 0,
                infomsg06 = data[0x1165] != 0,
                infomsg07 = data[0x1166] != 0,
                infomsg08 = data[0x1167] != 0,
                infomsg09 = data[0x1168] != 0,
                infomsg10 = data[0x1169] != 0,
                infomsg11 = data[0x116A] != 0,
                infomsg12 = data[0x116B] != 0,
                infomsg13 = data[0x116C] != 0,
                infomsg14 = data[0x116D] != 0,
                infomsg15 = data[0x116E] != 0,
                infomsg16 = data[0x116F] != 0,
                infomsg17 = data[0x1170] != 0,
                infomsg18 = data[0x1171] != 0,
                infomsg19 = data[0x1172] != 0,
                infomsg20 = data[0x1173] != 0,
                infomsg21 = data[0x1174] != 0,
                infomsg22 = data[0x1175] != 0,
                infomsg23 = data[0x1176] != 0,
                infomsg24 = data[0x1177] != 0,
                infomsg25 = data[0x1178] != 0,
                infomsg26 = data[0x1179] != 0,
                infomsg27 = data[0x117A] != 0,
                infomsg28 = data[0x117B] != 0,

                field_117Ch = data[0x117C] != 0,
                field_117Dh = data[0x117D] != 0,
                field_117Eh = data[0x117E] != 0,
                field_117Fh = data[0x117F] != 0,
            };

            // Verify checksum validity
            uint filecrc = BitConverter.ToUInt32(data, 0x1588);
            uint newcrc = Checksum.Run(data,0x1588);
            if (filecrc != newcrc)
            {
                Console.WriteLine(string.Format("Kbb.dat: Incorrect checksum: {0:X8}h (Expected {1:X8}h)", newcrc, filecrc));
            }

            // Load "PhotoF__.dat" files
            for (int i = 0; i < 49; i++)
            {
                string filename = string.Concat(path, string.Format("PhotoF{0:D2}.dat", i));
                if (FileSystem.FileExists(filename))
                {
                    data = FileSystem.ReadAllBytes(filename);
                    photof[i].marker = BitConverter.ToUInt32(data, 0);
                    photof[i].pxdata = new ushort[0x4000];
                    Buffer.BlockCopy(data, 4, photof[i].pxdata, 0, 0x8000);

                    filecrc = BitConverter.ToUInt32(data, 0x8004);
                    newcrc = Checksum.Run(data, 0x8004);
                    if (filecrc != newcrc)
                    {
                        Console.WriteLine(string.Format("PhotoF{0:D2}.dat: Incorrect checksum: {1:X8}h (Expected {2:X8}h)", i, newcrc, filecrc));
                    }

                    photof_loaded_flags[i] = true;
                }
                else photof_loaded_flags[i] = false;
            }

            // Load "PhotoP__.dat" files
            for (int i = 0; i < 10; i++)
            {
                string filename = string.Concat(path, string.Format("PhotoP{0:D2}.dat", i));
                if (FileSystem.FileExists(filename))
                {
                    data = FileSystem.ReadAllBytes(filename);
                    photop[i].marker = BitConverter.ToUInt32(data, 0);
                    photop[i].pxdata = new ushort[0x4000];
                    Buffer.BlockCopy(data, 4, photop[i].pxdata, 0, 0x8000);

                    filecrc = BitConverter.ToUInt32(data, 0x8004);
                    newcrc = Checksum.Run(data, 0x8004);
                    if (filecrc != newcrc)
                    {
                        Console.WriteLine(string.Format("PhotoP{0:D2}.dat: Incorrect checksum: {1:X8}h (Expected {2:X8}h)", i, newcrc, filecrc));
                    }

                    photop_loaded_flags[i] = true;
                }
                else photop_loaded_flags[i] = false;
            }

            // Convert all Photo textures into images that can be displayed by .NET core
            ConvertAllPhotoF();
            ConvertAllPhotoP();
            
            file_loaded = true;

            SortFacesByID();
            SortUFOFacesByID();

            return true;
        }

        static void WriteInt16(byte[] data, int offs, short value)
        {
            data[offs] = (byte)(value);
            data[offs + 1] = (byte)(value>>8);
        }
        static void WriteUInt16(byte[] data, int offs, ushort value)
        {
            data[offs] = (byte)(value);
            data[offs + 1] = (byte)(value >> 8);
        }
        static void WriteInt32(byte[] data, int offs, int value)
        {
            data[offs] = (byte)(value);
            data[offs + 1] = (byte)(value >> 8);
            data[offs + 2] = (byte)(value >> 16);
            data[offs + 3] = (byte)(value >> 24);
        }
        static void WriteUInt32(byte[] data, int offs, uint value)
        {
            data[offs] = (byte)(value);
            data[offs + 1] = (byte)(value >> 8);
            data[offs + 2] = (byte)(value >> 16);
            data[offs + 3] = (byte)(value >> 24);
        }
        static void WriteInt64(byte[] data, int offs, long value)
        {
            data[offs] = (byte)(value);
            data[offs + 1] = (byte)(value >> 8);
            data[offs + 2] = (byte)(value >> 16);
            data[offs + 3] = (byte)(value >> 24);
            data[offs + 4] = (byte)(value >> 32);
            data[offs + 5] = (byte)(value >> 40);
            data[offs + 6] = (byte)(value >> 48);
            data[offs + 7] = (byte)(value >> 56);
        }
        static void WriteUInt64(byte[] data, int offs, ulong value)
        {
            data[offs] = (byte)(value);
            data[offs + 1] = (byte)(value >> 8);
            data[offs + 2] = (byte)(value >> 16);
            data[offs + 3] = (byte)(value >> 24);
            data[offs + 4] = (byte)(value >> 32);
            data[offs + 5] = (byte)(value >> 40);
            data[offs + 6] = (byte)(value >> 48);
            data[offs + 7] = (byte)(value >> 56);
        }
        static void WriteFloat(byte[] data, int offs, float value)
        {
            uint value2 = BitConverter.SingleToUInt32Bits(value);
            data[offs] = (byte)(value2);
            data[offs + 1] = (byte)(value2 >> 8);
            data[offs + 2] = (byte)(value2 >> 16);
            data[offs + 3] = (byte)(value2 >> 24);
        }
        public static bool SaveKbb(string path)
        {
            byte[] data = new byte[0x1590];

            // Save Face records
            for (int i = 0; i < 49; i++)
            {
                int offs = i * 0x40; // calculate stride

                // unique face identifier
                WriteInt32(data,offs,kbbfile.face_records[i].faceid);

                // face encounter date
                WriteInt16(data,offs+0x4,kbbfile.face_records[i].met_year);
                data[offs+0x6] = (byte)kbbfile.face_records[i].met_month;
                data[offs+0x7] = (byte)kbbfile.face_records[i].met_day;

                // how many times used in a level
                WriteUInt16(data,offs+0x8,kbbfile.face_records[i].selections);
                
                // tbd
                WriteUInt16(data,offs+0xA,kbbfile.face_records[i].field_0Ah);
                
                // face identity attributes
                WriteInt16(data,offs+0xC,kbbfile.face_records[i].age);
                WriteInt16(data,offs+0xE,kbbfile.face_records[i].gender);
                
                // face texture attributes
                WriteFloat(data,offs+0x10,kbbfile.face_records[i].tx_move_x);
                WriteFloat(data,offs+0x14,kbbfile.face_records[i].tx_move_y);
                WriteFloat(data,offs+0x18,kbbfile.face_records[i].tx_stretch_x);
                WriteFloat(data,offs+0x1C,kbbfile.face_records[i].tx_stretch_y);
                WriteFloat(data,offs+0x20,kbbfile.face_records[i].tx_rot);

                // maker note
                WriteUInt32(data,offs+0x28,kbbfile.face_records[i].makernote.conhashunique);
                WriteUInt32(data,offs+0x2C,kbbfile.face_records[i].makernote.field_04h);
                WriteInt64(data,offs+0x30,kbbfile.face_records[i].makernote.capturedate);
                WriteUInt32(data,offs+0x38,kbbfile.face_records[i].makernote.src_facenum);
                WriteUInt32(data,offs+0x3C,kbbfile.face_records[i].makernote.field_14h);
            }

            // Save stage records
            for (int i = 0; i < 10; i++)
            {
                int offs = i * 0x2C + 0xC40; // calculate stride

                WriteInt32(data,offs+0x0,kbbfile.stg_records[i].r1_face);
                WriteUInt32(data,offs+0x4,kbbfile.stg_records[i].r1_score);
                WriteInt32(data,offs+0x8,kbbfile.stg_records[i].r2_face);
                WriteUInt32(data,offs+0xC,kbbfile.stg_records[i].r2_score);
                WriteInt32(data,offs+0x10,kbbfile.stg_records[i].r3_face);
                WriteUInt32(data,offs+0x14,kbbfile.stg_records[i].r3_score);
                WriteInt32(data,offs+0x18,kbbfile.stg_records[i].r4_face);
                WriteUInt32(data,offs+0x1C,kbbfile.stg_records[i].r4_score);
                WriteInt32(data,offs+0x20,kbbfile.stg_records[i].r5_face);
                WriteUInt32(data,offs+0x24,kbbfile.stg_records[i].r5_score);
                WriteUInt16(data,offs+0x28,kbbfile.stg_records[i].maxcombo);
                data[offs+0x2A] = (byte)(kbbfile.stg_records[i].beatstg ? 1 : 0);
            }

            // Save UFO face records
            for (int i = 0; i < 10; i++)
            {
                int offs = i * 0x28 + 0xDF8; // calculate stride

                WriteInt32(data,offs,kbbfile.ufo_records[i].faceid);

                // maker note
                WriteUInt32(data,offs+0x08,kbbfile.ufo_records[i].makernote.conhashunique);
                WriteUInt32(data,offs+0x0C,kbbfile.ufo_records[i].makernote.field_04h);
                WriteInt64(data,offs+0x10,kbbfile.ufo_records[i].makernote.capturedate);
                WriteUInt32(data,offs+0x18,kbbfile.ufo_records[i].makernote.src_facenum);
                WriteUInt32(data,offs+0x1C,kbbfile.ufo_records[i].makernote.field_14h);

                WriteInt16(data,offs+0x20,kbbfile.ufo_records[i].age);
                WriteInt16(data,offs+0x22,kbbfile.ufo_records[i].gender);
                
                data[offs+0x24] = (byte)(kbbfile.ufo_records[i].field_NEW ? 1 : 0);
            }

            // Save Deleted UFO face records
            for (int i = 0; i < 10; i++)
            {
                int offs = i * 0x20 + 0xF88; // calculate stride

                WriteInt32(data,offs,kbbfile.ufo_old_records[i].faceid);
                
                // maker note
                WriteUInt32(data,offs+0x08,kbbfile.ufo_old_records[i].makernote.conhashunique);
                WriteUInt32(data,offs+0x0C,kbbfile.ufo_old_records[i].makernote.field_04h);
                WriteInt64(data,offs+0x10,kbbfile.ufo_old_records[i].makernote.capturedate);
                WriteUInt32(data,offs+0x18,kbbfile.ufo_old_records[i].makernote.src_facenum);
                WriteUInt32(data,offs+0x1C,kbbfile.ufo_old_records[i].makernote.field_14h);
            }

            // Save globals
            data[0x10C8] = (byte)(kbbfile.globals.ufo_active ? 1 : 0);
            data[0x10C9] = kbbfile.globals.ufo_stg;
            data[0x10CA] = kbbfile.globals.ufo_counter;

            WriteInt32(data,0x10CC,kbbfile.globals.faceid_next);
            WriteInt32(data,0x10D0,kbbfile.globals.ufo_faceid_next);
            WriteInt32(data,0x10D4,kbbfile.globals.delufo_faceid_next);
            
            WriteUInt32(data,0x10D8,kbbfile.globals.field_10D8h);
            WriteUInt32(data,0x10DC,kbbfile.globals.field_10DCh);
            WriteUInt32(data,0x10E0,kbbfile.globals.field_10E0h);
            WriteUInt32(data,0x10E4,kbbfile.globals.field_10E4h);
            
            WriteUInt32(data,0x10E8,kbbfile.globals.friend_faces);
            WriteUInt32(data,0x10EC,kbbfile.globals.title_scenes_unlocked);
            WriteUInt32(data,0x10F0,kbbfile.globals.title_scenes_current);
            
            WriteUInt16(data,0x10F4,kbbfile.globals.field_10F4h);
            WriteUInt16(data,0x10F6,kbbfile.globals.field_10F6h);
            WriteUInt16(data,0x10F8,kbbfile.globals.field_10F8h);
            data[0x10FA] = kbbfile.globals.camp_adv_counter;
            data[0x10FB] = kbbfile.globals.saf_adv_counter;
            data[0x10FC] = (byte)(kbbfile.globals.sneaky_snaps_en ? 1 : 0);
            data[0x10FD] = (byte)(kbbfile.globals.field_10FDh ? 1 : 0);

            data[0x1100] = (byte)(kbbfile.globals.facecollection_unlock ? 1 : 0);
            data[0x1101] = (byte)(kbbfile.globals.field_1101h ? 1 : 0);
            data[0x1102] = (byte)(kbbfile.globals.field_1102h ? 1 : 0);
            data[0x1103] = (byte)(kbbfile.globals.stg2_unlock ? 1 : 0);
            data[0x1104] = (byte)(kbbfile.globals.field_1104h ? 1 : 0);
            data[0x1105] = (byte)(kbbfile.globals.stg3_unlock ? 1 : 0);
            data[0x1106] = (byte)(kbbfile.globals.stg4_unlock ? 1 : 0);
            data[0x1107] = (byte)(kbbfile.globals.stgbonus_unlock ? 1 : 0);
            data[0x1108] = (byte)(kbbfile.globals.stgextra_unlock ? 1 : 0);

            data[0x1109] = (byte)(kbbfile.globals.saf_stg2_unlock ? 1 : 0);
            data[0x110A] = (byte)(kbbfile.globals.saf_stgbonus_unlock ? 1 : 0);
            data[0x110B] = (byte)(kbbfile.globals.saf_stg1_unlock ? 1 : 0);

            data[0x110C] = (byte)(kbbfile.globals.field_110Ch ? 1 : 0);
            data[0x110D] = (byte)(kbbfile.globals.facesel_stg1 ? 1 : 0);
            data[0x110E] = (byte)(kbbfile.globals.facesel_stg2 ? 1 : 0);
            data[0x110F] = (byte)(kbbfile.globals.facesel_stg3 ? 1 : 0);
            data[0x1110] = (byte)(kbbfile.globals.facesel_stg4 ? 1 : 0);

            data[0x1111] = (byte)(kbbfile.globals.field_1111h ? 1 : 0);
            data[0x1112] = (byte)(kbbfile.globals.field_1112h ? 1 : 0);
            data[0x1113] = (byte)(kbbfile.globals.field_1113h ? 1 : 0);
            data[0x1114] = (byte)(kbbfile.globals.field_1114h ? 1 : 0);
            data[0x1115] = (byte)(kbbfile.globals.field_1115h ? 1 : 0);
            data[0x1116] = (byte)(kbbfile.globals.field_1116h ? 1 : 0);
            data[0x1117] = (byte)(kbbfile.globals.field_1117h ? 1 : 0);
            data[0x1118] = (byte)(kbbfile.globals.field_1118h ? 1 : 0);
            data[0x1119] = (byte)(kbbfile.globals.field_1119h ? 1 : 0);
            data[0x111A] = (byte)(kbbfile.globals.field_111Ah ? 1 : 0);
            data[0x111B] = (byte)(kbbfile.globals.field_111Bh ? 1 : 0);
            data[0x111C] = (byte)(kbbfile.globals.field_111Ch ? 1 : 0);
            data[0x111D] = (byte)(kbbfile.globals.field_111Dh ? 1 : 0);
            data[0x111E] = (byte)(kbbfile.globals.field_111Eh ? 1 : 0);
            data[0x111F] = (byte)(kbbfile.globals.field_111Fh ? 1 : 0);

            data[0x1120] = (byte)(kbbfile.globals.field_1120h ? 1 : 0);
            data[0x1121] = (byte)(kbbfile.globals.field_1121h ? 1 : 0);
            data[0x1122] = (byte)(kbbfile.globals.field_1122h ? 1 : 0);
            data[0x1123] = (byte)(kbbfile.globals.field_1123h ? 1 : 0);
            data[0x1124] = (byte)(kbbfile.globals.field_1124h ? 1 : 0);
            data[0x1125] = (byte)(kbbfile.globals.field_1125h ? 1 : 0);
            data[0x1126] = (byte)(kbbfile.globals.field_1126h ? 1 : 0);
            data[0x1127] = (byte)(kbbfile.globals.field_1127h ? 1 : 0);
            data[0x1128] = (byte)(kbbfile.globals.field_1128h ? 1 : 0);
            data[0x1129] = (byte)(kbbfile.globals.field_1129h ? 1 : 0);
            data[0x112A] = (byte)(kbbfile.globals.field_112Ah ? 1 : 0);

            data[0x112B] = (byte)(kbbfile.globals.stg2_unlock_anim ? 1 : 0);
            data[0x112C] = (byte)(kbbfile.globals.stg3_unlock_anim ? 1 : 0);
            data[0x112D] = (byte)(kbbfile.globals.stg4_unlock_anim ? 1 : 0);
            data[0x112E] = (byte)(kbbfile.globals.stgbonus_unlock_anim ? 1 : 0);
            data[0x112F] = (byte)(kbbfile.globals.stgextra_unlock_anim ? 1 : 0);
            data[0x1130] = (byte)(kbbfile.globals.saf_stg2_unlock_anim ? 1 : 0);
            data[0x1131] = (byte)(kbbfile.globals.saf_stgbonus_unlock_anim ? 1 : 0);

            data[0x1132] = (byte)(kbbfile.globals.ufo_landed ? 1 : 0);
            data[0x1133] = (byte)(kbbfile.globals.field_1133h ? 1 : 0);
            data[0x1134] = (byte)(kbbfile.globals.saf_stg1_unlock_anim ? 1 : 0);
            data[0x1135] = (byte)(kbbfile.globals.crown_en ? 1 : 0);
            data[0x1136] = (byte)(kbbfile.globals.field_1136h ? 1 : 0);
            data[0x1137] = (byte)(kbbfile.globals.field_1137h ? 1 : 0);
            data[0x1138] = (byte)(kbbfile.globals.field_1138h ? 1 : 0);
            data[0x1139] = (byte)(kbbfile.globals.field_1139h ? 1 : 0);
            data[0x113A] = (byte)(kbbfile.globals.slidebtn_unlock_anim ? 1 : 0);
            data[0x113B] = (byte)(kbbfile.globals.field_113Bh ? 1 : 0);
            data[0x113C] = (byte)(kbbfile.globals.stg1_unlock_anim ? 1 : 0);
            data[0x113D] = (byte)(kbbfile.globals.field_113Dh ? 1 : 0);
            data[0x113E] = (byte)(kbbfile.globals.field_113Eh ? 1 : 0);
            data[0x113F] = (byte)(kbbfile.globals.field_113Fh ? 1 : 0);

            data[0x1140] = (byte)(kbbfile.globals.field_1140h ? 1 : 0);
            data[0x1141] = (byte)(kbbfile.globals.field_1141h ? 1 : 0);
            data[0x1142] = (byte)(kbbfile.globals.field_1142h ? 1 : 0);
            data[0x1143] = (byte)(kbbfile.globals.field_1143h ? 1 : 0);
            data[0x1144] = (byte)(kbbfile.globals.field_1144h ? 1 : 0);
            data[0x1145] = (byte)(kbbfile.globals.sneaky_snaps_introduced ? 1 : 0);
            data[0x1146] = (byte)(kbbfile.globals.field_1146h ? 1 : 0);
            data[0x1147] = (byte)(kbbfile.globals.sneaky_snaps_unlocked ? 1 : 0);
            data[0x1148] = (byte)(kbbfile.globals.field_1148h ? 1 : 0);
            data[0x1149] = (byte)(kbbfile.globals.field_1149h ? 1 : 0);
            data[0x114A] = (byte)(kbbfile.globals.field_114Ah ? 1 : 0);
            data[0x114B] = (byte)(kbbfile.globals.field_114Bh ? 1 : 0);
            data[0x114C] = (byte)(kbbfile.globals.field_114Ch ? 1 : 0);
            data[0x114D] = (byte)(kbbfile.globals.field_114Dh ? 1 : 0);
            data[0x114E] = (byte)(kbbfile.globals.field_114Eh ? 1 : 0);
            data[0x114F] = (byte)(kbbfile.globals.field_114Fh ? 1 : 0);

            data[0x1150] = (byte)(kbbfile.globals.field_1150h ? 1 : 0);
            data[0x1151] = (byte)(kbbfile.globals.field_1151h ? 1 : 0);
            data[0x1152] = (byte)(kbbfile.globals.field_1152h ? 1 : 0);
            data[0x1153] = (byte)(kbbfile.globals.field_1153h ? 1 : 0);
            data[0x1154] = (byte)(kbbfile.globals.field_1154h ? 1 : 0);
            data[0x1155] = (byte)(kbbfile.globals.field_1155h ? 1 : 0);
            data[0x1156] = (byte)(kbbfile.globals.field_1156h ? 1 : 0);
            data[0x1157] = (byte)(kbbfile.globals.field_1157h ? 1 : 0);
            data[0x1158] = (byte)(kbbfile.globals.field_1158h ? 1 : 0);
            data[0x1159] = (byte)(kbbfile.globals.field_1159h ? 1 : 0);
            data[0x115A] = (byte)(kbbfile.globals.field_115Ah ? 1 : 0);
            data[0x115B] = (byte)(kbbfile.globals.field_115Bh ? 1 : 0);
            data[0x115C] = (byte)(kbbfile.globals.field_115Ch ? 1 : 0);
            data[0x115D] = (byte)(kbbfile.globals.field_115Dh ? 1 : 0);
            data[0x115E] = (byte)(kbbfile.globals.field_115Eh ? 1 : 0);
            data[0x115F] = (byte)(kbbfile.globals.field_115Fh ? 1 : 0);

            data[0x1160] = (byte)(kbbfile.globals.infomsg01 ? 1 : 0);
            data[0x1161] = (byte)(kbbfile.globals.infomsg02 ? 1 : 0);
            data[0x1162] = (byte)(kbbfile.globals.infomsg03 ? 1 : 0);
            data[0x1163] = (byte)(kbbfile.globals.infomsg04 ? 1 : 0);
            data[0x1164] = (byte)(kbbfile.globals.infomsg05 ? 1 : 0);
            data[0x1165] = (byte)(kbbfile.globals.infomsg06 ? 1 : 0);
            data[0x1166] = (byte)(kbbfile.globals.infomsg07 ? 1 : 0);
            data[0x1167] = (byte)(kbbfile.globals.infomsg08 ? 1 : 0);
            data[0x1168] = (byte)(kbbfile.globals.infomsg09 ? 1 : 0);
            data[0x1169] = (byte)(kbbfile.globals.infomsg10 ? 1 : 0);
            data[0x116A] = (byte)(kbbfile.globals.infomsg11 ? 1 : 0);
            data[0x116B] = (byte)(kbbfile.globals.infomsg12 ? 1 : 0);
            data[0x116C] = (byte)(kbbfile.globals.infomsg13 ? 1 : 0);
            data[0x116D] = (byte)(kbbfile.globals.infomsg14 ? 1 : 0);
            data[0x116E] = (byte)(kbbfile.globals.infomsg15 ? 1 : 0);
            data[0x116F] = (byte)(kbbfile.globals.infomsg16 ? 1 : 0);
            data[0x1170] = (byte)(kbbfile.globals.infomsg17 ? 1 : 0);
            data[0x1171] = (byte)(kbbfile.globals.infomsg18 ? 1 : 0);
            data[0x1172] = (byte)(kbbfile.globals.infomsg19 ? 1 : 0);
            data[0x1173] = (byte)(kbbfile.globals.infomsg20 ? 1 : 0);
            data[0x1174] = (byte)(kbbfile.globals.infomsg21 ? 1 : 0);
            data[0x1175] = (byte)(kbbfile.globals.infomsg22 ? 1 : 0);
            data[0x1176] = (byte)(kbbfile.globals.infomsg23 ? 1 : 0);
            data[0x1177] = (byte)(kbbfile.globals.infomsg24 ? 1 : 0);
            data[0x1178] = (byte)(kbbfile.globals.infomsg25 ? 1 : 0);
            data[0x1179] = (byte)(kbbfile.globals.infomsg26 ? 1 : 0);
            data[0x117A] = (byte)(kbbfile.globals.infomsg27 ? 1 : 0);
            data[0x117B] = (byte)(kbbfile.globals.infomsg28 ? 1 : 0);

            data[0x117C] = (byte)(kbbfile.globals.field_117Ch ? 1 : 0);
            data[0x117D] = (byte)(kbbfile.globals.field_117Dh ? 1 : 0);
            data[0x117E] = (byte)(kbbfile.globals.field_117Eh ? 1 : 0);
            data[0x117F] = (byte)(kbbfile.globals.field_117Fh ? 1 : 0);

            // write file format "version" and checksum
            WriteUInt32(data,0x1580,0x26);

            uint newcrc = Checksum.Run(data,0x1588);
            WriteUInt32(data,0x1588,newcrc);

            try
            {
                FileSystem.WriteAllBytes(string.Concat(path, "Kbb.dat"), data, false);
            }
            catch (Exception e) {
                Interaction.MsgBox(e.Message,MsgBoxStyle.Exclamation,"");
                return false;
            }

            // Save "PhotoF__.dat" files
            for (int i = 0; i < 49; i++)
            {
                if (photof_loaded_flags[i])
                {
                    string filename = string.Concat(path, string.Format("PhotoF{0:D2}.dat", i));

                    data = new byte[0x8008];

                    WriteUInt32(data, 0, photof[i].marker);
                    Buffer.BlockCopy(photof[i].pxdata, 0, data, 4, 0x8000);

                    newcrc = Checksum.Run(data, 0x8004);
                    WriteUInt32(data, 0x8004, newcrc);

                    try
                    {
                        FileSystem.WriteAllBytes(filename, data, false);
                    }
                    catch (Exception e)
                    {
                        Interaction.MsgBox(e.Message, MsgBoxStyle.Exclamation, "");
                        return false;
                    }
                }
            }

            // Save "PhotoP__.dat" files
            for (int i = 0; i < 10; i++)
            {
                if (photop_loaded_flags[i])
                {
                    string filename = string.Concat(path, string.Format("PhotoP{0:D2}.dat", i));

                    data = new byte[0x8008];

                    WriteUInt32(data, 0, photop[i].marker);
                    Buffer.BlockCopy(photop[i].pxdata, 0, data, 4, 0x8000);

                    newcrc = Checksum.Run(data, 0x8004);
                    WriteUInt32(data, 0x8004, newcrc);

                    try
                    {
                        FileSystem.WriteAllBytes(filename, data, false);
                    }
                    catch (Exception e)
                    {
                        Interaction.MsgBox(e.Message, MsgBoxStyle.Exclamation, "");
                        return false;
                    }
                }
            }

            return true;
        }
    }
}