using System;
using System.Collections.Generic;
using Algorithms.Sort;

namespace Algorithms.CTCI
{
    public class BSTNode<T>
    {
        public T Value { get; set; }
        private BSTNode<T> _left;
        private BSTNode<T> _right;

        public BSTNode<T> Left
        {
            get
            {
                return _left;
            }
            set
            {
                _left = value;
                if (value != null)
                {
                    _left.Parent = this;
                }
            }
        }

        public BSTNode<T> Right
        {
            get
            {
                return _right;
            }
            set
            {
                _right = value;
                if (value != null)
                {
                    _right.Parent = this;
                }
            }
        }
        public BSTNode<T> Parent { get; set; }
    }
    public class BinarySearchTree<T>
    {
        public BSTNode<T> Root { get; set; }

        public void Print()
        {
            Queue<BSTNode<T>> queue = new Queue<BSTNode<T>>();
            queue.Enqueue(Root);
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

        public void Remove(T node)
        {
            Remove(node, Root);
        }

        private BSTNode<T> Remove(T node, BSTNode<T> root)
        {
            if (root == null)
            {
                return null;
            }

            if (Comparer.Compare(node, root.Value) < 0)
            {
                root.Left = Remove(node, root.Left);
            }
            else
            {
                if (Comparer.Compare(node, root.Value) > 0)
                {
                    root.Right = Remove(node, root.Right);
                }
                else
                {
                    if (root.Left == null)
                    {
                        return root.Right;
                    }

                    if (root.Right == null)
                    {
                        return root.Left;
                    }

                    var nextSuccessor = GetMinChildOnTheRight(root.Right);
                    root.Value = nextSuccessor.Item2.Value;
                    root.Right = Remove(nextSuccessor.Item2.Value, root.Right);
                }
            }
            return root;
        }


        private Tuple<BSTNode<T>, BSTNode<T>, string> GetMinChildOnTheRight<T>(BSTNode<T> current)
        {
            var min = current;
            BSTNode<T> parent = current;
            string direction = "right";
            while (min.Left != null)
            {
                parent = min;
                min = min.Left;
                direction = "left";
            }

            return new Tuple<BSTNode<T>, BSTNode<T>, string>(parent, min, direction);
        }
        private void RemoveNode(BSTNode<T> parent, BSTNode<T> node)
        {
            if (parent.Left == node)
            {
                parent.Left = null;
            }
            else if (parent.Right == node)
            {
                parent.Right = null;
            }
        }

        private Tuple<BSTNode<T>, BSTNode<T>> FindNode(BSTNode<T> root, T node)
        {
            if (root == null)
            {
                return null;
            }

            if (Comparer.Compare(root.Value, node) == 0)
            {
                return new Tuple<BSTNode<T>, BSTNode<T>>(root, root);
            }

            if (root.Left != null && Comparer.Compare(root.Left.Value, node) == 0)
            {
                return new Tuple<BSTNode<T>, BSTNode<T>>(root, root.Left);
            }
            if (root.Right != null && Comparer.Compare(root.Right.Value, node) == 0)
            {
                return new Tuple<BSTNode<T>, BSTNode<T>>(root, root.Right);
            }

            var leftRes = FindNode(root.Left, node);
            if (leftRes == null)
            {
                return FindNode(root.Right, node);
            }

            return leftRes;
        }
        public void Insert(T value)
        {
            Root = Insert(Root, value);

        }

        private BSTNode<T> Insert(BSTNode<T> root, T value)
        {
            if (root == null)
            {
                root = new BSTNode<T>
                {
                    Value = value
                };
                return root;
            }

            if (Comparer.Compare(value, root.Value) <= 0)
            {
                root.Left = Insert(root.Left, value);
            }
            else
            {
                root.Right = Insert(root.Right, value);
            }

            return root;
        }
        public void InOrderTraversal()
        {
            InOrder(Root);
        }

        public void PreOrderTraversal()
        {
            PreOrder(Root);
        }
        public void PostOrderTraversal()
        {
            PostOrder(Root);
        }

        private void PreOrder(BSTNode<T> root)
        {
            if (root == null)
            {
                return;
            }
            Console.Out.Write($"{root.Value} -> ");
            InOrder(root.Left);
            InOrder(root.Right);
        }
        private void InOrder(BSTNode<T> root)
        {
            if (root == null)
            {
                return;
            }
            InOrder(root.Left);
            Console.Out.Write($"{root.Value} -> ");
            InOrder(root.Right);
        }
        private void PostOrder(BSTNode<T> root)
        {
            if (root == null)
            {
                return;
            }

            InOrder(root.Left);
            InOrder(root.Right);
            Console.Out.Write($"{root.Value} -> ");
        }
    }

}
