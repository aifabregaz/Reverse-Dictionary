using System;
using System.IO;

namespace TextLoader.FileSaver
{
    public class TxtTextSaver
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
