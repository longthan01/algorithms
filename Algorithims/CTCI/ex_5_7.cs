using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class ex_5_7
    {
        /// <summary>
        /// swap odd and even bits by pair
        /// </summary>
        public long SwapOddAndEvenBits(int n)
        {
            long integer_mask_even = 0xaaaaaaaa;
            long integer_mask_odd = 1431655765;
            long newn = n & integer_mask_even;
            return (((n & integer_mask_even) >> 1) | ((n & integer_mask_odd) << 1));
        }
    }
}
