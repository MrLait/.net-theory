using System;
using System.Collections;

namespace Ch_13_Interfaces
{
    public static class Program
    {
        public static void Main()
        {
            PointCompareTo();
            Console.WriteLine();
            Console.WriteLine();
            FirstExample();
            Console.WriteLine();
            SecondExample();
            Console.WriteLine();
            ThirdExample();

            UsingInterfacingParameters();
            DisposeSimpleTypeOne();
            DisposeSimpleTypeTwo();

            GenericInterfaceSomeMethodOne();
            GenericInterfaceSomeMethodTwo();
            GenericInterfaceWithGenericParameters();

            ExplicitSeveralInterfaces();
        }

        static void PointCompareTo()
        {
            Point[] points = new Point[]
            {
                new Point(3, 3),
                new Point(1, 2),
            };
            // Вызов метода CompareTo интерфейса IComparable<T> объекта Point
            if (points[0].CompareTo(points[1]) > 0)
            {
                Point tempPoint = points[0];
                points[0] = points[1];
                points[1] = tempPoint;
            }
            Console.WriteLine("Points from closest to (0, 0) to farthest:");
            foreach (Point p in points)
                Console.WriteLine(p);
        }

        /************************* Первый пример *************************/
        static void FirstExample()
        {
            BaseOne b = new BaseOne();
            // Вызов реализации Dispose в типе b: "Dispose класса Base"
            b.Dispose();
            // Вызов реализации Dispose в типе объекта b: "Dispose класса Base"
            ((IDisposable)b).Dispose();
        }
        /************************* Второй пример ************************/
        static void SecondExample()
        {
            DerivedOne d = new DerivedOne();
            // Вызов реализации Dispose в типе d: "Dispose класса Derived"
            d.Dispose();
            // Вызов реализации Dispose в типе объекта d: "Dispose класса Derived"
            ((IDisposable)d).Dispose();
        }
        /************************* Третий пример *************************/
        static void ThirdExample()
        {
            BaseOne b = new DerivedOne();
            // Вызов реализации Dispose в типе b: "Dispose класса Base"
            b.Dispose();
            // Вызов реализации Dispose в типе объекта b: "Dispose класса Derived"
            ((IDisposable)b).Dispose();
        }

        static void UsingInterfacingParameters()
        {
            // Переменная s ссылается на объект String
            String s = "Jeffrey";
            // Используя переменную s, можно вызывать любой метод,
            // определенный в String, Object, IComparable, ICloneable,
            // IConvertible, IEnumerable и т. д.

            // Переменная cloneable ссылается на тот же объект String
            ICloneable cloneable = s;
            // Используя переменную cloneable, я могу вызвать любой метод,
            // объявленный только в интерфейсе ICloneable (или любой метод,
            // определенный в типе Object)

            // Переменная comparable ссылается на тот же объект String
            IComparable comparable = s;
            // Используя переменную comparable, я могу вызвать любой метод,
            // объявленный только в интерфейсе IComparable (или любой метод,
            // определенный в типе Object)

            // Переменная enumerable ссылается на тот же объект String
            // Во время выполнения можно приводить интерфейсную переменную
            // к интерфейсу другого типа, если тип объекта реализует оба интерфейса
            IEnumerable enumerable = (IEnumerable)comparable;
            // Используя переменную enumerable, я могу вызывать любой метод,
            // объявленный только в интерфейсе IEnumerable (или любой метод,
            // определенный только в типе Object)
        }

        public static void DisposeSimpleTypeOne()
        {
            SimpleTypeOne st = new SimpleTypeOne();
            // Вызов реализации открытого метода Dispose
            st.Dispose();
            // Вызов реализации метода Dispose интерфейса IDisposable
            IDisposable d = st;
            d.Dispose();
        }

