namespace TestTasks.SortTests
{
    /// <summary>
    /// Quicksort with Lomuto's partition scheme. A more popular variation.
    /// It goes at one direction only (in this specific implementation it's right-to-left).
    /// Lomuto's scheme is less efficient than the original Hoare's one because 
    /// it does three times more swaps on average but it's easier to understand and implement.
    /// </summary>
    /// <remarks>
    /// The biggest possible asymptotic complexity (maximal execution time) is O(n^2),
    /// but in average cases it's around θ(n * log2(n)), while in the best case it's Ω(n).
    /// The biggest possible space complexity (maximal usage of memory) is O(log2(n)).
    /// </remarks>
    internal class LomutoQuickSort : ArraySort
    {
        public override int[] ReturnSorted(int[] array)
        {
            return QuicksortProcedure(array, 0, array.Length - 1);
        }

        private int[] QuicksortProcedure(int[] array, int leftBound, int rightBound)
        {
            if (leftBound >= rightBound || leftBound < 0)
            {
                return array;
            }

            int partition = PartitionSort(array, leftBound, rightBound);
            array = QuicksortProcedure(array, leftBound, partition-1);
            array = QuicksortProcedure(array, partition + 1, rightBound);

            return array;
        }

        private int PartitionSort(int[] array, int leftBound, int rightBound)
        {
            //sets partition pivot simply to right bound:
            int pivotElement = array[rightBound];

            //temporaty pivot index:
            int newPivotIndex = leftBound - 1;

            for (int i = leftBound; i < rightBound - 1; i++)
            {
                if (array[i] <= pivotElement)
                {
                    newPivotIndex++;
                    (array[newPivotIndex], array[i]) = (array[i], array[newPivotIndex]);
                }
            }

            newPivotIndex++;
            (array[newPivotIndex], array[rightBound]) = (array[rightBound], array[newPivotIndex]);
            return newPivotIndex;
        }
    }
}