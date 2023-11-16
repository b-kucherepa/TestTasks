namespace TestTasks.DIYClasses
{
    public class BinaryTree<T>
    {
        private BinaryNode<T> _root;
        public BinaryNode<T> Root { get => _root; }

        private int _count;
        public int Count { get => _count; }

        public BinaryTree(T[] dataArray, int rootIndex = 0)
        {
            //sets root data as the first array element and begins to recursively build the tree 
            _root = new(dataArray[rootIndex]);
            _count = 1;
            Construct(_root, dataArray, rootIndex);
        }

        private void Construct(BinaryNode<T> node, T[] dataArray, int parentIndex)
        {
            /* children of every node are located at:
             * left: (parentIndex * 2 + 1), right: (parentIndex * 2 + 2).
             * If these indexes are out of the array bounds, this child doesn't exist.
             * So we set the node data for each child (if it exists) and recursively call
             * the method to continue creating the tree: */

            if (parentIndex * 2 + 1 < dataArray.Length)
            {
                int leftChildIndex = parentIndex * 2 + 1;
                node.LeftChild = new(dataArray[leftChildIndex]);
                _count++;
                Construct(node.LeftChild, dataArray, leftChildIndex);
            }

            if (parentIndex * 2 + 2 < dataArray.Length)
            {
                int rightChildIndex = parentIndex * 2 + 2;
                node.RightChild = new(dataArray[rightChildIndex]);
                _count++;
                Construct(node.RightChild, dataArray, rightChildIndex);
            }
        }
    }
}
