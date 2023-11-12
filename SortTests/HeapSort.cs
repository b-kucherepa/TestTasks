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
    internal class HeapSort : SortAlgorithm
    {
        public override int[] SortArray(int[] array)
        {
            int count = array.Length;
            int midpoint = count / 2;

            /* recursively builds a binary heap rearranging the array. It treats each element
             * as if it were a root of it's own small subheap. Children of every node are located at:
             * left: (parentIndex * 2 + 1), right: (parentIndex * 2 + 2).
             * Therefore, a node has no children if (parentIndex * 2 + 1 > arrayLength-1).
             * Hence all the right part of the array consists of leaves (which have no children).
             * So algorithm needs to heapify only the left part or array.*/
            for (int i = midpoint - 1; i >= 0; i--)
            {
                Heapify(array, i, count);
            }

            //retrieves the next biggest element iteratively and
            //leaves it at the sorted part in the end of the array:
            for (int j = count - 1; j >= 0; j--)
            {
                //swaps the root with the last element,
                //the ex-root goes at the end of the array where sorted large elements stored:
                (array[0], array[j]) = (array[j], array[0]);

                //repeats heapifying with new root element which came to replace the ex-root:
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

            //children of the root are located at:
            int leftChild = 2 * root + 1;
            int rightChild = 2 * root + 2;

            //checks if leftChild child element exists and compares it with the largest element
            //(initially it's its root parent).
            //If it's bigger than the root, then it's new biggest element:
            if (leftChild < count && array[leftChild] > array[largest])
                largest = leftChild;

            //does the same for the rightChild child element (but this time the largest element
            //might be its sibling if sibling was bigger than the root parent)
            if (rightChild < count && array[rightChild] > array[largest])
                largest = rightChild;

            /* if the largest element isn't the root, it means the heapifying result 
             * isn't perfect so it's incomplete yet. Thus, it recursively calls itself to finish
             * the arrangement appropriate for a binary heap:*/
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
