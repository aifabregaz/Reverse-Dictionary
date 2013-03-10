using System;
using System.IO;
using NPOI.XWPF.UserModel;
using NPOI.XWPF.Extractor;

namespace TextLoader.FileLoader
{
    internal class DocxTextLoader : ITextLoader
    {
        private XWPFDocument _document;

        public void LoadFile(String path)
        {
            using(var file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                _document = new XWPFDocument(file);
            }
        }

        public string ExtractText()
        {
            return new XWPFWordExtractor(_document).Text;
        }

        public override String ToString()
        {
            return "MS Office 2007 files (*.docx)|*.docx";
        }
    }
}
