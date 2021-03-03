using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataPractice
{
    class CodePasswordPermutationCrack // this one is still a work in progress
    {
        public static List<string> GetPINs(string observed)
        {
            if (string.IsNullOrEmpty(observed))
            {
                throw new Exception("Inputted string cannot be null/empty!");
            }

            //setup 2d array
            var count = 0;
            var map = new Dictionary<int, (int row, int col)>();
            var digipad = new int[3, 3]; // rows, cols
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    digipad[i, j] = ++count;
                    map.Add(count, (i, j)); // save position of digit in int[][]
                }
            }

            var digits = observed.Select(c => int.Parse(c.ToString())).ToArray();
            var neighbors = new Dictionary<int, List<int>>();

            //generate neighbors of each digit
            foreach (var d in digits)
            {
                var _neightbors = new List<int>();
                var row = map[d].row;
                var col = map[d].col;

                if (d == 8)
                {
                    _neightbors = new List<int>() { 5, 7, 9, 0 };
                    continue;
                }

                if (row > 0) //up
                {
                    _neightbors.Add(map.First(x => x.Value.row == row - 1 && x.Value.col == col).Key);
                }

                if (row < 2) //down
                {
                    _neightbors.Add(map.First(x => x.Value.row == row + 1 && x.Value.col == col).Key);
                }

                if (col > 0) //left
                {
                    _neightbors.Add(map.First(x => x.Value.row == row && x.Value.col == col - 1).Key);
                }

                if (col < 2) //right
                {
                    _neightbors.Add(map.First(x => x.Value.row == row && x.Value.col == col + 1).Key);
                }

                neighbors.Add(d, _neightbors);
            }

            // get all permutations
            var permutations = new List<StringBuilder>();
            var position = 0;
            foreach (var n in neighbors)
            {
                // save first guess digits as new sb's
                if (position == 0)
                {
                    for (int i = 0; i < digits.Length; i++)
                    {
                        permutations.Add(new StringBuilder().Append(n.ToString()));
                        for (int j = 0; j < n.Value.Count; j++)
                        {
                            permutations.Add(new StringBuilder().Append(n.Value[j].ToString()));
                        }
                    }
                    position++;
                }
                else // tack onto the end
                {
                    for (int i = 0; i < n.Value.Count; i++)
                    {

                    }
                }

            }

            return null;
        }
    }
}
