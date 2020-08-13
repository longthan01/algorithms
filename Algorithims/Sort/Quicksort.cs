using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sort
{
    public class Quicksort<T> : SortBase<T>, Sort.ISort<T>
    {

        public Quicksort(T[] array)
        {
            this.Array = array;
        }
        public override void Sort()
        {
            this.SortInternal(0, this.Array.Length - 1);
        }
        private void SortInternal(int lower, int higher)
        {
            if (lower >= higher)
            {
                return;
            }
            int partitionedIdx = this.Partition(lower, higher);
            this.SortInternal(lower, partitionedIdx - 1);
            this.SortInternal(partitionedIdx, higher);

        }
        private int Partition(int lower, int higher)
        {
            int pivot = (lower + higher) / 2;
            T pivotElm = this.Array[pivot];
            int leftIdx = lower;
            int rightIdx = higher;
            while (leftIdx <= rightIdx)
            {
                // find the index element that is higher than pivot
                while (this.LessThan(this.Array[leftIdx], pivotElm)) { leftIdx++; }
                // find the index element that is lower than pivot
                while (this.GreaterThan(this.Array[rightIdx], pivotElm)) { rightIdx--; }
                // check left and right valid
                if (leftIdx <= rightIdx)
                {
                    Swap(leftIdx, rightIdx);
                    leftIdx++;
                    rightIdx--;
                }
            }
            return leftIdx;
        }
        private void Swap(int i, int i1)
        {
            T tmp = Array[i];
            Array[i] = Array[i1];
            Array[i1] = tmp;
        }
    }
}
