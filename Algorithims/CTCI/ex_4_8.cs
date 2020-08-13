using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Sort;

namespace Algorithms.CTCI
{
    public class ex_4_8
    {
        public BinaryTreeNode<T> FindFirstCommonAncestor<T>(BinaryTree<T> tree, BinaryTreeNode<T> node1,
            BinaryTreeNode<T> node2)
        {
            return this.FindFirstCommonAncestor(tree.Root, node1, node2);
        }
        private BinaryTreeNode<T> FindFirstCommonAncestor<T>(BinaryTreeNode<T> root, BinaryTreeNode<T> node1,
            BinaryTreeNode<T> node2)
        {
            if (root == null)
            {
                return null;
            }
            if (root == node1 || root == node2)
            {
                return root;
            }

            var isOnLeft1 = this.IsOnBranch(root.Left, node1);
            var isOnLeft2 = this.IsOnBranch(root.Left, node2);
            if (isOnLeft1 != isOnLeft2)
            {
                return root;
            }

            return FindFirstCommonAncestor(isOnLeft1 ? root.Left : root.Right, node1, node2);
        }

        private bool IsOnBranch<T>(BinaryTreeNode<T> root, BinaryTreeNode<T> node)
        {
            if (root == null || node == null)
            {
                return false;
            }
            if (root == node)
            {
                return true;
            }

            return IsOnBranch(root.Left, node) || IsOnBranch<T>(root.Right, node);
        }
    }
}
