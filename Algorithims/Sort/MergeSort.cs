using System.Collections.Generic;

namespace Algorithms.Sort
{
    /// <summary>
    /// Main idea: split array by half, sort each half then merge all together
    /// </summary>
    public class MergeSort<T> : SortBase<T>, Sort.ISort<T>
    {
        public MergeSort(T[] array)
        {
            this.Array = array;
        }

        public override void Sort()
        {
            // 0: left bound
            // Array.Length - 1: right bound
            Sort(0, Array.Length - 1);
        }

        private void Sort(int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                Sort(left, middle);
                Sort(middle + 1, right);
                SortAndMerge(left, middle, right);
            }
        }

        /// <summary>
        /// Sort and merge array1 from left to middle and array2 from middle + 1 to right
        /// </summary>
        private void SortAndMerge(int left, int middle, int right)
        {
            int leftArraySize = middle - left + 1;
            int rightArraySize = right - middle;
            List<T> tmpLeftArray = new List<T>();
            for (int i = 0; i < leftArraySize; i++)
            {
                tmpLeftArray.Add(Array[left + i]);
            }
            List<T> tmpRightArray = new List<T>();
            for (int i = 0; i < rightArraySize; i++)
            {
                tmpRightArray.Add(Array[middle + 1 + i]);
            }

            int leftSubArrayIndex = 0;
            int rightSubArrayIndex = 0;
            int currentSubArrayIndex = left;
            while (leftSubArrayIndex < leftArraySize || rightSubArrayIndex < rightArraySize)
            {
                // in case of there's one index exceed the limit array size, copy the rest of the other to destination array
                if (leftSubArrayIndex >= leftArraySize)
                {
                    while (rightSubArrayIndex < rightArraySize)
                    {
                        Array[currentSubArrayIndex++] = tmpRightArray[rightSubArrayIndex++];
                    }
                    break;
                }
                // in case of there's one index exceed the limit array size, copy the rest of the other to destination array
                if (rightSubArrayIndex >= rightArraySize)
                {
                    while (leftSubArrayIndex < leftArraySize)
                    {
                        Array[currentSubArrayIndex++] = tmpLeftArray[leftSubArrayIndex++];
                    }
                    break;
                }

                // if the index still in range, do the compare one by one
                if (this.LessThan(tmpLeftArray[leftSubArrayIndex], tmpRightArray[rightSubArrayIndex]))
                {
                    Array[currentSubArrayIndex] = tmpLeftArray[rightSubArrayIndex];
                    leftSubArrayIndex++;
                }
                else
                {
                    Array[currentSubArrayIndex] = tmpRightArray[rightSubArrayIndex];
                    rightSubArrayIndex++;
                }

                currentSubArrayIndex++;
            }
        }
    }
}
