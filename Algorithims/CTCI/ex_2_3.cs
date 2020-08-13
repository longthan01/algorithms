using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Sort;

namespace Algorithms.CTCI
{
    public class ex_2_3
    {
        public void RemoveMiddle<T>(Node<T> middleValue)
        {
            if (middleValue == null || middleValue.Next == null)
            {
                return;
            }
            Node<T> next = middleValue.Next;
            middleValue.Value = next.Value;
            middleValue.Next = next.Next;
        }
    }
}
