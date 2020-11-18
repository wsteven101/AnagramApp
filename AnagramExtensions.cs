using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AnagramApp
{
    static class AnagramExtensions
    {
         // functional method
        public static List<string> LargestAnagramListFunctional(this IEnumerable<string> words) =>
                  words.Select(w => (Key: SortWord(w), Word: w)).
                  GroupBy(kv => kv.Key).
                  OrderBy(g => g.Count()).
                  LastOrDefault().
                  Select(g => g.Word).
                  ToList();

         // imperative method
        public static List<string> LargestAnagramList(this IEnumerable<string> words)
        {
            KeyValuePair<string, int> largestSet = new KeyValuePair<string, int>("", 0);
            Dictionary<string, List<string>> anagramLists = new Dictionary<string, List<string>>();

             // build a dictionary of anagrams with a list 
             // of the words associated with each anagram

            foreach(var word in words)
            {
                var sortedWord = SortWord(word);
                if (anagramLists.TryGetValue(sortedWord,out var anagramList))
                {
                    anagramList.Add(word);
                }
                else
                {
                    anagramList = new List<string>() { word };
                    anagramLists[sortedWord] = anagramList;
                }
                
                if (anagramList.Count > largestSet.Value)
                {
                    largestSet = new KeyValuePair<string, int>(sortedWord, anagramList.Count);
                }
            }

             // find the anagram sets which occur the most frequently
             // and return the last set found of that frequency

            var maxSet = (count: 0, anagramList: new List<List<string>>());
            foreach(var kv in anagramLists)
            {
                if (kv.Value.Count == maxSet.count)
                {
                    maxSet.anagramList.Add( kv.Value );
                }
                else if (kv.Value.Count > maxSet.count)
                {
                    maxSet = (kv.Value.Count, new List<List<string>> { kv.Value } );
                }
            }

            return maxSet.anagramList[maxSet.anagramList.Count-1];

        }      

        public static bool IsAnagram(this string compareWord1, string compareWord2) => 
                                            (SortWord(compareWord1) == SortWord(compareWord2));

        private static string SortWord(string word)
        {
            var letters = word.ToCharArray();
            Array.Sort(letters);
            return new string(letters);
        }
    }
}
