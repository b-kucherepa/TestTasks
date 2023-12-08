using TestTasks.DIYTests;
using TestTasks.PolynomialCalculations;
using TestTasks.SearchTests;
using TestTasks.SortTests;
using TestTasks.TestingQuestions;

namespace TestTasks
{
    internal class MainMenu : TestMenu
    {
        public override void Select()
        {
            ConsoleIO.PrintLine("Select a category of tests:");
            ConsoleIO.PrintLine("> Enter 1 to test sort algorithms,");
            ConsoleIO.PrintLine("> Enter 2 to test search algorithms,");
            ConsoleIO.PrintLine("> Enter 3 to test homemade classes");
            ConsoleIO.PrintLine("> Enter 4 to test testing question solutions,");
            ConsoleIO.PrintLine("> Enter 5 to test polynomial equation calculator,");
            ConsoleIO.PrintLine("< Enter any other key to exit.");

            TestMenu selection;
            switch (ConsoleIO.Read())
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
            ConsoleIO.EmptyLine();

            selection.Select();

            Select();
        }
    }
}
