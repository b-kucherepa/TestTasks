namespace TestTasks.SortTests
{
    /// <summary>
    /// This sort algorithm creates binary heap recursively from the array to be sorted,
    /// it recursively heapifies heap branches until it becomes perfectly arranged.
    /// Every time it finds the next root, it places it at the end of the array 
    /// (in the sorted area). It then heapifies again to find the next root, 
    /// excluding the previous root, until all elements are sorted.
    /// It partially brings this algorithm together with the merge sort.
    /// </summary>
    /// <remarks>
    /// Worst-case asymptotic complexity (order of the execution time) is 
    /// O(N * log2(N)).
    /// Average asymptotic complexity is
    /// ϴ(N * log2(N)).
    /// Best-case asymptotic complexity is 
    /// Ω(N * log2(N)) (distinct keys) or Ω(N) (equal keys).
    /// Worst-case space complexity (order of the memory usage) is 
    /// O(N) total, O(1) auxiliary.
    /// </remarks>
    internal class HeapSort : Sort
    {
        public override int[] ReturnSorted(int[] inputArray)
        {
            int[] array = inputArray;
            int count = array.Length;
            int midpoint = count / 2;

            //recursively builds a binary heap regrouping the array
            for (int i = midpoint - 1; i >= 0; i--)
            {
                Heapify(array, i, count);
            }

            //retrieves elements from the heap iteratively
            for (int j = count - 1; j >= 0; j--)
            {
                //swaps the root with the last element
                //leaving it as the next biggest element
                (array[0], array[j]) = (array[j], array[0]);

                //excludes the outcasted root from the next iteration since
                //j becomes new subarray length, what means the last element is j-1:
                Heapify(array, 0, j);
            }
            return array;
        }


        /// <summary>
        /// Turns the part of array to the branch of the binary heap with 
        /// the specified array index as its root.
        /// </summary>
        void Heapify(int[] array, int root, int count)
        {
            //sees the root as the largest element (as it should be in binary heap):
            int largest = root;

            //that's the most convenient left and right elements to start heapifying from:
            int left = 2 * root + 1; 
            int right = 2 * root + 2;

            //compares left child element. If it's bigger than the root, then
            //it's new biggest element:
            if (left < count && array[left] > array[largest])
                largest = left;

            //does the same for the right child element:
            if (right < count && array[right] > array[largest])
                largest = right;

            /* if the largest element isn't the root, it means the heapifying
             * isn't incomplete yet. So it recursively calls itself to finish
             * the arrangment appropriate for a binary heap:*/
            if (largest != root)
            {
                //switches the root and the largest element and...
                (array[root], array[largest]) = (array[largest], array[root]);

                //...continues heapify elements which haven't been heapified yet:
                Heapify(array, largest, count);
            }
        }
    }
}
