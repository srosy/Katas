using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPractice
{
    class NextBiggerKata
    {
        //static void Main(string[] args)
        //{
        //    var nextBiggest = nextBigger(144); // 414
        //    Console.WriteLine($"answer is {nextBiggest}");

        //    nextBiggest = nextBigger(531);
        //    Console.WriteLine($"answer is {nextBiggest}");

        //    //nextBiggest = nextBigger(112);
        //    //Console.WriteLine($"answer is {nextBiggest}");

        //    nextBiggest = nextBigger(1234567890); //1234567908
        //    Console.WriteLine($"answer is {nextBiggest}");

        //    Console.Read();
        //}

        public static long nextBigger(long num)
        {
            if (num.ToString().Length <= 1) return -1;

            var numList = num.ToString().ToList().Select(c => long.Parse(c.ToString())).ToList();

            if (numList.Distinct().ToList().Count == 1) return -1;
            var candidates = new List<long>();
            for (int i = numList.Count - 1; i > 0; i--)
            {
                var temp = new List<long>();
                temp.AddRange(numList);

                Swap(temp, i, i - 1);

                var total = long.Parse(string.Join("", temp.Select(l => l.ToString()).ToList()));//1234567908 1234567890

                if (total > num)
                {
                    if (!candidates.Any(c => c == total))
                        candidates.Add(total);
                }

                for (int j = temp.Count - 1; j > 0; j--)
                {
                    Swap(temp, j, j - 1);
                    total = long.Parse(string.Join("", temp.Select(l => l.ToString()).ToList()));//1234567908 1234567890

                    if (total > num)
                    {
                        if (!candidates.Any(c => c == total))
                            candidates.Add(total);
                    }
                }
            }
            if (candidates.Any())
                return candidates.Min();
            return -1;
        }

        private static void Swap(List<long> nums, int index, int size)
        {
            long temp = nums[index];
            nums[index] = nums[size];
            nums[size] = temp;
        }
    }
}
