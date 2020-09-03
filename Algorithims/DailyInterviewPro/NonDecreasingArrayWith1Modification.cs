using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DailyInterviewPro
{
    class NonDecreasingArrayWith1Modification
    {
        public bool Solve(int[] arr)
        {
            int modCount = 0;
            for(int i=0; i < arr.Length-1; i++)
            {
                if(arr[i] > arr[i+1])
                {
                    modCount++;
                }
            }
            return modCount <= 1;
        }
    }
}
