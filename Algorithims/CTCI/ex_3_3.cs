using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{

    public class ex_3_3<T>
    {
        public int StackCapacity { get; set; }
        public int CurrentStackCapacity { get; set; }
        public ex_3_3(int stackCapacity)
        {
            this.StackCapacity = stackCapacity;

        }
        public List<SingleLinkedList<T>> StackSet { get; set; } = new List<SingleLinkedList<T>>();

        public bool Push(T value)
        {
            CurrentStackCapacity++;
            if (StackSet.Count == 0)
            {
                CurrentStackCapacity = 1;
                StackSet.Add(new SingleLinkedList<T>());
            }

            if (CurrentStackCapacity > StackCapacity)
            {
                CurrentStackCapacity = 1;
                StackSet.Add(new SingleLinkedList<T>());
            }

            var linkedList = StackSet[StackSet.Count - 1];
            linkedList.InsertHead(new Node<T>()
            {
                Value = value
            });
            return true;
        }

        public T Pop()
        {
            if (StackSet.Count == 0)
            {
                return default(T);
            }
            var stack = this.StackSet[this.StackSet.Count - 1];
            var res = stack.RemoveHead().Value;
            DecreaseCurrentStackCapacity();
            return res;
        }

        private void DecreaseCurrentStackCapacity()
        {
            CurrentStackCapacity--;
            if (CurrentStackCapacity == 0)
            {
                if (StackSet.Count > 0)
                {
                    CurrentStackCapacity = StackCapacity;
                    StackSet.RemoveAt(StackSet.Count - 1);
                }
                else
                {
                    CurrentStackCapacity = 0;
                }
            }
        }
        public T PopAss(int index)
        {
            int totalCount = 0;
            for (int i = 0; i < StackSet.Count - 1; i++)
            {
                totalCount += StackCapacity;
            }

            totalCount += CurrentStackCapacity;
            int stackIndex = index / this.StackCapacity;
            int nodeIndex = this.CurrentStackCapacity - (index % this.StackCapacity);
            Node<T> iterator = this.StackSet[stackIndex].Head;
            for (int i = 1; i < nodeIndex; i++)
            {
                iterator = iterator.Next;

            }

            this.StackSet[stackIndex].Remove(iterator);
            DecreaseCurrentStackCapacity();
            return iterator.Value;
        }
    }
}
