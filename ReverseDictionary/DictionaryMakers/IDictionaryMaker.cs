using System;
using System.Collections.Generic;
using LemmaSharp;

namespace ReverseDictionary.DictionaryMakers
{
    interface IDictionaryMaker
    {
        /// <summary>
        /// Makes dictionary from text using given lemmatizer
        /// </summary>
        /// <param name="text">Text, from which dictionary will be generated</param>
        /// <param name="lemmatizer">Lemmatizer, which used to lemmatise words</param>
        /// <returns>Dictionary</returns>
        IDictionary<String, int> InitDictionary();
        IDictionary<String, int> MakeDictionary(String text, ILemmatizer lemmatizer);
    }
}
