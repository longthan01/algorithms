using Algorithms.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI.SortingAndSearching
{
    public class ex_10_1
    {
        public T[] MergeInSortedOrder<T>(T[] arr1, T[] arr2)
        {
            // arr1 has enough space to hold arr2
            if (arr1.Length - arr2.Length <= 0)
            {
                throw new Exception("Invalid input");
            }
            int ri = arr1.Length - 1;
            int ai = arr1.Length - arr2.Length - 1;
            int aj = arr2.Length - 1;

            while (ai >= 0 && aj >= 0)
            {
                if (Comparer.Compare(arr1[ai], arr2[aj]) > 0)
                {
                    arr1[ri] = arr1[ai];
                    ai--;
                }
                else
                {
                    arr1[ri] = arr2[aj];
                    aj--;
                }
                ri--;
            }
            // copy the rest elements if one of 2 arrays has fully reached but the other still has remaining elements
            if (aj > 0)
            {
                while (aj >= 0)
                {
                    arr1[ri--] = arr2[aj--];
                }
            }
            return arr1;
        }
    }
}
