using IteratorPattern.ExFour;
using System;

namespace IteratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Aggregate a = new ConcreteAggregate();

            //Iterator i = a.CreateIterator();

            //object item = i.First();
            //while (!i.IsDone())
            //{
            //    item = i.Next();
            //}
            //////////////////////////////
            //Library library = new Library();
            //Reader reader = new Reader();
            //reader.SeeBooks(library);

            //Console.Read();

            // Клиентский код может знать или не знать о Конкретном Итераторе
            // или классах Коллекций, в зависимости от уровня косвенности,
            // который вы хотите сохранить в своей программе.
            //var collection = new WordsCollection();
            //collection.AddItem("First");
            //collection.AddItem("Second");
            //collection.AddItem("Third");

            //Console.WriteLine("Straight traversal:");

            //foreach (var element in collection)
            //{
            //    Console.WriteLine(element);
            //}

            //Console.WriteLine("\nReverse traversal:");

            //collection.ReverseDirection();

            //foreach (var element in collection)
            //{
            //    Console.WriteLine(element);
            //}

            //////////////////////////////
            Library library = new Library();
            library.AddItem(new Book() { Name = "One" });
            library.AddItem(new Book() { Name = "Two" });
            library.AddItem(new Book() { Name = "Three" });

            foreach (Book item in library)
            {
                Console.WriteLine(item.Name);
            }

            foreach (Book item in library)
            {
                Console.WriteLine(item.Name);
            }

            //Reader reader = new Reader();
            //reader.SeeBooks(library);

            Console.Read();

        }
    }
}
