// Copyright (c) 2016 Tom Overton
// Class for converting raw byte data to 8x8 tiles.

using System.Collections.Generic;
using System.Drawing;

namespace FE12GuideNameTool
{
    public class TileHelper
    {
        public List<Bitmap> tiles = new List<Bitmap>();

        private DataHelper helper;

        public TileHelper(string fileName)
        {
            helper = new DataHelper(fileName);
            CreateTilesFromData(this.helper.data);
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
                    Color color = Palette.Lookup(data[index]);
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
    }
}
