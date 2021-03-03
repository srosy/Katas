namespace Algorithms
{
    public class MergeSort
    {
        public static int[] mergeSort(int[] array)
        {
            int[] left;
            int[] right;
            int[] result = new int[array.Length];

            //As this is a recursive algorithm, we need to have a base case to avoid an infinite recursion and therfore a stackoverflow
            if (array.Length <= 1)
            {
                return array;
            }

            int midPoint = array.Length / 2; // The exact midpoint of our array  

            left = new int[midPoint]; //Will represent our 'left' array

            if (array.Length % 2 == 0) //if array has an even number of elements, the left and right array will have the same number of elements
            {
                right = new int[midPoint];
            }
            else //if array has an odd number of elements, the right array will have one more element than left
            {
                right = new int[midPoint + 1];
            }

            //populate left array
            for (int i = 0; i < midPoint; i++)
            {
                left[i] = array[i];
            }

            //populate right array; We start our index from the midpoint, as we have already populated the left array from 0 to midpont.
            int x = 0;
            for (int i = midPoint; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }
            
            left = mergeSort(left); //Recursively sort the left array
            right = mergeSort(right); //Recursively sort the right array
            result = merge(left, right); //Merge our two sorted arrays

            return result;
        }

        //This method will be responsible for combining our two sorted arrays into one giant array
        public static int[] merge(int[] left, int[] right)
        {
            int resultLength = right.Length + left.Length;
            int[] result = new int[resultLength];
            int indexLeft = 0, indexRight = 0, indexResult = 0;

            //while either array still has an element
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                //if both arrays have elements  
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    if (left[indexLeft] <= right[indexRight]) //If item on left array is less than item on right array, add that item to the result array 
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else // else the item in the right array wll be added to the results array
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                else if (indexLeft < left.Length) //if only the left array still has elements, add all its items to the results array
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if (indexRight < right.Length) //if only the right array still has elements, add all its items to the results array
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }

            return result;
        }
    }
}
