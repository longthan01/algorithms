using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class ex_5_3
    {
        public int FlipBitToWin(int n)
        {
            int start1sIdx = -1;
            int startLength = 0;
            int end1sIdx = -1;
            int endLength = 0;
            int startIdx = 0;
            int INT_SIZE = sizeof(int) * 8;
            int max1sSeq = -1;
            int tempMax1Seq = -1;
            bool startDone = false;
            bool endDone = false;

            for (startIdx = 0; startIdx < INT_SIZE; startIdx++)
            {
                bool bit = Ex5Helper.GetBit(n, startIdx);
                // bit = 1
                if (bit)
                {
                    if (start1sIdx == -1)
                    {
                        start1sIdx = startIdx;
                    }
                    if (!startDone)
                    {
                        startLength++;
                    }
                    else
                    {
                        if (end1sIdx == -1)
                        {
                            end1sIdx = startIdx;
                        }
                        if (!endDone)
                        {
                            endLength++;
                        }
                    }
                    if (startLength > max1sSeq)
                    {
                        max1sSeq = startLength + 1;
                    }
                    if (endLength > max1sSeq)
                    {
                        max1sSeq = endLength + 1;
                    }

                }
                // bit = 0
                else
                {
                    if (!startDone && start1sIdx != -1)
                    {
                        startDone = true;
                    }
                    else
                    {
                        if (!endDone && end1sIdx != -1)
                        {
                            endDone = true;
                        }
                    }
                    if (startDone && endDone)
                    {
                        tempMax1Seq = startLength + 1 + endLength;
                        if (tempMax1Seq > max1sSeq)
                        {
                            max1sSeq = tempMax1Seq;
                        }
                        start1sIdx = end1sIdx;
                        startLength = endLength;
                        end1sIdx = -1;
                        endLength = 0;
                    }
                    if (startIdx + 1 < INT_SIZE)
                    {
                        var nextBit = Ex5Helper.GetBit(n, startIdx + 1);
                        // current bit = 0, next bit also 0
                        if (!nextBit)
                        {
                            start1sIdx = -1;
                            startLength = 0;
                            end1sIdx = -1;
                            endLength = 0;
                            startDone = false;
                            endDone = false;
                        }
                    }
                }
            }
            return max1sSeq;
        }
    }
}
