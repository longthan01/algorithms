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
    public class ex_2_5
    {
        public SingleLinkedList<int> SumList(SingleLinkedList<int> n1, SingleLinkedList<int> n2)
        {
            int result = SingleLinkedListToInt(n1) + SingleLinkedListToInt(n2);
            int exp = 0;
            Node<int> head = null;
            Node<int> iterator = null;
            while (result > 0)
            {
                var node = new Node<int>()
                {
                    Value = result % 10
                };

                if (head == null)
                {
                    head = node;
                    iterator = head;
                }
                else
                {
                    iterator.Next = node;
                    iterator = iterator.Next;
                }

                result /= 10;
                exp++;
            }
            return new SingleLinkedList<int>()
            {
                Head = head
            };
        }

        private int SingleLinkedListToInt(SingleLinkedList<int> linkedList)
        {
            Node<int> iterator = linkedList.Head;
            int exp = 0;
            int result = 0;
            while (iterator != null)
            {
                result += iterator.Value * (int)Math.Pow(10, exp);
                iterator = iterator.Next;
                exp++;
            }

            return result;
        }
    }
}
