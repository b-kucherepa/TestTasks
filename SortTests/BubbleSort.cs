namespace TestTasks.SortTests
{
    /// <summary>
    /// This is a slow, basic, and primarily educational implementation of a sorting algorithm.
    /// If any swaps occur during the iteration process, it iterates again 
    /// to ensure the sorting is complete and there are no more swaps required.
    /// </summary>
    /// <remarks>
    /// Worst-case asymptotic complexity (order of the execution time) is 
    /// O(N^2) comparisons, O(N^2) swaps.
    /// Average asymptotic complexity is
    /// ϴ(N^2) comparisons, ϴ(N^2) swaps.
    /// Best-case asymptotic complexity is 
    /// Ω(N) comparisons, Ω(1) swaps.
    /// Worst-case space complexity (order of the memory usage) is 
    /// O(N) total, O(1) auxiliary.
    /// </remarks>
    internal class BubbleSort : SortAlgorithm
    {
        public override int[] ReturnSorted(int[] array)
        {
            bool isSwapped;

            do
            {
                isSwapped = false;

                //doesn't include last element because it finds its place during
                //the check of next to the last element:
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                        isSwapped = true;
                    }
                }
            }
            while (isSwapped);

            return array;
        }
    }
}