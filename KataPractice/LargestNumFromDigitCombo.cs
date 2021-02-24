using System;
using System.Linq;

namespace KataPractice
{
    class LargestNumFromDigitCombo
    {
        public int solution(int N)
        {

            if (N == 10000 || N == 0)
            {
                return N;
            }

            if (N < 0 || N > 10000)
            {
                throw new Exception("N must be in range [0, 10000]");
            }

            var orderedDigits = int.Parse(string.Join("", N.ToString().ToArray().OrderByDescending(c => c)));

            // not allowing me to do my usual here:
            //decimal.TryParse(string.Join("", N.ToString().ToArray().OrderByDescending(c => c)), out var orderedDigits); 

            return orderedDigits;
        }
    }
}
