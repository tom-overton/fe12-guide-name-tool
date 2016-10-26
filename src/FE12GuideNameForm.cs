// Copyright (c) 2016 Tom Overton

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
                SetPictureBoxState(nameListBox.SelectedIndex);
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
                    SetPictureBoxState(nameListBox.SelectedIndex);
                }
                catch (Exception ex)
                {
                    ShowErrorBox("An error occurred while importing the PNG: \n" + ex.Message);
                }
            }
        }

        private void ShowErrorBox(string message)
        {
            MessageBox.Show(message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void InitializeStateFromFile(string fileName)
        {
            nameHelper = new NameHelper(fileName);
            SetPictureBoxState(0);
            InitializeNameListBoxContents(fileName);
            nameListBox.SelectedIndex = 0;
        }

        private void InitializeNameListBoxContents(string fileName)
        {
            // Clear this in case this is the second file the user has opened.
            nameListBox.Items.Clear();
            List<string> nameList = NameFileMapper.GetNamesForFile(fileName);

            for (int i = 0; i < nameHelper.nameList.Count; i++)
            {
                if (nameList != null && i < nameList.Count)
                {
                    nameListBox.Items.Add(nameList[i]);
                }
                else
                {
                    nameListBox.Items.Add("Name" + i);
                }
            }
        }

        private void SetPictureBoxState(int index)
        {
            namePictureBox.Image = nameHelper.nameList[index];
            zoomedNamePictureBox.Image = GetZoomedGraphic(nameHelper.nameList[index], 2);
        }

        private Bitmap GetZoomedGraphic(Bitmap originalGraphic, int zoomFactor)
        {
            Bitmap newGraphic = new Bitmap(originalGraphic.Width * zoomFactor, originalGraphic.Height * zoomFactor);
            Graphics canvas = Graphics.FromImage(newGraphic);
            canvas.InterpolationMode = InterpolationMode.NearestNeighbor;
            canvas.DrawImage(originalGraphic, 0, 0, newGraphic.Width, newGraphic.Height);
            canvas.Dispose();
            return newGraphic;
        }
    }
}
