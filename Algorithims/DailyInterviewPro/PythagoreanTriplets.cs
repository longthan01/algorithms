using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DailyInterviewPro
{
    class PythagoreanTriplets
    {
        public List<int> IsExistPythagoreanTriplet(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Hashtable ht = new Hashtable();
                int ii = array[i] * array[i];
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                        continue;
                    int jj = array[j] * array[j];
                    if (!ht.ContainsKey(ii - jj))
                    {
                        if(!ht.ContainsKey(jj))
                        {
                            ht.Add(jj, 1);
                        }
                    }
                    else
                    {
                        return new List<int> {
                        array[i], array[j], (int) Math.Sqrt(ii-jj)
                        };
                    }
                }
            }
            return null;
        }
    }
}
