﻿// Copyright (c) 2016 Tom Overton
// Class for converting byte data to 8x8 tiles and vice versa.

using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace FE12GuideNameTool
{
    public class TileHelper
    {
        public List<Bitmap> tiles = new List<Bitmap>();

        public string fileName;
        public byte[] originalFileData;
        private FileData fileData;
        private Palette palette;

        public TileHelper(string fileName)
        {
            this.fileName = fileName;
            this.originalFileData = File.ReadAllBytes(this.fileName);
            this.palette = new Palette(this.originalFileData);
            this.fileData = new FileData(this.originalFileData);
            CreateTilesFromData(this.fileData.GetPalettizedData());
        }

        public void CreateTilesFromData(byte[] data)
        {
            int tileIndex = 0;
            bool previousTileContainsData;
            do
            {
                previousTileContainsData = false;
                Bitmap tile = new Bitmap(8, 8);
                for (int i = 0; i < 64; i++)
                {
                    int x = i % 8;
                    int y = i / 8;
                    int index = (tileIndex * 64) + i;
                    Color color = palette.Lookup(data[index]);
                    if (!previousTileContainsData && data[index] != 0)
                    {
                        previousTileContainsData = true;
                    }

                    tile.SetPixel(x, y, color);
                }

                tiles.Add(tile);
                tileIndex++;
            }
            while (previousTileContainsData);
        }

        public void UpdateTiles(List<Bitmap> newTiles, int tileIndex)
        {
            // Update the data based on the new tiles
            byte[] newData = new byte[newTiles.Count * 8 * 8];
            for (int tile = 0; tile < newTiles.Count; tile++)
            {
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        Color pixel = newTiles[tile].GetPixel(x, y);
                        int currentDataIndex = (tile * 8 * 8) + (y * 8) + x;
                        newData[currentDataIndex] = palette.ReverseLookup(pixel);
                    }
                }
            }

            int dataIndex = tileIndex * 8 * 8;
            this.fileData.UpdateFromPalettizedByteData(newData, dataIndex);

            for (int i = tileIndex; i < newTiles.Count; i++)
            {
                this.tiles[i] = newTiles[i];
            }

            WriteDataToFile();
        }

        private void WriteDataToFile()
        {
            // Write a backup to be nice to the user
            File.WriteAllBytes(fileName + ".bak", this.originalFileData);
            File.WriteAllBytes(this.fileName, this.fileData.Data);
        }
    }
}
