namespace TestTasks.SortTests
{
    public class SortMenu : TestMenu
    {
        private const int INNER_SORT_COUNT_LIMIT = 100000;
        private const int EXTERNAL_SORT_COUNT_LIMIT = 10000000;
        private const int EXTERNAL_SORT_BUFFER_MIN = 2;
        private const int EXTERNAL_SORT_BUFFER_MAX = 32768;
        private const int ELEMENT_LIMIT = 100000;

        private static int _innerTestNumber = 1;
        private static int _externalTestNumber = 1;
        private static int[] _testArray = GenerateRandomArray(20, ELEMENT_LIMIT);
        private static string _inputFilePath;


        public override void Select()
        {
            ConsoleIO.PrintLine("Select an inner sort algorithm to test:");
            ConsoleIO.PrintLine("> Enter 1 to use bubble sort,");
            ConsoleIO.PrintLine("> Enter 2 to use optimized bubble sort,");
            ConsoleIO.PrintLine("> Enter 3 to use selection sort,");
            ConsoleIO.PrintLine("> Enter 4 to use insertion sort,");
            ConsoleIO.PrintLine("> Enter 5 to use cocktail shaker sort,");
            ConsoleIO.PrintLine("> Enter 6 to use Shell sort,");
            ConsoleIO.PrintLine("> Enter 7 to use Hoare's partition scheme quicksort,");
            ConsoleIO.PrintLine("> Enter 8 to use Lomuto's partition scheme quicksort,");
            ConsoleIO.PrintLine("> Enter 9 to use merge sort,");
            ConsoleIO.PrintLine("> Enter 10 to use radix sort,");
            ConsoleIO.PrintLine("> Enter 11 to use heap sort,");
            ConsoleIO.PrintLine("< Enter any other key to return.");

            SortingAlgorithm sort;
            switch (ConsoleIO.Read())
            {
                case "1":
                    sort = new BubbleSort();
                    break;
                case "2":
                    sort = new BubbleOptimizedSort();
                    break;
                case "3":
                    sort = new SelectionSort();
                    break;
                case "4":
                    sort = new InsertionSort();
                    break;
                case "5":
                    sort = new CocktailShakerSort();
                    break;
                case "6":
                    sort = new ShellSort();
                    break;
                case "7":
                    sort = new HoareQuickSort();
                    break;
                case "8":
                    sort = new LomutoQuickSort();
                    break;
                case "9":
                    sort = new MergeSort();
                    break;
                case "10":
                    sort = new RadixSort();
                    break;
                case "11":
                    sort = new HeapSort();
                    break;
                default:
                    return;
            }
            ConsoleIO.EmptyLine();

            ConsoleIO.PrintLine("Should it be tested as the inner sort " +
                    "which is performed entirely in the memory, " +
                    "or as the external sort with limited memory buffer size using storage cash " +
                    "(with the chosen inner sort being applied for the first pass)?");
            ConsoleIO.PrintLine("> Enter 1 to use the chosen inner sort algorithm,");
            ConsoleIO.PrintLine("> Enter 2 to use external (outer) multiphase sort algorithm,");
            ConsoleIO.PrintLine("< Enter any other key to return.");

            switch (ConsoleIO.Read())
            {
                case "1":
                    PerformInternalSort(sort);
                    break;
                case "2":
                    PerformExternalSort(sort); ;
                    break;
                default:
                    return;
            }
            ConsoleIO.EmptyLine();

            Select();
        }


