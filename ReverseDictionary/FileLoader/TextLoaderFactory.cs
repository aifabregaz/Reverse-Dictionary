using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseDictionary.FileLoader
{
    class TextLoaderFactory
    {
        private readonly IList<ITextLoader> _loaders;

        public TextLoaderFactory()
        {
            _loaders = new List<ITextLoader>
            {
                new TxtTextLoader(),
                new RtfTextLoader(),
                new DocTextLoader()
            };
        }

        public String GetAvailableLoaders()
        {
            var sb = new StringBuilder();
            foreach (var textLoader in _loaders)
            {
                sb.Append(textLoader.ToString()).Append('|');
            }
            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        public ITextLoader GetLoader(int index)
        {
            return _loaders[index - 1];
        }
    }
}
