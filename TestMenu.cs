using System.Diagnostics;

namespace TestTasks
{
    public abstract class TestMenu
    {
        internal delegate void MethodToSample();


        public abstract void Select();


        internal static string MeasureTime(MethodToSample method)
        {
            Stopwatch timer = new();

            timer.Restart();
            method();
            timer.Stop();

            return timer.Elapsed.ToString();
        }


        internal static int[] GenerateRandomArray(int length, int maxLimit)
        {
            return GenerateRandomArray (0, length, maxLimit);
        }


        internal static int[] GenerateRandomArray(int length, int minElement, int maxLimit)
        {
            var _testArray = new int[length];

            Random random = new();
            for (int i = 0; i < _testArray.Length; i++)
            {
                _testArray[i] = random.Next(minElement, maxLimit);
            }

            return _testArray;
        }


        internal static int[] GenerateSortedArray(int length)
        {
            var _testArray = new int[length];

            int currentValue = 0;
            Random random = new();

            for (int i = 0; i < _testArray.Length; i++)
            {
                _testArray[i] = currentValue;
                currentValue += random.Next(1, 5);
            }

            return _testArray;
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