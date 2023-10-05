namespace TestTasks.TestingQuestions
{
    internal class TestingSolutionSelection : TestSelection
    {
        public override void Select()
        {

            Console.WriteLine();
            Console.WriteLine("Select a solution to test:");
            Console.WriteLine("> Enter 1 for string uniqueness program (using hash set),");
            Console.WriteLine("> Enter 2 for string uniqueness program " +
                "(using no special data structures),");
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
                default:
                    return;
            }

            task.Begin();
        }
    }
}
