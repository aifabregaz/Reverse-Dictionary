using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ReverseDictionary.FileSaver
{
    class TxtTextSaver
    {
        private String _text;

        public void SaveFile(String path)
        {
            using(var streamWriter = new StreamWriter(path))
            {
                streamWriter.Write(_text);
            }
        }
        public override string ToString()
        {
            return "Text files (*.txt)|*.txt";
        }
    
    }
}
