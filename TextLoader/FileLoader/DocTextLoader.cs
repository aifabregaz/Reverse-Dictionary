using System;
using Word = NetOffice.WordApi;

namespace TextLoader.FileLoader
{
    internal class DocTextLoader : ITextLoader
    {
        private String _text;

        public void LoadFile(String path)
        {
            using(var wordApplication = new Word.Application())
            {
                Word.Document newDocument = wordApplication.Documents.Open(path);

                _text = newDocument.Content.Text;

                wordApplication.Quit();
            }
        }

        public String ExtractText()
        {
            return _text;
        }

        public override string ToString()
        {
            return "Doc files (*.doc)|*.doc";
        }
    }
}
