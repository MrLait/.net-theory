using Sorts.Utils;

namespace Sorts
{
    public class GnomeSort
    {
        public int[] GetSort(int[] array)
        {
            int index = 0;

            while (index < array.Length - 1)
            {
                if (array[index] > array[index + 1])
                {
                    Swap.GetSwap(ref array[index], ref array[index + 1]);

                    if (index > 0)
                        index--;
                }
                else
                    index++;
            }
            return array;
        }

        public int[] GetSortOptimize(int[] array)
        {
            int index = 0;
            int tempIndex = 0;
            
            while (index < array.Length - 1)
            {
                if (array[index] > array[index + 1])
                {
                    Swap.GetSwap(ref array[index], ref array[index + 1]);
                    
                    if (index > 0)
                        index--;
                }
                else
                    index = ++tempIndex;
            }
            return array;
        }
    }
}
