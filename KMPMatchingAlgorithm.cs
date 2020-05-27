using System;
using System.Collections.Generic;
using System.Text;

namespace SubstringSearchAlgorithms
{
    class KMPMatchingAlgorithm : ISubstringSearchAlgorithm
    {
        public bool Search(string text, string pattern)
        {
            int[] patternSuffixTable = new int[pattern.Length];

            int tempIndex = 0;
            for (int i = 1; i < patternSuffixTable.Length; i++)
            {
                if (pattern[tempIndex] == pattern[i])
                {
                    patternSuffixTable[i] = tempIndex + 1;
                    tempIndex++;
                }
                else if (tempIndex != 0)
                {
                    tempIndex = patternSuffixTable[tempIndex - 1];
                    i--;
                }
            }

            int patternIndex = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == pattern[patternIndex])
                    patternIndex++;
                else
                {
                    if (patternIndex > 0)
                    {
                        i--;
                        patternIndex = patternSuffixTable[patternIndex - 1];
                    }
                }

                if (patternIndex == pattern.Length)
                    return true;
            }

            return false;
        }
    }
}
