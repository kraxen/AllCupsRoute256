using System;
using System.Collections.Generic;

namespace CountingCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] inputs = Console.ReadLine().ToCharArray();

            string outstring = "";
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            foreach (char c in inputs)
            {
                int count = 1;
                if (dictionary.ContainsKey(c))
                {
                    dictionary.TryGetValue(c, out count);
                    count++;
                    dictionary.Remove(c);
                    dictionary.Add(c, count);
                }
                else
                {
                    dictionary.Add(c, count);
                }
                outstring += count;
            }
            Console.WriteLine(outstring);
        }
    }
}
