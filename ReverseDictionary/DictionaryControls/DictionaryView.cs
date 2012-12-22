using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LemmaSharp;
using ReverseDictionary.DictionaryMakers;

namespace ReverseDictionary.DictionaryControls
{
    public partial class DictionaryView : UserControl
    {
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
        }

        public void CompareToDictionary(IDictionary<String, int> otherDictionary)
        {
            foreach (var pair in _dictionary)
            {
                //if (otherDictionary.ContainsKey(pair.Key))
                //{
                //    // change background color
                //    _gridView.Rows.IndexOf()
                //}
            }
        }

        public void CreateDictionary(String text)
        {
            if (!String.IsNullOrEmpty(text))
                _dictionary = _dictionaryMaker.MakeDictionary(text,
                                                              new LemmatizerPrebuiltCompact((LanguagePrebuilt)_langComboBox.SelectedItem));

            _gridView.DataSource = _dictionary.Select(x => new ViewItem { Count = x.Value, Word = x.Key }).ToList();
        }

        private void MakeButtonClick(object sender, EventArgs e)
        {
            OnNeedDictionary(e);
        }
    }
}
