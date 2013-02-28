using System;
using System.Collections.Generic;
using LemmaSharp;

namespace ReverseDictionary.DictionaryMakers
{
    class ReverseDictionaryMaker : IDictionaryMaker
    {
        private readonly Char[] _splitters = new[] { ' ', ',', '.', ';', ':', ')', '(', '\r', '\n', '!', 
            '?', '/', '\\', '%', '$', '#', '@', '*', '`', '~', '=', '+', '•', '—',
            '«', '»', '\t', '[',  ']',  '\"', '<', '>', '{', '}'  };
        
        public IDictionary<string, int> InitDictionary()
        {
            return new SortedDictionary<String, int>(new ReverseStringComparer());
        }

        public IDictionary<string, int> MakeDictionary(string text, ILemmatizer lemmatizer)
        {
            var dictionary = InitDictionary();
            var words = text.Split(_splitters, StringSplitOptions.RemoveEmptyEntries);


            foreach (var word in words)
            {
                int tmp;
                if (Int32.TryParse(word, out tmp))
                {
                    continue;
                }
                
                string lowerWord = lemmatizer.Lemmatize(word.ToLower().Trim());

                if (!dictionary.ContainsKey(lowerWord))
                    dictionary[lowerWord] = 1;
                else
                    dictionary[lowerWord] += 1;
            }

            return dictionary;
        }
    }
}
