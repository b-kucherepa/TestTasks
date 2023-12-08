using TestTasks.DIYClasses.Trees;

namespace TestTasks.SearchTests
{
    internal class SearchMenu : TestMenu
    {
        private const int SEARCH_COUNT_LIMIT = 100000;

        private static int _testNumber = 1;
        private static int[] _testArray = GenerateRandomArray(20, SEARCH_COUNT_LIMIT);
        private static int _key;


        public override void Select()
        {
            ConsoleIO.PrintLine("Select a search algorithm to test:");
            ConsoleIO.PrintLine("> Enter 1 to use naive consecutive search,");
            ConsoleIO.PrintLine("> Enter 2 to use binary search,");
            ConsoleIO.PrintLine("> Enter 3 to use BFS (breadth-first search),");
            ConsoleIO.PrintLine("> Enter 4 to use DFS (depth-first search),");
            ConsoleIO.PrintLine("< Enter any other key to return.");

            switch (ConsoleIO.Read())
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
            ConsoleIO.EmptyLine();

            Select();
        }

        private void ArraySearch(ArraySearchingAlgorithm searchAlgorithm)
        {
            SetupArray(SearchType.Array);

            SetupSearchKey();

            ConsoleIO.PrintLine(">>>TEST NUMBER " + _testNumber + "<<<");
            ConsoleIO.EmptyLine();

            string searchResult = "";
            string executionTime = MeasureTime(() =>
            {
                searchResult = searchAlgorithm.Find(_key, _testArray);
            });

            ConsoleIO.PrintLine($"{searchResult}");
            ConsoleIO.EmptyLine();

            ConsoleIO.PrintLine("An approximate execution time (more precise with bigger arrays): "
                + executionTime + "ms.");
            ConsoleIO.EmptyLine();

            _testNumber++;
        }


        private void TreeSearch(TreeSortingAlgorithm searchAlgorithm)
        {
            BinaryTree<DummyData> tree = SetupBinaryTree();

            SetupSearchKey();

            ConsoleIO.PrintLine(">>>TEST NUMBER " + _testNumber + "<<<");
            ConsoleIO.EmptyLine();

            BinaryNode<DummyData>? result = null;
            string searchPath = "";

            string executionTime = MeasureTime(() =>
            {
                result = searchAlgorithm.Find(_key, tree, out searchPath);
            });

            if (result is null)
            {
                ConsoleIO.PrintLine("A node with the required data key hasn't been found");
            }
            else
            {
                ConsoleIO.PrintLine($"The key has been found in the node at the next position: " +
                    $"{result.Data.Position}.");
                ConsoleIO.PrintLine("The algorithm has followed next path:");
                ConsoleIO.PrintLine($"{searchPath}");
            }
            ConsoleIO.EmptyLine();

            ConsoleIO.PrintLine("An approximate execution time (more precise with bigger trees): "
                + executionTime + "ms.");
            ConsoleIO.EmptyLine();

            _testNumber++;
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

            ConsoleIO.PrintBinaryTree(tree, "-A tree to search through:-");
            ConsoleIO.EmptyLine();
            return tree;
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
                    ConsoleIO.PrintLine("To search in a array:");
                    break;
                case SearchType.BinaryTree:
                    ConsoleIO.PrintLine("To search in a binary tree:");
                    break;
                default:
                    throw new Exception("Unknown type of object to search in!");
            }
            ConsoleIO.EmptyLine();


            ConsoleIO.PrintLine($"Enter the consecutive test array length (1-"
                + SEARCH_COUNT_LIMIT + ") to generate one, ");
            if (_testNumber == 1)
            {
                ConsoleIO.PrintLine("or enter any other key to use an array " +
                    $"of the default length {_testArray.Length}:");
            }
            else
            {
                ConsoleIO.PrintLine("or enter any other key to keep the same array:");
            }

            bool readIsSuccessful = ConsoleIO.ReadNumberInLimit(1, SEARCH_COUNT_LIMIT, 
                out int readNumber);
            if (readIsSuccessful)
            {
                _testArray = GenerateSortedArray(readNumber);
            }
            else if (_testNumber == 1)
            {
                _testArray = GenerateSortedArray(20);
            }
            ConsoleIO.EmptyLine();

            ConsoleIO.PrintArrayData(_testArray, "-An array to search through:-");
            ConsoleIO.EmptyLine();
        }


        private static void SetupSearchKey()
        {
            ConsoleIO.PrintLine($"Enter a key to find in the data structure:");

            bool readIsSuccessful = ConsoleIO.ReadNumberInLimit(int.MinValue, int.MaxValue, 
                out int key);
            if (readIsSuccessful)
            {
                _key = key;
            }
            ConsoleIO.EmptyLine();
        }
    }
}