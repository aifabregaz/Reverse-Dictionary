using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ReverseDictionary.FileLoader;

namespace ReverseDictionary
{
    public partial class MainForm : Form
    {
        private readonly TextLoaderFactory _loaderFactory = new TextLoaderFactory();

        public MainForm()
        {
            InitializeComponent();

            _openFileDialog.Filter = _loaderFactory.GetAvailableLoaders();
        }

        private void OpenFileClick(object sender, EventArgs e)
        {
            if(_openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            ITextLoader loader = _loaderFactory.GetLoader(_openFileDialog.FilterIndex);
            // Open and read file
            loader.LoadFile(_openFileDialog.FileName);
            _textBox.Text = loader.ExtractText();
        }
    }
}
