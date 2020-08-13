using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Sort;

namespace Algorithms.CTCI
{
    public class ex_2_6
    {
        public bool IsPalindrome<T>(SingleLinkedList<T> linkedList)
        {
            Node<T> it1 = linkedList.Head;
            SingleLinkedList<T> reverseLinkedList = Reverse(linkedList);
            Node<T> it2 = reverseLinkedList.Head;
            while (it1 != null || it2 != null)
            {
                if ((it1 == null && it2 != null) || (it1 != null && it2 == null))
                {
                    return false;
                }

                if (Comparer.Compare(it1.Value, it2.Value) != 0)
                {
                    return false;
                }

                it1 = it1.Next;
                it2 = it2.Next;
            }

            return true;

        }

        private SingleLinkedList<T> Reverse<T>(SingleLinkedList<T> linkedList)
        {
            Node<T> head = null;
            Node<T> iterator = linkedList.Head;
            SingleLinkedList<T> result = new SingleLinkedList<T>();
            while (iterator != null)
            {
                Node<T> node = new Node<T>()
                {
                    Value = iterator.Value
                };
                node.Next = head;
                head = node;
                iterator = iterator.Next;
            }

            result.Head = head;
            return result;
        }

        public bool IsPalindromeByStack<T>(SingleLinkedList<T> linkedList)
        {
            Node<T> iterator = linkedList.Head;
            Node<T> runner = linkedList.Head;
            Stack<Node<T>> stack = new Stack<Node<T>>();
            while (runner != null && runner.Next != null)
            {
                stack.Push(iterator);
                iterator = iterator.Next;
                runner = runner.Next.Next;
            }
            // check palindrome
            while (iterator != null)
            {
                Node<T> node = stack.Pop();
                if (Comparer.Compare(node.Value, iterator.Value) != 0)
                {
                    return false;
                }

                iterator = iterator.Next;
            }

            return iterator == null;
        }
    }
}
