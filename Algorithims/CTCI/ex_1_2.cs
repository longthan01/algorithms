using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Sort;

namespace Algorithms.CTCI
{
    public class ex_1_2
    {
        public bool IsPermutationOf_Count(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }
            // count characters 
            // assume that this is an ascii string
            int[] ascii = Enumerable.Repeat(0, 128).ToArray();
            for (int i = 0; i < str1.Length; i++)
            {
                ascii[str1[i]]++;
            }
            // loop for the second string, substract character count
            for (int i = 0; i < str2.Length; i++)
            {
                ascii[str2[i]]--;
                if (ascii[str2[i]] < 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsPermutationOf_Sort(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }
            ISort<char> sortedStr1 = new Quicksort<char>(str1.ToCharArray());
            sortedStr1.Sort();
            ISort<char> sortedStr2 = new Quicksort<char>(str2.ToCharArray());
            sortedStr2.Sort();

            for (int i = 0; i < sortedStr1.Array.Length; i++)
            {
                if (sortedStr1.Array[i] != sortedStr2.Array[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
