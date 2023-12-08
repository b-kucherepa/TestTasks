namespace TestTasks.DIYTests
{
    public class DIYTestSelection : TestMenu
    {
        public override void Select()
        {
            ConsoleIO.PrintLine("Select a homemade class to test:");
            ConsoleIO.PrintLine("> Enter 1 to test singly linked list,");
            ConsoleIO.PrintLine("< Enter any other key to return.");

            ITestTask test;
            switch (ConsoleIO.Read())
            {
                case "1":
                    test = new SinglyLinkedListTest();
                    break;
                default:
                    return;
            }

            test.Begin();
        }
    }
}
