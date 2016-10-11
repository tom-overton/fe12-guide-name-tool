# fe12-guide-name-tool
A quick-and-dirty tool for working with the name graphics found in FE12's Guide.

![screenshot](https://cloud.githubusercontent.com/assets/12245827/19224598/eb7d2ca2-8e3d-11e6-9104-3d28df114c9f.png)

This tool is intended to be used with the name_[faction].pkcg files found in the dic/ directory of FE12. It may work with other PKCG files, but it probably won't. To use this tool:

1. [Download the tool](https://github.com/tom-overton/fe12-guide-name-tool/releases) or pull and compile it yourself.
2. Extract the name file from the FE12 ROM. I recommend using [Tinke](https://github.com/pleonex/tinke) to do this. All name files are located in the dic/ directory, and are labeled by faction.
3. Decompress the name file you extracted. I used [Puyo Tools](http://www.romhacking.net/utilities/1130/) for this, but feel free to use whatever you like, so long as it supports LZSS compression.
4. Open the FE12 Guide Name Tool, then use the Open File button to select the decompressed PKCG you created in Step 3.
5. You should now see all of the names in the PKCG in the list to the right. You can click on one of the names to make it visible in the box to the left.
6. Click the Export to PNG button to save the currently-visible name as a PNG somewhere on your computer. From there, edit the name to your liking.
7. Click the Import from PNG button to replace the currently-visible name with the name you edited in the previous step. Ensure that the imported name is 64x16 pixels large and obeys the palette restrictions from the original name.
8. If the import was successful, the PKCG will be updated (a backup is created in case you want to revert the import). Compress the PKCG with Puyo Tools using LZSS compression.
9. Open the FE12 ROM in Tinke again, and use the Change File button to replace the original name file with your updated one. Save the updated ROM.
10. Boot FE12. Your updated name should be visible in the Guide menu!