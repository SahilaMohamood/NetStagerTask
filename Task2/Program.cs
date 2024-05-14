using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter the String: ");
            string s = Console.ReadLine();
            Console.WriteLine("Enter the string for check: ");
            string p = Console.ReadLine();

            // Call the function to find all start indices of p's anagrams in s
            List<int> result = FindAnagrams(s, p);

            // Print the result
            Console.WriteLine($"Input: s: \"{s}\" p: \"{p}\"");
            Console.WriteLine("Output: [" + string.Join(", ", result) + "]");
            Console.ReadLine();
        }

        public static List<int> FindAnagrams(string s, string p)
        {
            List<int> result = new List<int>();

            if (s.Length == 0 || p.Length == 0 || s.Length < p.Length)
                return result;

            int[] pCount = new int[26];
            int[] sCount = new int[26];

            // Fill the pCount array with the frequency of each character in p
            foreach (char c in p)
            {
                pCount[c - 'a']++;
            }

            int pLength = p.Length;
            int sLength = s.Length;

            // Sliding window on the string s
            for (int i = 0; i < sLength; i++)
            {
                // Add the current character to the sCount array
                sCount[s[i] - 'a']++;

                // If the window size exceeds the size of p, slide the window
                if (i >= pLength)
                {
                    sCount[s[i - pLength] - 'a']--;
                }

                // Compare the frequency counts of the current window with p's counts
                if (Enumerable.SequenceEqual(pCount, sCount))
                {
                    result.Add(i - pLength + 1);
                }
            }

            return result;
        }
    
}
}
