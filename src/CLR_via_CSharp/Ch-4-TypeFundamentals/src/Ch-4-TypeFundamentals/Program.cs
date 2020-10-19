using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_4_TypeFundamentals
{
    /*В CLR каждый объект прямо или косвенно является производным от System.
Object.Это значит, что следующие определения типов идентичны: */

    // Тип, неявно производный от Object
    internal class Employee {}
    // Тип, явно производный от Object
    class EmployeeTwo : System.Object { }

    internal class Manager : Employee {}

    class Program
    {
        static void Main(string[] args)
        {
            //CLR требует, чтобы все объекты создавались оператором new. 
            Employee emploeeOne = new Employee();

            // Приведение типа не требуется, т. к. new возвращает объект Employee,
            // а Object — это базовый тип для Employee.
            Object o = new Employee();

            // Приведение типа обязательно, т. к. Employee — производный от Object
            Employee e = (Employee)o;
            Employee emploee = (Employee)new object();
        }

        static void MainTwo()
        {
            // Создаем объект Manager и передаем его в PromoteEmployee
            // Manager ЯВЛЯЕТСЯ производным от Employee,
            // поэтому PromoteEmployee работает
            Manager m = new Manager();
            PromoteEmployee(m);

            // Создаем объект DateTime и передаем его в PromoteEmployee
            // DateTime НЕ ЯВЛЯЕТСЯ производным от Employee,
            // поэтому PromoteEmployee выбрасывает
            // исключение System.InvalidCastException
            DateTime newYears = new DateTime(2013, 1, 1);
            PromoteEmployee(newYears);
        }

        static void MainThree()
        {
            object o = new object();
            // b1 равно true
            bool bOne = o is object;
            // b2 равно false
            bool bTwo = o is Employee;

            object oNull = null;
            /*Для null - ссылок оператор is всегда возвращает false, 
             *так как объекта, тип которого нужно проверить, не существует.*/
            bool bThree = oNull is object;

            if (o is Employee)
            {
                Employee e = (Employee)o;
                // Используем e внутри инструкции if
            }
        }

        static void MainFour() 
        {
            object o = new object();
            Employee e = o as Employee;
            if (e != null)
            {
                // Используем e внутри инструкции if
            }
            // Преобразование невыполнимо: исключение не возникло, но e равно null
            e.ToString(); // Обращение к e вызывает исключение NullReferenceException

        }
                
        private static void PromoteEmployee(object o)
        {
            // В этом месте компилятор не знает точно, на какой тип объекта
            // ссылается o, поэтому скомпилирует этот код
            // Однако в период выполнения CLR знает, на какой тип
            // ссылается объект o (приведение типа выполняется каждый раз),
            // и проверяет, соответствует ли тип объекта типу Employee
            // или другому типу, производному от Employee
            Employee e = (Employee)o;
        }

        ///////////////////////////////////////////////////////////////

        internal class B {/* Базовый класс**/}
        internal class D : B { /* Производный класс*/}

        static void MainFive()
        {
            Object o1 = new Object(); // ok
            Object o2 = new B(); // ok
            Object o3 = new D(); // ok
            Object o4 = o3; // ok
            B b1 = new B(); // ok
            B b2 = new D(); // ok
            D d1 = new D(); //ok
            B b3 = new Object(); //CTE invalid castExceprion
            D d2 = new Object();  //CTE invalid castExceprion
            B b4 = d1; // ok
            D d3 = b2; // CTE invalid castExceprion
            D d4 = (D)d1; // ok 
            D d5 = (D)b2; // ok
            D d6 = (D)b1; // RTE 
            B b5 = (B)o1; // RTE
            B b6 = (D)b2; // ok
        }

    }
}
