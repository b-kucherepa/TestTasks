using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTasks.DIYClasses
{
    public class SinglyNode<T>
    {
        private T _data;
        public T Data { get => _data; set => _data = value; }

        private SinglyNode<T>? _next = null;
        internal SinglyNode<T>? Next { get => _next; set => _next = value; }

        internal SinglyNode(T dataReference)
        {
            _data = dataReference;
        }
    }
}
