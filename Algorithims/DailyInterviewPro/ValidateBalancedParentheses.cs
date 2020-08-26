using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DailyInterviewPro
{
    class ValidateBalancedParentheses
    {
        public bool IsBalanced(string input)
        {
            Stack<string> stack = new Stack<string>();
            int i = 0;
            while (i < input.Length)
            {
                string v = input[i++].ToString();
                if (IsOpenBracket(v))
                {
                    stack.Push(v);
                }
                if(IsClosingBracket(v))
                {
                    if(stack.Count == 0)
                    {
                        return false;
                    }
                    string ov = stack.Pop();
                    if(!IsValidClosing(ov, v))
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }
        private bool IsClosingBracket(string s)
        {
            return s == ")" || s == "}" || s == "]";
        }
        private bool IsOpenBracket(string s)
        {
            return s == "(" || s == "{" || s == "[";
        }
        private bool IsValidClosing(string open, string close)
        {
            switch(open)
            {
                case "(":
                    return close == ")";
                case "{":
                    return close == "}";
                case "[":
                    return close == "]";
            }
            return false;
        }
    }
}
