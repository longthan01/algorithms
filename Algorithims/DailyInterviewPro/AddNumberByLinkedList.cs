using Algorithms.CTCI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DailyInterviewPro
{
    public class AddNumberByLinkedList
    {
        public SingleLinkedList<int> Add(SingleLinkedList<int> l1, SingleLinkedList<int> l2)
        {
            int n1 = LinkedListToNum(l1);
            int n2 = LinkedListToNum(l2);
            int r = n1 + n2;
            // create linked list result
            SingleLinkedList<int> res = new SingleLinkedList<int>();
            Node<int> it = res.Head;
            while (r > 0)
            {
                int digit = r % 10;
                if (res.Head == null) {
                    it = new Node<int>()
                    {
                        Value = digit
                    };
                    res.Head = it;
                }
                else
                {
                    it.Next = new Node<int>()
                    {
                        Value = digit
                    };
                    it = it.Next;
                }
                r /= 10;
            }
            return res;
        }
        private int LinkedListToNum(SingleLinkedList<int> l)
        {
            int res = 0;
            if(l.Head == null)
            {
                return res;
            }
            Node<int> it = l.Head;
            int c = 0;
            while (it != null)
            {
                res += it.Value * (int)Math.Pow(10, c);
                c++;
                it = it.Next;
            }
            return res;
        }
    }
}
