using System;
using System.Collections.Generic;

namespace TextLoader.FileSaver
{
    public interface ITextSaver
    {
        void SaveFile(String path, List<String> text);
    }
}