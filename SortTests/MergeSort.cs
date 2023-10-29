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
        public override int[] ReturnSorted(int[] inputArray)
        {
            int[] array = inputArray;
            return Split(array, 0, array.Length-1);
        }


        private int[] Split(int[] array, int leftBound, int rightBound)
        {
            //if two bounds are equal, it means array consists of only 1 element
            //(which is == leftBound == rightBound). One-element array is sorted
            //by default so the method returns it:
            if (rightBound == leftBound)
            {
                return new int[] { array[leftBound] };
            }
            else
            //continues splitting...
            {
                int midPoint = (rightBound + leftBound) / 2;

                int[] leftHalf = Split(array, leftBound, midPoint);
                int[] rightHalf = Split(array, midPoint + 1, rightBound);
                
                //...to merge all parts eventually and return recursively for merging further:
                return SortAndMerge(leftHalf, rightHalf);
            }
        }


        private int[] SortAndMerge(int[] leftArray, int[] rightArray)
        {
            int[] combinedArray = new int[leftArray.Length + rightArray.Length];

            /* The FOR loop sees two smaller arrays as two packs of already arranged elements. 
             * In each pack, the smaller elements are always closer to the pack opening. 
             * Every iteration, the loop takes the smallest element it "sees" from 
             * the pack openings of two arrays and adds it into the one big arranged array.*/

            int lIndex = 0;
            int bIndex = 0;

            for (int cIndex = 0; cIndex < combinedArray.Length; cIndex++)
            {
                /* If the leftArray hasn't been depleted 
                 * and the current leftArray element is lesser than the current rightArray element, 
                 * or if the rightArray has been depleted, 
                 * the current leftArray value is added to the result array 
                 * as the next smallest number, and the leftArray index is incremented.*/
                if ((lIndex < leftArray.Length)
                    && ((bIndex >= rightArray.Length) || (leftArray[lIndex] < rightArray[bIndex])))
                {
                    combinedArray[cIndex] = leftArray[lIndex];
                    lIndex++;
                    continue;
                }

                //this condition performs the same operation for the rightArray
                if ((bIndex < rightArray.Length)
                    && ((lIndex >= leftArray.Length) || (rightArray[bIndex] <= leftArray[lIndex])))
                {
                    combinedArray[cIndex] = rightArray[bIndex];
                    bIndex++;
                    continue;
                }
            }

            return combinedArray;
        }
    }
}
