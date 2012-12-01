using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ReverseDictionary.FileSaver
{
    class TxtTextSaver
    {
        public void SaveFile(String path, String text)
        {
            using(var streamWriter = new StreamWriter(path))
            {
                streamWriter.Write(text);
            }
        }
        public override string ToString()
        {
            return "Text files (*.txt)|*.txt";
        }
    
    }
}
