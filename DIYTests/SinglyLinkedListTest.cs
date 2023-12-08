using TestTasks.DIYClasses;

namespace TestTasks.DIYTests
{
    internal class SinglyLinkedListTest : ITestTask
    {
        public void Begin()
        {
            SinglyLinkedList<string> list = new("I'm the first!");
            ConsoleIO.PrintLinkedList(list, "On creation");
            ConsoleIO.EmptyLine();

            list.AddLast("I'm the last!");
            ConsoleIO.PrintLinkedList(list, "Last node added");
            ConsoleIO.EmptyLine();

            list.AddLast("I'm new last one!");
            ConsoleIO.PrintLinkedList(list, "New last node added");
            ConsoleIO.EmptyLine();

            list.AddFirst("And I'm new first one!");
            ConsoleIO.PrintLinkedList(list, "New first node added");
            ConsoleIO.EmptyLine();

            list.InsertAfter(2, "I've cut in, sorry guys!");
            ConsoleIO.PrintLinkedList(list, "New node inserted");
            ConsoleIO.EmptyLine();

            ConsoleIO.PrintLine("Found the inserted node. It says: " +
                $"\"{list.Find("I've cut in, sorry guys!").Data}\" Shame on it! >:(");
            ConsoleIO.EmptyLine();

            list.RemoveAt(3);
            ConsoleIO.PrintLinkedList(list, "Removed that node from position 3 (there's no place for such insolence!)");
            ConsoleIO.EmptyLine();

            list.InsertAfter(2, "There is more of us!");
            list.InsertAfter(2, "There is more of us!");
            list.InsertAfter(2, "There is more of us!");
            list.InsertAfter(2, "There is more of us!");
            list.InsertAfter(2, "There is more of us!");
            list.InsertAfter(2, "There is more of us!");
            ConsoleIO.PrintLinkedList(list, "Added more nodes:");
            ConsoleIO.EmptyLine();

            ConsoleIO.PrintLine("Accessed first node:");
            ConsoleIO.PrintLine(list.First.Data ?? "No nodes found");
            ConsoleIO.EmptyLine();

            ConsoleIO.PrintLine("Accessed last node:");
            ConsoleIO.PrintLine(list.Last.Data ?? "No nodes found");
            ConsoleIO.EmptyLine();

            ConsoleIO.PrintLine("Accessed some other node:");
            ConsoleIO.PrintLine(list[4].Data ?? "No nodes found");
            ConsoleIO.EmptyLine();
        }
    }
}
