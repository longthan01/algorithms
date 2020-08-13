using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class ex_1_9
    {
        private bool IsSubstring(string s, string subString)
        {
            return s.Contains(subString);
        }

        public bool IsRotationOf(string source, string dest)
        {
            return source.Length == dest.Length && IsSubstring(source + source, dest);
        }
    }
}
