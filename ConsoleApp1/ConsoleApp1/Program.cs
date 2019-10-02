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
            //Выполнить действия по набору номера
        }
    }
}
//А теперь представьте, что в компании CompanyB спроектировали другой тип,
//BetterPhone, использующий тип Phone в качестве базового:
namespace CompanyB
{
    public class BetterPhone : Phone
    {
        //Предупреждение CS0108	'"BetterPhone.Dial()"
        //скрывает наследуемый член "Phone.Dial()".
        public void Dial() 

        {
            Console.WriteLine("BetterPhone.Dial");
            EstablishConnection();
            base.Dial();
        }
        protected virtual void EstablishConnection()
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

//Предупреждение CS0108: //'"BetterPhone.Dial()" скрывает наследуемый член "Phone.Dial()". 
                        //Если скрытие было намеренным, используйте ключевое слово new.	


//warning CS0108: //'CompanyB.BetterPhone.Dial()' hides inherited member
                 // 'CompanyA.Phone.Dial()'. Use the new keyword if hiding
                //   was intended.