namespace TestTasks.TestingQuestions
{
    internal class SolutionMenu : TestMenu
    {
        public override void Select()
        {
            ConsoleIO.PrintLine("Select a solution to test:");
            ConsoleIO.PrintLine("> Enter 1 for string characters uniqueness check " +
                "(using hash set),");
            ConsoleIO.PrintLine("> Enter 2 for string characters uniqueness check " +
                "(using no special data structures),");
            ConsoleIO.PrintLine("> Enter 3 to count lower case letters,");
            ConsoleIO.PrintLine("< Enter any other key to return.");

            ITestTask task;

            switch (ConsoleIO.Read())
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
            ConsoleIO.EmptyLine();

            task.Begin();
            Select();
        }
    }
}
