namespace TestTasks.SortTests
{
    /// <summary>
    /// This modified bubble sort algorithm includes an iteration limit, which is set 
    /// to the location where the last swap occurred during the previous iteration. 
    /// Since everything to the right of that location is already sorted, 
    /// it doesn't require any swaps. It incorporates an element of insertion sort 
    /// which separates the sorted part of the array as well.
    /// </summary>
    /// <remarks>
    /// Worst-case asymptotic complexity (order of the execution time) is 
    /// O(N^2) comparisons, O(N^2) swaps.
    /// Average asymptotic complexity is
    /// ϴ(N^2) comparisons, ϴ(N^2) swaps, however can be as twice as fast as the unoptimized version.
    /// Best-case asymptotic complexity is 
    /// Ω(N) comparisons, Ω(1) swaps.
    /// Worst-case space complexity (order of the memory usage) is 
    /// O(N) total, O(1) auxiliary.
    /// </remarks>
    internal class BubbleOptimizedSort : SortAlgorithm
    {
        public override int[] ReturnSorted(int[] array)
        {
            //defines the limit for the right end
            int rightBound = array.Length - 1;

            do
            {
                //sets the potential new limit to [0] in case if the array is sorted already
                int newBound = 0;
                for (int i = 0; i < rightBound; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                        newBound = i;
                    }
                }

                //sets new limit according to the last swap occurence
                rightBound = newBound;
            }
            while (rightBound > 0);

            return array;
        }
    }
}