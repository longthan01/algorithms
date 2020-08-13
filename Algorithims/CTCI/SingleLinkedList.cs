using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Sort;

namespace Algorithms.CTCI
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }
    public class SingleLinkedList<T>
    {
        public Node<T> Head { get; set; }

        public Node<T> InsertTail(Node<T> node)
        {
            if (Head == null)
            {
                Head = node;
                return node;
            }
            Node<T> N = this.Head;
            while (N.Next != null)
            {
                N = N.Next;
            }

            N.Next = node;
            return node;
        }

        public Node<T> InsertHead(Node<T> node)
        {
            node.Next = Head;
            Head = node;
            return node;
        }

        public Node<T> RemoveHead()
        {
            if (this.Head == null)
            {
                return null;
            }
            Node<T> res = new Node<T>()
            {
                Value = this.Head.Value
            };
            this.Head = this.Head.Next;
            return res;
        }
        public Node<T> Remove(Node<T> node)
        {
            if (this.Head == null)
            {
                return null;
            }

            if (Comparer.Compare(this.Head.Value, node.Value) == 0)
            {
                return this.RemoveHead();
            }
            Node<T> N = this.Head;
            Node<T> preN = null;
            while (N != null)
            {
                if (Comparer.Compare<T>(N.Value, node.Value) == 0)
                {
                    break;
                }

                preN = N;
                N = N.Next;
            }

            if (N != null)
            {
                preN.Next = N.Next;
            }

            return N;
        }

        public void Print()
        {
            Console.WriteLine();
            Node<T> N = this.Head;
            while (N != null)
            {
                Console.Write($"{N.Value}");
                Console.Write(N.Next == null ? "" : "->");
                N = N.Next;
            }
        }

    }
}
