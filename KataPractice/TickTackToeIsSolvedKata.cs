using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPractice
{
    class TickTackToeIsSolvedKata
    {
        //public static void Main(string[] args)
        //{
        //    int[,] board = new int[,] { { 1, 1, 1 }, { 0, 2, 2 }, { 0, 0, 0 } }; // 1, row
        //    var answer = IsSolved(board);
        //    Console.WriteLine(answer);

        //    int[,] board2 = new int[,] { { 1, 0, 1 }, { 2, 1, 2 }, { 1, 2, 2 } }; // 1, diagonal
        //    answer = IsSolved(board2);
        //    Console.WriteLine(answer);

        //    int[,] board3 = new int[,] { { 1, 2, 1 }, { 1, 2, 2 }, { 2, 1, 1 } }; // 0, cat's game
        //    answer = IsSolved(board3);
        //    Console.WriteLine(answer);

        //    int[,] board4 = new int[,] { { 0, 2, 2 }, { 2, 1, 1 }, { 0, 0, 1 } }; // -1, board not filled out all the way
        //    answer = IsSolved(board4);
        //    Console.WriteLine(answer);

        //    Console.ReadLine();
        //}

        public static int IsSolved(int[,] board)
        {
            var winner = 0;

            for (int i = 0; i < board.GetLength(1); i++)
            {
                // first check all rows
                bool rowSolved = board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != 0;
                if (rowSolved) winner = board[i, 0];

                // then check all columns
                bool columnSolved = board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != 0;
                if (columnSolved) winner = board[0, i];
            }

            // then check diagonals
            var n = board[1, 1]; // middle
            bool diagonalSolved = board[0, 0] == n && board[2, 2] == n || board[2, 0] == n && board[0, 2] == n && n != 0;
            if (diagonalSolved) winner = n;

            if (winner > 0) return winner;

            var notFilledOut = board.Cast<int>().Any(x => x == 0);
            if (notFilledOut) return -1;
            return 0;
        }
    }
}
