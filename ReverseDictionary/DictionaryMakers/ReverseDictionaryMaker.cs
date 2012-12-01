using System;
using System.Collections.Generic;
using LemmaSharp;

namespace ReverseDictionary.DictionaryMakers
{
    class ReverseDictionaryMaker : IDictionaryMaker
    {
        public IDictionary<string, int> MakeDictionary(string text, ILemmatizer lemmatizer)
        {
            var dictionary = new SortedDictionary<String, int>(new ReverseStringComparer());

            var words = text.Split(new[] { ' ', ',', '.', ')', '(' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                string w = lemmatizer.Lemmatize(word.ToLower().Trim());

                if (!dictionary.ContainsKey(w))
                    dictionary[w] = 1;
                else
                    dictionary[w] += 1;
            }

            return dictionary;
        }
    }
}
