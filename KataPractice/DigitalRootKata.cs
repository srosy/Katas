using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPractice
{
    class DigitalRootKata
    {
        //static void Main(string[] args)
        //{
        //    var answer = DigitalRoot(456); // 6
        //    Console.WriteLine($"answer is {answer}");

        //    answer = DigitalRoot(16); // 6
        //    Console.WriteLine($"answer is {answer}");

        //    Console.Read();
        //}

        public static int DigitalRoot(long num)
        {
            var numList = num.ToString().ToList().Select(c => int.Parse(c.ToString())).ToList();
            var answer = numList.Sum();

            var isReducable = answer >= 10;
            if (isReducable)
                answer = DigitalRoot(answer);
            return answer;
        }
    }
}
