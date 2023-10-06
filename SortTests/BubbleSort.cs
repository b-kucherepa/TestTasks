namespace TestTasks.SortTests
{
    /// <summary>
    /// This is a slow, basic, and primarily educational implementation of a sorting algorithm.
    /// If any swaps occur during the iteration process, it iterates again 
    /// to ensure the sorting is complete and there are no more swaps required.
    /// </summary>
    /// <remarks>
    /// The biggest possible asymptotic complexity (maximal execution time) is O(n^2),
    /// and the same is for average cases. That makes it one of the slowest sort algorithms.
    /// The biggest possible space complexity (maximal usage of memory) is O(n).
    /// </remarks>
    internal class BubbleSort : ArraySort
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