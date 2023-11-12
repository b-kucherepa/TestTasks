namespace TestTasks.SortTests
{
    /// <summary>
    /// This sort algorithm was developed by Donald Shell. 
    /// It improves insertion sorting algorithm approach by splitting the array into groups,
    /// proceeding with the insertion sorting inside of each group. At next iterations
    /// it splits the array into the less number of enlarged groups and repeats the sort. 
    /// This process is repeated until the whole array is sorted in the final passing. 
    /// The core idea is to reduce the disorder of array elements with every splitting step,
    /// thus speeding up the sort of groups at next iterations.
    /// Splitting into the groups is implemented by taking all elements which stay at
    /// the same interval in one group, decreasing the interval each iteration.
    /// This version has optimized grouping steps.
    /// </summary>
    /// <remarks>
    /// Worst-case asymptotic complexity (order of the execution time) is 
    /// O(N^2) (worst known worst case gap sequence), 
    /// O(N * log2(N)^2) (worst known worst case gap sequence).
    /// Average asymptotic complexity is
    /// dependent on gap sequence (really hard to compute).
    /// Best-case asymptotic complexity is 
    /// Ω(N * log2(N)) (most gap sequences), 
    /// Ω(N * log2(N)^2) (best known worst-case gap sequence).
    /// Worst-case space complexity (order of the memory usage) is 
    /// O(N) total, 
    /// O(1) auxiliary.
    /// </remarks>
    internal class ShellSort : SortAlgorithm
    {
        public override int[] SortArray(int[] array)
        {
            int step = 1;

            //searches for the optimal sort step recursively:
            while (step <= array.Length / 3)
            {
                step = step * 3 + 1;
            }

            //repeats until the sort step is bigger than 0 
            //(from the bigger step to 1 where the whole array is in one "group")
            while (step > 0)
            {
                for (int sortedIndex = step; sortedIndex < array.Length; sortedIndex++)
                {
                    //saves array[sortedIndex] in temp variable and
                    //makes a hole at position "sortedIndex": 
                    int preservedElement = array[sortedIndex];

                    //shifts elements up inside the every group until the correct  
                    //location for array[sortedIndex] (the preservedElement currently) is found:
                    int inGroupIndex = sortedIndex;
                    while (inGroupIndex > step - 1 && array[inGroupIndex - step] > preservedElement)
                    {
                        array[inGroupIndex] = array[inGroupIndex - step];
                        inGroupIndex -= step;
                    }

                    //puts the saved variable back in the array in the correct position:
                    array[inGroupIndex] = preservedElement;
                }

                //decreases the sort step thus making each "group" bigger:
                step = (step - 1) / 3;
            }

            return array;
        }
    }
}
