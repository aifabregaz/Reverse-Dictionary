using System;

namespace TextLoader.FileLoader
{
    public interface ITextLoader
    {
        void LoadFile(String path);
        String ExtractText();
    }
}
