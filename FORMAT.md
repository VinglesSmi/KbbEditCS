# Face Raiders Save Data Format

This document will explain how the format used by the game to store progress works.

Most of these fields are initialized to 0 by the game, unless stated otherwise.

# Kbb.dat

## 0x0000 to 0x0C3F: Face slots (49 entries)

### Each Face slot is 0x40 bytes.

0x00 (s32) - Unique Face Identifier. A slot is marked as "empty" when this field is set to -1.

0x04 (s16) - Year when the Face was first encountered.

0x06 (s8) - Month when the Face was first encountered.

0x07 (s8) - Day when the Face was first encountered.

0x08 (s16) - How many times the Face was chosen to play a Stage. The game normally caps this counter to 99, but accepts values up to 999.

0x0A (u16) - Unknown, initialized to 0 by the game.

0x0C (s16) - Age of the Face.

0x0E (s16) - Gender of the Face.

0x10 (f32) - Horizontal translation of the Face Image. Must be a value between -0.5 and 0.5.

0x14 (f32) - Vertical translation of the Face Image. Must be a value between -0.5 and 0.5.

0x18 (f32) - Horizontal scaling of the Face Image. Must be a value between 0.25 and 2.0.

0x1C (f32) - Vertical scaling of the Face Image. Must be a value between 0.25 and 2.0.

0x20 (f32) - Rotation in radians of the Face Image. Must be a value between -π (around -3.14) and π (around 3.14).

The four bytes at 0x24 are completely ignored by the game.

0x28 (0x18 bytes) - Maker Note. Its structure is explained later in the file. Only Faces that originated from the UFO Crew have this.

### Note about the "Age" field:

By default, this field is initialized to -1, which represents an unknown, unidentified age.

The game can identify five different age ranges:

0: Baby, 3 years or less.

1: Child, 4 to 9 years.

2: Young, 10 to 29 years.

3: Adult, 30 to 49 years.

4: Adult, 50 years or above.

### Note about the "Gender" field:

By default, this field is initialized to -1, which represents an unknown, unidentified gender.

A value of 0 represents a Male face. A value of 1 represents a Female face.

## 0x0C40 to 0x0DF7: Stage records (10 entries)

### Each entry is 0x2C bytes.

0x00 (s32) - Record #1 Face ID.

0x04 (u32) - Record #1 Score.

0x08 (s32) - Record #2 Face ID.

0x0C (u32) - Record #2 Score.

0x10 (s32) - Record #3 Face ID.

0x14 (u32) - Record #3 Score.

0x18 (s32) - Record #4 Face ID.

0x1C (u32) - Record #4 Score.

0x20 (s32) - Record #5 Face ID.

0x24 (u32) - Record #5 Score.

0x28 (u16) - Max combo.

0x2A (bool) - Level completed flag. When this flag is cleared for Stages 1, 2, 3 and Final, these will show a face suggestion on the camera.

### Each entry is assigned to a Stage in the game.

0x0C40: Stage 1

0x0C6C: Stage 2

0x0C98: Stage 3

0x0CC4: Final Stage

0x0CF0: Bonus Stage

0x0D1C: Extra Stage

0x0D48: SAF Stage 1

0x0D74: SAF Stage 2

0x0DA0: SAF Bonus Stage

0x0DCC: Tutorial Stage

Note: The Tutorial Stage is identical to SAF Stage 1 (aside from the fact that it does not have the UFO nor the Showing Off feature functionality) and is only playable once before obtaining your first face.

## 0x0DF8 to 0x0F87: UFO Crew Face slots (10 entries)

### Each Face slot is 0x28 bytes.

0x00 (s32) - Unique Face Identifier

The four bytes at 0x04 are completely ignored by the game.

0x08 (0x18 bytes) - Maker Note. Its structure is explained later in the file.

0x20 (s16) - Age of the Face.

0x22 (s16) - Gender of the Face.

0x24 (bool) - "NEW" Bubble in the UFO Crew.

## 0x0F88 to 0x10C7: Deleted UFO Crew Face slots (10 entries)

### Each slot is 0x20 bytes.

0x00 (s32) - Unique Face Identifier

The four bytes at 0x04 are completely ignored by the game.

0x08 (0x18 bytes) - Maker Note. Its structure is explained later in the file.

Note: this section of the file is used to prevent the UFO from abducting the same faces over and over again.

## 0x10C8 to 0x10FF: Global game parameters

### Certain fields are explained at the end of this paragraph.

0x10C8 (bool) - UFO active flag. UFOs can appear in a Stage when this flag is set.

