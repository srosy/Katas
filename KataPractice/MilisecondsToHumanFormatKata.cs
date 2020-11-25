using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPractice
{
    class MilisecondsToHumanFormatKata
    {
        //public static void Main(string[] args)
        //{
        //    //var answer = formatDuration(120);
        //    //Console.WriteLine(answer);

        //    //answer = formatDuration(121);
        //    //Console.WriteLine(answer);

        //    //answer = formatDuration(122);
        //    //Console.WriteLine(answer);

        //    //answer = formatDuration(4568);
        //    //Console.WriteLine(answer);

        //    //answer = formatDuration(46546987);
        //    //Console.WriteLine(answer);

        //    var answer = formatDuration(132030240);
        //    Console.WriteLine(answer);

        //    Console.ReadLine();
        //}

        public static string formatDuration(int seconds)
        {
            var dict = new Dictionary<string, int>()
            {
                { "year", 31536000},
                { "day",  86400},
                { "hour", 3600 },
                { "minute", 60 },
                { "second", 1 }
            };

            if (seconds <= 0)
                return "now";

            var time = new int[5];

            while (seconds > 0)
            {
                while (seconds - dict["year"] >= 0)
                {
                    time[0]++;
                    seconds -= dict["year"];
                }

                while (seconds - dict["day"] >= 0)
                {
                    time[1]++;
                    seconds -= dict["day"];

                    if (time[1] >= 365)
                    {
                        time[1] = time[1] - 365;
                        time[0]++;
                    }
                }

                while (seconds - dict["hour"] >= 0)
                {
                    time[2]++;
                    seconds -= dict["hour"];

                    if (time[2] >= 24)
                    {
                        time[2] = time[2] - 24;
                        time[1]++;
                    }
                }

                while (seconds - dict["minute"] >= 0)
                {
                    time[3]++;
                    seconds -= dict["minute"];

                    if (time[3] >= 60)
                    {
                        time[3] = time[3] - 60;
                        time[2]++;
                    }
                }

                if (seconds == 0)
                    break;

                time[4]++;
                seconds--;
            }

            var sb = new StringBuilder();

            // find index of smallest 
            var indexOfSmallest = 0;
            for (int i = time.Length - 1; i > 0; i--)
            {
                if (time[i] > 0)
                {
                    indexOfSmallest = i;
                    break;
                }
            }

            for (int i = 0; i < time.Length; i++)
            {
                if (time[i] > 0)
                {
                    // add commas / and
                    if (sb.Length > 0 && i == indexOfSmallest)
                        sb.Append(" and ");
                    else if (sb.Length > 0 && i < 4)
                        sb.Append(", ");

                    if (time[i] == 1) // handle plurals
                        sb.Append($"{time[i]} {dict.ElementAt(i).Key}");
                    else
                        sb.Append($"{time[i]} {dict.ElementAt(i).Key + "s"}");
                }
            }

            return sb.ToString();
        }
    }
}
