namespace TestTasks.DIYClasses.Trees
{
    public class BinaryNode<T>
    {
        private T _data;
        private BinaryNode<T>? _leftChild = null;
        private BinaryNode<T>? _rightChild = null;

        public T Data { get => _data; set => _data = value; }
        public BinaryNode<T>? LeftChild { get => _leftChild; set => _leftChild = value; }
        public BinaryNode<T>? RightChild { get => _rightChild; set => _rightChild = value; }


        public BinaryNode(T dataReference)
        {
            _data = dataReference;
        }
    }
}
