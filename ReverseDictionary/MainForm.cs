using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ReverseDictionary.FileLoader;
using ReverseDictionary.FileSaver;

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

        #region Event handlers

        private void OpenFileClick(object sender, EventArgs e)
        {
            if(_openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            ITextLoader loader = _loaderFactory.GetLoader(_openFileDialog.FilterIndex);
            // Open and read file
            loader.LoadFile(_openFileDialog.FileName);
            _textBox.Text = loader.ExtractText();
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            if (_saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            TxtTextSaver saver = new TxtTextSaver();
            //TODO: write dict to file
            //TODO: add save as... handler
        }

        private void AboutMenuItem1Click(object sender, EventArgs e)
        {
            var dlg = new AboutBox();
            dlg.ShowDialog();
        }

        private void ExitMenuItemClick(object sender, EventArgs e)
        {
            // TODO: check for changes than save/close
            Close();
        }

        private void CreateDictionaryButtonClick(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
