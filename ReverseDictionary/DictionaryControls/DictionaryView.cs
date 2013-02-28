using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LemmaSharp;
using ReverseDictionary.DictionaryMakers;
using ReverseDictionary.FileLoader;

namespace ReverseDictionary.DictionaryControls
{
    public partial class DictionaryView : UserControl
    {
        private readonly TextLoaderFactory _loaderFactory = new TextLoaderFactory();

        private IDictionary<String, int> _dictionary;
        private readonly IDictionaryMaker _dictionaryMaker = new ReverseDictionaryMaker();
        private bool _dictionaryChanged;
        private String _fileName = String.Empty;

        
        public event EventHandler<EventArgs> NeedTextForDictionary;

        public void OnNeedDictionary(EventArgs e)
        {
            EventHandler<EventArgs> handler = NeedTextForDictionary;
            if(handler != null)
                handler(this, e);
        }

        public DictionaryView()
        {
            InitializeComponent();

            _langComboBox.Items.AddRange(Enum.GetValues(typeof(LanguagePrebuilt)).Cast<Object>().ToArray());
            _langComboBox.SelectedItem = LanguagePrebuilt.Russian;
            
            _openFileDialog.Filter = _loaderFactory.GetAvailableLoaders();

        }

        public void CompareToDictionary(IDictionary<String, int> otherDictionary)
        {
            foreach (var pair in _dictionary)
            {
                if (otherDictionary.ContainsKey(pair.Key))
                {
                    // change background color
                    //_gridView.Rows.IndexOf();
                }
            }
        }

        public void CreateDictionary(String text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                _dictionary = _dictionaryMaker.MakeDictionary(text,
                                                              new LemmatizerPrebuiltCompact((LanguagePrebuilt)_langComboBox.SelectedItem));

                _gridView.DataSource = _dictionary.Select(x => new ViewItem { Count = x.Value, Word = x.Key }).ToList();

                EnableSaveButtons(true);
            }
        }

        public void EnableMakeDictionaryButton(bool value)
        {
            _makeButton.Enabled = value;
        }

        private void MakeButtonClick(object sender, EventArgs e)
        {
            OnNeedDictionary(e);
        }

        private void OpenDictionary(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            ITextLoader loader = _loaderFactory.GetLoader(_openFileDialog.FilterIndex);
            // Open and read file
            _fileName = _openFileDialog.FileName;
            loader.LoadFile(_fileName);
            DictFromTxt(loader.ExtractText());

            EnableSaveButtons(true);
        }

        private void DictFromTxt(string text)
        {
            if (_dictionary == null)
                _dictionary = _dictionaryMaker.InitDictionary();
            else 
                _dictionary.Clear();
            string[] strList = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var str in strList) {
                string[] record = str.Split(' ');
                _dictionary[record[0]] = Int32.Parse(record[1]);
            }

            _gridView.DataSource = _dictionary.Select(x => new ViewItem { Count = x.Value, Word = x.Key }).ToList();
        }

        private void WriteDictToFile(string path)
        {
            File.WriteAllLines(path, _dictionary.Select(x => x.Key + " " + x.Value));
        }

        private void SaveDictionary(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_fileName))
                SaveDictionaryAs(sender, e);
            else
            {
                WriteDictToFile(_fileName);
            }
        }

        private void SaveDictionaryAs(object sender, EventArgs e)
        {
            _saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            _saveFileDialog.FileName = Path.GetFileName(_fileName);
            if (_saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            _fileName = _saveFileDialog.FileName;
            WriteDictToFile(_fileName);
        }

        private void EnableSaveButtons(bool value)
        {
            _saveButton.Enabled = _saveAsButton.Enabled = value;
        }
    }
}