0x10C9 (byte) - Stage where UFOs will appear.

0x10CA (byte) - UFO activation/deactivation counter.

The byte at 0x10CB is completely ignored by the game.

0x10CC (s32) - Next ID to be assigned to a new Face. When the game creates the save file, this is initialized with the value 10. IDs 0 through 9 are instead used to reference the UFO Crew Faces, and therefore must not be assigned to a Face in the Face Collection.

0x10D0 (s32) - Next ID to be assigned to a newly abducted UFO Crew Face.

0x10D4 (s32) - Next ID to be assigned to a deleted UFO Crew Face.

0x10D8 (u32) - Unknown, initialized to 0 by the game.

0x10DC (u32) - Unknown purpose.

0x10E0 (u32) - Exact purpose unknown. When this field is 0, the game will load the Tutorial stage when accessing the campaign. The game caps this field to 999.

0x10E4 (u32) - Unknown purpose. The game caps this field to 99.

0x10E8 (u32) - SAF Friend Faces counter. The game caps this field to 99.

0x10EC (u32) - Cutscenes unlocked on the Title Screen.

0x10F0 (u32) - Last Cutscene viewed on the Title Screen.

0x10F4 (u16) - Exact purpose unknown. See notes.

0x10F6 (u16) - Exact purpose unknown. See notes.

0x10F8 (u16) - Exact purpose unknown. See notes.

0x10FA (byte) - Advice tip counter in Campaign.

0x10FB (byte) - Advice tip counter in SAF.

0x10FC (bool) - Sneaky Snaps enable flag.

0x10FD (bool) - Normally cleared by default, the code used to set this flag is never called anywhere in the game's code. See notes.

The two bytes at 0x10FE are completely ignored by the game.

### Note about the UFO-related fields:

When the game creates the save file, the UFO active flag is automatically set, which will make UFOs immediately active upon the first face abductions when the UFO is unlocked in game.

The byte at 0x10C9 can take the following values:

0: Stage 1 (Two UFOs)

1: Stage 2 (Three UFOs)

2: SAF Stage 1 (One UFO)

3: Stage 3 (Three UFOs)

4: Final Stage (Three UFOs)

### Note about the 0x10FD flag:

When this flag is set, an unused functionality is enabled, which reads the fields 0x10F4, 0x10F6 and 0x10F8.

It has been observed that setting these fields to non-zero values affects how the game detects faces, and how the game identifies a face's age and gender.

## 0x1100 to 0x117F: Global game flags

### All of these fields are boolean values.

0x1100 - Face Collection is unlocked

0x1101 - Unused

0x1102 - Exact purpose unknown. Set after a successful UFO search.

0x1103 - Stage 2 is unlocked

0x1104 - Exact purpose unknown. Set every time the game starts.

0x1105 - Stage 3 is unlocked

0x1106 - Final Stage is unlocked

0x1107 - Bonus Stage is unlocked

0x1108 - Extra Stage is unlocked

0x1109 - SAF Stage 2 is unlocked

0x110A - SAF Bonus Stage is unlocked

0x110B - SAF Stage 1 is unlocked

0x110C - Unused

0x110D - Slide button unlock flag for Stage 1

0x110E - Slide button unlock flag for Stage 2

0x110F - Slide button unlock flag for Stage 3

0x1110 - Slide button unlock flag for Final Stage

0x1111 - Exact purpose unknown. Set after a successful UFO search.

0x1112 - Show the UFO in Face Collection. The game always sets this when flag 0x1105 is set (Stage 3 is unlocked).

0x1113 - Unknown purpose.

Fields 0x1114 through 0x1126 seem to be unused.

0x1127 - Unknown purpose.

0x1128 - Show the Red Arrow on the Main Menu screen if cleared. When it gets displayed this field gets set, and thus this field is never cleared again.

0x1129 - Unused

0x112A - "NEW" Bubble for Face Collection

0x112B - The unlocking animation for Stage 2 is shown if this field is cleared.

0x112C - The unlocking animation for Stage 3 is shown if this field is cleared.

0x112D - The unlocking animation for Final Stage is shown if this field is cleared.

0x112E - The unlocking animation for Bonus Stage is shown if this field is cleared.

0x112F - The unlocking animation for Extra Stage is shown if this field is cleared.

0x1130 - The unlocking animation for SAF Stage 2 is shown if this field is cleared.

0x1131 - The unlocking animation for SAF Bonus Stage is shown if this field is cleared.

