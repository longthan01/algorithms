namespace Algorithms.Sort
{
    public interface ISort<T>
    {
        T[] Array { get; set; }
        void Sort();
        bool GreaterThan(T t1, T t2);
        bool LessThan(T t1, T t2);
        bool IsEquals(T t1, T t2);
    }
}
