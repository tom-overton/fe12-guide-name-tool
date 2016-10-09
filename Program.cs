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
        public static byte[] fileData;
        public static byte[] data;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Palette.InitializePalette();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FE12GuideNameForm());
        }

        public static Bitmap CreateFirstTile()
        {
            InitializeData();
            Bitmap result = new Bitmap(8, 8);
            for (int i = 0; i < 64; i++)
            {
                int x = i % 8;
                int y = i / 8;
                Color color = Palette.Lookup(data[i]);
                result.SetPixel(x, y, color);
            }

            return result;
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
