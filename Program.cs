using TestTasks.DIYTests;
using TestTasks.SortTests;
using TestTasks.TestingQuestions;

namespace TestTasks
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine();
            Console.WriteLine("Select a category of tests:");
            Console.WriteLine("> Enter 1 to test sort algorithms,");
            Console.WriteLine("> Enter 2 to test homemade classes");
            Console.WriteLine("> Enter 3 to test testing question solutions,");
            Console.WriteLine("< Enter any other key to exit.");
            Console.WriteLine();

            TestSelection selection;
            switch (Console.ReadLine())
            {
                case "1":
                    selection = new SortSelection();
                    break;
                case "2":
                    selection = new DIYTestSelection();
                    break;
                case "3":
                    selection = new TestingSolutionSelection();
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

        public static void PrintLinkedList(DIY.SinglyLinkedList<string> list,
            string label)
        {

            Console.WriteLine();
            Console.WriteLine(label);
            Console.WriteLine("Count: " + list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{i}. {list[i].Data} => ");
            }

            Console.WriteLine();
        }
    }
}