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

            var words = text.Split(new[] { ' ', ',', '.', ')', '(', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
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
