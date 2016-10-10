// Copyright (c) 2016 Tom Overton

using System;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace FE12GuideNameTool
{
    public partial class FE12GuideNameForm : Form
    {
        private NameHelper nameHelper;

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
                    InitializeStateFromFile(file);
                }
                catch (Exception ex)
                {
                    ShowErrorBox("An error occurred while opening the PKCG: \n" + ex.Message);
                }
            }
        }

        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nameListBox.SelectedIndex >= 0 && nameListBox.SelectedIndex < nameHelper.nameList.Count)
            {
                namePictureBox.Image = nameHelper.nameList[nameListBox.SelectedIndex];
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            DialogResult result = exportPngSaveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = exportPngSaveFileDialog.FileName;
                nameHelper.nameList[nameListBox.SelectedIndex].Save(file, ImageFormat.Png);
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            DialogResult result = importPngOpenFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    nameHelper.UpdateName(importPngOpenFileDialog.FileName, nameListBox.SelectedIndex);
                    namePictureBox.Image = nameHelper.nameList[nameListBox.SelectedIndex];
                }
                catch (Exception ex)
                {
                    ShowErrorBox("An error occurred while importing the PNG: \n" + ex.Message);
                }
            }
        }

        private void InitializeStateFromFile(string fileName)
        {
            nameHelper = new NameHelper(fileName);
            namePictureBox.Image = nameHelper.nameList[0];

            // Clear this in case this is the second file the user has opened.
            nameListBox.Items.Clear();
            for (int i = 0; i < nameHelper.nameList.Count; i++)
            {
                nameListBox.Items.Add("Name" + i);
            }

            nameListBox.SelectedIndex = 0;
        }

        private void ShowErrorBox(string message)
        {
            MessageBox.Show(message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
