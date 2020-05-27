using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace SubstringSearchAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "abxxxxabca";
            string pattern = "abca";
            List<ISubstringSearchAlgorithm> substringSearchAlgorithms = new List<ISubstringSearchAlgorithm>();
            //substringSearchAlgorithms.Add(new KMPMatchingAlgorithm());
            //substringSearchAlgorithms.Add(new WildCardMatchingAlgorithm());
            //substringSearchAlgorithms.Add(new RabinKarpMatchingAlgorithm());
            substringSearchAlgorithms.Add(new BoyerMooreMatchingAlgorithm());

            Stopwatch stopwatch = new Stopwatch();
            foreach (ISubstringSearchAlgorithm item in substringSearchAlgorithms)
            {
                stopwatch.Restart();
                Console.Write(item.GetType().Name + ": ");
                bool result = item.Search(text, pattern);
                Console.WriteLine((result ? "Match " : "No Match ") + stopwatch.ElapsedMilliseconds +"ms\n");
            }

            Console.ReadKey();
        }
    }
}
