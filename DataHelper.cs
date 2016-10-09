// Copyright (c) 2016 Tom Overton
// Class for reading, writing, and canonizing PKCG data from files.

using System.IO;

namespace FE12GuideNameTool
{
    public class DataHelper
    {
        public string fileName;
        public byte[] fileData;
        public byte[] data;

        public DataHelper(string fileName)
        {
            this.fileName = fileName;
            this.fileData = File.ReadAllBytes(this.fileName);
            InitializeData();
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
    }
}
