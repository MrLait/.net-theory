using NUnit.Framework;
using DataStructures.LinkedList;

namespace DataStructures.LinkedList.Tests
{
    [TestFixture()]
    public class LinkedListTests
    {
        [Test()]
        public void AddTest()
        {
            LinkedList<int> vs = new LinkedList<int>();
            vs.Add(1);
            vs.Add(2);

            vs.Add(3);
            vs.Add(4);
        }
    }
}