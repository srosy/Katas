using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPractice
{
    class TribonacciKata
    {
        //public static void Main(string[] args)
        //{
        //    var answer = Tribonacci(new double[] { 1, 1, 1 }, 10);
        //    Console.WriteLine($"{string.Join(", ", answer)}");

        //    answer = Tribonacci(new double[] { 0, 0, 1 }, 10);
        //    Console.WriteLine($"{string.Join(", ", answer)}");

        //    answer = Tribonacci(new double[] { 0, 1, 1 }, 10);
        //    Console.WriteLine($"{string.Join(", ", answer)}");

        //    answer = Tribonacci(new double[] { 13, 16, 10 }, 2);
        //    Console.WriteLine($"{string.Join(", ", answer)}");

        //    Console.ReadLine();
        //}

        public static double[] Tribonacci(double[] signature, int n)
        {
            if (n <= 0)
                return Array.Empty<double>();

            var l = signature.Length;
            if (l >= n)
                return signature.Take(n).ToArray();

            var sig = new List<double>(signature);

            for (int i = l == 3 ? 3 : 2; i < n; i++)
            {
                var result = 0d;
                for (int j = l; j > 0; j--) // F(n) = F(n-1) + F(n-2) + F(n-3)...
                {
                    result += sig[sig.Count - j];
                }
                sig.Add(result);
            }

            return sig.ToArray();
        }

        // another way to do it
        //public double[] Tribonacci(double[] signature, int n)
        //{
        //    var seq = new List<double>(signature);

        //    for (var i = 3; i < n; i++)
        //    {
        //        seq.Add(seq[i - 1] + seq[i - 2] + seq[i - 3]);
        //    }

        //    return seq.Take(n).ToArray();
        //}
    }
}
