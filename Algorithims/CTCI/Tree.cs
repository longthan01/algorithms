using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Sort;

namespace Algorithms.CTCI
{
    public class BinaryTreeNode<T>
    {
        public T Value { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

    }


    public class BinaryTree<T>
    {
        public int TotalNodes { get; set; }
        public BinaryTreeNode<T> Root
        { get; set; }

        public void Insert(T data)
        {
            TotalNodes++;
            if (Root == null)
            {
                Root = new BinaryTreeNode<T>() { Value = data };
                return;
            }
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(this.Root);
            BinaryTreeNode<T> node = null;
            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>()
                    {
                        Value = data
                    };
                    break;
                }

                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>()
                    {
                        Value = data
                    };
                    break;
                }
                queue.Enqueue(node.Left);
                queue.Enqueue(node.Right);
            }

        }

        public BinaryTreeNode<T> Find(T value)
        {
            return this.Find(this.Root, value);
        }
        private BinaryTreeNode<T> Find<T>(BinaryTreeNode<T> root, T value)
        {
            if (root == null)
            {
                return null;
            }
            if (Comparer.Compare(root.Value, value) == 0)
            {
                return root;
            }

            var leftRes = this.Find(root.Left, value);
            if (leftRes == null)
            {
                return this.Find(root.Right, value);
            }

            return leftRes;
        }
        public T Delete(T value)
        {
            if (this.Root == null)
            {
                throw new Exception("Root is null");
            }
            var deepest = this.FindDeepestRightMost();
            //  find value
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                var root = queue.Dequeue();
                if (Comparer.Compare(root.Value, value) == 0)
                {
                    root.Value = deepest.Value;
                    this.DeleteDeepestRightMost();
                    return root.Value;
                }
                if (root.Left != null)
                {
                    queue.Enqueue(root.Left);
                }
                if (root.Right != null)
                {
                    queue.Enqueue(root.Left);
                }
            }
            return value;
        }
        private BinaryTreeNode<T> FindDeepestRightMost()
        {
            if (this.Root == null)
            {
                return null;
            }
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(this.Root);
            while (queue.Count > 0)
            {
                var root = queue.Dequeue();
                if (queue.Count == 0)
                {
                    return root;
                }
                if (root.Left != null)
                {
                    queue.Enqueue(root.Left);
                }
                if (root.Right != null)
                {
                    queue.Enqueue(root.Left);
                }
            }
            return null;
        }
        private void DeleteDeepestRightMost()
        {
            if (this.Root == null)
            {
                return;
            }
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(Root);
            var deepest = this.FindDeepestRightMost();
            while (queue.Count > 0)
            {
                var root = queue.Dequeue();
                if (root.Left == deepest)
                {
                    root.Left = null;
                }
                if (root.Right == deepest)
                {
                    root.Right = null;
                }
                if (root.Left != null)
                {
                    queue.Enqueue(root.Left);
                }
                if (root.Right != null)
                {
                    queue.Enqueue(root.Left);
                }
            }
        }
        public void Print()
        {
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(this.Root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                Console.Out.Write($"{node.Value}");

                Console.Out.Write("->");


                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }
        }
    }
}
