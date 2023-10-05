using System.Drawing;
using System.Globalization;
using System.Reflection.Emit;
using System.Reflection;
using System.Xml.Linq;

namespace TestTasks.SortTests
{
    /// <summary>
    /// Quicksort was developed by British computer scientist Tony Hoare in 1959 and published in 1961.
    /// The current realization uses Hoare's partition scheme.
    /// It chooses a random pivot and compares all other elements, placing lesser ones 
    /// on the left side and bigger ones on the right side of the pivot. 
    /// Once it's done, the algorithm selects two new pivots on both sides and repeats the sort. 
    /// It iterates recursively until there is only one element remaining in each separation. 
    /// After that, the algorithm inserts every pivot between 
    /// the sorted groups it's connected with and merges them from the leaves to the root.
    /// </summary>
    /// <remarks>
    /// The biggest possible asymptotic complexity (maximal execution time) is O(n^2),
    /// but in average cases it's around θ(n * log2(n)), while in the best case it's O(n).
    /// The biggest possible space complexity (maximal usage of memory) is Ω(log2(n)).
    /// </remarks>
    internal class HoareQuickSorter : ArraySorter
    {
        public override int[] Sort(int[] array)
        {
            return QuicksortProcedure(array, 0, array.Length-1);
        }
        private int[] QuicksortProcedure(int[] array, int leftBound, int rightBound)
        {
            //if the bounds are within the limits, the algorithm defines a new partition and
            //makes recursive calls at the two halves of the list itself
            if (leftBound >= 0 && rightBound >= 0 && leftBound < rightBound)
            {
                int partition = PartitionSort(array, leftBound, rightBound);
                array = QuicksortProcedure(array, leftBound, partition);
                array = QuicksortProcedure(array, partition + 1, rightBound);
            }

            return array;
        }
        /// <summary>
        /// Sorts elements along the pivot and defines the new one upon finishing
        /// </summary>
        private int PartitionSort(int[] array, int leftBound, int rightBound)
        {
            //in this specific implementation, the function takes the 3/4 point of
            //the provided array (or subarray) as new random pivot element:
            int pivotIndex = (rightBound - leftBound) / 2 + leftBound;
            int pivotElement = array[pivotIndex];

            //the starting indices are defined to compensate for the first increment/decrement that
            //occurs within the unavoidable DO operators that are executed below:
            int leftIndex = leftBound - 1;
            int rightIndex = rightBound + 1;

            //The outer WHILE loop keeps going until while both "scanning lines" are met.
            //That's the new partition pivot to be returned.
            while (true)
            {
                /* this block skips all elements that are smaller than the pivot element, since 
                 * they could be considered already sorted relative to the pivot element. 
                 * It still advances one step at a time during each iteration to prevent stuck.
                 * It doesn't miss any pairs of elements that need to be swapped, as those pairs 
                 * were already swapped forcefully at the end of the previous iteration: */

                do
                {
                    leftIndex++;
                }
                while (array[leftIndex] < pivotElement);


                //the same is true symmetrically for this block:
                do
                {
                    rightIndex--;
                }
                while (array[rightIndex] > pivotElement);

                /* if the two scanning positions are met, this stage of sorting is finished, and
                 * a new partition element is found to be returned. The function then returns
                 * the new pivot element, which will be used to define the new partition: */
                if (leftIndex >= rightIndex)
                {
                    return rightIndex;
                }

                /* swaps the left and right elements currently being "scanned" forcibly because 
                 * at least one of the elements is on the wrong side of the pivot (while 
                 * the second element is also on the wrong side or equal to the pivot): */
                (array[leftIndex],array[rightIndex]) = (array[rightIndex],array[leftIndex]); 
            }
        }
    }
}