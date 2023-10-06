namespace TestTasks.SortTests
{
    /// <summary>
    /// This sort iterates through the unsorted array and compares each element with 
    /// the element in the sorted part located at the beginning of the array 
    /// to find the right position to insert it.
    /// </summary>
    /// <remarks>
    /// The biggest possible asymptotic complexity (maximal execution time) is O(n^2),
    /// The biggest possible space complexity (maximal usage of memory) is O(n).
    /// </remarks>
    internal class InsertionSort : ArraySort
    {
        public override int[] ReturnSorted(int[] array)
        {
            /* The outer FOR loop iterates through the unsorted array part
             * starting from the second element*/
            for (int processedIndex = 1; processedIndex < array.Length; processedIndex++)
            {
                //a value to be inserted during the current iteration
                int element = array[processedIndex];

                //an index to iterate through the sorted part,
                //except for the first index which finds its place automatically:
                int sortedIndex = processedIndex - 1;

                // The inner WHILE loop iterates through the sorted part in descending order: 
                while ((sortedIndex >= 0) && (array[sortedIndex] > element))
                {
                    //if the sorted element is still bigger than the inserted element,
                    //the loop shifts that element one step to the right... 
                    array[sortedIndex + 1] = array[sortedIndex];

                    //...and goes to check the next sorted element to...
                    sortedIndex--;
                }

                //... give the inserted element its place eventually:
                array[sortedIndex + 1] = element;
            }

            return array;
        }
    }
}