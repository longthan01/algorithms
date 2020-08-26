using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DailyInterviewPro
{
    class FindFirstAndLastOccurencesOfATarget
    {
        static int count = 0;
        public int[] Solve(int[] sortedArray, int target)
        {
            int al = sortedArray.Length-1;
            int left = FindIndex(0, al, target, sortedArray, true);
            Console.WriteLine(count);
            count = 0;
            int right = FindIndex(0, al, target, sortedArray, false);
            Console.WriteLine(count);
            return new int[] { left, right };
        }
        int FindIndex(int low, int high, int target, int[] array, bool forleft)
        {
            count++;
            int mid = (low + high) / 2;
            int midEl = array[mid];
            if (low == high && midEl != target)
            {
                return -1;
            }
            if (low == high && midEl == target)
            {
                return mid;
            }
            
            if ((forleft && midEl == target))
            {
                int leftIdx = FindIndex(low, mid, target, array, forleft);
                if(leftIdx ==-1)
                {
                    return mid;
                }
                else
                {
                    return leftIdx;
                }
            }
            if((!forleft && midEl == target))
            {
                int rightIdx = FindIndex(mid+1, high, target, array, forleft);
                if (rightIdx == -1)
                {
                    return mid;
                }
                else return rightIdx;
            }

            if(target < midEl)
            {
                return FindIndex(low, mid, target, array, forleft);
            }
                return FindIndex(mid+1, high, target, array, forleft);
            
        }
    }
}
