using TestTasks.DIYClasses;

namespace TestTasks.SearchTests
{
    internal class SearchMenu : TestMenu
    {
        private const int SEARCH_COUNT_LIMIT = 100000;

        private static int _testNumber = 1;
        private static int[] _testArray;
        private static int _key;


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
            SetupArray(SearchType.Array);

            SetupSearchKey();

            Console.WriteLine("\n>>>TEST NUMBER " + _testNumber + "<<<\n");

            string searchResult = "";
            string executionTime = MeasureTime(() =>
            {
                searchResult = searchAlgorithm.Find(_key, _testArray);
            });

            Console.WriteLine($"\n{searchResult}\n");

            Console.WriteLine("\nAn approximate execution time (more precise with bigger arrays): "
                + executionTime + "ms.\n");

            _testNumber++;
        }

        private void TreeSearch(TreeSortingAlgorithm searchAlgorithm)
        {
            BinaryTree<DummyData> tree = SetupBinaryTree();

            SetupSearchKey();

            Console.WriteLine("\n>>>TEST NUMBER " + _testNumber + "<<<\n");

            BinaryNode<DummyData>? result = null;
            string searchPath = "";

            string executionTime = MeasureTime(() =>
            {
                result = searchAlgorithm.Find(_key, tree, out searchPath);
            });

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
                + executionTime + "ms.\n");

            _testNumber++;
        }


        enum SearchType
        {
            Array,
            BinaryTree
        }


        private static void SetupArray(SearchType searchIn)
        {
            switch (searchIn)
            {
                case SearchType.Array:
                    Console.WriteLine("\nTo search in the array:");
                    break;
                case SearchType.BinaryTree:
                    Console.WriteLine("\nTo search in the array:");
                    break;
                default:
                    throw new Exception("Unknown type of object to search in!");
            }


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

            bool readIsSuccessful = ReadNumberInLimit(1, SEARCH_COUNT_LIMIT, out int readNumber);
            if (readIsSuccessful)
            {
                _testArray = GenerateSortedArray(readNumber);
            }
            else if (_testNumber == 1)
            {
                _testArray = GenerateSortedArray(20);
            }

            Program.PrintArrayData(_testArray, "\n-An array to search through:-");
        }


        private static void SetupSearchKey()
        {
            Console.WriteLine($"\nEnter a key to find in the data structure:");

            bool readIsSuccessful = ReadNumberInLimit(int.MinValue, int.MaxValue, out int key);
            if (readIsSuccessful)
            {
                _key = key;
            }
        }


        private static BinaryTree<DummyData> SetupBinaryTree()
        {
            SetupArray(SearchType.BinaryTree);

            DummyData[] data = new DummyData[_testArray.Length];

            for (int i = 0; i < _testArray.Length; i++)
            {
                data[i] = new DummyData(_testArray[i], i);
            }
            //creates a tree from the array:
            BinaryTree<DummyData> tree = new(data);

            Program.PrintBinaryTree(tree, "\n-A tree to search through:-");
            return tree;
        }
    }
}