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
    public class ex_2_2
    {
        public SingleLinkedList<T> FindFrom<T>(SingleLinkedList<T> linkedList, int k)
        {
            int count = 0;
            Node<T> head = linkedList.Head;
            for (int i = 0; i < k; i++)
            {
                head = head?.Next;
                count++;
            }

            SingleLinkedList<T> result = new SingleLinkedList<T>();

            result.Head = head;
            return result;
        }
    }
}
