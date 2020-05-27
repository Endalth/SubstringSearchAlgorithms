using System;
using System.Collections.Generic;
using System.Text;


namespace SubstringSearchAlgorithms
{
    class WildCardMatchingAlgorithm : ISubstringSearchAlgorithm
    {
        public bool Search(string text, string pattern)
        {
            bool[,] resultArray = new bool[text.Length + 1, pattern.Length + 1];
            resultArray[0, 0] = true;
            //This loop is for when "*" is at the beginning of the string
            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] == '*')
                    resultArray[0, i + 1] = resultArray[0, i];
            }
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (text[i] == pattern[j] || pattern[j] == '?')
                        resultArray[i + 1, j + 1] = resultArray[i, j];
                        //If you don't want entire string to match and just want to know if pattern is in the text use the line below
                        //resultArray[i + 1, j + 1] = j == 0 ? true : resultArray[i, j];
                    else if (pattern[j] == '*')
                        resultArray[i + 1, j + 1] = resultArray[i, j + 1] || resultArray[i + 1, j];
                }
            }

            return resultArray[text.Length, pattern.Length];
        }
    }
}
