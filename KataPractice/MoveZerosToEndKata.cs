using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPractice
{
    class MoveZerosToEndKata
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine($"{string.Join("", MoveZeros(new int[] { 5, 0, 0, 0, 0, 0, 1, 3, 4, 1 }))}");
        //    Console.ReadLine();
        //}

        public static int[] MoveZeros(int[] array)
        {
            // a better way to do it: 
            //return arr.OrderBy(x => x==0).ToArray();
            //public static int[] MoveZeroes(int[] arr) => arr.OrderBy(o => o == 0).ToArray();

            var zerosCount = array.Count(i => i == 0);
            var list = new List<int>(array);
            list.RemoveAll(i => i == 0);

            if (zerosCount > 0)
            {
                for (int i = 0; i < zerosCount; i++)
                {
                    list.Add(0);
                }
            }
            return list.ToArray();
        }
    }
}
