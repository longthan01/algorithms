using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class ex_4_12
    {
        public int CountPaths(BinaryTree<int> tree, int sum)
        {
            if (tree.Root == null) { return 0; }
            List<List<BinaryTreeNode<int>>> paths = new List<List<BinaryTreeNode<int>>>();
            Queue<BinaryTreeNode<int>> queue = new Queue<BinaryTreeNode<int>>();
            queue.Enqueue(tree.Root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                this.GetPathLists(paths, new List<BinaryTreeNode<int>>(), node, 0, sum);
                if (node.Left != null) { queue.Enqueue(node.Left); }
                if (node.Right != null) { queue.Enqueue(node.Right); }
            }
            foreach (var item in paths)
            {
                foreach (var binaryTreeNode in item)
                {
                    Console.Write($"{binaryTreeNode.Value} -> ");
                }
                Console.WriteLine();
            }
            return paths.Count;
        }
        private void GetPathLists(List<List<BinaryTreeNode<int>>> result, List<BinaryTreeNode<int>> currentList, BinaryTreeNode<int> currentNode, int currentCount, int sum)
        {
            if (currentNode == null)
            {
                return;
            }
            currentList.Add(currentNode);
            int newSum = currentNode.Value + currentCount;
            if (newSum == sum)
            {
                result.Add(new List<BinaryTreeNode<int>>(currentList.Select(x => x).ToList()));
            }
            // if (newSum < sum)
            {
                GetPathLists(result, currentList.Select(x => x).ToList(), currentNode.Left, newSum, sum);
                //currentList.RemoveAt(currentList.Count - 1);
                GetPathLists(result, currentList.Select(x => x).ToList(), currentNode.Right, newSum, sum);
            }
        }
    }
}
