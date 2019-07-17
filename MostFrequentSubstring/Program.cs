using System;
using System.Collections.Generic;
using System.Linq;

namespace MostFrequentSubstring
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            int minLength = Convert.ToInt32(Console.ReadLine());
            int maxLength = Convert.ToInt32(Console.ReadLine());
            int maxOccurence = Convert.ToInt32(Console.ReadLine());

            int noOfPossibleSubstrings = MostFrequentSubstring(inputString, minLength, maxLength, maxOccurence);

            Console.WriteLine(noOfPossibleSubstrings);
            Console.ReadLine();
        }

        private static int MostFrequentSubstring(string str, int minLength, int maxLength, int maxOccurence)
        {
            Dictionary<string, int> substrings = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
            int inputStringLength = str.Length;
            for (int i = 0; i < inputStringLength; i++)
            {
                int maxBounds;
                if (minLength < inputStringLength - i)
                    maxBounds = minLength;
                else
                    maxBounds = inputStringLength - 1;

                for (int j = minLength; j <= maxBounds; j++)
                {
                    if (i + j <= inputStringLength)
                    {
                        string substring = str.Substring(i, j);
                        int distinctCharacters = substring.Distinct().Count();

                        if (substring.Length >= minLength && substring.Length <= maxLength && distinctCharacters <= maxOccurence)
                        {
                            if (substrings.ContainsKey(substring))
                                substrings[substring]++;
                            else
                                substrings.Add(substring, 1);
                        }
                    }
                }
            }
            return substrings.Max(s => s.Value);
        }
    }
}
