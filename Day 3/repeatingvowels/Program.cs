using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace repeatingvowels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vowels();
        }
        static void Vowels()
        {
            Console.WriteLine("Enter the series of words separated by a comma");
            string phrase = Console.ReadLine();
            Dictionary<string, int> countofvowels = separatewords(phrase);
            int min = countofvowels.Values.Min();
            Console.WriteLine("These are the words with minimum number of vowels :");
            foreach (var word in countofvowels)
            {
                if (word.Value == min)
                    Console.WriteLine($"{word.Key}");
            }
        }
        static Dictionary<string, int> separatewords(string phrase)
        {
            Dictionary<string, int> countofvowels = new Dictionary<string, int>();
            string[] words = phrase.Split(',');
            for (int i = 0; i < words.Length; i++)
            {
                int count = vowelsreps(words[i]);
                countofvowels.Add(words[i], count);
            }
            return countofvowels;
        }
        static int vowelsreps(string word)
        {
            HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

            int count = 0;

            foreach (char c in word.ToLower())
            {
                if (vowels.Contains(c))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
