using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class ex_2_8
    {
        public Node<T> DetechCircular<T>(SingleLinkedList<T> linkedList)
        {
            Hashtable table = new Hashtable();
            Node<T> iterator = linkedList.Head;
            while (iterator != null)
            {
                if (table.ContainsKey(iterator))
                {
                    return iterator;
                }
                table.Add(iterator, iterator);
                iterator = iterator.Next;
            }

            return iterator;
        }

        public Node<T> DetechCircularUsingRunner<T>(SingleLinkedList<T> linkedList)
        {
            Node<T> slow = linkedList.Head;
            Node<T> fast = linkedList.Head;
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if (slow == fast)
                {
                    break;
                }
            }

            if (fast?.Next == null)
            {
                return null;
            }
            slow = linkedList.Head;
            while (slow != fast)
            {
                slow = slow.Next;
                fast = fast.Next;
            }

            return slow;
        }
    }
}
