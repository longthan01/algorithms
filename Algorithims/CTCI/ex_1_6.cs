using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class ex_1_6
    {
        // You can assume the string has only uppercase and lowercase letters (a - z).
        public string Compress(char[] s)
        {
            if (s.Length == 0)
            {
                return null;
            }
            char[] result = new char[s.Length];
            char currentChar = s[0];
            int currentCharCount = 0;
            int rindex = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != currentChar)
                {
                    if (rindex >= s.Length)
                    {
                        return new string(s);
                    }
                    result[rindex++] = currentChar;
                    char[] numChars = ToChars(currentCharCount);
                    for (int j = 0; j < numChars.Length; j++)
                    {
                        if (rindex >= s.Length)
                        {
                            return new string(s);
                        }
                        result[rindex++] = numChars[j];
                    }

                    currentCharCount = 0;
                }

                currentCharCount++;
                if (currentCharCount == 1)
                {
                    currentChar = s[i];
                }
            }
            if (rindex >= s.Length)
            {
                return new string(s);
            }
            result[rindex++] = currentChar;
            char[] lastNumChars = ToChars(currentCharCount);
            for (int j = 0; j < lastNumChars.Length; j++)
            {
                if (rindex >= s.Length)
                {
                    return new string(s);
                }
                result[rindex++] = lastNumChars[j];
            }
            return new string(result);
        }

        private char[] ToChars(int n)
        {
            return n.ToString().ToCharArray();
        }
    }
}
