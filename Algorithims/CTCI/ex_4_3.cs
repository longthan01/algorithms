using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class ex_4_3
    {
        public List<SingleLinkedList<T>> CreateLinkedListPerDepth<T>(BinaryTree<T> tree)
        {
            List<SingleLinkedList<T>> linkedLists = new List<SingleLinkedList<T>>();
            int currentChilds = 1;
            int nextChilds = 0;
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(tree.Root);
            SingleLinkedList<T> linkedList = new SingleLinkedList<T>();
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (currentChilds > 0)
                {
                    linkedList.InsertHead(new Node<T>() { Value = node.Value });
                }

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                    nextChilds++;
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                    nextChilds++;
                }
                currentChilds--;
                if (currentChilds == 0)
                {
                    currentChilds = nextChilds;
                    nextChilds = 0;
                    linkedLists.Add(linkedList);
                    linkedList = new SingleLinkedList<T>();
                }
            }

            return linkedLists;
        }
    }
}
