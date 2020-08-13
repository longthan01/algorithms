using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class ex_3_4<T>
    {
        private MyQueue<T> myQueue = new MyQueue<T>();
        public bool Enqueue(T value)
        {
            return myQueue.Enqueue(value);
        }

        public T Dequeue()
        {
            return myQueue.Dequeue();
        }
        private class MyQueue<T>
        {
            private StackByLinkedList<T> OldestFirstStack { get; set; } = new StackByLinkedList<T>();
            private StackByLinkedList<T> NewestFirstStack { get; set; } = new StackByLinkedList<T>();

            public bool Enqueue(T value)
            {

                // move element from oldest stack to newest stack
                while (!OldestFirstStack.IsEmpty())
                {
                    var v = this.OldestFirstStack.Pop();
                    this.NewestFirstStack.Push(v);
                }
                this.NewestFirstStack.Push(value);
                return true;
            }
            public T Dequeue()
            {

                // move element from newest stack to oldest stack
                while (!NewestFirstStack.IsEmpty())
                {
                    var v = this.NewestFirstStack.Pop();
                    this.OldestFirstStack.Push(v);
                }
                return this.OldestFirstStack.Pop();
            }
        }
    }
}
