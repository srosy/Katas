﻿
using System.Text;

using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPractice
{
    class Program
    {
        public static void Main(string[] args)
        {
            var answer = Solution(2, "");
            Console.WriteLine(answer);
        }

        // return the largest number of the family
        public static int Solution(int N, string S)
        {
            if (string.IsNullOrEmpty(S))
            {
                return 2; // only 2 families at most can be seated in a single row
            }

            var resevedSeats = S.ToUpper().Split(' ').ToArray();
            var map = new Dictionary<char, int>()
            {
                {'A', 0 },
                {'B', 1 },
                {'C', 2 },
                {'D', 3 },
                {'E', 4 },
                {'F', 5 },
                {'G', 6 },
                {'H', 7 },
                {'I', 8 },
                {'J', 9 },
                {'K', 10 }
            };
            var seats = new bool[N, 10]; // row, col

            var allowedAssignments = new List<decimal>() { 1234, 3456, 5678 };

            // setup the prereserved seats
            for (int i = 0; i < resevedSeats.Length; i++)
            {
                var col = map[resevedSeats[i].Last()];
                //map.TryGetValue(resevedSeats[i].Last(), out var col);

                var row = int.Parse(resevedSeats[i].First().ToString()) - 1;
                //int.TryParse(resevedSeats[i].First().ToString(), out var row); row--;

                if (col < 0 || row < 0)
                {
                    throw new Exception($"Invalid input string: {S}");
                }

                seats[row, col] = true;
            }

            // find the number of families that could fit
            var numFamiliesOfFourThatFit = 0;
            for (int i = 0; i < N; i++)
            {
                var seatsOpen = new List<string>();
                for (int j = 1; j < 9; j++) // skip the first and last
                {
                    if (!seats[i, j])
                    {
                        seatsOpen.Add(j.ToString());
                        if (seatsOpen.Count == 4 && allowedAssignments.Contains(decimal.Parse(string.Join("", seatsOpen))))
                        {
                            numFamiliesOfFourThatFit++;
                            seatsOpen.Clear();
                        }
                        else if (seatsOpen.Count == 4)
                        {
                            seatsOpen.Clear();
                            j = j - 3;
                        }
                    }
                }
            }

            return numFamiliesOfFourThatFit;
        }
    }
}



