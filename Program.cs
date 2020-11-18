using System;
using System.Collections.Generic;
using static System.Console;
using System.Linq;

namespace AnagramApp
{
    class Program
    {

        /// ////////////////////////////////////////////////////////////////////////////
        /// 
        // This program takes a list of words and finds the biggest set of words
        // within that list that are anagrams of each other. If this process
        // finds that there are mpore than set of anagrams that meet this requirement
        // then the last found set is returned
        // 
        // There are two approaches to finding the largest set with corresponding methods
        //
        //     1. LargestAnagramListFunctional() - functional extension method using LINQ
        //     2. LargestAnagramList()           - imperative method
        //
        /// ////////////////////////////////////////////////////////////////////////////


        static void Main(string[] args)
        {

            List<string> testWords = new List<string>() {  "AB", "BA",
                                                            "ABC", "ACB", "BAC", "CAB",
                                                            "BBB", "BBB",
                                                            "1234", "4321", "3412" };


            var anagramSet1 = testWords.LargestAnagramListFunctional();  // functional method
            var anagramSet2 = testWords.LargestAnagramList();            // imperative method


            if (CompareResults(anagramSet1, anagramSet2))
            {
                throw new Exception("Algorithmic error: The two methods have not returned the same results!");
            }

            DisplayRsults(anagramSet1);

        }

        static bool CompareResults(List<string> anagramSet1, List<string> anagramSet2)
        {
            var intersectingCount = (anagramSet1.Distinct().Intersect(anagramSet2.Distinct())).ToList().Count;
            return (anagramSet1.Distinct().Count() != intersectingCount);
        }

        static void DisplayRsults(List<string> anagramSet)
        {
            WriteLine($"Largest Anagram Set Is: \n");
            foreach (var anagram in anagramSet)
            {
                WriteLine($"    {anagram}");
            }
        }

    }
}
