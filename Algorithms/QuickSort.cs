using System;

namespace Algorithms
{
    public class QuickSort
    {
        /*
            Quicksort algorithm on average makes O(n log n) comparisons to sort n items.
         */

        //public static void Main(string[] args)
        //{
        //    int[] arr = new int[10]
        //    {
        //        1, 5, 4, 11, 20, 8, 2, 98, 90, 16
        //    };

        //    Sort(arr, 0, arr.Length - 1);
        //    Console.WriteLine("Sorted Values:");
        //    for (int i = 0; i < arr.Length; i++)
        //        Console.WriteLine(arr[i]);
        //}

        private void Sort(int[] arr, int start, int end)
        {
            int i;
            if (start < end)
            {
                i = Partition(arr, start, end);

                Sort(arr, start, i - 1);
                Sort(arr, i + 1, end);
            }
        }

        private int Partition(int[] arr, int start, int end)
        {
            int temp;
            int p = arr[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (arr[j] <= p)
                {
                    i++;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            temp = arr[i + 1];
            arr[i + 1] = arr[end];
            arr[end] = temp;
            return i + 1;
        }
    }
}
