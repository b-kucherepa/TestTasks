namespace TestTasks.SortTests
{
    public class SortSelection : TestSelection
    {
        private int testNumber = 1;
        private int[] testArray;

        public override void Select()
        {
            Console.WriteLine();
            Console.WriteLine("Enter the random test array length (1-10000) to generate one,");

            if (testNumber == 1)
            {
                Console.WriteLine("or enter any other key to use an array " +
                    "of the default length 50");
            }
            else
            {
                Console.WriteLine("or enter any other key to keep the same array");
            }

            int selectedOption = ReadNumberInLimit(1, 10000);
            if (selectedOption != -1)
            {
                testArray = NewTestArray(selectedOption);
            }

            Console.WriteLine("Select a sort algorithm to test:");
            Console.WriteLine("> Enter 1 to use merge sort,");
            Console.WriteLine("> Enter 1 to use merge sort,");
            Console.WriteLine("> Enter 2 to use insertion sort,");
            Console.WriteLine("> Enter 3 to use selection sort,");
            Console.WriteLine("> Enter 4 to use bubble sort,");
            Console.WriteLine("> Enter 5 to use optimized bubble sort,");
            Console.WriteLine("> Enter 6 to use cocktail shaker sort,");
            Console.WriteLine("> Enter 7 to use Hoare's partition scheme quicksort,");
            Console.WriteLine("> Enter 8 to use Lomuto's partition scheme quicksort,");
            Console.WriteLine("< Enter any other key to return.");

            ArraySorter sorter;
            switch (Console.ReadLine())
            {
                case "1":
                    sorter = new MergeSorter();
                    break;
                case "2":
                    sorter = new InsertionSorter();
                    break;
                case "3":
                    sorter = new SelectionSorter();
                    break;
                case "4":
                    sorter = new BubbleSorter();
                    break;
                case "5":
                    sorter = new BubbleOptimizedSorter();
                    break;
                case "6":
                    sorter = new CocktailShakerSorter();
                    break;
                case "7":
                    sorter = new HoareQuickSorter();
                    break;
                case "8":
                    sorter = new LomutoQuickSorter();
                    break;
                default:
                    return;
            }

            Console.WriteLine("\n>>>TEST NUMBER " + testNumber + "<<<\n");
            Program.PrintArrayData(testArray, "\n-Unsorted:-");

            int[] sortedArray = sorter.Sort(testArray);
            Program.PrintArrayData(sortedArray, "\n-Sorted:-");

            testNumber++;

            Select();
        }


        private int[] NewTestArray(int length)
        {
            var testArray = new int[length];

            Random random = new();
            for (int i = 0; i < testArray.Length; i++)
            {
                testArray[i] = random.Next(5000);
            }

            return testArray;
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