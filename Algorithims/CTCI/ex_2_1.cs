using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Sort;

namespace Algorithms.CTCI
{
    public class ex_2_1
    {
        public void RemoveDuplicate<T>(SingleLinkedList<T> linkedList)
        {
            HashSet<T> counterSet = new HashSet<T>();
            Node<T> N = linkedList.Head;
            Node<T> preN = null;
            while (N != null)
            {
                if (counterSet.Contains(N.Value))
                {
                    preN.Next = N.Next;
                }
                else
                {
                    counterSet.Add(N.Value);
                    preN = N;

                }
                N = N.Next;
            }

        }

        public void RemoveDuplicateWithoutBuffer<T>(SingleLinkedList<T> linkedList)
        {
            Node<T> N = linkedList.Head;
            while (N != null)
            {
                Node<T> runner = N;
                while (runner.Next != null)
                {
                    if (Comparer.Compare(N.Value, runner.Next.Value) == 0)
                    {
                        runner.Next = runner.Next.Next;

                    }
                    else
                    {
                        runner = runner.Next;
                    }

                }

                N = N.Next;
            }
        }
    }
}
