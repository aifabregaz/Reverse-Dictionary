using System;
using System.Collections.Generic;
using System.IO;

namespace TextLoader.FileSaver
{
    public class TxtTextSaver : ITextSaver
    {
        public void SaveFile(String path, List<String> text)
        {
            File.WriteAllLines(path, text);
        }
        public override string ToString()
        {
            return "Text files (*.txt)|*.txt";
        }
    
    }
}
