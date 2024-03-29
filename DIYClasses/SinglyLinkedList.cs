﻿namespace TestTasks.DIYClasses
{
    public class SinglyLinkedList<T>
    {
        private SinglyNode<T>? _firstNode = null;
        private int _nodesCount = 0;

        public SinglyNode<T>? this[int index] => RetrieveNode(index);
        public SinglyNode<T>? First => _firstNode;
        public SinglyNode<T>? Last => this[_nodesCount - 1];
        public int Count => _nodesCount;


        public SinglyLinkedList() { }

        public SinglyLinkedList(T dataReference)
        {
            _firstNode = new SinglyNode<T>(dataReference);
            _firstNode.Data = dataReference;
            _nodesCount++;
        }


        public void AddFirst(T dataReference)
        {
            SinglyNode<T>? newNode = new(dataReference);
            newNode.Next = _firstNode;
            _firstNode = newNode;
            _nodesCount++;
        }


        public void RemoveFirst()
        {
            _firstNode = _firstNode.Next;
            _nodesCount--;
        }


        public void InsertAfter(int index, T dataReference)
        {
            SinglyNode<T>? beforeNode = RetrieveNode(index);
            SinglyNode<T>? newNode = new(dataReference);
            newNode.Next = beforeNode.Next;
            beforeNode.Next = newNode;
            _nodesCount++;
        }


        public void RemoveAt(int index)
        {
            SinglyNode<T>? beforeNode = RetrieveNode(index - 1);
            SinglyNode<T>? nodeAfter = beforeNode.Next.Next;
            beforeNode.Next = nodeAfter;
            _nodesCount--;
        }


        public void AddLast(T dataReference)
        {
            SinglyNode<T>? lastNode = RetrieveNode(_nodesCount - 1);
            SinglyNode<T>? newLastNode = new(dataReference);
            lastNode.Next = newLastNode;
            _nodesCount++;
        }


        public void RemoveLast()
        {
            SinglyNode<T>? beforeLastNode = RetrieveNode(_nodesCount - 2);
            beforeLastNode.Next = null;
            _nodesCount--;
        }


        private SinglyNode<T>? RetrieveNode(int index)
        {
            SinglyNode<T>? indexedNode = _firstNode;

            for (int i = 0; i < index; i++)
            {
                indexedNode = indexedNode.Next;
            }

            return indexedNode;
        }

        public SinglyNode<T>? Find(T dataReference)
        {
            SinglyNode<T>? visitedNode = _firstNode;

            while (visitedNode.Next is not null)
            {
                if (EqualityComparer<T>.Default.Equals(visitedNode.Data, dataReference))
                {
                    return visitedNode;
                }
                visitedNode = visitedNode.Next;
            }
            return null;
        }
    }
}
