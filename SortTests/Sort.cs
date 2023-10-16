namespace TestTasks.SortTests
{
    internal abstract class Sort
    {
        public virtual int[] ReturnSorted(int[] array)
        {
            return array;
        }


        internal static int[] GetSubArray(int[] array, int firstIndex, int length)
        {
            int[] subArray = new int[length];
            Array.Copy(array, firstIndex, subArray, 0, length);
            return subArray;
        }


        public static int[] ConcatArrays(int[] a, int[] b)
        {
            int[] mergedArray = new int[a.Length + b.Length]; ;
            a.CopyTo(mergedArray, 0);
            b.CopyTo(mergedArray, a.Length);
            return mergedArray;
        }
    }
}