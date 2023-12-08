using TestTasks.SortTests;

namespace TestTasks.SearchTests
{
    /// <summary>
    /// This algorithm filters half of rest elements in the array every time it compares the searched key
    /// with the central element among the rest of the array. It allows to ignore elements which 
    /// are a priori lesser or greater than the key.
    /// </summary>
    /// <remarks>
    /// Worst-case asymptotic complexity (order of the execution time) is 
    /// O(N * log2(N)).
    /// Average asymptotic complexity is
    /// ϴ(N * log2(N)).
    /// Best-case asymptotic complexity is 
    /// Ω(1).
    /// Worst-case space complexity (order of the memory usage) is 
    /// O(1).
    /// </remarks>
    internal class BinarySearch : ArraySearchingAlgorithm
    {
        //an implementation which illustrates usage of the pretty visual integral numeric types comparison operators:
        public override string Find(int key, int[] array)
        {
            int startIndex = 0;
            int endIndex = array.Length - 1;

            while (startIndex <= endIndex)
            {
                int middleIndex = (startIndex + endIndex) / 2;

                if (key < array[middleIndex])
                {
                    endIndex = middleIndex - 1;
                }
                else if (key > array[middleIndex])
                {
                    startIndex = middleIndex + 1;
                }
                else
                {
                    return $"The key has been found at the index {middleIndex}";
                }
            }
            return "The key hasn't been found";
        }

        //an implementation which illustrates generic approach to comparison for any type
        //(don't forget to implement IComparable.CompareTo() method for a custom class!)
        public override string Find(string key, string[] array)
        {
            int startIndex = 0;
            int endIndex = array.Length - 1;

            while (startIndex <= endIndex)
            {
                int middleIndex = (startIndex + endIndex) / 2;
                string middleElement = array[middleIndex];
                switch (middleElement.CompareTo(key))
                {
                    case 1:
                        endIndex = middleIndex - 1;
                        break;
                    case -1:
                        startIndex = middleIndex + 1;
                        break;
                    case 0:
                        return $"The key has been found at the index {middleIndex}";
                    default:
                        throw new Exception("middle.CompareTo returned not 1, 0, or -1!");
                }
            }
            return "The key hasn't been found";
        }
    }
}
