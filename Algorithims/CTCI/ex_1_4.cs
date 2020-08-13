using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class ex_1_4
    {
        public bool IsPalindromePermutation(string str)
        {
            // assume ascii chars
            int asciiCount = 128;
            int[] ascii = Enumerable.Repeat(0, asciiCount).ToArray();
            int oldCharsCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                ascii[str[i]]++;
            }

            for (int i = 0; i < ascii.Length; i++)
            {
                if (ascii[i] % 2 == 1)
                {
                    oldCharsCount++;
                }
            }
            return oldCharsCount <= 1;
        }
    }
}