        public static void DisposeSimpleTypeTwo()
        {
            SimpleTypeTwo st = new SimpleTypeTwo();
            // Вызов реализации открытого метода Dispose
            st.Dispose();
            // Вызов реализации метода Dispose интерфейса IDisposable
            IDisposable d = st;
            d.Dispose();

            D b = new D();
            //Вызовет базовую реализацию
            b.Dispose();

            //Вызовет интерфейсную реализацию
            IDisposable disposable = b;
            disposable.Dispose();
            //Или
            ((IDisposable)b).Dispose();
        }

        static void GenericInterfaceSomeMethodOne()
        {
            Int32 x = 1, y = 2;
            IComparable c = x;
            // CompareTo ожидает Object,
            // но вполне допустимо передать переменную y типа Int32
            c.CompareTo(y); // Выполняется упаковка
                            // CompareTo ожидает Object,
                            // при передаче "2" (тип String) компиляция выполняется нормально,
                            // но во время выполнения генерируется исключение ArgumentException
                            // c.CompareTo("2");
        }

        static void GenericInterfaceSomeMethodTwo()
        {
            Int32 x = 1, y = 2;
            IComparable<Int32> c = x;
            // CompareTo ожидает Object,
            // но вполне допустимо передать переменную y типа Int32
            c.CompareTo(y); // УПАКОВКА НЕ ВЫПОЛНЯЕТСЯ
                            // CompareTo ожидает Int32,
                            // передача "2" (тип String) приводит к ошибке компиляции
                            // с сообщением о невозможности привести тип String к Int32
                            // c.CompareTo("2"); // Ошибка cannot convert from 'string' to 'int'
        }

        static void GenericInterfaceWithGenericParameters()
        {
            Number n = new Number();
            // Значение n сравнивается со значением 5 типа Int32
            IComparable<Int32> cInt32 = n;
            Int32 result = cInt32.CompareTo(5);
            // Значение n сравнивается со значением "5" типа String
            IComparable<String> cString = n;
            result = cString.CompareTo("5");
        }

        static void ExplicitSeveralInterfaces()
        {
            /*Код, в котором используется объект MarioPizzeria, должен выполнять 
             * приведение типа к определенному интерфейсу для вызова нужного метода:*/
            MarioPizzeria mp = new MarioPizzeria();

            // Эта строка вызывает открытый метод GetMenu класса MarioPizzeria
            mp.GetMenu();

            // Эти строки вызывают метод IWindow.GetMenu
            IWindow window = mp;
            window.GetMenu();
            ((IWindow)mp).GetMenu();

            // Эти строки вызывают метод IRestaurant.GetMenu
            IRestaurant restaurant = mp;
            restaurant.GetMenu();
            ((IRestaurant)mp).GetMenu();
        }

        static void DangersExplicitImplementationInterfaceMethodsOne()
        {
            Int32 x = 5;
            /*
            // Попытка вызвать метод
            // интерфейса IConvertible
            Single s = x.ToSingle(null);  
            */

            Single s = ((IConvertible)x).ToSingle(null);
        }

    }

    // Этот класс является производным от Object и реализует IDisposable
    internal class BaseOne : IDisposable
    {
        // Этот метод неявно запечатан и его нельзя переопределить
        public void Dispose()
        {
            Console.WriteLine("Base's Dispose");
        }
    }
    // Этот класс наследует от Base и повторно реализует IDisposable
    internal class DerivedOne : BaseOne, IDisposable
    {
        // Этот метод не может переопределить Dispose из Base.
        // Ключевое слово 'new' указывает на то, что этот метод
        // повторно реализует метод Dispose интерфейса IDisposable
        public new void Dispose()
        {
            Console.WriteLine("Derived's Dispose");
            // ПРИМЕЧАНИЕ: следующая строка кода показывает,
            // как вызвать реализацию базового класса (если нужно)
            // base.Dispose();
        }
    }


