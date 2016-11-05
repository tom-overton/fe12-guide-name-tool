// Copyright (c) 2016 Tom Overton
// FileData represents the data read from FE12's PKCG files.

using System;

namespace FE12GuideNameTool
{
    public class FileData
    {
        /// <summary>
        /// The raw bytes that are read and written to the PKCG file.
        /// </summary>
        public byte[] Data { get; set; }

        public FileData(byte[] data)
        {
            this.Data = data;
        }

        /// <summary>
        /// Returns an array where each byte indicates an index into the palette.
        /// </summary>
        public byte[] GetPalettizedData()
        {
            if (Data == null || Data.Length == 0)
            {
                return new byte[0];
            }

            byte[] formattedData = new byte[Data.Length * 2];
            for (int i = 0; i < Data.Length; i++)
            {
                int first16Bits = Data[i] % 16;
                int second16Bits = Data[i] / 16;
                formattedData[2 * i] = (byte)first16Bits;
                formattedData[(2 * i) + 1] = (byte)second16Bits;
            }

            return formattedData;
        }

        /// <summary>
        /// Updates the stored file data using palettized data. We start from a given
        /// byte index, convert the palettized data to file data, and overwrite the stored
        /// data until there are no more bytes to write.
        /// </summary>
        public void UpdateFromPalettizedByteData(byte[] palettizedData, int dataIndex)
        {
            // First, calculate where we want to insert the new data into the file data.
            // Check if the palettized data (when converted) will run off the end of the file
            // when we try to insert it; throw an appropriate error if this is the case.
            int fileDataIndex = dataIndex / 2;
            int convertedLength = palettizedData.Length / 2;
            if (fileDataIndex + convertedLength > this.Data.Length)
            {
                throw new ArgumentException("Cannot update the file data due to size constraints. " +
                                            "Check that the size of your data and your data index are correct.");
            }

            byte[] newFileData = new byte[convertedLength];
            for (int i = 0; i < newFileData.Length; i++)
            {
                int first16Bits = palettizedData[2 * i];
                int second16Bits = palettizedData[(2 * i) + 1] * 16;
                newFileData[i] = (byte)(second16Bits + first16Bits);
            }

            for (int i = fileDataIndex; i < fileDataIndex + convertedLength; i++)
            {
                this.Data[i] = newFileData[i - fileDataIndex];
            }
        }
    }
}
