using System;
using System.IO;

namespace ReverseDictionary.FileLoader
{
    class TxtTextLoader : ITextLoader
    {
        private String _text;

        public void LoadFile(String path)
        {
            using(var streamReader = new StreamReader(path))
            {
                _text = streamReader.ReadToEnd();
            }
        }

        public string ExtractText()
        {
            return _text;
        }

        public override string ToString()
        {
            return "Text files (*.txt)|*.txt";
        }
    }
}
