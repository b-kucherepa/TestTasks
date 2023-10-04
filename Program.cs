using System;

namespace Interview
{
    public static class Program
    {
        public static void Main()
        {
            Test task = new StringUniquenessCheckerWithHash ();
            
            Console.WriteLine ("Select a test program to begin:");
            Console.WriteLine ("> Enter 1 for string uniqueness program (using hash set),");
            Console.WriteLine ("> Enter 2 for string uniqueness program (using no special data structures),");
            Console.WriteLine ("> Enter any other key to exit.");
            Console.WriteLine ();

            switch (Console.ReadLine())
            {
                case "1":
                    task = new StringUniquenessCheckerWithHash();
                    break;
                case "2":
                    task = new StringUniquenessCheckerNoDataStructures();
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