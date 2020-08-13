using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class ex_4_10
    {
        private StringBuilder GetArray(BinaryTree<int> tree)
        {
            // inorder traversal
            StringBuilder res = new StringBuilder();
            PreOrder(tree.Root, res);
            return res;
        }
        private void PreOrder(BinaryTreeNode<int> root, StringBuilder res)
        {
            if (root == null)
            {
                res.Append("DCM");
            }
            if (root.Left == null)
            {
                res.Append("DCM");
            }
            else
            {
                PreOrder(root.Left, res);
            }

            res.Append(root.Value.ToString());
            if (root.Right == null)
            {
                res.Append("DCM");
            }
            else
            {
                PreOrder(root.Right, res);
            }

        }
        public bool IsSubTree(BinaryTree<int> t1, BinaryTree<int> t2)
        {
            var arr1 = this.GetArray(t1);
            var arr2 = this.GetArray(t2);
            return arr1.ToString().IndexOf(arr2.ToString()) != -1;
        }
    }
}
