// Copyright (c) 2016 Tom Overton

namespace FE12GuideNameTool
{
    partial class FE12GuideNameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FE12GuideNameForm));
            this.filenameBox = new System.Windows.Forms.TextBox();
            this.OpenFile = new System.Windows.Forms.Button();
            this.pkcgOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.zoomedNamePictureBox = new System.Windows.Forms.PictureBox();
            this.nameListBox = new System.Windows.Forms.ListBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.exportPngSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.importPngOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.namePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.zoomedNamePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.namePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // filenameBox
            // 
            this.filenameBox.Location = new System.Drawing.Point(12, 12);
            this.filenameBox.Multiline = true;
            this.filenameBox.Name = "filenameBox";
            this.filenameBox.Size = new System.Drawing.Size(179, 23);
            this.filenameBox.TabIndex = 0;
            this.filenameBox.WordWrap = false;
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(197, 12);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(75, 23);
            this.OpenFile.TabIndex = 1;
            this.OpenFile.Text = "Open File";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // pkcgOpenFileDialog
            // 
            this.pkcgOpenFileDialog.Filter = "PKCG files|*.pkcg|All Files|*.*";
            // 
            // zoomedNamePictureBox
            // 
            this.zoomedNamePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zoomedNamePictureBox.Location = new System.Drawing.Point(12, 91);
            this.zoomedNamePictureBox.Name = "zoomedNamePictureBox";
            this.zoomedNamePictureBox.Size = new System.Drawing.Size(128, 45);
            this.zoomedNamePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.zoomedNamePictureBox.TabIndex = 2;
            this.zoomedNamePictureBox.TabStop = false;
            // 
            // nameListBox
            // 
            this.nameListBox.FormattingEnabled = true;
            this.nameListBox.Location = new System.Drawing.Point(146, 41);
            this.nameListBox.Name = "nameListBox";
            this.nameListBox.Size = new System.Drawing.Size(126, 95);
            this.nameListBox.TabIndex = 3;
            this.nameListBox.SelectedIndexChanged += new System.EventHandler(this.nameListBox_SelectedIndexChanged);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(12, 142);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(128, 23);
            this.exportButton.TabIndex = 4;
            this.exportButton.Text = "Export to PNG";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(146, 142);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(126, 23);
            this.importButton.TabIndex = 5;
            this.importButton.Text = "Import from PNG";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // exportPngSaveFileDialog
            // 
            this.exportPngSaveFileDialog.Filter = "PNG files|*.png|All Files|*.*";
            // 
            // importPngOpenFileDialog
            // 
            this.importPngOpenFileDialog.Filter = "PNG files|*.png|All Files|*.*";
            // 
            // namePictureBox
            // 
            this.namePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.namePictureBox.Location = new System.Drawing.Point(12, 41);
            this.namePictureBox.Name = "namePictureBox";
            this.namePictureBox.Size = new System.Drawing.Size(128, 44);
            this.namePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.namePictureBox.TabIndex = 6;
            this.namePictureBox.TabStop = false;
            // 
            // FE12GuideNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 174);
            this.Controls.Add(this.namePictureBox);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.nameListBox);
            this.Controls.Add(this.zoomedNamePictureBox);
            this.Controls.Add(this.OpenFile);
            this.Controls.Add(this.filenameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FE12GuideNameForm";
            this.Text = "FE12 Guide Name Tool";
            ((System.ComponentModel.ISupportInitialize)(this.zoomedNamePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.namePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox filenameBox;
        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.OpenFileDialog pkcgOpenFileDialog;
        private System.Windows.Forms.PictureBox zoomedNamePictureBox;
        private System.Windows.Forms.ListBox nameListBox;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.SaveFileDialog exportPngSaveFileDialog;
        private System.Windows.Forms.OpenFileDialog importPngOpenFileDialog;
        private System.Windows.Forms.PictureBox namePictureBox;
    }
}

