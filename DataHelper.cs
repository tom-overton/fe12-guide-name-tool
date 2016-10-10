// Copyright (c) 2016 Tom Overton
// Class for reading and writing PKCG data to and from files.

using System.IO;

namespace FE12GuideNameTool
{
    public class DataHelper
    {
        public string fileName;
        public byte[] fileData;
        public byte[] data;

        private static int paletteLocationOffset = 0x0C;

        public DataHelper(string fileName)
        {
            this.fileName = fileName;
            this.fileData = File.ReadAllBytes(this.fileName);
            InitializeData();
            InitializePaletteData();
        }

        public void UpdateData(byte[] newData, int dataIndex)
        {
            // Update fileData based on the new data
            byte[] newFileData = new byte[newData.Length / 2];
            for (int i = 0; i < newFileData.Length; i++)
            {
                int first16Bits = newData[2 * i];
                int second16Bits = newData[(2 * i) + 1] * 16;
                newFileData[i] = (byte)(second16Bits + first16Bits);
            }

            int fileDataIndex = dataIndex / 2;

            // Write the updated fileData to disk
            WriteDataToFile(newFileData, fileDataIndex);

            for (int i = dataIndex; i < newData.Length; i++)
            {
                this.data[i] = newData[i];
            }

        }

        private void InitializeData()
        {
            if (fileData == null || fileData.Length == 0)
            {
                return;
            }

            data = new byte[fileData.Length * 2];
            for (int i = 0; i < fileData.Length; i++)
            {
                int first16Bits = fileData[i] % 16;
                int second16Bits = fileData[i] / 16;
                data[2 * i] = (byte)first16Bits;
                data[(2 * i) + 1] = (byte)second16Bits;
            }
        }

        private void InitializePaletteData()
        {
            Palette.ClearPalette();
            int paletteLocation = (fileData[paletteLocationOffset + 1] * 256) + fileData[paletteLocationOffset];
            for (int i = 0; i < 16; i++)
            {
                int location = paletteLocation + (2 * i);
                int bgr555 = (fileData[location + 1] * 256) + fileData[location];
                int r = bgr555 & 31;
                int g = (bgr555 >> 5) & 31;
                int b = (bgr555 >> 10) & 31;
                Palette.AddColor(i, r * 8, g * 8, b * 8);
            }
        }

        private void WriteDataToFile(byte[] newFileData, int fileDataIndex)
        {
            // Write a backup to be nice to the user
            File.WriteAllBytes(fileName + ".bak", this.fileData);

            for (int i = fileDataIndex; i < fileDataIndex + newFileData.Length; i++)
            {
                this.fileData[i] = newFileData[i - fileDataIndex];
            }

            File.WriteAllBytes(this.fileName, this.fileData);
        }
    }
}
