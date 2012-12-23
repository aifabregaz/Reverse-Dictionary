using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TextLoader.FileLoader
{
    public class TextLoaderFactory
    {
        private readonly IList<ITextLoader> _loaders;

        public TextLoaderFactory()
        {
            _loaders = new List<ITextLoader>();

            foreach (var textLoaders in Assembly.GetExecutingAssembly().GetTypes()
                                            .Where(textLoaders => textLoaders.GetInterface("ITextLoader") != null))
            {
                _loaders.Add((ITextLoader)Activator.CreateInstance(textLoaders));
            }
        }

        public String GetAvailableLoaders()
        {
            var sb = new StringBuilder();
            foreach (var textLoader in _loaders)
            {
                sb.Append(textLoader).Append('|');
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
