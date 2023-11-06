using System.Diagnostics;

namespace TestTasks.SortTests
{
    public class SortSelection : TestSelection
    {
        private int _testNumber = 1;
        private int[] _testArray = NewTestArray(20);
        private Stopwatch _timer = new();
        private const int NUMBER_LIMIT = 10000;

        public override void Select()
        {
            Console.WriteLine();
            Console.WriteLine("Enter the random test array length (1-100000) to generate one,");

            if (_testNumber == 1)
            {
                Console.WriteLine("or enter any other key to use an array " +
                    "of the default length 20");
            }
            else
            {
                Console.WriteLine("or enter any other key to keep the same array");
            }

            int selectedOption = ReadNumberInLimit(1, 100000);
            if (selectedOption != -1)
            {
                _testArray = NewTestArray(selectedOption);
            }

            Console.WriteLine("Select a sort algorithm to test:");
            Console.WriteLine("> Enter 1 to use merge sort,");
            Console.WriteLine("> Enter 2 to use insertion sort,");
            Console.WriteLine("> Enter 3 to use selection sort,");
            Console.WriteLine("> Enter 4 to use bubble sort,");
            Console.WriteLine("> Enter 5 to use optimized bubble sort,");
            Console.WriteLine("> Enter 6 to use cocktail shaker sort,");
            Console.WriteLine("> Enter 7 to use Hoare's partition scheme quicksort,");
            Console.WriteLine("> Enter 8 to use Lomuto's partition scheme quicksort,");
            Console.WriteLine("> Enter 9 to use heap sort,");
            Console.WriteLine("> Enter 10 to use Shell sort,");
            Console.WriteLine("> Enter 11 to use radix sort,");
            Console.WriteLine("< Enter any other key to return.");

            SortAlgorithm sort;
            switch (Console.ReadLine())
            {
                case "1":
                    sort = new MergeSort();
                    break;
                case "2":
                    sort = new InsertionSort();
                    break;
                case "3":
                    sort = new SelectionSort();
                    break;
                case "4":
                    sort = new BubbleSort();
                    break;
                case "5":
                    sort = new BubbleOptimizedSort();
                    break;
                case "6":
                    sort = new CocktailShakerSort();
                    break;
                case "7":
                    sort = new HoareQuickSort();
                    break;
                case "8":
                    sort = new LomutoQuickSort();
                    break;
                case "9":
                    sort = new HeapSort();
                    break;
                case "10":
                    sort = new ShellSort();
                    break;
                case "11":
                    sort = new RadixSort();
                    break;
                default:
                    return;
            }

            Console.WriteLine("\n>>>TEST NUMBER " + _testNumber + "<<<\n");
            Program.PrintArrayData(_testArray, "\n-Unsorted:-");

            int [] arrayToSort = new int[_testArray.Length];
            Array.Copy(_testArray, arrayToSort, _testArray.Length);

            _timer.Restart();
            arrayToSort = sort.ReturnSorted(arrayToSort);
            _timer.Stop();
            Program.PrintArrayData(arrayToSort, "\n-Sorted:-");
            Console.WriteLine("\nAn approximate execution time (more precise with bigger arrays): " 
                + _timer.Elapsed + "ms.\n");

            _testNumber++;

            Select();
        }


        private static int[] NewTestArray(int length)
        {
            var _testArray = new int[length];

            Random random = new();
            for (int i = 0; i < _testArray.Length; i++)
            {
                _testArray[i] = random.Next(NUMBER_LIMIT);
            }

            return _testArray;
        }


        public static int ReadNumberInLimit(int min, int max)
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
    }
}