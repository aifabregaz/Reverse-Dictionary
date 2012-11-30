using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseDictionary.FileLoader
{
    interface ITextLoader
    {
        void LoadFile(String path);
        String ExtractText();
    }
}
