using System.Drawing;
using TestTasks.DIYClasses;

namespace TestTasks.SearchTests
{
    internal class SearchMenu : TestMenu
    {
        private static int _testNumber = 1;
        private static int[] _testArray;
        private static int _key;

        private const int SEARCH_COUNT_LIMIT = 100000;


        public override void Select()
        {
            Console.WriteLine("\nSelect a search algorithm to test:");
            Console.WriteLine("> Enter 1 to use naive consecutive search,");
            Console.WriteLine("> Enter 2 to use binary search,");
            Console.WriteLine("> Enter 3 to use BFS (breadth-first search),");
            Console.WriteLine("> Enter 4 to use DFS (depth-first search),");
            Console.WriteLine("< Enter any other key to return.");

            switch (Console.ReadLine())
            {
                case "1":
                    ArraySearch(new LinearSearch());
                    break;
                case "2":
                    ArraySearch(new BinarySearch());
                    break;
                case "3":
                    TreeSearch(new BreadthFirstSearch());
                    break;
                case "4":
                    TreeSearch(new DepthFirstSearch());
                    break;
                default:
                    return;
            }

            Select();
        }

        private void ArraySearch(ArraySearchingAlgorithm searchAlgorithm)
        {
            Console.WriteLine($"\nEnter the consecutive test array length (1-"
                + SEARCH_COUNT_LIMIT + ") to generate one, ");

            if (_testNumber == 1)
            {
                Console.Write("or enter any other key to use an array " +
                    "of the default length 20:");
            }
            else
            {
                Console.Write("or enter any other key to keep the same array:");
            }

            int readNumber; 
            bool readIsSuccessful = ReadNumberInLimit(1, SEARCH_COUNT_LIMIT, out readNumber);
            if (readIsSuccessful)
            {
                _testArray = GenerateSortedArray(readNumber);
            }
            else if (_testNumber == 1)
            {
                _testArray = GenerateSortedArray(20);
            }

            Program.PrintArrayData(_testArray, "\n-An array to search through:-");

            Console.WriteLine($"\nEnter a key to find in the array:");

            int key;
            readIsSuccessful = ReadNumberInLimit(int.MinValue, int.MaxValue, out key);
            if (readIsSuccessful)
            {
                _key = key;
            }

            Console.WriteLine("\n>>>TEST NUMBER " + _testNumber + "<<<\n");

            _timer.Restart();
            string searchResult = searchAlgorithm.Find(_key, _testArray);
            _timer.Stop();

            Console.WriteLine($"\n{searchResult}\n");

            Console.WriteLine("\nAn approximate execution time (more precise with bigger arrays): "
                + _timer.Elapsed + "ms.\n");

            _testNumber++;
        }

        private void TreeSearch(TreeSortingAlgorithm searchAlgorithm)
        {
            Console.WriteLine($"\nEnter the consecutive test array length (1-"
              + SEARCH_COUNT_LIMIT + ") to build a binary tree, ");

            if (_testNumber == 1)
            {
                Console.Write("or enter any other key to build the tree from an array " +
                    "of the default length 20:");
            }
            else
            {
                Console.Write("or enter any other key to keep the same array to build the tree from:");
            }


            int readNumber;
            bool readIsSuccessful = ReadNumberInLimit(1, SEARCH_COUNT_LIMIT, out readNumber);
            if (readIsSuccessful)
            {
                _testArray = GenerateSortedArray(readNumber);
            }
            else if (_testNumber == 1)
            {
                _testArray = GenerateSortedArray(20);
            }

            DummyData[] data = new DummyData[_testArray.Length];

            for (int i = 0; i < _testArray.Length; i++)
            {
                data[i] = new DummyData(_testArray[i], i);
            }
            //creates a tree from the array:
            BinaryTree<DummyData> tree = new(data);

            Program.PrintBinaryTree(tree, "\n-A tree to search through:-");


            Console.WriteLine($"\nEnter a key to find in the array:");
            int key;
            readIsSuccessful = ReadNumberInLimit(int.MinValue, int.MaxValue, out key);
            if (readIsSuccessful)
            {
                _key = key;
            }

            Console.WriteLine("\n>>>TEST NUMBER " + _testNumber + "<<<\n");

            string searchPath;

            _timer.Restart();
            BinaryNode<DummyData>? result = searchAlgorithm.Find(key, tree, out searchPath);
            _timer.Stop();

            if (result is null)
            {
                Console.WriteLine("A node with the required data key hasn't been found");
            }
            else
            {
                Console.WriteLine($"The key has been found in the node at the next position: {result.Data.Position}." +
                    $"\nThe algorithm has followed next path:\n{searchPath} ");
            }

            Console.WriteLine("\nAn approximate execution time (more precise with bigger trees): "
    + _timer.Elapsed + "ms.\n");

            _testNumber++;
        }
    }
}