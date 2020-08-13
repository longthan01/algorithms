using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Sort;

namespace Algorithms.CTCI
{
    public class ex_2_4
    {
        public void Partition<T>(SingleLinkedList<T> linkedList, T partitionValue)
        {
            Node<T> lessThanP = null;
            Node<T> largerThanP = null;
            Node<T> iterator = linkedList.Head;
            Node<T> newHeadLess = null;
            Node<T> newHeadLarger = null;
            while (iterator != null)
            {
                if (Comparer.Compare(iterator.Value, partitionValue) < 0)
                {
                    if (lessThanP == null)
                    {
                        newHeadLess = iterator;
                        lessThanP = iterator;
                    }
                    else
                    {
                        lessThanP.Next = iterator;
                        lessThanP = lessThanP.Next;
                    }
                }
                else
                {
                    if (largerThanP == null)
                    {
                        newHeadLarger = iterator;
                        largerThanP = iterator;
                    }
                    else
                    {
                        largerThanP.Next = iterator;
                        largerThanP = largerThanP.Next;
                    }
                }

                iterator = iterator.Next;
            }

            if (lessThanP == null || largerThanP == null)
            {
                return;
            };
            lessThanP.Next = newHeadLarger;
            linkedList.Head = newHeadLess;
        }
    }
}
