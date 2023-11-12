﻿using System.Diagnostics;

namespace TestTasks.SortTests
{
    public class SortMenu : TestMenu
    {
        private static int _innerTestNumber = 1;
        private static int _externalTestNumber = 1;
        private static int[] _testArray = NewTestArray(20);
        private static string _inputFilePath;
        private static Stopwatch _timer = new();
        private const int INNER_SORT_COUNT_LIMIT = 100000;
        private const int EXTERNAL_SORT_COUNT_LIMIT = 10000000;
        private const int EXTERNAL_SORT_BUFFER_LIMIT = 32768;
        private const int ELEMENT_LIMIT = 100000;

        public override void Select()
        {
            Console.WriteLine();

            Console.WriteLine("Select an inner sort algorithm to test:");
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

            Console.WriteLine("\nShould it be tested as the inner sort " +
                "which is performed entirely in the memory, " +
                "or as the external sort with limited memory buffer size using storage cash " +
                "(with the chosen inner sort being applied for the first pass)?");
            Console.WriteLine("> Enter 1 to use the chosen inner sort algorithm,");
            Console.WriteLine("> Enter 2 to use external (outer) multiphase sort algorithm,");
            Console.WriteLine("< Enter any other key to return.");

            switch (Console.ReadLine())
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

            Select();
        }


        private static void PerformInternalSort(SortAlgorithm sort)
        {
            Console.WriteLine($"\nEnter the random test array length (1-"
                + INNER_SORT_COUNT_LIMIT + ") to generate one,");

            if (_innerTestNumber == 1)
            {
                Console.WriteLine("or enter any other key to use an array " +
                    "of the default length 20:");
            }
            else
            {
                Console.WriteLine("or enter any other key to keep the same array:");
            }

            int selectedOption = ReadNumberInLimit(1, INNER_SORT_COUNT_LIMIT);
            if (selectedOption != -1)
            {
                _testArray = NewTestArray(selectedOption);
            }

            Console.WriteLine("\n>>>TEST NUMBER " + _innerTestNumber + "<<<\n");
            Program.PrintArrayData(_testArray, "\n-Unsorted:-");

            int[] arrayToSort = new int[_testArray.Length];
            Array.Copy(_testArray, arrayToSort, _testArray.Length);

            _timer.Restart();
            arrayToSort = sort.SortArray(arrayToSort);
            _timer.Stop();
            Program.PrintArrayData(arrayToSort, "\n-Sorted:-");
            Console.WriteLine("\nAn approximate execution time (more precise with bigger arrays): "
                + _timer.Elapsed + "ms.\n");

            _innerTestNumber++;
        }


        private static void PerformExternalSort(SortAlgorithm sort)
        {
            Console.WriteLine($"\nEnter the random test array length (1-"
                + EXTERNAL_SORT_COUNT_LIMIT + ") to generate a file with one,");

            if (_externalTestNumber == 1)
            {
                Console.WriteLine("or enter any other key to create a file with array " +
                    "of the default length 10000:");
            }
            else
            {
                Console.WriteLine("or enter any other key to keep the same array file:");
            }

            int selectedOption = ReadNumberInLimit(1, EXTERNAL_SORT_COUNT_LIMIT);
            if (selectedOption != -1)
            {
                _inputFilePath = FileManager.CreateEmptyFile("FileToSort.txt", "ExternalSort\\");
                FileManager.GenerateRandomArrayInFile(_inputFilePath, selectedOption, ELEMENT_LIMIT);
            }
            else if (_externalTestNumber == 1)
            {
                _inputFilePath = FileManager.CreateEmptyFile("FileToSort.txt", "ExternalSort\\");
                FileManager.GenerateRandomArrayInFile(_inputFilePath, 10000, ELEMENT_LIMIT);
            }

            int bufferLimit;
            Console.WriteLine($"\nEnter the buffer size limit (1-" + EXTERNAL_SORT_BUFFER_LIMIT + 
                "), or enter any other key to use the default limit of 1024:");

            selectedOption = ReadNumberInLimit(1, EXTERNAL_SORT_COUNT_LIMIT);
            if (selectedOption != -1)
            {
                bufferLimit = selectedOption;
            }
            else
            {
                bufferLimit = 1024;
            }

            ExternalSort externalSort = new();
            _timer.Restart();
            string outputPath =
                externalSort.SortFile(_inputFilePath, bufferLimit, sort);
            _timer.Stop();

            Console.WriteLine("\nSorted. Check the file to verify:\n");
            Console.WriteLine(outputPath);
            Console.WriteLine("\nAn approximate execution time (more precise with bigger arrays): "
                + _timer.Elapsed + "ms.\n");

            _innerTestNumber++;
        }

        private static int[] NewTestArray(int length)
        {
            var _testArray = new int[length];

            Random random = new();
            for (int i = 0; i < _testArray.Length; i++)
            {
                _testArray[i] = random.Next(ELEMENT_LIMIT);
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