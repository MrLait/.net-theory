using CompanyA;
using CompanyB;
using System;

namespace CompanyA
{
    public class Phone
    {
        public void Dial()
        {
            Console.WriteLine("Phone.Dial");
            EstablishConnection();
            //Выполнить действия по набору номера
        }
        protected virtual void EstablishConnection()
        {
            Console.WriteLine("Phone.EstablishConnection");
            // Выполнить действия по установлению соединения
        }
    }
}
//А теперь представьте, что в компании CompanyB спроектировали другой тип,
//BetterPhone, использующий тип Phone в качестве базового:
namespace CompanyB
{
    public class BetterPhone : Phone
    {
        // Этот метод Dial никак не связан с одноименным методом класса Phone
        public new void Dial()

        {
            Console.WriteLine("BetterPhone.Dial");
            EstablishConnection();
            base.Dial();
        }
        // Ключевое слово 'new' указывает, что этот метод
        // не связан с методом EstablishConnection базового типа
        protected new virtual void EstablishConnection()
        {
            Console.WriteLine("BetterPhone.EstablishConnection");
            // Выполнить действия по набору телефонного номера
        }
    }
}

public sealed class Programm
{
    public static void Main()
    {
        Phone p1 = new Phone();
        p1.Dial();
        BetterPhone p2 = new BetterPhone();
        p2.Dial();
        Console.ReadKey();
    }
}

//Предупреждение CS0114://'"BetterPhone.EstablishConnection()" скрывает наследуемый член "Phone.EstablishConnection()". 
                        //Чтобы текущий член переопределял эту реализацию, добавьте ключевое слово override. 
                        //В противном случае добавьте ключевое слово new.
