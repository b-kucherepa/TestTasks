using TestTasks.DIYClasses;
using TestTasks.DIYClasses.Trees;
using TestTasks.SearchTests;

namespace TestTasks
{
    public class ConsoleIO
    {
        public static string? Read() => Console.ReadLine();


        public static bool ReadNumberInLimit(int min, int max, out int retrievedNumber)
        {
            string? input = Read();
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


        public static bool ReadIntegersArray(string separator, int min, int max, 
            out int[] array)
        {
            string? input = Read();
            string[] elements = input.Split(separator);
            array = new int[elements.Length];

            for (int i = 0; i < array.Length; i++)
            {
                bool isSuccessful = int.TryParse(elements[i], out int number);
                if ((isSuccessful) && (number >= min) && (number <= max))
                {
                    array[array.Length - i - 1] = number;
                }
                else
                {
                    array = new int[0];
                    return false;
                }
            }

            return true;
        }


        public static void Print(object s) => Console.Write(s);


        public static void PrintLine(object o) => Console.WriteLine(o);


        public static void EmptyLine() => Console.WriteLine();


        public static void EmptyLine(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine();
            }
        }


        public static void PrintArrayData(int[] array, string label)
        {
            PrintLine(label);
            PrintLine("Length: " + array.Length + ".");
            foreach (int i in array)
            {
                PrintLine(i);
            }
            EmptyLine();
        }


        public static void PrintLinkedList(SinglyLinkedList<string> list, string label)
        {

            PrintLine(label);
            PrintLine("Count: " + list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                Print($"{i}. {list[i].Data ?? "Missing node!"} => ");
            }

            EmptyLine();
        }


        public static void PrintBinaryTree(BinaryTree<DummyData> tree, string label)
        {
            //acts the same way as the breadth-first search algorithm
            HashSet<BinaryNode<DummyData>> visitedNodes = new();
            Queue<BinaryNode<DummyData>> prospectedNodes = new();

            prospectedNodes.Enqueue(tree.Root);

            int currentNodeInRow = 0;
            int level = 1;

            PrintLine(label);
            PrintLine("Count: " + tree.Count);
            PrintLine($"Level {level}:");

            while (prospectedNodes.Any())
            {
                BinaryNode<DummyData> node = prospectedNodes.Dequeue();

                if (currentNodeInRow == Math.Pow(2, level - 1))
                {
                    currentNodeInRow = 0;
                    level++;
                    EmptyLine();
                    PrintLine($"Level {level}:");
                }

                Print($"(#{node.Data.Position.ToString() ?? "X"}) {node.Data.Id.ToString() ?? "X"}, ");
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

            EmptyLine();
        }
    }
}
