using NUnit.Framework;

namespace Sorts.Tests
{
    [TestFixture()]
    public class SortsTests
    {
        [Test()]
        public void QuickSortTest()
        {
            int[] array = new int[] { 6, 11, 1, 8, 2, 16, 18, 4, 10, 7, 17, 15, 12, 9, 14, 3, 13, 5 };
            int[] array2 = new int[] { 6, 11, 1, 8, 2, 16, 18, 4, 10, 7, 17, 15, 12, 9, 14, 3, 13, 5 };
            int[] array3 = new int[] { 6, 11, 1, 8, 2, 16, 18, 4, 10, 7, 17, 15, 12, 9, 14, 3, 13, 5 };
            int[] array4 = new int[] { 6, 11, 1, 8, 2, 16, 18, 4, 10, 7, 17, 15, 12, 9, 14, 3, 13, 5 };

            var test = new QuickSort().GetSortOne(array);
            var test2 = new QuickSort().GetSortTwo(array);
            var test3 = new GnomeSort().GetSort(array2);
            var test4 = new GnomeSort().GetSortOptimize(array3);
            var test5 = new InsertionSort().GetSort(array4);
        }
    }
}