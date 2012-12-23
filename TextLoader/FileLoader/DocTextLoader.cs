using System;

namespace TextLoader.FileLoader
{
    class DocTextLoader : ITextLoader
    {
        public void LoadFile(String path)
        {
            throw new NotImplementedException();
        }

        public String ExtractText()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Doc files (*.doc)|*.doc";
        }
    }
}
