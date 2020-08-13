using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{

    public class ex_4_4
    {
        public bool IsBalanced<T>(BinaryTree<T> tree)
        {
            return this.GetHeight(tree.Root) != int.MinValue;
        }


        private int GetHeight<T>(BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                return -1;
            }

            int leftH = GetHeight<T>(root.Left);
            if (leftH == int.MinValue)
            {
                //break the recursion  call
                return int.MinValue;
            }

            int rightH = GetHeight<T>(root.Right);
            if (rightH == int.MinValue)
            {
                // break the recursion call
                return Int32.MinValue;
            }
            if (Math.Abs(leftH - rightH) > 1)
            {
                return Int32.MinValue;
            }
            else
            {
                return Math.Max(leftH, rightH) + 1;
            }
        }
    }
}
