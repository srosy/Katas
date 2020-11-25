using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPractice
{
    class GreedGameKata
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine(GreedGame(new int[] { 5, 1, 3, 4, 1 }));
        //    Console.WriteLine(GreedGame(new int[] { 1, 1, 1, 3, 1 }));
        //    Console.WriteLine(GreedGame(new int[] { 2, 4, 4, 5, 4 }));
        //    Console.ReadLine();
        //}

        public static int GreedGame(int[] rolls)
        {
            var score = 0;

            if (rolls.Any(c => rolls.Count(n => n == c) >= 3))
            {
                var val = rolls.Where(c => rolls.Count(n => n == c) >= 3).FirstOrDefault();
                if (val == 1)
                    score += 1000;
                else
                    score += val * 100;

                var count = 0;
                for (int i = 0; i < rolls.Length; i++)
                {
                    if (rolls[i] == val && count < 3)
                    {
                        count++;
                        rolls[i] = 0;
                    }
                }
            }

            rolls.Where(r => r > 0).ToList().ForEach(r =>
            {
                if (r == 1) score += 100;
                if (r == 5) score += 50;
            });

            return score;
        }

        /** A cooler way to do it
         * 
          private static int[,] g_score = {
            {0, 100, 200, 1000, 1100, 1200}, //1
            {0,   0,   0,  200,  200,  200}, //2
            {0,   0,   0,  300,  300,  300}, //3
            {0,   0,   0,  400,  400,  400}, //4
            {0,  50, 100,  500,  550,  600}, //5
            {0,   0,   0,  600,  600,  600}  //6
          };
  
          public static int Score(int[] dice) {
            return dice.GroupBy(v => v).Select(v => g_score[v.Key-1,v.Count()]).Sum();
          }
         * 
         */
    }
}
