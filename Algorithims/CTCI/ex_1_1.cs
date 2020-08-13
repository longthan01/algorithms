using Algorithms.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    // Is Unique: Implement an algorithm to determine if a string has all unique characters. What if you
    // cannot use additional data structures?
    public class ex_1_1
    {
        // O(nlog(n))
        public bool IsUniqueSort(string str)
        {
            //cannot use additional data structures => sort string, check adjacent index
            ISort<char> sort = new Quicksort<char>(str.ToCharArray());
            sort.Sort();
            for (int i = 0; i < sort.Array.Length - 1; i++)
            {

                if (sort.Array[i] == sort.Array[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
        // O(n)
        public bool IsUniqueCount(string str)
        {
            // assume that this is an array of ascii char
            int[] ascii = Enumerable.Repeat(0, 128).ToArray();
            for (int i = 0; i < str.Length; i++)
            {
                // count the characters, ascii[i] corresponding to character in str at i
                ascii[str[i]]++;
            }
            for (int i = 0; i < ascii.Length; i++)
            {
                if (ascii[i] > 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
