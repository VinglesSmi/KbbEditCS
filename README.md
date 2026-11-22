# KbbEditCS

A Face Raiders Save Data Editor.

KbbEdit -> Kbb.dat Editor. Kbb is the abbreviation for the game's code name: Kao Bang Bang (顔・バン・バン).

# How to use

Face Raiders stores its save data on the 3DS's NAND, which requires the console to be modded to have access to it.

[FBI](https://github.com/steveice10/FBI) is recommended to copy the save data from there.

In FBI, go to System Save Data -> 000202xD -> Browse Save Data (x = Region Code), and copy all the files from there.
Create a temporary folder in your SD card where you will paste your Save Data, so you can then access it either by putting the SD card in your computer, or using [FTPD](https://github.com/mtheall/ftpd) to transfer the files wirelessly.

Once the Save Data is on your computer, you can open the Kbb.dat file with the editor, which will automatically load the Photo.dat files as well.

When done editing, simply move the modified Save Data back to your 3DS, and put it in the System Save Data folder they originated from.
Of course, it is recommended to keep a copy of the original, unmodified Save Data.

# Features

- Score Editor: Edit Stage records and which Stages are unlocked.
- Face Editor: Modify, import and export Faces.
- Globals Editor: Edit parameters used in various places in the game.
- (DEBUG ONLY) Hex Editor: Edit the raw Save Data. Tread carefully.
