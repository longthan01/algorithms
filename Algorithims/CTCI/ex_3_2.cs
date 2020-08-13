using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Sort;

namespace Algorithms.CTCI
{
    public class ex_3_2<T>
    {
        public SingleLinkedList<T> Stack { get; set; } = new SingleLinkedList<T>();
        public T Min { get; set; }
        // O(1)
        public bool Push(T value)
        {
            if (this.Stack.Head == null)
            {
                Min = value;
            }
            else
            {
                if (Comparer.Compare(value, this.Stack.Head.Value) < 1)
                {
                    Min = value;
                }
            }


            return this.Stack.InsertHead(new Node<T>() { Value = value }) != null;
        }

        public T Pop()
        {
            var res = this.Stack.RemoveHead();
            return res == null ? default(T) : res.Value;
        }

        public T GetMin()
        {
            return this.Min;
        }
    }
}
