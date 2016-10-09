using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE12GuideNameTool
{
    public class TileHelper
    {
        public static byte[] fileData;
        public static byte[] data;
        public static List<Bitmap> tiles = new List<Bitmap>();

        public static void InitializeTileHelper(byte[] rawData)
        {
            fileData = rawData;
            InitializeData();
        }

        public static Bitmap CreateBigTestBitmap()
        {
            CreateTiles();

            int xDim = 256;
            int yDim = ((tiles.Count / 32) + 1) * 8;
            Bitmap result = new Bitmap(xDim, yDim);
            Graphics canvas = Graphics.FromImage(result);
            for (int i = 0; i < tiles.Count; i++)
            {
                int x = (i % 32) * 8;
                int y = (i / 32) * 8;
                canvas.DrawImage(tiles[i], x, y, 8, 8);
                canvas.Save();
            }

            return result;
        }

        private static void CreateTiles()
        {
            InitializeData();

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

        private static void InitializeData()
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
