using System;

namespace TestTasks
{
    public static class Program
    {
        public static void Main()
        {
            TestTask task = new StringsAndArrays.UniquenessWithHash ();
            
            Console.WriteLine ("Select a test program to begin:");
            Console.WriteLine ("> Enter 1 for string uniqueness program (using hash set),");
            Console.WriteLine ("> Enter 2 for string uniqueness program" + 
                "(using no special data structures),");
            Console.WriteLine("> Enter 3 to test homemade singly linked list,");
            Console.WriteLine ("> Enter any other key to exit.");
            Console.WriteLine ();

            switch (Console.ReadLine())
            {
                case "1":
                    task = new StringsAndArrays.UniquenessWithHash();
                    break;
                case "2":
                    task = new StringsAndArrays.UniquenessNoDataStructures();
                    break;
                case "3":
                    task = new DIYTests.SinglyLinkedListTest();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }

            task.Begin();

            Main();
        }
    }
}