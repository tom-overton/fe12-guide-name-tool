// Copyright (c) 2016 Tom Overton
// Class for converting palette index to RGB color and vice versa.

using System.Collections.Generic;
using System.Drawing;

namespace FE12GuideNameTool
{
    public static class Palette
    {
        private static Dictionary<int, Color> palette = new Dictionary<int, Color>();
        private static Dictionary<Color, int> reversePalette = new Dictionary<Color, int>();

        public static void InitializePalette()
        {
            InitializeForwardPalette();
            InitializeReversePalette();
        }

        public static Color Lookup(int index)
        {
            return palette[index];
        }

        public static int ReverseLookup(Color color)
        {
            return reversePalette[color];
        }

        private static void InitializeForwardPalette()
        {
            palette.Add(0, Color.FromArgb(0, 0, 0));
            palette.Add(1, Color.FromArgb(248, 248, 248));
            palette.Add(2, Color.FromArgb(184, 184, 184));
            palette.Add(3, Color.FromArgb(144, 144, 144));
            palette.Add(4, Color.FromArgb(112, 112, 112));
            palette.Add(5, Color.FromArgb(96, 96, 96));
            palette.Add(6, Color.FromArgb(80, 80, 80));
            palette.Add(7, Color.FromArgb(64, 64, 64));
            palette.Add(8, Color.FromArgb(48, 48, 48));
            palette.Add(9, Color.FromArgb(32, 32, 32));
            palette.Add(10, Color.FromArgb(248, 0, 0));      // Unused?
            palette.Add(11, Color.FromArgb(0, 248, 0));      // Unused?
            palette.Add(12, Color.FromArgb(128, 80, 168));
            palette.Add(13, Color.FromArgb(0, 0, 248));      // Unused?
            palette.Add(14, Color.FromArgb(0, 48, 104));
            palette.Add(15, Color.FromArgb(48, 64, 128));
        }

        private static void InitializeReversePalette()
        {
            reversePalette.Add(Color.FromArgb(0, 0, 0), 0);
            reversePalette.Add(Color.FromArgb(248, 248, 248), 1);
            reversePalette.Add(Color.FromArgb(184, 184, 184), 2);
            reversePalette.Add(Color.FromArgb(144, 144, 144), 3);
            reversePalette.Add(Color.FromArgb(112, 112, 112), 4);
            reversePalette.Add(Color.FromArgb(96, 96, 96), 5);
            reversePalette.Add(Color.FromArgb(80, 80, 80), 6);
            reversePalette.Add(Color.FromArgb(64, 64, 64), 7);
            reversePalette.Add(Color.FromArgb(48, 48, 48), 8);
            reversePalette.Add(Color.FromArgb(32, 32, 32), 9);
            reversePalette.Add(Color.FromArgb(248, 0, 0), 10);      // Unused?
            reversePalette.Add(Color.FromArgb(0, 248, 0), 11);      // Unused?
            reversePalette.Add(Color.FromArgb(128, 80, 168), 12);
            reversePalette.Add(Color.FromArgb(0, 0, 248), 13);      // Unused?
            reversePalette.Add(Color.FromArgb(0, 48, 104), 14);
            reversePalette.Add(Color.FromArgb(48, 64, 128), 15);
        }
    }
}
