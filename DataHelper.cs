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

        public DataHelper(string fileName)
        {
            this.fileName = fileName;
            this.fileData = File.ReadAllBytes(this.fileName);
            InitializeData();
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

        private void WriteDataToFile(byte[] newFileData, int fileDataIndex)
        {
            // Write a backup to be nice to the user
            File.WriteAllBytes(fileName + ".bak", this.fileData);

            for (int i = fileDataIndex; i < newFileData.Length; i++)
            {
                this.fileData[i] = newFileData[i];
            }

            File.WriteAllBytes(this.fileName, this.fileData);
        }
    }
}
