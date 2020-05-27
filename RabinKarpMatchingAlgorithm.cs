using System;
using System.Collections.Generic;
using System.Text;

namespace SubstringSearchAlgorithms
{
    class RabinKarpMatchingAlgorithm : ISubstringSearchAlgorithm
    {
        public bool Search(string text, string pattern)
        {
            int prime = 101;
            int patternHash = 0;
            int substringHash = 0;
            if (pattern.Length <= text.Length)
            {
                //Find pattern hash
                for (int i = 0; i < pattern.Length; i++)
                {
                    patternHash += pattern[i] * (int)Math.Pow(prime, i);
                }

                //Find first substring hash
                for (int j = 0; j < pattern.Length; j++)
                {
                    substringHash += text[j] * (int)Math.Pow(prime, j);
                }

                for (int i = 0; i <= text.Length - pattern.Length; i++)
                {
                    if (substringHash == patternHash)
                    {
                        bool charactersMatch = true;

                        //If hashes match check if characters are the same
                        for (int j = 0; j < pattern.Length; j++)
                        {
                            if (text[i + j] != pattern[j])
                            {
                                charactersMatch = false;
                                break;
                            }
                        }
                        if (charactersMatch)
                            return true;
                    }

                    if (i + pattern.Length < text.Length)
                    {
                        substringHash -= text[i];
                        substringHash /= prime;
                        substringHash += text[i + pattern.Length] * (int)Math.Pow(prime, pattern.Length - 1);
                    }
                }
            }

            return false;
        }
    }
}
