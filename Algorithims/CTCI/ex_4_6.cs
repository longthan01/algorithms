using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{

    public class ex_4_6
    {
        // in-order traversal
        public BSTNode<T> GetInOrderSuccessor<T>(BinarySearchTree<T> tree, BSTNode<T> current)
        {
            if (current.Right != null)
            {
                return GetLeftMostChildOnTheRight(current);
            }
            else
            {
                BSTNode<T> iterator = current;
                BSTNode<T> parent = current.Parent;
                while (parent != null && parent.Left != iterator)
                {
                    iterator = iterator.Parent;
                    parent = parent.Parent;
                }

                return parent;
            }
        }
        private BSTNode<T> GetLeftMostChildOnTheRight<T>(BSTNode<T> current)
        {
            var iterator = current.Right;
            while (iterator != null)
            {
                if (iterator.Left != null)
                {
                    iterator = iterator.Left;
                }
                else
                {
                    break;
                }
            }

            return iterator;
        }
    }
}
