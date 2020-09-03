using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class ex_5_2
    {
        /// <summary>
        /// convert floating point to binary
        /// </summary>
        public string ToBinary(double number)
        {
            int n = (int)number;
            string nb = Ex5Helper.ToBinary(n);
            StringBuilder sb = new StringBuilder(nb);
            double floatingPoint = number - n;
            sb.Append(".");
            int count = 0;
            while (floatingPoint != 0)
            {
                count++;
                if (count > 32)
                {
                    sb = new StringBuilder("ERROR");
                    break;
                }
                floatingPoint *= 2;
                if (floatingPoint >= 1)
                {
                    sb.Append("1");
                    floatingPoint -= 1;
                }
                else
                {
                    sb.Append("0");
                }

            }
            return sb.ToString();
        }
    }
}
