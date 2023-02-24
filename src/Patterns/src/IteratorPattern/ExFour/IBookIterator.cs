using System.Collections;

namespace IteratorPattern.ExFour
{
    abstract class IBookIterator : IEnumerator
    {
        object IEnumerator.Current => Current();

        public abstract object Current();

        public abstract bool MoveNext();

        public abstract void Reset();
    }

    class LibraryNumerator : IBookIterator
    {
        BookAggregate _bookAggregate;
        private int index = -1;

        public LibraryNumerator(BookAggregate bookAggregate)
        {
            _bookAggregate = bookAggregate;
        }

        public override object Current()
        {
            return _bookAggregate.GetItem(index);
        }

        public override bool MoveNext()
        {
            index++;
            if (index < _bookAggregate.Count)
            {
                return true;
            }
            return false;
        }

        public override void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}
