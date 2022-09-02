using System;
using System.Linq;
using System.Collections.Generic;

namespace TestTask
{
    internal class SortUtility
    {
        private readonly List<Func<IEnumerable<int>, IEnumerable<int>>> _sortFuncs;

        public SortUtility()
        {
            _sortFuncs = new List<Func<IEnumerable<int>, IEnumerable<int>>>
            {
                 BubbleSort,
                 InsertionSort
            };
        }

        public IEnumerable<int> RandomSort(IEnumerable<int> data)
        {
            return _sortFuncs[new Random().Next(0, _sortFuncs.Count)](data);
        }

        public IEnumerable<int> BubbleSort(IEnumerable<int> data)
        {
            #if DEBUG
                Console.WriteLine("Bubble sort");
            #endif

            var dataArr = data.ToArray();
            var size = dataArr.Length;
            int tmp;

            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (dataArr[i] > dataArr[j])
                    {
                        tmp = dataArr[i];
                        dataArr[i] = dataArr[j];
                        dataArr[j] = tmp;
                    }
                }
            }
            return dataArr;
        }
        public IEnumerable<int> InsertionSort(IEnumerable<int> data)
        {
            #if DEBUG
                Console.WriteLine("Insertion sort");
            #endif

            var sourceArr = data.ToArray();
            var size = sourceArr.Length;
            int[] resultArr = new int[sourceArr.Length];

            for (int i = 0; i < size; i++)
            {
                int j = i;
                while (j > 0 && resultArr[j - 1] > sourceArr[i])
                {
                    resultArr[j] = resultArr[j - 1];
                    j--;
                }
                resultArr[j] = sourceArr[i];
            }
            return resultArr;
        }
    }
}