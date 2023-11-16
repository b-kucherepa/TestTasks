using System.Diagnostics;

namespace TestTasks
{
    public abstract class TestMenu
    {
        internal static Stopwatch _timer = new();

        public abstract void Select();

        //internal static void 

        internal static bool ReadNumberInLimit(int min, int max, out int retrievedNumber)
        {
            Console.WriteLine("");
            string? input = Console.ReadLine();
            bool isSuccessful = int.TryParse(input, out int number);
            if ((isSuccessful) && (number >= min) && (number <= max))
            {
                retrievedNumber = number;
                return true;
            }
            else
            {
                retrievedNumber = 0;
                return false;
            }
        }

        internal int[] ReadIntegersArray(string separator, int min, int max)
        {
            Console.WriteLine("");
            string? input = Console.ReadLine();
            string[] elements = input.Split(separator);
            int[] integers = new int[elements.Length];

            for(int i = 0; i < integers.Length; i++) 
            {
                bool isSuccessful = int.TryParse(elements[i], out int number);
                if ((isSuccessful) && (number >= min) && (number <= max))
                {
                    integers[integers.Length-i-1] = number;
                }
                else
                {
                    return new int[0];
                }
            }

            return integers;
        }


        internal static int[] GenerateRandomArray(int length, int maxElement)
        {
            var _testArray = new int[length];

            Random random = new();
            for (int i = 0; i < _testArray.Length; i++)
            {
                _testArray[i] = random.Next(maxElement);
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
                currentValue += random.Next(1,5);
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