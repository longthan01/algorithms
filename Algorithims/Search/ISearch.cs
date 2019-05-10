using System;

namespace Algorithms.Search
{
    public interface ISearch<T> where T : IComparable
    {
        int Search(T key, T[] array);
    }
}
