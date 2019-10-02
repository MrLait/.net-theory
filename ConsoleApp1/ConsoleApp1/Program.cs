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
        // Метод Dial удален (так как он наследуется от базового типа)

        // Здесь ключевое слово new удалено, а модификатор virtual заменен
        // на override, чтобы указать, что этот метод связан с методом
        // EstablishConnection из базового типа
        protected override void EstablishConnection()
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
        BetterPhone p2 = new BetterPhone();
        p2.Dial();
        Console.ReadKey();
    }
}