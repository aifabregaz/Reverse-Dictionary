using System;

namespace TextLoader.FileLoader
{
    class DocxTextLoader : ITextLoader
    {
        public void LoadFile(string path)
        {
            throw new NotImplementedException();
        }

        public string ExtractText()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "MS Office 2007 files (*.docx)|*.docx";
        }
    }
}
