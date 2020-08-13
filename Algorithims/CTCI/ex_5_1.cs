using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class ex_5_1
    {
        public int Insert(int N, int M, int j, int i)
        {
            int mask = 1 << (j + 1);
            for (int id = 0; id <= j - i; id++)
            {
                bool val = GetBit(M, id);
                N = this.SetBit(N, i + id, val ? 1 : 0);
            }
            return N;
        }
        private int SetBit(int N, int i, int value)
        {
            int mask = ~(1 << i);
            int newN = N & mask;
            return newN | (value << i);
        }
        public bool GetBit(int N, int i)
        {
            int mask = (1 << i);
            return (N & mask) != 0;
        }
    }
}
