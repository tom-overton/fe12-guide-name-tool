using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Imaging;
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
            DialogResult result = pkcgOpenFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = pkcgOpenFileDialog.FileName;
                filenameBox.Text = file;
                try
                {
                    NameHelper.InitializeNameHelper(file);
                    NameHelper.CreateScrambledNameList();
                    pictureBox1.Image = NameHelper.nameList[0];

                    // Clear this in case this is the second file the user has opened.
                    nameListBox.Items.Clear();
                    for (int i = 0; i < NameHelper.nameList.Count; i++)
                    {
                        nameListBox.Items.Add("Name" + i);
                    }

                    nameListBox.SelectedIndex = 0;
                }
                catch (IOException)
                {
                }
            }
        }

        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nameListBox.SelectedIndex >= 0 && nameListBox.SelectedIndex < NameHelper.nameList.Count)
            {
                pictureBox1.Image = NameHelper.nameList[nameListBox.SelectedIndex];
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            DialogResult result = exportPngSaveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = exportPngSaveFileDialog.FileName;
                NameHelper.nameList[nameListBox.SelectedIndex].Save(file, ImageFormat.Png);
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            DialogResult result = importPngOpenFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                NameHelper.UpdateName(importPngOpenFileDialog.FileName, nameListBox.SelectedIndex);
            }
        }
    }
}
