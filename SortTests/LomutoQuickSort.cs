namespace TestTasks.SortTests
{
    /// <summary>
    /// Quicksort with Lomuto's partition scheme. A more popular variation.
    /// It goes at one direction only (in this specific implementation it's right-to-left).
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
    internal class LomutoQuickSort : Sort
    {
        public override int[] ReturnSorted(int[] inputArray)
        {
            int[] array = inputArray;
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
            array = QuicksortProcedure(array, partition, rightBound);

            return array;
        }

        private int PartitionSort(int[] array, int leftBound, int rightBound)
        {
            //sets partition pivot simply to right bound:
            int pivotElement = array[rightBound];

            //temporaty pivot index:
            int newPivotIndex = leftBound - 1;

            for (int i = leftBound; i < rightBound; i++)
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