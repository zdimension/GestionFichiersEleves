﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestionFichiersEleves
{
    public partial class FileSelector : UserControl
    {
        public FileSelector()
        {
            InitializeComponent();
            SetStyle(
                ControlStyles.DoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor, true);
        }

        [Category("Action")]
        public event EventHandler SelectedFileChanged = delegate { };

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (ofpFile.ShowDialog() == DialogResult.OK)
            {
                setLabelText(ofpFile.FileName);
            }
        }

        public string FileName
        {
            get { return fName; }
            set { fName = value; setLabelText(fName); SelectedFileChanged(this, EventArgs.Empty); }
        }

        private string fName = "";

        private void FileSelector_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var fls = (string[])e.Data.GetData(DataFormats.FileDrop);
                if(fls.Length == 1)
                {
                    if(Path.GetExtension(fls[0]).ToLower() == ".csv")
                    {
                        e.Effect = DragDropEffects.Copy;
                        return;
                    }
                }
            }
            e.Effect = DragDropEffects.None;
        }

        private void FileSelector_DragDrop(object sender, DragEventArgs e)
        {
            var fls = (string[])e.Data.GetData(DataFormats.FileDrop);
            
            setLabelText(fls[0]);
        }

        private void setLabelText(string t)
        {
            txtFile.ForeColor = Color.Black;
            fName = t;
            setLabelTextWrap(t);
            ofpFile.InitialDirectory = Path.GetDirectoryName(t);
            toolTip1.SetToolTip(txtFile, t);
            SelectedFileChanged(this, EventArgs.Empty);
        }

        private void FileSelector_Load(object sender, EventArgs e)
        {
            
        }

        private void setLabelTextWrap(string t)
        {
            var wrapped = t.WrapPixel(txtFile.Width - 18, Font);
            if (wrapped != t) wrapped += "...";
            txtFile.Text = wrapped;
        }

        private void txtFile_SizeChanged(object sender, EventArgs e)
        {
            var s = txtFile.Size;
            setLabelTextWrap(fName);
            txtFile.Size = s;
        }
    }
}