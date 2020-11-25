using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPractice
{
    class ReverseIntArray
    {
        //static void Main(string[] args)
        //{
        //    int[] array = new int[] { 1, 2, 3, 4 };
        //    var answer = run(array);
        //    Console.WriteLine($"answer is: [{string.Join(" ", answer)}]");
        //    Console.Read();
        //}

        public static int[] run(int[] a)
        {
            var array = new int[a.Length];

            var index = 0;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                array[index] = a[i];
                index++;
            }

            return array;
        }
    }
}
