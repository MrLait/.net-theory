using NUnit.Framework;

namespace Sorts.Tests
{
    [TestFixture()]
    public class GnomeSortTests
    {
        [Test()]
        public void GetSortTest()
        {
            int[] array4 = new int[] { 6, 11, 1, 8, 2, 16, 18, 4, 10, 7, 17, 15, 12, 9, 14, 3, 13, 5 };

            var test = new QuickSort().GetSortOne(array4);
        }
    }
}