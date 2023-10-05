namespace TestTasks.SortTests
{
    /// <summary>
    /// The easiest type of sort. Checks all unsorted elements on the right side of array,
    /// finds the lowest value and adds it to the sorted part on the left side of array.
    /// </summary>
    /// <remarks>
    /// The biggest possible asymptotic complexity (maximal execution time) is O(n^2),
    /// The biggest possible space complexity (maximal usage of memory) is O(1).
    /// </remarks>

    internal class SelectionSort : ArraySort
    {
        public override int[] Begin(int[] array)
        {
            //The outer FOR loop iterates through every element of the array except the last one
            for (int leftIndex = 0; leftIndex < array.Length - 1; leftIndex++)
            {
                /* The inner FOR loop searches for the smallest elements sequentially 
                 * so all it needs is to find the next smallest candidate to 
                 * the leftIndex position from the unsorted rest of the array:*/
                int minIndex = leftIndex;

                for (int rightIndex = leftIndex + 1; rightIndex < array.Length; rightIndex++)
                {
                    //updates the new smallest element index if finds the one
                    if (array[rightIndex] < array[minIndex])
                    {
                        minIndex = rightIndex;
                    }
                }

                //swaps a new smallest element found with the leftIndex element,
                //pushing the latter away:
                (array[leftIndex], array[minIndex]) = (array[minIndex], array[leftIndex]);
            }

            return array;
        }
    }
}