using Sorts.Utils;

namespace Sorts
{
    public class InsertionSort
    {
        public int[] GetSort(int[] array)
        {
            int temp = 0;
            int insertIndex = 0;

            for (int i = 1; i < array.Length; i++)
            {
                temp = array[i];
                insertIndex = i;

                while (insertIndex > 0 && array[insertIndex - 1] > temp)
                {
                    Swap.GetSwap(ref array[insertIndex], ref array[insertIndex - 1]);
                    insertIndex--;
                }
                array[insertIndex] = temp;
            }
            return array;
        }

        public int[] GetSortV1(int[] array)
        {
            int temp = 0;
            int index = 1;

            if (array.Length <= 1)
                return array;

            while (index < array.Length)
            {
                temp = array[index];

                for (int i = index; i > 0; i--)
                {
                    if (array[i - 1] > temp)
                    {
                        Swap.GetSwap(ref array[i], ref array[i - 1]);
                    }
                    else if (array[i - 1] <= temp)
                    {
                        array[i] = temp;
                        break;
                    }
                }

                index++;
            }
            return array;
        }
    }
}