using System.Diagnostics;

namespace TestTasks
{
    public abstract class TestMenu
    {
        internal static Stopwatch _timer = new();

        public abstract void Select();

        internal static int ReadNumberInLimit(int min, int max)
        {
            Console.WriteLine("");
            string? input = Console.ReadLine();
            bool isSuccessful = int.TryParse(input, out int number);
            if ((isSuccessful) && (number >= min) && (number <= max))
            {
                return number;
            }
            else
            {
                return -1;
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
    }
}