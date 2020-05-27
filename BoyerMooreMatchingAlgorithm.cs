using System;
using System.Collections.Generic;
using System.Text;

namespace SubstringSearchAlgorithms
{
    class BoyerMooreMatchingAlgorithm : ISubstringSearchAlgorithm
    {
        public bool Search(string text, string pattern)
        {
            Dictionary<char, int> badMatchTable = new Dictionary<char, int>();
            
            //Constructing bad match table
            for (int i = 0; i < pattern.Length; i++)
                badMatchTable[pattern[i]] = Math.Max(1, pattern.Length - i - 1);

            int textIndex = pattern.Length - 1;
            int patternIndex = pattern.Length - 1;

            while (textIndex < text.Length)
            {
                if(text[textIndex] != pattern[patternIndex])
                {
                    if (badMatchTable.ContainsKey(text[textIndex]))
                        textIndex += badMatchTable[text[textIndex]];
                    else
                        textIndex += pattern.Length;

                    patternIndex = pattern.Length - 1;
                }
                else
                {
                    patternIndex--;
                    textIndex--;

                    //if patternIndex reaches -1 that means pattern completely matched
                    if (patternIndex == -1)
                        return true;
                }
            }

            return false;
        }
    }
}
