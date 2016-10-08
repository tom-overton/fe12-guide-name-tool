using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FE12GuideNameTool
{
    static class Program
    {
        public static Dictionary<int, Color> palette = new Dictionary<int, Color>();
        public static byte[] fileData;
        public static byte[] data;
        private static byte first16BitsMask = 0x0F;
        private static byte second16BitsMask = 0xF0;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitializePalette();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void InitializeData()
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

        private static void InitializePalette()
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
    }
}
