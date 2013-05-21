using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LemmaSharp;
using ReverseDictionary.DictionaryMakers;
using TextLoader.FileLoader;
using TextLoader.FileSaver;

namespace ReverseDictionary.DictionaryControls
{
    public partial class DictionaryView : UserControl
    {
        private readonly TextLoaderFactory _loaderFactory = new TextLoaderFactory();

        private IDictionary<String, int> _dictionary;
        private IList<ViewItem> _dataSource;
        private readonly IDictionaryMaker _dictionaryMaker = new ReverseDictionaryMaker();
        private bool _dictionaryChanged;
        private String _fileName = String.Empty;

        
        public event EventHandler<EventArgs> NeedTextForDictionary;

        public IList<ViewItem> GetItems()
        {
            return _dataSource;
        }

        public virtual void OnNeedDictionary(EventArgs e)
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

        public void CreateDictionary(String text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                _dictionary = _dictionaryMaker.MakeDictionary(text,
                                                              new LemmatizerPrebuiltCompact((LanguagePrebuilt)_langComboBox.SelectedItem));

                // TODO: do it with backgroung worker due to hangling gui
                SetDataSource(_dictionary);
                
                EnableSaveButtons(true);
                EnableChangeSortOrderButton(true);
            }
        }

        public void EnableMakeDictionaryButton(bool value)
        {
            _makeButton.Enabled = value;
        }

        private void SetDataSource(IDictionary<String, int> dict)
        {
            _dataSource = dict.Select(x => new ViewItem { Count = x.Value, Word = x.Key }).ToList();
            _gridView.DataSource = _dataSource;
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
            EnableChangeSortOrderButton(true);
        }

        private void DictFromTxt(string text)
        {
            if (_dictionary == null)
                _dictionary = _dictionaryMaker.InitDictionary();
            else 
                _dictionary.Clear();
            string[] strList = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var str in strList) {
                string[] record = str.Split(' ');
                _dictionary[record[0]] = Int32.Parse(record[1]);
            }

            SetDataSource(_dictionary);
        }

        private void WriteDictToFile(string path)
        {
            //File.WriteAllLines(path, _dataSource.Select(x => x.Word + " " + x.Count));
            _saver.SaveFile(path, _dataSource.Select(x => x.Word + " " + x.Count).ToList());
        }

        private void SaveDictionary(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_fileName))
                SaveDictionaryAs(sender, e);
            else
                WriteDictToFile(_fileName);
        }

        private ITextSaver _saver = new TxtTextSaver();

        private void SaveDictionaryAs(object sender, EventArgs e)
        {
            _saveFileDialog.Filter = "Text files (*.txt)|*.txt| Excel files (*.xls)|*.xls";
            _saveFileDialog.FileName = Path.GetFileName(_fileName);
            if (_saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            if(_saveFileDialog.FilterIndex == 1)
            {
                _saver = new TxtTextSaver();
            }
            else
            {
                _saver = new XlsTextSaver();
            }

            _fileName = _saveFileDialog.FileName;
            WriteDictToFile(_fileName);
        }

        private void EnableSaveButtons(bool value)
        {
            _saveButton.Enabled = _saveAsButton.Enabled = value;
        }

        private void EnableChangeSortOrderButton(bool value)
        {
            _sortDirectionButton.Enabled = value;
        }

        private void SaveClick(Object sender, EventArgs e)
        {
            if (_fileName == String.Empty)
                SaveAsClick(sender, e);
            else
                SaveFile();
        }

        private void SaveAsClick(Object sender, EventArgs e)
        {
            if (_saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            _fileName = _saveFileDialog.FileName;
            SaveFile();
        }

        private void SortingOrderChanged(Object sender, EventArgs e)
        {
            _dictionary = _sortDirectionButton.Checked 
                ? new SortedDictionary<string, int>(_dictionary, new ReverseStringComparer()) 
                : new SortedDictionary<string, int>(_dictionary);
            SetDataSource(_dictionary);
        }

        private void SaveFile()
        {
            var saver = new TxtTextSaver();
            //saver.SaveFile(_fileName, _gridView.Text);
        }

        public void CompareTo(IList<ViewItem> dict)
        {
            if(dict == null || _gridView.Rows.Count < 1)
            {
                return;
            }

            for(int i = 0; i < _gridView.Rows.Count; i++)
            {
                foreach (var viewItem in dict)
                {
                    if ((String)_gridView[0, i].Value == viewItem.Word)
                    {
                        _gridView[0, i].Style.BackColor = Color.Yellow;
                    }
                }
                if (_gridView[0, i].Style.BackColor != Color.Yellow)
                {
                    _gridView[0, i].Style.BackColor = Color.Green;
                }
            }

        }

        private void SaveCompared(Object sender, EventArgs e)
        {
            SaveIntersection();
            SaveDifferentWords();
        }

        private void SaveIntersection()
        {
            _saveFileDialog.Filter = "Text files (*.txt)|*.txt| Excel files (*.xls)|*.xls";
            _saveFileDialog.Title = "Save words included in another dictionary";
            _saveFileDialog.FileName = Path.GetFileName(_fileName);
            if (_saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            if (_saveFileDialog.FilterIndex == 1)
            {
                _saver = new TxtTextSaver();
            }
            else
            {
                _saver = new XlsTextSaver();
            }

            var path = _saveFileDialog.FileName;

            List<String> records = new List<String>();

            for (int i = 0; i < _gridView.Rows.Count; i++)
            {
                if (_gridView[0, i].Style.BackColor == Color.Yellow)
                {
                    records.Add(_gridView[0, i].Value + " " + _gridView[1, i].Value);
                }
            }

            _saver.SaveFile(path, records);

        }

        private void SaveDifferentWords()
        {
            _saveFileDialog.Filter = "Text files (*.txt)|*.txt| Excel files (*.xls)|*.xls";
            _saveFileDialog.Title = "Save words not included in another dictionary";
            _saveFileDialog.FileName = Path.GetFileName(_fileName);
            if (_saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            if (_saveFileDialog.FilterIndex == 1)
            {
                _saver = new TxtTextSaver();
            }
            else
            {
                _saver = new XlsTextSaver();
            }

            var path = _saveFileDialog.FileName;

            List<String> records = new List<String>();

            for (int i = 0; i < _gridView.Rows.Count; i++)
            {
                if (_gridView[0, i].Style.BackColor == Color.Green)
                {
                    records.Add(_gridView[0, i].Value + " " + _gridView[1, i].Value);
                }
            }

            _saver.SaveFile(path, records);
        }
    }
}
