using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Sort;

namespace Algorithms.CTCI
{
    public class ex_2_7
    {
        public SingleLinkedList<T> GetIntersection<T>(SingleLinkedList<T> linkedList1, SingleLinkedList<T> linkedList2)
        {
            Hashtable table = new Hashtable();
            var it1 = linkedList1.Head;
            SingleLinkedList<T> result = new SingleLinkedList<T>();
            Node<T> rit = null;
            while (it1 != null)
            {
                table.Add(it1, it1);
                it1 = it1.Next;
            }

            var it2 = linkedList2.Head;
            while (it2 != null)
            {
                if (table.ContainsKey(it2))
                {
                    result.InsertTail(new Node<T>() { Value = it2.Value });
                }
                else
                {
                    table.Add(it2, it2);
                }

                it2 = it2.Next;
            }

            return result;
        }
    }
}
