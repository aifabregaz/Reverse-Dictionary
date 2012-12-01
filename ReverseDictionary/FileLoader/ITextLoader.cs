using System;

namespace ReverseDictionary.FileLoader
{
    interface ITextLoader
    {
        void LoadFile(String path);
        String ExtractText();
    }
}
