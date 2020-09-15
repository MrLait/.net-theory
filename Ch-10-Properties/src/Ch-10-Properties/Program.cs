using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Ch_10_Properties
{
    public class Program
    {
        public static void Main()
        {
            GetEmploeeOne();
            GetEmployeeWithProp();
            AnonymousType();
            AnonymousTypeWithLINQ();
            TupleTypes();
            UsingIndexator();
        }

        static void GetEmploeeOne()
        {
            EmployeeWithoiutIncapsulate e = new EmployeeWithoiutIncapsulate();
            e.Name = "Jeffrey Richter"; // Задаем имя сотрудника
            e.Age = 48; // Задаем возраст сотрудника
            Console.WriteLine(e.Name); // Выводим на экран "Jeffrey Richter"
        }

        static void GetEmployeeWithProp()
        {
            EmployeeWithPropery e = new EmployeeWithPropery();
            e.Name = "Jeffrey Richter"; // "Задать" имя сотрудника
            String EmployeeName = e.Name; // "Получить" имя сотрудника
            e.Age = 41; // "Задать" возраст сотрудника
            e.Age = -5; // Вброс исключения
                        // ArgumentOutOfRangeException
            Int32 EmployeeAge = e.Age; // "Получить" возраст сотрудника
        }
        static void AnonymousType()
        {
            // Определение типа, создание сущности и инициализация свойств
            var o1 = new { Name = "Jeff", Year = 1964 };
            // Вывод свойств на консоль
            Console.WriteLine("Name={0}, Year={1}", o1.Name, o1.Year); // Выводит: Name=Jeff, Year=1964

            var o = new { /*property1 = expression1, ..., propertyN = expressionN */};

            String Name = "Grant";
            DateTime dt = DateTime.Now;
            // Анонимный тип с двумя свойствами
            // 1. Строковому свойству Name назначено значение Grant
            // 2. Свойству Year типа Int32 Year назначен год из dt
            var o2 = new { Name, dt.Year };

        }

        static void AnonymousTypeWithLINQ()
        {
            String myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var query =
             from pathname in Directory.GetFiles(myDocuments)
             let LastWriteTime = File.GetLastWriteTime(pathname)
             where LastWriteTime > (DateTime.Now - TimeSpan.FromDays(7))
             orderby LastWriteTime
             select new { Path = pathname, LastWriteTime };

            foreach (var file in query)
                Console.WriteLine("LastWriteTime={0}, Path={1}",
                file.LastWriteTime, file.Path);
        }

        // Возвращает минимум в Item1 и максимум в Item2
        private static Tuple<Int32, Int32> MinMax(Int32 a, Int32 b)
        {
            return new Tuple<Int32, Int32>(Math.Min(a, b), Math.Max(a, b));
        }

        // Пример вызова метода и использования Tuple
        private static void TupleTypes()
        {
            var minmax = MinMax(6, 2);
            Console.WriteLine("Min={0}, Max={1}", minmax.Item1, minmax.Item2); // Min=2, Max=6

            /*Чтобы создать тип Tuple с более, чем восьмью элементами, передайте другой
            объект Tuple в параметре Rest:*/
            var t = Tuple.Create(0, 1, 2, 3, 4, 5, 6, Tuple.Create(7, 8));
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}",
             t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6, t.Item7,
             t.Rest.Item1.Item1, t.Rest.Item1.Item2);
        }

        static void UsingIndexator()
        {
            // Выделить массив BitArray, который может хранить 14 бит
            BitArray ba = new BitArray(14);

            // Установить все четные биты вызовом метода доступа set
            for (Int32 x = 0; x < 14; x++)
            {
                ba[x] = (x % 2 == 0);
            }

            // Вывести состояние всех битов вызовом метода доступа get
            for (Int32 x = 0; x < 14; x++)
            {
                Console.WriteLine("Bit " + x + " is " + (ba[x] ? "On" : "Off"));
            }

        }

        public sealed class EmployeeWithoiutIncapsulate
        {
            public String Name; // Имя сотрудника
            public Int32 Age; // Возраст сотрудника
        }

        public sealed class EmployeeAccessor
        {
            private String m_Name; // Поле стало закрытым
            private Int32 m_Age; // Поле стало закрытым

            public String GetName()
            {
                return (m_Name);
            }

            public void SetName(String value)
            {
                m_Name = value;
            }

            public Int32 GetAge()
            {
                return (m_Age);
            }

            public void SetAge(Int32 value)
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", value.ToString(),
                    "The value must be greater than or equal to 0");
                m_Age = value;
            }
        }

        public sealed class EmployeeWithPropery
        {
            private String m_Name;
            private Int32 m_Age;

            public String Name
            {
                get { return (m_Name); }
                set { m_Name = value; } // Ключевое слово value
            }                           // идентифицирует новое значение

            public Int32 Age
            {
                get { return (m_Age); }
                set
                {
                    if (value < 0) // Ключевое слово value всегда
                                   // идентифицирует новое значение
                        throw new ArgumentOutOfRangeException("value", value.ToString(),
                        "The value must be greater than or equal to 0");
                    m_Age = value;
                }
            }
        }

        public sealed class BitArray
        {
            // Закрытый байтовый массив, хранящий биты
            private Byte[] m_byteArray;
            private Int32 m_numBits;

            // Конструктор, выделяющий память для байтового массива
            // и устанавливающий все биты в 0
            public BitArray(Int32 numBits)
            {
                // Начинаем с проверки аргументов
                if (numBits <= 0)
                    throw new ArgumentOutOfRangeException("numBits must be > 0");
                // Сохранить число битов
                m_numBits = numBits;
                // Выделить байты для массива битов
                m_byteArray = new Byte[(numBits + 7) / 8];
            }

            // Индексатор (свойство с параметрами)
            public Boolean this[Int32 bitPos]
            {
                // Метод доступа get индексатора
                get
                {
                    // Сначала нужно проверить аргументы
                    if ((bitPos < 0) || (bitPos >= m_numBits))
                        throw new ArgumentOutOfRangeException("bitPos");

                    // Вернуть состояние индексируемого бита
                    return (m_byteArray[bitPos / 8] & (1 << (bitPos % 8))) != 0;
                }

                // Метод доступа set индексатора
                set
                {
                    if ((bitPos < 0) || (bitPos >= m_numBits))
                        throw new ArgumentOutOfRangeException(
                        "bitPos", bitPos.ToString());

                    if (value)
                    {
                        // Установить индексируемый бит
                        m_byteArray[bitPos / 8] = (Byte)
                        (m_byteArray[bitPos / 8] | (1 << (bitPos % 8)));
                    }
                    else
                    {
                        // Сбросить индексируемый бит
                        m_byteArray[bitPos / 8] = (Byte)
                        (m_byteArray[bitPos / 8] & ~(1 << (bitPos % 8)));
                    }
                }
            }
        }

        public sealed class SomeType
        {
            // Определяем метод доступа get_Item
            public Int32 this[Boolean b]
            {
                get { return 0; }
            }
            // Определяем метод доступа get_Jeff
            public String this[Int16 b]
            {
                get { return null; }
            }
        }


    }
}