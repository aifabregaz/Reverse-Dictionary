using System;
using System.Windows.Forms;

namespace ReverseDictionary.FileLoader
{
    class RtfTextLoader : ITextLoader
    {
        private String _text;

        public void LoadFile(string path)
        {
            var rtfTempBox = new RichTextBox();
            rtfTempBox.LoadFile(path, RichTextBoxStreamType.RichText);
            _text = rtfTempBox.Text;
        }

        public string ExtractText()
        {
            return _text;
        }

        public override string ToString()
        {
            return "RTF files (*.rtf)|*.rtf";
        }
    }
}
