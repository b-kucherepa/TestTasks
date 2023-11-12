namespace TestTasks.TestingQuestions
{
    internal class SolutionMenu : TestMenu
    {
        public override void Select()
        {

            Console.WriteLine();
            Console.WriteLine("Select a solution to test:");
            Console.WriteLine("> Enter 1 for string characters uniqueness check " +
                "(using hash set),");
            Console.WriteLine("> Enter 2 for string characters uniqueness check " +
                "(using no special data structures),");
            Console.WriteLine("> Enter 3 to count lower case letters,");
            Console.WriteLine("< Enter any other key to return.");
            Console.WriteLine();

            TestTask task;

            switch (Console.ReadLine())
            {
                case "1":
                    task = new StringsAndArrays.UniquenessWithHash();
                    break;
                case "2":
                    task = new StringsAndArrays.UniquenessNoDataStructures();
                    break;
                case "3":
                    task = new StringsAndArrays.CountLowerCase();
                    break;
                default:
                    return;
            }

            task.Begin();
            Select();
        }
    }
}
