using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace ReverseDictionary
{
    class ReverseStringComparer : IComparer<String>
    {
        public int Compare(string x, string y)
        {
            var comparer = new CaseInsensitiveComparer();
            return comparer.Compare(new String(x.Reverse().ToArray()), new String(y.Reverse().ToArray()));
        }
    }
}
