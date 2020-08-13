using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Sort;

namespace Algorithms.CTCI
{
    public class ex_3_5<T>
    {
        private SortedStack<T> Stack = new SortedStack<T>();

        public bool Push(T value)
        {
            return this.Stack.Push(value);
        }

        public T Peek()
        {
            return this.Stack.Peek();
        }

        public T Pop()
        {
            return this.Stack.Pop();
        }

        public bool IsEmpty()
        {
            return this.Stack.IsEmpty();
        }
        private class SortedStack<T>
        {
            private StackByLinkedList<T> Stack = new StackByLinkedList<T>();
            private StackByLinkedList<T> Buffer = new StackByLinkedList<T>();
            public bool Push(T value)
            {
                if (Stack.IsEmpty())
                {
                    Stack.Push(value);
                }
                else
                {
                    while (!Stack.IsEmpty() && Comparer.Compare(value, Stack.Peek()) > 0)
                    {
                        Buffer.Push(Stack.Pop());
                    }

                    Stack.Push(value);
                    while (!Buffer.IsEmpty())
                    {
                        Stack.Push(Buffer.Pop());
                    }
                }
                return true;
            }

            public T Pop()
            {
                if (this.Stack.Storage.Head == null)
                {
                    return default(T);
                }

                return this.Stack.Pop();
            }

            public T Peek()
            {
                if (this.Stack.Storage.Head == null)
                {
                    return default(T);
                }

                return this.Stack.Storage.Head.Value;
            }

            public bool IsEmpty()
            {
                return this.Stack.Storage.Head == null;
            }
        }
    }
}
