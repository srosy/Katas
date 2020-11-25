using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPractice
{
    /// <summary>
    /// https://www.codewars.com/kata/521c2db8ddc89b9b7a0000c1/train/csharp
    /// </summary>
    class SnailKata
    {
        //static void Main(string[] args)
        //{
        //    int[][] array0 = { new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 } };
        //    var answer = string.Join(", ", Snail(array0));
        //    Console.WriteLine($"answer is: [{answer}]");

        //    int[][] array = { new[] { 1, 2, 3, 4 }, new[] { 4, 5, 6, 7 }, new[] { 7, 8, 9, 10 } };
        //    answer = string.Join(", ", Snail(array));
        //    Console.WriteLine($"answer is: [{answer}]");

        //    int[][] array2 = { new[] { 1, 2, 3, 4, 5 }, new[] { 6, 7, 8, 9, 10 }, new[] { 11, 12, 13, 14, 15 }, new[] { 16, 17, 18, 19, 20 }, new[] { 21, 22, 23, 24, 25 } };
        //    answer = string.Join(", ", Snail(array2));
        //    Console.WriteLine($"answer is: [{answer}]");

        //    int[][] array3 = { new[] { 1 } };
        //    answer = string.Join(", ", Snail(array3));
        //    Console.WriteLine($"answer is: [{answer}]");

        //    int[][] array4 = { new[] { 708 } };
        //    answer = string.Join(", ", Snail(array4));
        //    Console.WriteLine($"answer is: [{answer}]");

        //    Console.Read();
        //}

        public static int[] Snail(int[][] a)
        {
            if (a[0].Length == 1)
                return a[0];

            List<int> snail = new List<int>();
            int rows = a.Length;
            int columns = a[0].Length;
            int positionX = 0;
            int positionY = 0;

            int reps = a[0].Length % 2 == 0 ? a[0].Length / 2 : a[0].Length / 2 + 1;

            (int y, int x) cursor = (positionY, positionX);

            for (int j = 0; j < reps; j++)
            {
                if (rows == 0 || columns == 0)
                    break;

                // firstrow, right
                if (rows == 1 && a[0].Length != 3) columns++;
                for (int i = positionX; i < columns; i++)
                {
                    positionX = i;
                    cursor = Move(positionY, positionX);
                    snail.Add(a[positionY][positionX]);
                }
                rows--;

                if (rows == 0 || columns == 0)
                    break;

                // down 
                for (int i = 0; i < rows; i++)
                {
                    cursor = Move(++positionY, positionX);
                    snail.Add(a[positionY][positionX]);
                }
                columns -= j + 1;

                if (rows == 0 || columns == 0)
                    break;

                // left 
                for (int i = columns; i > 0; i--)
                {
                    cursor = Move(positionY, --positionX);
                    snail.Add(a[positionY][positionX]);
                }
                rows--;

                if (rows == 0 || columns == 0)
                    break;

                // up 
                for (int i = rows; i > 0; i--)
                {
                    cursor = Move(--positionY, positionX);
                    snail.Add(a[positionY][positionX]);
                }
                positionX++;

                if (rows == 0 || columns == 0)
                    break;
            }
            return snail.ToArray();
        }

        private static (int, int) Move(int positionY, int positionX)
        {
            (int, int) cursor = (positionY, positionX);
            //Console.WriteLine($"{ cursor.Item2}, { cursor.Item1 }");
            return cursor;
        }
    }
}
