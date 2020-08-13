using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class ex_1_3
    {
        // replace space with %20
        public char[] Urlify(char[] url, int trueLength)
        {
            int spaces = 0;
            // O(n)
            for (int i = 0; i < trueLength; i++)
            {
                if (url[i] == ' ')
                {
                    spaces += 3;
                }
                else
                {
                    spaces++;
                }
            }
            int sindex = trueLength - 1;
            int rindex = spaces - 1;

            while (sindex >= 0)
            {
                if (url[sindex] != ' ')
                {
                    url[rindex--] = url[sindex];
                }
                else
                {
                    url[rindex--] = '0';
                    url[rindex--] = '2';
                    url[rindex--] = '%';
                }

                sindex--;
            }

            return url;
        }
    }
}
