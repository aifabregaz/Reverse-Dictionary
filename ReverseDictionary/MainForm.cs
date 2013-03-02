using System;
using System.Windows.Forms;
using ReverseDictionary.DictionaryControls;
using TextLoader.FileLoader;

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

        private void OpenFileClick(Object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            
            ITextLoader loader = _loaderFactory.GetLoader(_openFileDialog.FilterIndex);
            // Open and read file
            loader.LoadFile(_openFileDialog.FileName);
            _textBox.Text = loader.ExtractText();
            
        }

        private void AboutMenuItem1Click(Object sender, EventArgs e)
        {
            var dlg = new AboutBox();
            dlg.ShowDialog();
        }

        private void ExitMenuItemClick(Object sender, EventArgs e)
        {
            //if (_dictionaryChanged)
            //{
            //    DialogResult result = MessageBox.Show("There are unsaved changes. Do you want to save?", "Save Changes",
            //        MessageBoxButtons.YesNoCancel);

            //    switch (result)
            //    {
            //        case DialogResult.OK:
            //            //SaveFileClick(null, null);
            //            break;

            //        case DialogResult.Cancel:
            //            return;

            //        case DialogResult.No:
            //            Close();
            //            break;
            //    }
            //}
        }

        private void NeedTextForDictionaryHandler(Object sender, EventArgs e)
        {
            var view = sender as DictionaryView;

            if (view != null)
                view.CreateDictionary(_textBox.Text);
        }

        #endregion
    }
}
