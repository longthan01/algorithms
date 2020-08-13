using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class ex_4_11
    {
        public T GetRandomNode<T>(BinaryTree<T> tree)
        {
            if (tree.Root == null)
            {
                return default(T);
            }
            var r = new Random();
            int index = r.Next(1, tree.TotalNodes);
            int count = 0;
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(tree.Root);
            while (queue.Count > 0)
            {
                count++;
                var node = queue.Dequeue();
                if (index == count)
                {
                    return node.Value;
                }
                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
            return default(T);
        }
    }
}
