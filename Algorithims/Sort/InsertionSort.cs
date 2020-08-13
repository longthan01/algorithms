namespace Algorithms.Sort
{
    public class InsertionSort<T> : SortBase<T>, Sort.ISort<T>
    {
        public InsertionSort(T[] array)
        {
            Array = array;
        }

        public override void Sort()
        {
            for (int i = 1; i < Array.Length; i++)
            {
                Insert(i);
            }
        }

        private void Insert(int i)
        {
            T valueAti = Array[i];
            int indexBeforei = i - 1;
            while (indexBeforei >= 0 && this.GreaterThan(Array[indexBeforei], valueAti))
            {
                Array[indexBeforei + 1] = Array[indexBeforei];
                indexBeforei--;
            }

            Array[indexBeforei + 1] = valueAti;
        }
    }
}
