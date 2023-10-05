namespace TestTasks.SortTests
{
    /// <summary>
    /// The merge sort algorithm is a comparatively quick algorithm which halves the array until 
    /// the smallest elements remaining have a length of one. 
    /// Then, it merges these elements pair by pair in ascending order 
    /// using recursive calls to itself. It follows the "divide and conquer" paradigm.
    /// </summary>
    /// <remarks>
    /// The biggest possible asymptotic complexity (maximal execution time) is O(n * log2(n)).
    /// The biggest possible space complexity (maximal usage of memory) is O(n).
    /// </remarks>
    internal class MergeSorter : ArraySorter
    {
        public override int[] Sort(int[] array)
        {

            int count = array.Length;
            if (count <= 1)
            {
                return array;
            }
            else
            {
                int half = count / 2;

                int[] leftHalf = GetSubArray(array, 0, half);
                int[] rightHalf = GetSubArray(array, half, count - half);

                int[] subLeftHalf = Sort(leftHalf);
                int[] subRightHalf = Sort(rightHalf);

                return MergeFromMinToMax(subLeftHalf, subRightHalf);
            }
        }


        private int[] MergeFromMinToMax(int[] aArray, int[] bArray)
        {
            int[] mergedArray = new int[aArray.Length + bArray.Length];

            /* The FOR loop sees two smaller arrays as two packs of already arranged elements. 
             * In each pack, the smaller elements are always closer to the pack opening. 
             * Every iteration, the loop takes the smallest element it "sees" from 
             * the pack openings of two arrays and adds it into the one big arranged array.*/

            int aIndex = 0;
            int bIndex = 0;

            for (int mIndex = 0; mIndex < mergedArray.Length; mIndex++)
            {
                /* If the aArray hasn't been depleted 
                 * and the current aArray element is lesser than the current bArray element, 
                 * or if the bArray has been depleted, 
                 * the current aArray value is added to the result array 
                 * as the next smallest number, and the aArray index is incremented.*/
                if ((aIndex < aArray.Length)
                    && ((bIndex >= bArray.Length) || (aArray[aIndex] < bArray[bIndex])))
                {
                    mergedArray[mIndex] = aArray[aIndex];
                    aIndex++;
                    continue;
                }

                //this condition performs the same operation for the bArray
                if ((bIndex < bArray.Length)
                    && ((aIndex >= aArray.Length) || (bArray[bIndex] <= aArray[aIndex])))
                {
                    mergedArray[mIndex] = bArray[bIndex];
                    bIndex++;
                    continue;
                }
            }

            return mergedArray;
        }
    }
}
