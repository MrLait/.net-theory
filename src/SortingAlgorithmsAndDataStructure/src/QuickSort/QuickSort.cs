using Sorts.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Sorts
{
    public class QuickSort
    {
        public int[] GetSortOne(int[] array)
        {
            return GetSortOne(array, 0, array.Length - 1);
        }

        private int[] GetSortOne(int[] array, int start, int end)
        {
            if (start >= end)
                return array;

            int pivot = GetPivot(array, start, end);
            array = GetSortOne(array, start, pivot - 1);
            array = GetSortOne(array, pivot + 1, end);
            return array;
        }

        private int GetPivot(int[] array, int start, int end)
        {
            int pivot = start;

            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end])
                {
                    Swap.GetSwap(ref array[i], ref array[pivot]);
                    pivot++;
                }
            }

            Swap.GetSwap(ref array[end], ref array[pivot]);
            return pivot;
        }

        public int[] GetSortTwo(int[] array)
        {
            var less = new List<int>();
            var pivotList = new List<int>();
            var more = new List<int>();

            if (array.Length <= 1)
                return array;
            else
            {
                int pivot = array[0];

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] < pivot)
                        less.Add(array[i]);
                    else if (array[i] > pivot)
                        more.Add(array[i]);
                    else
                        pivotList.Add(array[i]);
                }
                less = GetSortTwo(less.ToArray()).ToList();
                more = GetSortTwo(more.ToArray()).ToList();
                return less.Concat(pivotList.Concat(more)).ToArray();
            }
        }
    }
}
