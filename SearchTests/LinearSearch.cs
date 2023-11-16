using TestTasks.SortTests;

namespace TestTasks.SearchTests
{
    /// <summary>
    /// This algorithm iterates through array primitively to find the needed key.
    /// </summary>
    /// <remarks>
    /// Worst-case asymptotic complexity (order of the execution time) is 
    /// O(N).
    /// Average asymptotic complexity is
    /// ϴ(N).
    /// Best-case asymptotic complexity is 
    /// Ω(1).
    /// Worst-case space complexity (order of the memory usage) is 
    /// O(1).
    /// </remarks>
    internal class LinearSearch : ArraySearchingAlgorithm
    {
        public override string Find(int key, int[] array)
        {
            for (int i = 0; i < array.Length; i++) 
            {
                if (array[i] == key)
                {
                    return $"The key has been found at the index {i}";
                }
            }
            return "The key hasn't been found";
        }

        public override string Find(string key, string[] array)
        {
            for (int i = 0; i < array.Length; i++) 
            {
                if (array[i] == key)
                {
                    return $"The key has been found at the index {i}";
                }
            }
            return "The key hasn't been found";
        }
    }
}