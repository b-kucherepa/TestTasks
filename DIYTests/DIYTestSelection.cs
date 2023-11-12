namespace TestTasks.DIYTests
{
    public class DIYTestSelection : TestMenu
    {
        public override void Select()
        {
            Console.WriteLine();
            Console.WriteLine("Select a homemade class to test:");
            Console.WriteLine("> Enter 1 to test singly linked list,");
            Console.WriteLine("< Enter any other key to return.");
            Console.WriteLine();

            TestTask test;
            switch (Console.ReadLine())
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
