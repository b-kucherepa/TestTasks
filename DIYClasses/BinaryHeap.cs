namespace TestTasks.DIYClasses
{
    internal class BinaryHeap<T>
    {
        BinaryNode<T> root;
        public BinaryHeap(T dataReference) 
        {
            root = new(dataReference);
        }
    }
}
