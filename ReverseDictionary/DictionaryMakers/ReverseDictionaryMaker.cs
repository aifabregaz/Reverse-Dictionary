using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using LemmaSharp;

namespace ReverseDictionary.DictionaryMakers
{
    class ReverseDictionaryMaker : IDictionaryMaker
    {
        private Char[] _splitters = new Char[] { ' ', ',', '.', ';', ':', ')', '(', '\n', '!', 
            '?', '/', '\\', '%', '$', '#', '@', '*', '`', '~', '=', '+', '•', '–' };


        public IDictionary<string, int> MakeDictionary(string text, ILemmatizer lemmatizer)
        {
            // var _spl = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            // Console.Out.Write(_spl);
            
            var dictionary = new SortedDictionary<String, int>(new ReverseStringComparer());
            var words = text.Split(_splitters, StringSplitOptions.RemoveEmptyEntries);


            foreach (var word in words)
            {
                int tmp = 0;
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
