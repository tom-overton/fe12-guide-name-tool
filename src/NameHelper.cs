// Copyright (c) 2016 Tom Overton
// Class for converting 8x8 tiles to 64x16 name bitmaps and vice versa.

using System;
using System.Collections.Generic;
using System.Drawing;

namespace FE12GuideNameTool
{
    public class NameHelper
    {
        public List<Bitmap> scrambledNameList;
        public List<Bitmap> nameList;

        private TileHelper tileHelper;
        private int xDim = 136;
        private int yDim = 8;

        // Describes the position and size of each section of the name within the larger scrambled name graphic.
        private static Rectangle scrambledSection1 = new Rectangle(0, 5, 32, 3);
        private static Rectangle scrambledSection2 = new Rectangle(8, 0, 32, 5);
        private static Rectangle scrambledSection3 = new Rectangle(32, 5, 32, 3);
        private static Rectangle scrambledSection4 = new Rectangle(40, 0, 32, 5);
        private static Rectangle scrambledSection5 = new Rectangle(64, 5, 32, 3);
        private static Rectangle scrambledSection6 = new Rectangle(72, 0, 32, 5);
        private static Rectangle scrambledSection7 = new Rectangle(96, 5, 32, 3);
        private static Rectangle scrambledSection8 = new Rectangle(104, 0, 32, 5);

        // Describes the position and size of the above sections once placed within the "correct" name graphic.
        private static Rectangle section1 = new Rectangle(0, 0, 32, 3);
        private static Rectangle section2 = new Rectangle(0, 3, 32, 5);
        private static Rectangle section3 = new Rectangle(0, 8, 32, 3);
        private static Rectangle section4 = new Rectangle(0, 11, 32, 5);
        private static Rectangle section5 = new Rectangle(32, 0, 32, 3);
        private static Rectangle section6 = new Rectangle(32, 3, 32, 5);
        private static Rectangle section7 = new Rectangle(32, 8, 32, 3);
        private static Rectangle section8 = new Rectangle(32, 11, 32, 5);

        public NameHelper(string fileName)
        {
            this.tileHelper = new TileHelper(fileName);
            CreateScrambledNameList();
            CreateNameList();
        }

        public  void UpdateName(string file, int nameIndex)
        {
            Bitmap bitmap = (Bitmap)Image.FromFile(file);
            if (bitmap.Width != 64 || bitmap.Height != 16)
            {
                throw new ArgumentException("Supplied PNG is not the right size. Please use a 64x16 PNG.");
            }

            UpdateScrambledName(bitmap, nameIndex);
            nameList[nameIndex] = bitmap;
        }

        public void CreateScrambledNameList()
        {
            scrambledNameList = new List<Bitmap>();

            for (int i = 0; i < tileHelper.tiles.Count; i += 16)
            {
                Bitmap bitmap = new Bitmap(xDim, yDim);
                Graphics canvas = Graphics.FromImage(bitmap);
                bool discardCurrentTile = false;
                for (int j = 0; j < 17; j++)
                {
                    int x = j * 8;
                    int y = 0;
                    if (i + j < tileHelper.tiles.Count)
                    {
                        canvas.DrawImage(tileHelper.tiles[i + j], x, y, 8, 8);
                    }
                    else
                    {
                        discardCurrentTile = true;
                    }
                }

                canvas.Dispose();
                if (!discardCurrentTile)
                {
                    scrambledNameList.Add(bitmap);
                }
            }
        }

        private void CreateNameList()
        {
            nameList = new List<Bitmap>();
            foreach (Bitmap scrambledName in scrambledNameList)
            {
                Bitmap bitmap = new Bitmap(64, 16);
                Graphics canvas = Graphics.FromImage(bitmap);
                canvas.DrawImage(scrambledName, section1.X, section1.Y, scrambledSection1, GraphicsUnit.Pixel);
                canvas.DrawImage(scrambledName, section2.X, section2.Y, scrambledSection2, GraphicsUnit.Pixel);
                canvas.DrawImage(scrambledName, section3.X, section3.Y, scrambledSection3, GraphicsUnit.Pixel);
                canvas.DrawImage(scrambledName, section4.X, section4.Y, scrambledSection4, GraphicsUnit.Pixel);
                canvas.DrawImage(scrambledName, section5.X, section5.Y, scrambledSection5, GraphicsUnit.Pixel);
                canvas.DrawImage(scrambledName, section6.X, section6.Y, scrambledSection6, GraphicsUnit.Pixel);
                canvas.DrawImage(scrambledName, section7.X, section7.Y, scrambledSection7, GraphicsUnit.Pixel);
                canvas.DrawImage(scrambledName, section8.X, section8.Y, scrambledSection8, GraphicsUnit.Pixel);
                canvas.Dispose();
                nameList.Add(bitmap);
            }
        }

        private void UpdateScrambledName(Bitmap name, int nameIndex)
        {
            // Build the scrambled name from the unscrambled bitmap
            Bitmap bitmap = new Bitmap(xDim, yDim);
            Graphics canvas = Graphics.FromImage(bitmap);
            canvas.DrawImage(scrambledNameList[nameIndex], 0, 0, xDim, yDim);
            canvas.DrawImage(name, scrambledSection1.X, scrambledSection1.Y, section1, GraphicsUnit.Pixel);
            canvas.DrawImage(name, scrambledSection2.X, scrambledSection2.Y, section2, GraphicsUnit.Pixel);
            canvas.DrawImage(name, scrambledSection3.X, scrambledSection3.Y, section3, GraphicsUnit.Pixel);
            canvas.DrawImage(name, scrambledSection4.X, scrambledSection4.Y, section4, GraphicsUnit.Pixel);
            canvas.DrawImage(name, scrambledSection5.X, scrambledSection5.Y, section5, GraphicsUnit.Pixel);
            canvas.DrawImage(name, scrambledSection6.X, scrambledSection6.Y, section6, GraphicsUnit.Pixel);
            canvas.DrawImage(name, scrambledSection7.X, scrambledSection7.Y, section7, GraphicsUnit.Pixel);
            canvas.DrawImage(name, scrambledSection8.X, scrambledSection8.Y, section8, GraphicsUnit.Pixel);
            canvas.Dispose();

            // Turn the new scrambled name into a set of tiles to send to the TileHelper
            List<Bitmap> newTiles = new List<Bitmap>();
            for (int i = 0; i < 17; i++)
            {
                Rectangle tileSection = new Rectangle(i * 8, 0, 8, 8);
                Bitmap tile = new Bitmap(8, 8);
                canvas = Graphics.FromImage(tile);
                canvas.DrawImage(bitmap, 0, 0, tileSection, GraphicsUnit.Pixel);
                newTiles.Add(tile);
                canvas.Dispose();
            }

            tileHelper.UpdateTiles(newTiles, nameIndex * 16);
            scrambledNameList[nameIndex] = bitmap;
        }
    }
}
