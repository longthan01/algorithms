using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class ex_1_5
    {
        public bool IsOneEditAway(string s1, string s2)
        {
            return IsOneEditReplace(s1, s2) || IsOneEditInsertRemove(s1, s2);
        }

        private bool IsOneEditReplace(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            bool foundDiff = false;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    if (foundDiff)
                    {
                        return false;
                    }

                    foundDiff = true;
                }
            }

            return foundDiff;
        }

        private bool IsOneEditInsertRemove(string s1, string s2)
        {
            if (Math.Abs(s1.Length - s2.Length) != 1)
            {
                return false;
            }

            int s1i = 0;
            int s2i = 0;
            bool s1LongerThanS2 = s1.Length > s2.Length;
            bool foundDiff = false;
            while (s1i < s1.Length && s2i < s2.Length)
            {
                if (s1[s1i] != s2[s2i])
                {
                    if (foundDiff)
                    {
                        return false;
                    }
                    foundDiff = true;
                    if (s1LongerThanS2)
                    {
                        s1i++;
                    }
                    else
                    {
                        s2i++;
                    }
                }
                else
                {
                    s1i++;
                    s2i++;
                }

                if ((s1i == s1.Length - 1 && s2i != s2.Length - 1) || (s2i == s2.Length - 1 && s1i != s1.Length - 1))
                {
                    foundDiff = true;
                }
            }

            return foundDiff;
        }
    }
}
