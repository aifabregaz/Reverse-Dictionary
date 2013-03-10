using System.Windows.Forms;

namespace TextLoader.FileLoader
{
    internal class RtfTextLoader : ITextLoader
    {
        private readonly RichTextBox _richTextBox = new RichTextBox();
        
        public void LoadFile(string path)
        {
            _richTextBox.LoadFile(path, RichTextBoxStreamType.RichText);
        }

        public string ExtractText()
        {
            return _richTextBox.Text;
        }

        public override string ToString()
        {
            return "RTF files (*.rtf)|*.rtf";
        }
    }
}
