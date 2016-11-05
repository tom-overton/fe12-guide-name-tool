// Copyright (c) 2016 Tom Overton
// Palette represents the 16-color palette used in FE12's Guide names.

using System;
using System.Collections.Generic;
using System.Drawing;

namespace FE12GuideNameTool
{
    public class Palette
    {
        /// <summary>
        /// The two bytes located at this offset tells us the location of the palette in the PKCG file.
        /// </summary>
        private static int paletteLocationOffset = 0x0C;

        private Dictionary<byte, Color> palette = new Dictionary<byte, Color>();
        private Dictionary<Color, byte> reversePalette = new Dictionary<Color, byte>();

        public Palette(byte[] fileData)
        {
            this.InitializePalette(fileData);
        }

        /// <summary>
        /// Returns the color associated with the given index in the palette. If the index is not valid, it will throw an error.
        /// </summary>
        public Color Lookup(byte index)
        {
            Color result;
            if (!palette.TryGetValue(index, out result))
            {
                string message = "Attempted to lookup invalid palette index. \n" +
                                 "Ensure the index is in the range of 0 to 15, inclusive.";
                throw new ArgumentException(message);
            }

            return result;
        }

        /// <summary>
        /// Returns the index associated with a given color in the palette. If the color is not in the palette, it will throw an error.
        /// </summary>
        public byte ReverseLookup(Color color)
        {
            byte result;
            if (!reversePalette.TryGetValue(color, out result))
            {
                string colorString = "(" + color.R + ", " + color.G + ", " + color.B + ")";
                string message = "Supplied PNG contains the invalid color " + colorString + ".\n" +
                                 "Ensure all colors in the image are part of the palette.";
                throw new ArgumentException(message);
            }

            return result;
        }

        private void InitializePalette(byte[] fileData)
        {
            int paletteLocation = this.ReadLittleEndianShort(fileData, paletteLocationOffset);
            for (byte i = 0; i < 16; i++)
            {
                int colorLocation = paletteLocation + (2 * i);
                int bgr555 = this.ReadLittleEndianShort(fileData, colorLocation);
                int r = bgr555 & 31;
                int g = (bgr555 >> 5) & 31;
                int b = (bgr555 >> 10) & 31;
                this.AddColor(i, r * 8, g * 8, b * 8);
            }
        }

        private void AddColor(byte index, int r, int g, int b)
        {
            Color color = Color.FromArgb(r, g, b);

            // For some files, two things in the palette have the same color. In that case,
            // differentiate them with a red color.
            byte duplicateIndex;
            if (reversePalette.TryGetValue(color, out duplicateIndex))
            {
                color = Color.FromArgb(248, 0, 0);
            }

            palette.Add(index, color);
            reversePalette.Add(color, index);
        }

        private short ReadLittleEndianShort(byte[] data, int offset)
        {
            byte leastSignificantByte = data[offset];
            byte mostSignificantByte = data[offset + 1];
            return (short)((mostSignificantByte * 256) + leastSignificantByte);
        }
    }
}