0x1132 - The game will introduce the player to the UFO if this field is cleared.

0x1133 - Unused

0x1134 - The unlocking animation for SAF Stage 1 is shown if this field is cleared.

0x1135 - The most chosen Face is shown with a crown.

Fields 0x1136 through 0x1139 are normally unused, and the only code found that reads these fields can never normally be reached.

0x113A - The unlocking animation for the Slide Button when entering a Stage is shown if this field is cleared.

0x113B - "NEW" Bubble for SAF.

0x113C - The unlocking animation for Stage 1 is shown if this field is cleared.

The purpose for fields 0x113D through 0x1143 is unknown. No code that sets these fields has been found.

0x1144 - "NEW" Bubble for the UFO in Face Collection.

0x1145 - Sneaky Snaps is introduced at the end of a stage if this field is cleared.

0x1146 - "NEW" Bubble for Face Collection (TODO: is this field functionally a duplicate of 0x112A?)

0x1147 - Sneaky Snaps is unlocked

0x1148 - Exact purpose unknown. Seems to be related to the UFO's face abduction feature.

Fields 0x1149 through 0x115F seem to be unused.

Fields 0x1160 through 0x117B are used as flags to indicate which Advice Tips have been displayed to the user. They correspond to each "StgFace_Information_message" string in the MSBT file, starting from 01 up to 28 (in decimal).
When the game reads the flag for an Advice Tip and it is cleared, the Advice Tip button indicator will have a '!' indicator in its top left corner.

Finally, fields 0x117C through 0x117F are not used by the game.

## 0x1180 to 0x157F: Scratchpad?

This 1024-byte region of the save file is initialized to all zeroes when the save file is created, but the game never attempts to read there afterwards.
The purpose of this region of the save file remains a mystery.

## 0x1580 (u32): File magic

This field is used as an identifier and must be set to 0x26 to be accepted by the game, otherwise the file is considered invalid and will be reset entirely.

## 0x1588 (u32): File checksum

This field is used to validate the save file. It is the CRC32 calculation of the bytes 0x0000 through 0x1587 with the 0xEDB88320 polynomial.

## Final note about Kbb.dat

The four bytes at 0x1584 are ignored by the game.
And although the save field is 0x1590 bytes in size, the four bytes at 0x158C are also ignored by the game.

## Maker Note structure (0x18 bytes)

Most of the values in these fields originate from the phtcache.bin (Photo Cache) generated by the 3DS Camera app.

0x00 (u32) - Unique Console hash identifier. This is the lower word of Cfg:GenHashConsoleUnique. The game does not use this field.

0x04 (u32) - Unknown. Only the value 0 has been observed in this field.

0x08 (s64) - Capture Date. Seconds since the "DS Epoch" (January 1st 2000 Midnight) (UNIX+946684800)

0x10 (u32) - Face number in the source image.

0x14 (bool) - Exact purpose unknown. Used UFO Crew Face slots must have this flag set.

# PhotoF and PhotoP files

"PhotoF" files are used for Faces in the Face Collection (F stands for Face) and "PhotoP" files are used for abducted Faces in the UFO Crew (P stands for PNote).

"PhotoF" files are named with a two digit number as a postfix, from "PhotoF00.dat" to "PhotoF48.dat". Each file corresponds to a slot in the Face slots region of Kbb.dat

Likewise, "PhotoP" files are named with a two digit number as a postfix, though they range from "PhotoP00.dat" to "PhotoP09.dat" as there are 10 slots in the UFO Crew.

These images have a resolution of 128x128 pixels, in RGB565 color format.

There are 0x8008 bytes in each Photo file:

0x0000 (u32) - Marker field. See notes.

0x0004 through 0x8003 - The pixel data for the image.

0x8004 (u32) - File checksum: CRC32 of the bytes 0x0000 through 0x8003 with the 0xEDB88320 polynomial.

### Note about the "Marker" field

Two values have been observed in this field: 0 and 5.

By default it is initialized to 0, and when a Face gets removed,
either by getting transfered from the UFO Crew to the Face Collection,
or getting deleted from the Face Collection, or getting deleted from the UFO Crew,
this field is set to 5. The game never attempts to read this field, aside from calculating the checksum.

No code has been found to write any other value than 0 or 5.

### Note about the pixel format

The 3DS's PICA processes pixel data in a specific order called "Z-order curve" or "Morton curve".
The textures are always made up of 8x8 cells, and these cells are processed in the order of the Z-order curve.
However, the 8x8 cells are arranged linearly, from left to right, then from top to bottom of the image.
