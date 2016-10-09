// Copyright (c) 2016 Tom Overton
// Class for converting palette index to RGB color and vice versa.

using System;
using System.Collections.Generic;
using System.Drawing;

namespace FE12GuideNameTool
{
    public static class Palette
    {
        private static Dictionary<int, Color> palette = new Dictionary<int, Color>();
        private static Dictionary<Color, int> reversePalette = new Dictionary<Color, int>();

        public static void AddColor(int index, int r, int g, int b)
        {
            Color color = Color.FromArgb(r, g, b);

            // For some files, two things in the palette have the same color. In that case,
            // differentiate them with a red color.
            int duplicateIndex;
            if (reversePalette.TryGetValue(color, out duplicateIndex))
            {
                color = Color.FromArgb(248, 0, 0);
            }

            palette.Add(index, color);
            reversePalette.Add(color, index);
        }

        public static void ClearPalette()
        {
            palette.Clear();
            reversePalette.Clear();
        }

        public static Color Lookup(int index)
        {
            Color result;
            if (!palette.TryGetValue(index, out result))
            {
                string message = "Attempted to lookup invalid palette index. \n" +
                                 "Please contact the developer if you see this error.";
                throw new ArgumentException(message);
            }

            return result;
        }

        public static int ReverseLookup(Color color)
        {
            int result;
            if (!reversePalette.TryGetValue(color, out result))
            {
                string message = "Supplied PNG contains an invalid color. \n" +
                                 "Ensure all colors in the image are part of the palette.";
                throw new ArgumentException(message);
            }

            return result;
        }
    }
}
