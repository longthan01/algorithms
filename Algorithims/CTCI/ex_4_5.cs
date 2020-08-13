using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Sort;

namespace Algorithms.CTCI
{

    public class ex_4_5
    {
        public class NullableT<T>
        {
            public T Value { get; set; }
        }
        public bool IsBST<T>(BinaryTree<T> tree) where T : struct
        {
            return CheckBST(tree.Root, null, null);
        }

        public bool CheckBST<T>(BinaryTreeNode<T> node, NullableT<T> min, NullableT<T> max)
        {
            if (node == null)
            {
                return true;
            }

            if ((max != null && Comparer.Compare(node.Value, max.Value) > 0) || (min != null && Comparer.Compare(node.Value, min.Value) <= 0))
            {
                return false;
            }

            return CheckBST<T>(node.Left, min, new NullableT<T>()
            {
                Value = node.Value
            }) && CheckBST<T>(node.Right, new NullableT<T>()
            {
                Value = node.Value
            }, max);
        }
    }
}
