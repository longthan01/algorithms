using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public static class Ex5Helper
    {
        public static int SetBit(int N, int i, int value)
        {
            int mask = ~(1 << i);
            int newN = N & mask;
            return newN | (value << i);
        }
        public static bool GetBit(int N, int i)
        {
            int mask = (1 << i);
            return (N & mask) != 0;
        }
        public static string ToBinary(long n)
        {
            if (n < 0)
            {
                return Convert.ToString(n, 2);
            }
            StringBuilder sb = new StringBuilder();
            while (n > 0)
            {
                long bit = n % 2;
                sb.Insert(0, bit);
                n /= 2;
            }
            return sb.ToString();
        }
        private static string ToBinaryNegative(int n)
        {
            uint absN = (uint)Math.Abs(n);
            int notN = (int)~absN;
            int newN = notN + 1;
            int test = (int)newN;
            return ToBinary(test);
        }
    }
}
