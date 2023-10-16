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
    /// The biggest possible asymptotic complexity (maximal execution time) is O(n^2),
    /// hovewer it can be up to twice as fast as the non-optimized bubble sort.
    /// The biggest possible space complexity (maximal usage of memory) is O(n).
    /// </remarks>
    internal class BubbleOptimizedSort : Sort
    {
        public override int[] ReturnSorted(int[] inputArray)
        {
            int[] array = inputArray;
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