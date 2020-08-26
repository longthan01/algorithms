using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI.DynamicProgramming
{
   public class ex_8_1
    {
        public int CountPossibleWays(int stairCaseSteps)
        {
            int first = 1;
            int second = 2;
            int third = 4;
            if(stairCaseSteps == 1) { return first; }
            if(stairCaseSteps == 2) { return second; }
            if(stairCaseSteps == 3) { return third; }
            for(int i=4; i <stairCaseSteps; i++)
            {
                int current = 
                    third // (current-1)
                    + second  // (current-2)
                    + first; // (current-3)
                first = second;
                second = third;
                third = current;
            }
            return
                    third // (current-1)
                    + second  // (current-2)
                    + first; // (current-3)
        }
    }
}
