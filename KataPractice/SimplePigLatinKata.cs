using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPractice
{
    class SimplePigLatinKata
    {
        //public static void Main(string[] args)
        //{
        //    var answer = SimplePigLatin("Pig latin is cool");
        //    Console.WriteLine(answer);

        //    var answer2 = SimplerPigLatin("Pig latin is cool");
        //    Console.WriteLine(answer2);


        //    Console.ReadLine();
        //}

        public static string SimplePigLatin(string message)
        {
            var words = message.Split(' ');
            var pigLatinWords = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                var pigLatinWord = word.Substring(1) + word[0] + "ay";
                pigLatinWords[i] = pigLatinWord;
            }

            return string.Join(" ", pigLatinWords);
        }

        public static string SimplerPigLatin(string message) => string.Join(" ", message.Split(' ').Select(w => w = w.Substring(1) + w[0] + "ay").ToArray());
    }
}
