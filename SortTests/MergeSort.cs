namespace TestTasks.SortTests
{
    /// <summary>
    /// The merge sort algorithm is a comparatively quick algorithm which halves the array until 
    /// the smallest elements remaining have a length of one. 
    /// Then, it merges these elements pair by pair in ascending order 
    /// using recursive calls to itself. It follows the "divide and conquer" paradigm.
    /// </summary>
    /// <remarks>
    /// Worst-case asymptotic complexity (order of the execution time) is 
    /// O(N * log2(N)).
    /// Average asymptotic complexity is
    /// ϴ(N * log2(N)).
    /// Best-case asymptotic complexity is 
    /// Ω(N * log2(N)) (typical) or Ω(N) (natural variant).
    /// Worst-case space complexity (order of the memory usage) is 
    /// O(N) total, O(n) auxiliary typically but O(1) with linked lists.
    /// </remarks>
    internal class MergeSort : SortAlgorithm
    {
        public override int[] ReturnSorted(int[] array)
        {
            Split(array, 0, array.Length - 1);
            return array;
        }


        private void Split(int[] array, int leftBound, int rightBound)
        {
            //while subarray consist of more than one element (an interval between two bounds
            //is bigger than 0),...
            if (leftBound < rightBound)
            {
                //...the algorithm finds the middle point between two bounds and...
                int midPoint = (leftBound + rightBound) / 2;

                //...splits subarray at two halves until each half consists only of 1 element:
                Split(array, leftBound, midPoint);
                Split(array, midPoint + 1, rightBound);

                //then it begins to sort and merge every pair of subarrays recursively,
                //merging them until the whole-sized, now sorted, array is reassembled:
                SortAndMerge(array, leftBound, midPoint, midPoint + 1, rightBound);
            }
            //if two bounds are met, it means array consists of only 1 element
            //(which is == leftBound == rightBound). One-element array is sorted
            //by default so we can just leave it as it is:
            else
            {
                return;
            }
        }


        private void SortAndMerge(int[] array, int leftStart, int leftEnd,
        int rightStart, int rightEnd)
        {
            //preparing space for the sorted combined array:
            int[] mergedArray = new int[rightEnd + 1 - leftStart];

            //left subarray half elements stand between leftStart and leftEnd index:
            int leftIndex = leftStart;
            //similarly for right subarray half elements:
            int rightIndex = rightStart;

            /* this FOR loop sees two subarray halves as two "packs" of already arranged elements. 
             * In each "pack", the smaller elements are always closer to the "pack opening". 
             * On every iteration, the loop takes the smallest element it "sees" through 
             * the "pack openings", and copies it into the one big arranged merged array.*/
            for (int mergedIndex = 0; mergedIndex < mergedArray.Length; mergedIndex++)
            {
                //if one of halves is depleted (because its elements were smaller than
                //the rest in the other half), the loop just takes the rest from the other half:
                if (leftIndex > leftEnd)
                {
                    mergedArray[mergedIndex] = array[rightIndex];
                    rightIndex++;
                    continue;
                }

                if (rightIndex > rightEnd)
                {
                    mergedArray[mergedIndex] = array[leftIndex];
                    leftIndex++;
                    continue;
                }

                /* otherwise, if the current left half element (an element looking from 
                 * the "left pack opening" currently) is lesser than the current right half element, 
                 * the current left half value is added to the resulting merged array as 
                 * the next smallest number, and the left half index is incremented
                 * (so next element will be looking from the "opening").*/
                if (array[leftIndex] < array[rightIndex])
                {
                    mergedArray[mergedIndex] = array[leftIndex];
                    leftIndex++;
                    continue;
                }

                //this block performs similar operations for the right subarray half:
                if (array[rightIndex] <= array[leftIndex])
                {
                    mergedArray[mergedIndex] = array[rightIndex];
                    rightIndex++;
                    continue;
                }
            }

            /* copies sorted elements from the sorted merged subarray back to the initial array.
             * It's possible to be done directly due to the fact arrays are passed by reference.*/
            for (int copyingIndex = 0; copyingIndex < mergedArray.Length; copyingIndex++)
            {
                array[leftStart + copyingIndex] = mergedArray[copyingIndex];
            }
        }
    }
}