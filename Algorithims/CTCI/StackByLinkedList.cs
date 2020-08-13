using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class StackByLinkedList<T>
    {
        public SingleLinkedList<T> Storage { get; set; } = new SingleLinkedList<T>();

        public bool Push(T value)
        {
            this.Storage.InsertHead(new Node<T>() { Value = value });
            return true;
        }

        public T Pop()
        {
            if (Storage.Head == null)
            {
                return default(T);
            }

            return this.Storage.RemoveHead().Value;
        }

        public T Peek()
        {
            return this.Storage.Head == null ? default(T) : this.Storage.Head.Value;
        }
        public bool IsEmpty()
        {
            return this.Storage.Head == null;
        }
    }
}
