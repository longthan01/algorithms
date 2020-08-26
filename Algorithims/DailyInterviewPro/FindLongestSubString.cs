using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DailyInterviewPro
{
    public class FindLongestSubString
    {
        public int Solve(string s)
        {
                int res = 0; // result 

            // last index of all characters is initialized 
            // as -1 
            int[] lastIndex = Enumerable.Repeat(-1, 256).ToArray();
                // Initialize start of current window 
                int i = 0;

                // Move end of current window 
                for (int j = 0; j < s.Length; j++)
                {

                    // Find the last index of str[j] 
                    // Update i (starting index of current window) 
                    // as maximum of current value of i and last 
                    // index plus 1 
                    i = Math.Max(i, lastIndex[s[j]] + 1);

                    // Update result if we get a larger window 
                    res = Math.Max(res, j - i + 1);

                    // Update last index of j. 
                    lastIndex[s[j]] = j;
                }
                return res;
        }
    }
}
