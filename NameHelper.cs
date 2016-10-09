// Copyright (c) 2016 Tom Overton
// Class for converting 8x8 tiles to 64x12 name bitmaps and vice versa.

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

        private static Rectangle section1 = new Rectangle(0, 7, 32, 1);
        private static Rectangle section2 = new Rectangle(8, 0, 32, 5);
        private static Rectangle section3 = new Rectangle(32, 5, 32, 3);
        private static Rectangle section4 = new Rectangle(40, 0, 32, 3);
        private static Rectangle section5 = new Rectangle(64, 7, 32, 1);
        private static Rectangle section6 = new Rectangle(72, 0, 32, 5);
        private static Rectangle section7 = new Rectangle(96, 5, 32, 3);
        private static Rectangle section8 = new Rectangle(104, 0, 32, 3);

        private static Rectangle reverseSection1 = new Rectangle(0, 0, 32, 1);
        private static Rectangle reverseSection2 = new Rectangle(0, 1, 32, 5);
        private static Rectangle reverseSection3 = new Rectangle(0, 6, 32, 3);
        private static Rectangle reverseSection4 = new Rectangle(0, 9, 32, 3);
        private static Rectangle reverseSection5 = new Rectangle(32, 0, 32, 1);
        private static Rectangle reverseSection6 = new Rectangle(32, 1, 32, 5);
        private static Rectangle reverseSection7 = new Rectangle(32, 6, 32, 3);
        private static Rectangle reverseSection8 = new Rectangle(32, 9, 32, 3);

        public NameHelper(string fileName)
        {
            this.tileHelper = new TileHelper(fileName);
            CreateScrambledNameList();
            CreateNameList();
        }

        public  void UpdateName(string file, int nameIndex)
        {
            Bitmap bitmap = (Bitmap)Image.FromFile(file);
            if (bitmap.Width != 64 || bitmap.Height != 12)
            {
                throw new ArgumentException("Supplied PNG is not the right size. Please use a 64x12 PNG.");
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
            canvas.DrawImage(name, 0, 7, reverseSection1, GraphicsUnit.Pixel);
            canvas.DrawImage(name, 8, 0, reverseSection2, GraphicsUnit.Pixel);
            canvas.DrawImage(name, 32, 5, reverseSection3, GraphicsUnit.Pixel);
            canvas.DrawImage(name, 40, 0, reverseSection4, GraphicsUnit.Pixel);
            canvas.DrawImage(name, 64, 7, reverseSection5, GraphicsUnit.Pixel);
            canvas.DrawImage(name, 72, 0, reverseSection6, GraphicsUnit.Pixel);
            canvas.DrawImage(name, 96, 5, reverseSection7, GraphicsUnit.Pixel);
            canvas.DrawImage(name, 104, 0, reverseSection8, GraphicsUnit.Pixel);
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
