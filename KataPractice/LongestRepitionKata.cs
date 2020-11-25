using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPractice
{
    class LongestRepitionKata
    {
        //static void Main(string[] args)
        //{
        //    var tuple = LongestRepetition("bbbaaabaaaa");
        //    Console.WriteLine($"{tuple.Item1} {tuple.Item2}");
        //    Console.Read();
        //}

        public static Tuple<char?, int> LongestRepetition(string str)
        {
            if (string.IsNullOrEmpty(str))
                return new Tuple<char?, int>(null, 0);

            List<(char _char, int count)> keyValues = new List<(char, int)>() { }; // allow duplicate keys

            var previousLetter = str[0];
            var count = 0;

            var index = 0;
            foreach (char c in str)
            {
                bool letterChanged = c != previousLetter;

                if (letterChanged)
                {
                    keyValues.Add((previousLetter, count));
                    previousLetter = c;
                    count = 1;
                }
                else if (index == str.Length - 1)
                {
                    keyValues.Add((previousLetter, count));
                }
                else
                    count++;

                index++;
            }

            var max = keyValues.FirstOrDefault(k => k.Item2 == keyValues.Max(x => x.Item2));

            return new Tuple<char?, int>(max._char, max.count);
        }
    }
}
