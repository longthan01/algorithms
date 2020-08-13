using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sort
{
    public class SortBase<T> : ISort<T>
    {
        public T[] Array { get; set; }

        public bool GreaterThan(T t1, T t2)
        {
            return Comparer.Compare<T>(t1, t2) > 0;
        }

        public bool IsEquals(T t1, T t2)
        {
            return Comparer.Compare<T>(t1, t2) == 0;
        }

        public bool LessThan(T t1, T t2)
        {
            return Comparer.Compare<T>(t1, t2) < 0;
        }

        public virtual void Sort()
        {
            throw new NotImplementedException();
        }
    }
}
