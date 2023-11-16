namespace TestTasks.SortTests
{
    /// <summary>
    /// Quicksort was developed by British computer scientist Tony Hoare in 1959 and 
    /// published in 1961.
    /// The current realization uses Hoare's partition scheme.
    /// It chooses a pivot in the middle of subarray and compares all other elements, 
    /// placing lesser ones on the left side and bigger ones on the right side of the pivot. 
    /// Once it's done, the algorithm selects two new pivots on both sides and repeats the sort. 
    /// It iterates recursively until there is only one element remaining in each separation. 
    /// After that, the algorithm inserts every pivot between 
    /// the sorted groups it's connected with and merges them from the leaves to the root.
    /// </summary>
    /// <remarks>
    /// Worst-case asymptotic complexity (order of the execution time) is 
    /// O(N^2).
    /// Average asymptotic complexity is
    /// ϴ(N * log2(N)).
    /// Best-case asymptotic complexity is 
    /// Ω(N) due to three-way partition and equal keys.
    /// Worst-case space complexity (order of the memory usage) is 
    /// Ω(N * log2(N)).
    /// </remarks>
    internal class HoareQuickSort : SortingAlgorithm
    {
        public override int[] SortArray(int[] array)
        {
            return QuicksortProcedure(array, 0, array.Length - 1);
        }


        private int[] QuicksortProcedure(int[] array, int leftBound, int rightBound)
        {
            /* if the bounds are within the limits and not met together (so partition consists
             * more than of one element), the algorithm defines a new partition and
             * makes recursive calls of itself at the two halves of the array */
            if (leftBound >= 0 && rightBound >= 0 && leftBound < rightBound)
            {
                //at first, it sorts the array compared to the pivot element, and
                //returns new partition index:
                int partitionIndex = PartitionSort(array, leftBound, rightBound);
                //NB: arrays are passed by reference, so we don't need to save
                //returned sorted array any special way since the initial array was sorted itself:
                QuicksortProcedure(array, leftBound, partitionIndex);
                QuicksortProcedure(array, partitionIndex + 1, rightBound);
            }

            return array;
        }


        /// <summary>
        /// Sorts elements along the pivot and defines the new one upon finishing
        /// </summary>
        private int PartitionSort(int[] array, int leftBound, int rightBound)
        {
            //in this specific implementation, the function takes the middle point of
            //the provided subarray as new sort pivot element:
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
                 * It still advances one step during each iteration to prevent stuck.
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
                 * a new partition element is found to be returned. The block then returns
                 * an element which will be used to perform the next partition: */
                if (leftIndex >= rightIndex)
                {
                    return rightIndex;
                }

                /* swaps the left and right elements being "scanned" currently by force because
                 * at least one of the elements is on the wrong side of the pivot (while 
                 * the second element is also on the wrong side or equal to the pivot).
                 * That's true due to the fact the algorithm skipped all elements
                 * which were at proper sides.*/
                (array[leftIndex], array[rightIndex]) = (array[rightIndex], array[leftIndex]);
            }
        }
    }
}