namespace TestTasks.DIYClasses
{
    public class SinglyNode<T>
    {
        private T _data;
        private SinglyNode<T>? _next = null;

        public T Data { get => _data; set => _data = value; }
        internal SinglyNode<T>? Next { get => _next; set => _next = value; }

        internal SinglyNode(T dataReference)
        {
            _data = dataReference;
        }
    }
}