        private static void PerformInternalSort(SortingAlgorithm sort)
        {
            SetupInternalArray();

            ConsoleIO.PrintLine(">>>TEST NUMBER " + _innerTestNumber + "<<<");
            ConsoleIO.EmptyLine();

            ConsoleIO.PrintArrayData(_testArray, "-Unsorted:-");
            ConsoleIO.EmptyLine();

            int[] arrayToSort = new int[_testArray.Length];
            Array.Copy(_testArray, arrayToSort, _testArray.Length);

            string executionTime = MeasureTime(() =>
            {
                arrayToSort = sort.SortArray(arrayToSort);
            });

            ConsoleIO.PrintArrayData(arrayToSort, "-Sorted:-");
            ConsoleIO.EmptyLine();

            ConsoleIO.PrintLine("An approximate execution time (more precise with bigger arrays): "
                + executionTime + "ms.");
            ConsoleIO.EmptyLine();

            _innerTestNumber++;
        }

        private static void SetupInternalArray()
        {
            ConsoleIO.PrintLine($"Enter the random test array length (1-{INNER_SORT_COUNT_LIMIT} " +
                $"to generate one, ");

            if (_innerTestNumber == 1)
            {
                ConsoleIO.PrintLine("or enter any other key to use an array " +
                    $"of the default length {_testArray.Length}:");
            }
            else
            {
                ConsoleIO.PrintLine("or enter any other key to keep the same array:");
            }

            bool readIsSuccessful = ConsoleIO.ReadNumberInLimit(1, INNER_SORT_COUNT_LIMIT, out int readNumber);
            if (readIsSuccessful)
            {
                _testArray = GenerateRandomArray(readNumber, ELEMENT_LIMIT);
            }
            ConsoleIO.EmptyLine();
        }

        private static void PerformExternalSort(SortingAlgorithm sort)
        {

            SetupExternalArrayFile();

            int bufferLimit = SetupBufferSize();

            ExternalSort externalSort = new();

            string outputPath = "";
            string executionTime = MeasureTime(() =>
            {
                string outputPath = externalSort.SortFile(_inputFilePath, bufferLimit, sort);
            });
            ConsoleIO.EmptyLine();

            ConsoleIO.PrintLine("Sorted. Check the file to verify:");
            ConsoleIO.PrintLine(outputPath);
            ConsoleIO.EmptyLine();

            ConsoleIO.PrintLine("An approximate execution time (more precise with bigger arrays): "
                + executionTime + "ms.");
            ConsoleIO.EmptyLine();

            _innerTestNumber++;
        }



        private static void SetupExternalArrayFile()
        {
            ConsoleIO.PrintLine($"Enter the random test array length (1-"
                + EXTERNAL_SORT_COUNT_LIMIT + ") to generate a file with one, ");

            if (_externalTestNumber == 1)
            {
                ConsoleIO.PrintLine("or enter any other key to create a file with array " +
                    "of the default length 10000:");
            }
            else
            {
                ConsoleIO.PrintLine("or enter any other key to keep the same array file:");
            }

            bool readIsSuccessful = ConsoleIO.ReadNumberInLimit(1, EXTERNAL_SORT_COUNT_LIMIT, out int readNumber);
            if (readIsSuccessful)
            {
                _inputFilePath = FileManager.CreateEmptyFile("FileToSort.txt", "ExternalSort\\");
                FileManager.GenerateRandomArrayInFile(_inputFilePath, readNumber, ELEMENT_LIMIT);
            }
            else if (_externalTestNumber == 1)
            {
                _inputFilePath = FileManager.CreateEmptyFile("FileToSort.txt", "ExternalSort\\");
                FileManager.GenerateRandomArrayInFile(_inputFilePath, 10000, ELEMENT_LIMIT);
            }
            ConsoleIO.EmptyLine();
        }

        private static int SetupBufferSize()
        {
            ConsoleIO.PrintLine("Enter the buffer size limit " +
                $"({EXTERNAL_SORT_BUFFER_MIN}-{EXTERNAL_SORT_BUFFER_MAX})," + 
                "or enter any other key to use the default limit of 1024:");

            bool readIsSuccessful = ConsoleIO.ReadNumberInLimit(2, EXTERNAL_SORT_COUNT_LIMIT, out int readNumber);
            if (readIsSuccessful)
            {
                return readNumber;
            }
            else
            {
                return 1024;
            }
        }
    }
}