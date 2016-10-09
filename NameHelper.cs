using System.Collections.Generic;
using System.Drawing;

namespace FE12GuideNameTool
{
    public class NameHelper
    {
        public static List<Bitmap> scrambledNameList;
        public static List<Bitmap> nameList;

        private static TileHelper tileHelper;

        public static void InitializeNameHelper(string fileName)
        {
            Palette.InitializePalette();
            tileHelper = new TileHelper(fileName);
            CreateScrambledNameList();
            CreateNameList();
        }

        public static void CreateScrambledNameList()
        {
            scrambledNameList = new List<Bitmap>();

            for (int i = 0; i < tileHelper.tiles.Count; i += 16)
            {
                int xDim = 136;
                int yDim = 8;
                Bitmap bitmap = new Bitmap(xDim, yDim);
                Graphics canvas = Graphics.FromImage(bitmap);
                for (int j = 0; j < 17; j++)
                {
                    int x = j * 8;
                    int y = 0;
                    if (i + j < tileHelper.tiles.Count)
                    {
                        canvas.DrawImage(tileHelper.tiles[i + j], x, y, 8, 8);
                    }
                }

                scrambledNameList.Add(bitmap);
            }
        }

        public static void CreateNameList()
        {
            nameList = new List<Bitmap>();
            Rectangle section1 = new Rectangle(0, 7, 32, 1);
            Rectangle section2 = new Rectangle(8, 0, 32, 5);
            Rectangle section3 = new Rectangle(32, 5, 32, 3);
            Rectangle section4 = new Rectangle(40, 0, 32, 3);
            Rectangle section5 = new Rectangle(64, 7, 32, 1);
            Rectangle section6 = new Rectangle(72, 0, 32, 5);
            Rectangle section7 = new Rectangle(96, 5, 32, 3);
            Rectangle section8 = new Rectangle(104, 0, 32, 3);

            foreach (Bitmap scrambledName in scrambledNameList)
            {
                Bitmap bitmap = new Bitmap(64, 12);
                Graphics canvas = Graphics.FromImage(bitmap);
                canvas.DrawImage(scrambledName, 0, 0, section1, GraphicsUnit.Pixel);
                canvas.DrawImage(scrambledName, 0, 1, section2, GraphicsUnit.Pixel);
                canvas.DrawImage(scrambledName, 0, 6, section3, GraphicsUnit.Pixel);
                canvas.DrawImage(scrambledName, 0, 9, section4, GraphicsUnit.Pixel);
                canvas.DrawImage(scrambledName, 32, 0, section5, GraphicsUnit.Pixel);
                canvas.DrawImage(scrambledName, 32, 1, section6, GraphicsUnit.Pixel);
                canvas.DrawImage(scrambledName, 32, 6, section7, GraphicsUnit.Pixel);
                canvas.DrawImage(scrambledName, 32, 9, section8, GraphicsUnit.Pixel);
                nameList.Add(bitmap);
            }
        }
    }
}
