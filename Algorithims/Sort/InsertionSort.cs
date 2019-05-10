namespace Algorithms.Sort
{
    public class InsertionSort : Sort.ISort
    {
        public InsertionSort(int[] array)
        {
            Array = array;
        }

        public int[] Array { get; set; }
        public void Sort()
        {
            for (int i = 1; i < Array.Length; i++)
            {
                Insert(i);
            }
        }

        private void Insert(int i)
        {
            int valueAti = Array[i];
            int indexBeforei = i - 1;
            while (indexBeforei >= 0 && Array[indexBeforei] > valueAti)
            {
                Array[indexBeforei + 1] = Array[indexBeforei];
                indexBeforei--;
            }

            Array[indexBeforei + 1] = valueAti;
        }
    }
}
