using System;
using System.Collections.Generic;
using System.Text;

namespace SubstringSearchAlgorithms
{
    interface ISubstringSearchAlgorithm
    {
        bool Search(string text, string pattern);
    }
}
