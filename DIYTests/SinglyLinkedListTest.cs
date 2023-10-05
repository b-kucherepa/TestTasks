﻿namespace TestTasks.DIYTests
{
    internal class SinglyLinkedListTest : TestTasks.TestTask
    {
        public override void Begin()
        {
            DIY.SinglyLinkedList<string> list = new("I'm the first!");
            Program.PrintLinkedList(list, "On creation");

            list.AddLast("I'm the last!");
            Program.PrintLinkedList(list, "Last node added");

            list.AddLast("I'm new last one!");
            Program.PrintLinkedList(list, "New last node added");

            list.AddFirst("And I'm new first one!");
            Program.PrintLinkedList(list, "New first node added");

            list.InsertAfter(2, "I've cut in, sorry guys!");
            Program.PrintLinkedList(list, "New node inserted");

            list.RemoveAt(3);
            Program.PrintLinkedList(list, "Removed new node (there's no place for such insolence!)");

            Console.WriteLine();
            list.InsertAfter(2, "There is more of us!");
            list.InsertAfter(2, "There is more of us!");
            list.InsertAfter(2, "There is more of us!");
            list.InsertAfter(2, "There is more of us!");
            list.InsertAfter(2, "There is more of us!");
            list.InsertAfter(2, "There is more of us!");
            Program.PrintLinkedList(list, "Added more nodes:");
            Console.WriteLine();

            Console.WriteLine("Accessed first node:");
            Console.WriteLine(list.First.Data ?? "No nodes found");
            Console.WriteLine();

            Console.WriteLine("Accessed last node:");
            Console.WriteLine(list.Last.Data ?? "No nodes found");
            Console.WriteLine();

            Console.WriteLine("Accessed random node:");
            Console.WriteLine(list[4].Data ?? "No nodes found");
            Console.WriteLine();


        }
    }
}