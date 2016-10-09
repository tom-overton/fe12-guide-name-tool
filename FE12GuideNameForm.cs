using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FE12GuideNameTool
{
    public partial class FE12GuideNameForm : Form
    {
        public FE12GuideNameForm()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                filenameBox.Text = file;
                try
                {
                    TileHelper.InitializeTileHelper(File.ReadAllBytes(file));
                    Bitmap test = TileHelper.CreateBigTestBitmap();
                    pictureBox1.Image = test;
                }
                catch (IOException)
                {
                }
            }
        }
    }
}
