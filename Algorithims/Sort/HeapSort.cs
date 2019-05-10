namespace Algorithms.Sort
{
    /// <summary>
    /// Main idea: first build max heap from array, then for each element from end to start, move the largest element of the heap to the end of heap (end of array), reduce the heap size (array size to sort) by 1, repeat the process until heap size >= 1
    /// </summary>
    public class HeapSort : Sort.ISort
    {
        public HeapSort(int[] array)
        {
            Array = array;
        }

        public int[] Array { get; set; }
        public void Sort()
        {
            int nodeHaveChildren = Array.Length / 2 - 1;
            // build max heap for the entire array
            for (int i = nodeHaveChildren; i >=0; i--)
            {   
                BuildMaxHeap(i, Array.Length);
            }

            for (int i = Array.Length - 1; i>=0; i--)
            {
                // move the largest element to the end of tree (array)
                SwapArray(i, 0);

                // rebuild max heap since the largest element is now swapped to the end of tree
                // so we need to rebuild max heap from the root of tree
                // why root? because of as the max heap definition, any child will not greater than it's parent
                // so we rebuild max heap from top of the tree and inside the build max heap implementation it will recursively call itself 
                // for it's children, so the max heap essential will be remained
                BuildMaxHeap(0, i);
            }
        }

        private void BuildMaxHeap(int i, int subArrayLength)
        {
            int maxIndex = i;
            int leftChildIndex = 2 * i + 1;
            int rightChildIndex = 2 * i + 2;
            if (leftChildIndex < subArrayLength && Array[maxIndex] < Array[leftChildIndex])
            {
                maxIndex = leftChildIndex;
            }
            if (rightChildIndex < subArrayLength && Array[maxIndex] < Array[rightChildIndex])
            {
                maxIndex = rightChildIndex;
            }

            if (maxIndex != i)
            {
                SwapArray(i, maxIndex);
                // recursively heapify the sub-tree
                BuildMaxHeap(maxIndex, subArrayLength);
            }
        }

        private void SwapArray(int i, int i1)
        {
            int tmp = Array[i];
            Array[i] = Array[i1];
            Array[i1] = tmp;
        }
    }
}
