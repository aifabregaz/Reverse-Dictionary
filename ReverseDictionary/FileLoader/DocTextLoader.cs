using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseDictionary.FileLoader
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
