using System.Collections;
using System.Collections.Generic;

namespace IteratorPattern.ExFour
{
    abstract class BookAggregate : IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
        public virtual int Count { get; set; }
        public abstract Book GetItem(int index);
    }

    class Book
    {
        public string Name { get; set; }
    }

    class Library : BookAggregate
    {
        readonly List<Book> _books;
        public override int Count => _books.Count;

        public Library()
        {
            _books = new List<Book>();
        }

        public void AddItem(Book book)
        {
            _books.Add(book);
        }

        public override Book GetItem(int index)
        {
            return _books[index];
        }


        public override IEnumerator GetEnumerator()
        {
            return new LibraryNumerator(this);
        }
    }
}
