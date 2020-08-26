using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI.Hard
{
    public class ex_17_1
    {
        public int AddWithoutArithmetic(int a, int b)
        {
            int mem = 0;
            int res = 0;
            for(int i=0; i < sizeof(int) * 8; i++)
            {
                int ba = GetBit(a, i);
                int bb = GetBit(b, i);
                int r = (ba ^ bb) ^ mem;
                res = SetBit(res, i, r == 1 ? true : false);
                if(ba == 1 && bb == 1 || ba == 1 && mem == 1 || bb == 1 && mem == 1)
                {
                    mem = 1;
                }
                else
                {
                    mem = 0;
                }
            }
            return res;
        }
        private int SetBit(int n, int i, bool value)
        {
            int mask = 1 << i;
            mask = ~mask; // create mask like 111101111
            int v = value ? 1 : 0;
            int res = n & mask; // clear the ith bit
            return res | (v << i); // put back the ith bit by "value"
        }
        private int GetBit(int n, int i)
        {
            int mask = 1 << i;
            return (n & mask) > 0 ? 1 : 0;
        }
    }
}
