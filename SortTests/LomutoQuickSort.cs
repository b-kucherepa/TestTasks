namespace TestTasks.SortTests
{
    /// <summary>
    /// Quicksort with Lomuto's partition scheme. A more popular variation.
    /// It goes at one direction only (here it's from left-to-right taking the rightmost element 
    /// as the pivot value to compare subarrays with).
    /// Lomuto's scheme is less efficient than the original Hoare's one because 
    /// it does three times more swaps on average but it's easier to understand and implement.
    /// </summary>
    /// <remarks>
    /// Worst-case asymptotic complexity (order of the execution time) is 
    /// O(N^2).
    /// Average asymptotic complexity is
    /// ϴ(N * log2(N)).
    /// Best-case asymptotic complexity is 
    /// Ω(N * log2(N)) because of simple partition.
    /// Worst-case space complexity (order of the memory usage) is 
    /// Ω(N).
    /// </remarks>
    internal class LomutoQuickSort : SortingAlgorithm
    {
        public override int[] SortArray(int[] array)
        {
            return QuicksortProcedure(array, 0, array.Length - 1);
        }


        private int[] QuicksortProcedure(int[] array, int leftBound, int rightBound)
        {
            //unlike Hoare's sort, it has only left bound changeable:
            if (leftBound >= 0 && leftBound < rightBound)
            {
                int partitionIndex = PartitionSort(array, leftBound, rightBound);
                QuicksortProcedure(array, leftBound, partitionIndex - 1);
                QuicksortProcedure(array, partitionIndex+1, rightBound);
            }

            return array;
        }


        private int PartitionSort(int[] array, int leftBound, int rightBound)
        {
            //sets sort pivot value equal to the rightmost element of the subarray:
            int pivotElement = array[rightBound];

            /* sets the "virtual" separation index to the leftmost element.
             * It doesn't bear any value to compare, it just points the separation line
             * between those elements which are lesser and those elements which are greater than
             * the "real" pivot value used for comparison: */
            int separatorIndex = leftBound;

            /* the FOR loop iterates through the subarray. If the current element is greater than
             * the pivot element, it does nothing because it's already at the proper place 
             * (by the right side of the separator). 
             * But if the current element is lesser than the pivot element, it swaps 
             * the element standing at the separator index with the current element (because 
             * the current element should be by the left side of the separator), and shifts 
             * the separator to the right because there was one more element inserted before it: */
            for (int i = leftBound; i < rightBound; i++)
            {
                if (array[i] < pivotElement)
                {
                    (array[separatorIndex], array[i]) = (array[i], array[separatorIndex]);
                    separatorIndex++;
                }
            }

            /* once the whole subarray is sorted, it swaps the pivot element which value was used to
             * sort the subarray with the separator index element. Since it's greater than elements 
             * by the left side and lesser than elements by the right side of the separator, 
             * it should be between these two groups to maintain order. */
            (array[separatorIndex], array[rightBound]) = (array[rightBound], array[separatorIndex]);

            //the separator index becomes next partition index:
            return separatorIndex;
        }
    }
}