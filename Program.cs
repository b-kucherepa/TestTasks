using TestTasks.SortTests;
using TestTasks.SearchTests;
using TestTasks.DIYTests;
using TestTasks.TestingQuestions;
using TestTasks.PolynomialCalculations;

using TestTasks.DIYClasses;
using System.Collections.Generic;


namespace TestTasks
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine();
            Console.WriteLine("Select a category of tests:");
            Console.WriteLine("> Enter 1 to test sort algorithms,");
            Console.WriteLine("> Enter 2 to test search algorithms,");
            Console.WriteLine("> Enter 3 to test homemade classes");
            Console.WriteLine("> Enter 4 to test testing question solutions,");
            Console.WriteLine("> Enter 5 to test polynomial equation calculator,");
            Console.WriteLine("< Enter any other key to exit.");
            Console.WriteLine();

            TestMenu selection;
            switch (Console.ReadLine())
            {
                case "1":
                    selection = new SortMenu();
                    break;
                case "2":
                    selection = new SearchMenu();
                    break;
                case "3":
                    selection = new DIYTestSelection();
                    break;
                case "4":
                    selection = new SolutionMenu();
                    break;
                case "5":
                    selection = new PolynomialMenu();
                    break;
                default:
                    Environment.Exit(0);
                    return;
            }

            selection.Select();

            Main();
        }

        public static void PrintArrayData(int[] array, string label = "")
        {
            Console.WriteLine(label + "\n");
            Console.WriteLine("Length: " + array.Length + ".");
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }

        public static void PrintLinkedList(SinglyLinkedList<string> list,
            string label)
        {

            Console.WriteLine();
            Console.WriteLine(label);
            Console.WriteLine("Count: " + list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{i}. {list[i].Data ?? "Missing node!"} => ");
            }

            Console.WriteLine();
        }

        public static void PrintBinaryTree(BinaryTree<DummyData> tree,
            string label)
        {
            Console.WriteLine();
            Console.WriteLine(label);
            Console.WriteLine("Count: " + tree.Count);

            //acts the same way as the breadth-first search algorithm
            HashSet<BinaryNode<DummyData>> visitedNodes = new();
            Queue<BinaryNode<DummyData>> prospectedNodes = new();

            prospectedNodes.Enqueue(tree.Root);

            int currentNodeInRow = 0;
            int totalNodesInRow = 1;

            while (prospectedNodes.Any())
            {
                BinaryNode<DummyData> node = prospectedNodes.Dequeue();

                if (currentNodeInRow == totalNodesInRow)
                {
                    Console.WriteLine();
                    currentNodeInRow = 0;
                    totalNodesInRow *= 2;
                }

                Console.Write($"(#{node.Data.Position.ToString() ?? "X"}) {node.Data.Id.ToString() ?? "X"}, ");
                currentNodeInRow++;

                visitedNodes.Add(node);

                if ((node.LeftChild is not null) && (!visitedNodes.Contains(node.LeftChild)))
                {
                    prospectedNodes.Enqueue(node.LeftChild);
                }

                if ((node.RightChild is not null) && (!visitedNodes.Contains(node.RightChild)))
                {
                    prospectedNodes.Enqueue(node.RightChild);
                }
            }

            Console.WriteLine();
        }
    }
}