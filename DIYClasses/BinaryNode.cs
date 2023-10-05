namespace TestTasks.DIYClasses
{
    internal class BinaryNode<T>
    {
        private T _data;
        public T Data { get => _data; set => _data = value; }

        private BinaryNode<T>? _leftChild = null;
        internal BinaryNode<T>? LeftChild { get => _leftChild; set => _leftChild = value; }

        private BinaryNode<T>? _rightChild = null;
        internal BinaryNode<T>? RightChild { get => _rightChild; set => _rightChild = value; }
        
        
        internal BinaryNode(T dataReference)
        {
            _data = dataReference;
        }
    }
}
