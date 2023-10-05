namespace TestTasks.DIYClasses
{
    public class SinglyLinkedList<T>
    {
        SinglyNode<T>? firstNode = null;
        public SinglyNode<T>? First => firstNode;

        public SinglyNode<T>? Last => this[_nodesCount - 1];

        int _nodesCount = 0;
        public int Count => _nodesCount;


        public SinglyNode<T>? this[int index] => RetrieveNode(index);

        public SinglyLinkedList() { }

        public SinglyLinkedList(T dataReference)
        {
            firstNode = new SinglyNode<T>(dataReference);
            firstNode.Data = dataReference;
            _nodesCount++;
        }


        public void AddFirst(T dataReference)
        {
            SinglyNode<T>? newNode = new(dataReference);
            newNode.Next = firstNode;
            firstNode = newNode;
            _nodesCount++;
        }


        public void RemoveFirst()
        {
            firstNode = firstNode.Next;
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
            SinglyNode<T>? indexedNode = firstNode;

            for (int i = 0; i < index; i++)
            {
                indexedNode = indexedNode.Next;
            }

            return indexedNode;
        }
    }
}