    // Этот класс реализует обобщенный интерфейс IComparable<T> дважды
    public sealed class Number : IComparable<Int32>, IComparable<String>
    {
        private Int32 m_val = 5;
        // Этот метод реализует метод CompareTo интерфейса IComparable<Int32>
        public Int32 CompareTo(Int32 n)
        {
            return m_val.CompareTo(n);
        }
        // Этот метод реализует метод CompareTo интерфейса IComparable<String>
        public Int32 CompareTo(String s)
        {
            return m_val.CompareTo(Int32.Parse(s));
        }
    }


    public static class SomeTypeOne
    {
        private static void Test()
        {
            Int32 x = 5;
            Guid g = new Guid();
            // Компиляция этого вызова M выполняется без проблем,
            // поскольку Int32 реализует и IComparable, и IConvertible
            M(x);
            /*  Компиляция этого вызова M приводит к ошибке, поскольку
                Guid реализует IComparable, но не реализует IConvertible
            M(g);*/
        }
        // Параметр T типа M ограничивается только теми типами,
        // которые реализуют оба интерфейса: IComparable И IConvertible
        private static Int32 M<T>(T t) where T : IComparable, IConvertible
        { return 0; }


        private static Int32 M(IComparable t)
        {
            return 0;
        }
    }

    public interface IWindow
    {
        Object GetMenu();
    }

    public interface IRestaurant
    {
        Object GetMenu();
    }

    // Этот тип является производным от System.Object
    // и реализует интерфейсы IWindow и IRestaurant
    public sealed class MarioPizzeria : IWindow, IRestaurant
    {
        // Реализация метода GetMenu интерфейса IWindow
        Object IWindow.GetMenu()
        {
            Console.WriteLine("IWindow GetMenu");
            return null;
        }

        // Реализация метода GetMenu интерфейса IRestaurant
        Object IRestaurant.GetMenu()
        {
            Console.WriteLine("IRestaurant GetMenu");
            return null;
        }

        // Метод GetMenu (необязательный),
        // не имеющий отношения к интерфейсу
        public Object GetMenu()
        {
            Console.WriteLine("GetMenu");
            return null;
        }
    }

    internal class BaseTwo : IComparable
    {

        // Явная реализация интерфейсного метода (EIMI)
        Int32 IComparable.CompareTo(Object o)
        {
            Console.WriteLine("Base's CompareTo");
            return 0;
        }
    }

    internal sealed class DerivedTwo : BaseTwo, IComparable
    {
        // Открытый метод, также являющийся реализацией интерфейса
        public Int32 CompareTo(Object o)
        {
            Console.WriteLine("Derived's CompareTo");
            /* Эта попытка вызвать EIMI базового класса приводит к ошибке:
                "error CS0117: 'Base' does not contain a definition for 'CompareTo'"
            base.CompareTo(o);*/

            /*
            // Эта попытка вызова EIMI базового класса приводит
            // к бесконечной рекурсии
            IComparable c = this;
            c.CompareTo(o);
            */

            return 0;
        }
    }

    internal sealed class DerivedThree : BaseTwo /*, IComparable */
    {
        // Открытый метод, также являющийся реализацией интерфейса
        public Int32 CompareTo(Object o)
        {
            Console.WriteLine("Derived's CompareTo");

            IComparable c = this;
            c.CompareTo(o);
            return 0;
        }

    }

    internal class BaseFour : IComparable
    {
        // Явная реализация интерфейсного метода (EIMI)
        Int32 IComparable.CompareTo(Object o)
        {
            Console.WriteLine("Base's IComparable CompareTo");
            return CompareTo(o); // Теперь здесь вызывается виртуальный метод
        }

        // Виртуальный метод для производных классов
        // (этот метод может иметь любое имя)
        public virtual Int32 CompareTo(Object o)
        {
            Console.WriteLine("Base's virtual CompareTo");
            return 0;
        }
    }

    internal sealed class DerivedFour : BaseFour, IComparable
    {
        // Открытый метод, который также является реализацией интерфейса
        public override Int32 CompareTo(Object o)
        {
            Console.WriteLine("Derived's CompareTo");
            // Теперь можно вызвать виртуальный метод класса Base
            return base.CompareTo(o);
        }
    }


}