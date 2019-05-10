using System;

namespace Algorithms.Search
{
    public class BinarySearch<T> : ISearch<T> where T : IComparable
    {
        public int Search(T key, T[] array)
        {
            return Search(key, array, 0, array.Length-1);
        }

        private int Search(T key, T[] array, int start, int end)
        {
            int middle = (end + start) / 2;
            if (array[middle].CompareTo(key) == 0)
            {
                return middle;
            }
            if (start == end)
            {
                return -1;
            }
            if (array[middle].CompareTo(key) > 0)
            {

                // find in the left side
                return Search(key, array, 0, middle);
            }
            else
            {
                // find in the right side
                return Search(key, array, middle + 1, end);
            }
        }
    }
}
