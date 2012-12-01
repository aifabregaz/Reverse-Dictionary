using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LemmaSharp;
using ReverseDictionary.DictionaryMakers;
using ReverseDictionary.FileLoader;
using ReverseDictionary.FileSaver;

namespace ReverseDictionary
{
    public partial class MainForm : Form
    {
        private readonly TextLoaderFactory _loaderFactory = new TextLoaderFactory();
        private readonly IDictionaryMaker _dictionaryMaker = new ReverseDictionaryMaker(); 
        private IDictionary<String, int> _dictionary;

        public MainForm()
        {
            InitializeComponent();

            _openFileDialog.Filter = _loaderFactory.GetAvailableLoaders();

            _langComboBox.Items.AddRange(Enum.GetValues(typeof(LanguagePrebuilt)).Cast<Object>().ToArray());
            _langComboBox.SelectedIndex = 0;
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

            var saver = new TxtTextSaver();
            //TODO: write dict to file
        }

        private void SaveAsButtonClick(object sender, EventArgs e)
        {
            
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
            // TODO: check for changes
            if (!String.IsNullOrEmpty(_dictionatyTextBox.Text))
                _dictionatyTextBox.Text = String.Empty;

            if (!String.IsNullOrEmpty(_textBox.Text))
                _dictionary = _dictionaryMaker.MakeDictionary(_textBox.Text,
                                                              new LemmatizerPrebuiltCompact((LanguagePrebuilt)_langComboBox.SelectedItem));
            _dictionatyTextBox.Lines = _dictionary.Keys.ToArray();
        }

        #endregion
    }
}
