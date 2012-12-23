using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LemmaSharp;
using ReverseDictionary.DictionaryControls;
using ReverseDictionary.DictionaryMakers;
using TextLoader.FileSaver;
using TextLoader.FileLoader;

namespace ReverseDictionary
{
    public partial class MainForm : Form
    {
        private readonly TextLoaderFactory _loaderFactory = new TextLoaderFactory();
        
        private bool _dictionaryChanged;
        private String _fileName = String.Empty;

        public MainForm()
        {
            InitializeComponent();

            _openFileDialog.Filter = _loaderFactory.GetAvailableLoaders();

        }

        private void SaveFile()
        {
            var saver = new TxtTextSaver();
        }

        #region Event handlers

        private void OpenFileClick(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            ITextLoader loader = _loaderFactory.GetLoader(_openFileDialog.FilterIndex);
            // Open and read file
            loader.LoadFile(_openFileDialog.FileName);
            _textBox.Text = loader.ExtractText();
        }

        private void SaveFileClick(object sender, EventArgs e)
        {
            if (_fileName == String.Empty)
                SaveAsClick(sender, e);
            else
                SaveFile();
        }

        private void SaveAsClick(object sender, EventArgs e)
        {
            if (_saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            _fileName = _saveFileDialog.FileName;
            SaveFile();
        }

        private void AboutMenuItem1Click(object sender, EventArgs e)
        {
            var dlg = new AboutBox();
            dlg.ShowDialog();
        }

        private void ExitMenuItemClick(object sender, EventArgs e)
        {
            if (_dictionaryChanged)
            {
                DialogResult result = MessageBox.Show("There are unsaved changes. Do you want to save?", "Save Changes",
                    MessageBoxButtons.YesNoCancel);

                switch (result)
                {
                    case DialogResult.OK:
                        SaveFileClick(null, null);
                        break;

                    case DialogResult.Cancel:
                        return;

                    case DialogResult.No:
                        Close();
                        break;
                }
            }
        }

        private void NeedTextForDictionaryHandler(object sender, EventArgs e)
        {
            var view = sender as DictionaryView;

            if(view != null)
                view.CreateDictionary(_textBox.Text);
        }

        #endregion

        private void dictionaryView1_NeedTextForDictionary(object sender, EventArgs e)
        {

        }
    }
}
