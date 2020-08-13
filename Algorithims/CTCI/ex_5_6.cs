using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class ex_5_6
    {
        public int GetBitNeedToFlip(int a, int b)
        {
            int sizeInt = sizeof(int);
            int c = 0;
            for (int i = 0; i < sizeInt; i++)
            {
                int na = a & 1;
                int nb = b & 1;
                if ((na ^ nb) != 0)
                {
                    c++;
                }
            }
            return c;
        }
    }
}
