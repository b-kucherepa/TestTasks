namespace TestTasks.SortTests
{
    /// <summary>
    /// It modifies bubble sort adding the backward movement to swapping iteration. 
    /// It contains the optimized bubble sorter insertion-alike improvement.
    /// </summary>
    /// <remarks>
    /// Worst-case asymptotic complexity (order of the execution time) is 
    /// O(N^2).
    /// Average asymptotic complexity is
    /// ϴ(N^2).
    /// Best-case asymptotic complexity is 
    /// Ω(N).
    /// Worst-case space complexity (order of the memory usage) is 
    /// O(1).
    /// </remarks>
    internal class CocktailShakerSort : SortAlgorithm
    {
        public override int[] ReturnSorted(int[] array)
        {
            //defines limits for both ends
            int leftBound = 0;
            int rightBound = array.Length - 1;

            do
            {
                //sets the potential new limits to opposites in case if the array is sorted already:
                int newLeftBound = rightBound;
                int newRightBound = leftBound;

                //starts from the left limit, the rest is the same as for the optimized bubble sort:
                for (int rightIndex = leftBound; rightIndex < rightBound; rightIndex++)
                {
                    if (array[rightIndex] > array[rightIndex + 1])
                    {
                        (array[rightIndex], array[rightIndex + 1]) 
                            = (array[rightIndex + 1], array[rightIndex]);
                        newRightBound = rightIndex;
                    }
                }
                rightBound = newRightBound;

                //the symmetrical backward movement:
                for (int leftIndex = rightBound; leftIndex >= leftBound; leftIndex--)
                {
                    if (array[leftIndex + 1] < array[leftIndex])
                    {
                        (array[leftIndex], array[leftIndex + 1]) 
                            = (array[leftIndex + 1], array[leftIndex]);
                        newLeftBound = leftIndex;
                    }
                }
                leftBound = newLeftBound;
            }
            while (leftBound <= rightBound);

            return array;
        }
    }
}