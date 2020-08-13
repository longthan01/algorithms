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
    public class ex_4_2
    {
        public BinarySearchTree<T> CreateBinarySearchTree<T>(T[] sortedArray)
        {
            BinarySearchTree<T> tree = new BinarySearchTree<T>();
            BSTNode<T> root = null;
            CreateTree(ref root, 0, sortedArray.Length - 1, sortedArray);
            tree.Root = root;
            return tree;
        }

        public void CreateTree<T>(ref BSTNode<T> parent, int left, int right, T[] sortedArray)
        {
            int mid = (left + right) / 2;
            if (right < left)
            {
                return;
            }
            if (parent == null)
            {
                parent = new BSTNode<T>()
                {
                    Value = sortedArray[mid]
                };
            }

            BSTNode<T> leftEl = null;
            CreateTree<T>(ref leftEl, left, mid - 1, sortedArray);
            parent.Left = leftEl;
            BSTNode<T> rightEL = null;
            CreateTree<T>(ref rightEL, mid + 1, right, sortedArray);
            parent.Right = rightEL;
        }
    }
}
