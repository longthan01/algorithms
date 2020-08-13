using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.CTCI;

namespace Algorithms.Sort
{
    public static class Comparer
    {
        public static int Compare<T>(T t1, T t2)
        {
            Type t = typeof(T);
            switch (t.FullName)
            {
                case "System.Int32":
                    int i1 = (int)Convert.ChangeType(t1, typeof(int));
                    int i2 = (int)Convert.ChangeType(t2, typeof(int));
                    return i1 > i2 ? 1 : i1 == i2 ? 0 : -1;
                case "System.Char":
                    char c1 = (char)Convert.ChangeType(t1, typeof(char));
                    char c2 = (char)Convert.ChangeType(t2, typeof(char));
                    return c1.CompareTo(c2);
                case "Algorithms.CTCI.Animal":
                    Animal a1 = t1 as Animal;
                    Animal a2 = t2 as Animal;
                    ;
                    return a1.Type == a2.Type ? 0 : a1.Type == Animal.Types.Dog ? 1 : -1;
            }
            throw new Exception("Not yet implemented");
        }
    }
}
