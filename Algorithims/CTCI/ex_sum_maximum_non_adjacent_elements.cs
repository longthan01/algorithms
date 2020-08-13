using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{

    public class ex_sum_maximum_non_adjcent_elements

    {
        public int MaxNonAdjcents(int[] array)
        {
            // find max 
            int maxi = 0, max1i = 0, max2i = 0;
            int max = int.MinValue;
            int max1 = int.MinValue;
            int max2 = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    maxi = i;
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max1 && array[i] <= max && i != maxi)
                {
                    max1 = array[i];
                    max1i = i;
                }
            }

            if (Math.Abs(maxi - max1i) == 1)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] > max2 && array[i] <= max1 && i != maxi && i != max1i)
                    {
                        max2 = array[i];
                        max2i = i;
                    }
                }

                return max + max2;

            }
            else
            {
                return max + max1;
            }
        }
    }
}
