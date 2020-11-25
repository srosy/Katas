using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPractice
{
    class Multiples3Or5SumKata
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine(Multiples3Or5Sum(10));
        //    Console.ReadLine();
        //}

        public static int Multiples3Or5Sum(int value) => Enumerable.Range(0, value).Sum(i => i % 3 == 0 || i % 5 == 0 ? i : 0);
    }
}
