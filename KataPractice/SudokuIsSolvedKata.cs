using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPractice
{
    class SudokuIsSolvedKata
    {
        //public static void Main(string[] args)
        //{
        //    var board = new int[][]
        //    {
        //        new int[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
        //        new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
        //        new int[] {1, 9, 8, 3, 4, 2, 5, 6, 7},
        //        new int[] {8, 5, 9, 7, 6, 1, 4, 2, 3},
        //        new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
        //        new int[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
        //        new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
        //        new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
        //        new int[] {3, 4, 5, 2, 8, 6, 1, 7, 9},
        //    };
        //    var answer = ValidateSolution(board);
        //    Console.WriteLine(answer);

        //    var falseBoard2 = new int[][]
        //    {
        //      new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9},
        //      new int[] {2, 3, 1, 5, 6, 4, 8, 9, 7},
        //      new int[] {3, 1, 2, 6, 4, 5, 9, 7, 8},
        //      new int[] {4, 5, 6, 7, 8, 9, 1, 2, 3},
        //      new int[] {5, 6, 4, 8, 9, 7, 2, 3, 1},
        //      new int[] {6, 4, 5, 9, 7, 8, 3, 1, 2},
        //      new int[] {7, 8, 9, 1, 2, 3, 4, 5, 6},
        //      new int[] {8, 9, 7, 2, 3, 1, 5, 6, 4},
        //      new int[] {9, 7, 8, 3, 1, 2, 6, 4, 5},
        //    };
        //    var answer2 = ValidateSolution(falseBoard2);
        //    Console.WriteLine(answer2);

        //    Console.ReadLine();
        //}

        public static bool ValidateSolution(int[][] board)
        {
            HashSet<int> range = new HashSet<int>();

            // rows
            for (int i = 0; i < board.Length; i++)
            {
                range.Clear();
                for (int j = 0; j < board.Length; j++)
                {
                    var n = board[i][j];
                    if (n == 0)
                        return false;
                    if (range.Contains(n))
                        return false;
                    range.Add(n);
                }
            }

            // columns
            for (int i = 0; i < board.Length; i++)
            {
                range.Clear();
                for (int j = 0; j < board.Length; j++)
                {
                    var n = board[j][i];
                    if (n == 0)
                        return false;
                    if (range.Contains(n))
                        return false;
                    range.Add(n);
                }
            }

            //subsets
            for (int i = 0; i < board.Length; i += 3) // do this for 3 rows
            {
                for (int j = 0; j < board.Length; j += 3) // hop to [0, 0] position of each subset, check row
                {
                    range.Clear();
                    for (int k = 0; k < board.Length / 3; k++) // add to range and check
                    {
                        for (int z = 0; z < board.Length / 3; z++)
                        {
                            var col = j + z;
                            var row = k + i;
                            var n = board[row][col];
                            if (n == 0)
                                return false;
                            if (range.Contains(n))
                                return false;
                            range.Add(n);
                        }
                    }
                }
            }

            return true;
        }

        /* A better way to do it **********************************************************
            private static int[] nineNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    
            public static bool ValidateSolution(int[][] board)
            {
                for (int i = 0; i < 9; ++i)
                {
                    var row = new List<int>();
                    for (int j = 0; j < 9; ++j) row.Add(board[i][j]);
                    if (!ValidateNine(row)) return false;

                    var col = new List<int>();
                    for (int j = 0; j < 9; ++j) col.Add(board[j][i]);
                    if (!ValidateNine(col)) return false;

                    var block = new List<int>();
                    int br = (i / 3) * 3;
                    int bc = (i % 3) * 3;
                    for (int j = 0; j < 9; ++j) block.Add(board[br + j / 3][bc + j % 3]);
                    if (!ValidateNine(block)) return false;
                }

                return true;
            }

            private static bool ValidateNine(IList<int> nine)
            {
                return nineNumbers.All(nine.Contains);
            }
        ******************************************************************************************/
    }
}
