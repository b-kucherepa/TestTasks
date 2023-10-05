namespace DIYTests
{
    internal class SinglyLinkedListTest : TestTasks.TestTask
    {
        public override void Begin()
        {
            DIY.SinglyLinkedList<string> list = new ("I'm the first!");
            PrintLinkedList(list, "On creation");

            list.AddLast("I'm the last!");
            PrintLinkedList(list, "Last node added");

            list.AddLast("I'm new last one!");
            PrintLinkedList(list, "New last node added");

            list.AddFirst("And I'm new first one!");
            PrintLinkedList(list, "New first node added");

            list.InsertAfter(2, "I've cut in, sorry guys!");
            PrintLinkedList(list, "New node inserted");

            list.RemoveAt(3);
            PrintLinkedList(list, "Removed new node (there's no place for such insolence!)");

            Console.WriteLine();
            list.InsertAfter(2, "There is more of us!");
            list.InsertAfter(2, "There is more of us!");
            list.InsertAfter(2, "There is more of us!");
            list.InsertAfter(2, "There is more of us!");
            list.InsertAfter(2, "There is more of us!");
            list.InsertAfter(2, "There is more of us!");
            PrintLinkedList(list, "Added more nodes:");
            Console.WriteLine();

            Console.WriteLine("Accessed first node:");
            Console.WriteLine(list.First.Data);
            Console.WriteLine();

            Console.WriteLine("Accessed last node:");
            Console.WriteLine(list.Last.Data);
            Console.WriteLine();

            Console.WriteLine("Accessed random node:");
            Console.WriteLine(list[4].Data);
            Console.WriteLine();


        }

        private void PrintLinkedList (DIY.SinglyLinkedList<string> list, 
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
