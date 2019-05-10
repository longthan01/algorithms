using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Search;
using Algorithms.Sort;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        void DoCountDistinctPairDiffByK()
        {
            int testCases = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < testCases; i++)
            {
                int arrayLength = int.Parse(Console.ReadLine());
                List<int> array = new List<int>();
                for (int j = 0; j < arrayLength; j++)
                {
                    array.Add(int.Parse(Console.ReadLine()));
                }

                int k = int.Parse(Console.ReadLine());
                int count = CountDistinctPairDiffByK(array, k);
                Console.WriteLine($"Output is {count}");
            }
        }
        private static int CountDistinctPairDiffByK(List<int> array, int k)
        {
            int count = 0;
            ISort sort = new MergeSort(array.ToArray());
            sort.Sort();
            array = sort.Array.ToList();
            ISearch<int> searcher = new BinarySearch<int>();
            for (int i = 0; i < array.Count; i++)
            {
                if (i - 1 >= 0 && array[i] == array[i - 1])
                {
                    continue;
                }

                int idx = searcher.Search(array[i] + k, array.ToArray());
                if (idx >= 0)
                {
                    count++;
                }
            }

            return count;
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }

            Console.ReadKey();
        }
    }
}
