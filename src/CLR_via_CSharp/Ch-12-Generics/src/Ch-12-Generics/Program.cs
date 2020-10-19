using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Ch_12_Generics
{
    public class Program
    {
        public static void Main()
        {
            SomeMethodOne();
            ValueTypePerfTest();
            ReferenceTypePerfTest();
            MethodsFromArray();
            InternalSealedDictionaryStringKey();
            SameDataLinkedList();
            DifferentDataLinkedList();
            DelegateImplicitParam();
            InterfaceImplicitParam();
            CallingSwap();
            CallingSwapUsingInference();
            CallDDisplay();
            MethodTakingAnyType(new Object());
            CallMin();
            CallingConvertIList();
        }

        private static void SomeMethodOne()
        {
            // Создание списка (List), работающего с объектами DateTime
            List<DateTime> dtList = new List<DateTime>();

            // Добавление объекта DateTime в список
            dtList.Add(DateTime.Now); // Без упаковки

            // Добавление еще одного объекта DateTime в список
            dtList.Add(DateTime.MinValue); // Без упаковки

            // Попытка добавить объект типа String в список
            //dtList.Add("1/1/2004"); // Ошибка компиляции

            // Извлечение объекта DateTime из списка
            DateTime dt = dtList[0]; // Приведение типов не требуется
        }

        private static void ValueTypePerfTest()
        {
            const Int32 count = 100000000;
            using (new OperationTimer("List<Int32>"))
            {
                List<Int32> l = new List<Int32>();
                for (Int32 n = 0; n < count; n++)
                {
                    l.Add(n); // Без упаковки
                    Int32 x = l[n]; // Без распаковки
                }
                l = null; // Для удаления в процессе уборки мусора
            }

            using (new OperationTimer("ArrayList of Int32"))
            {
                ArrayList a = new ArrayList();
                for (Int32 n = 0; n < count; n++)
                {
                    a.Add(n); // Упаковка
                    Int32 x = (Int32)a[n]; // Распаковка
                }
                a = null; // Для удаления в процессе уборки мусора
            }
        }

        private static void ReferenceTypePerfTest()
        {
            const Int32 count = 100000000;

            using (new OperationTimer("List<String>"))
            {
                List<String> l = new List<String>();
                for (Int32 n = 0; n < count; n++)
                {
                    l.Add("X"); // Копирование ссылки
                    String x = l[n]; // Копирование ссылки
                }
                l = null; // Для удаления в процессе уборки мусора
            }

            using (new OperationTimer("ArrayList of String"))
            {
                ArrayList a = new ArrayList();
                for (Int32 n = 0; n < count; n++)
                {
                    a.Add("X"); // Копирование ссылки
                    string x = (string)a[n]; // Проверка преобразования
                } // и копирование ссылки
                a = null; // Для удаления в процессе уборки мусора
            }
        }

        static void MethodsFromArray()
        {
            // Создание и инициализация массива байтов
            Byte[] byteArray = new Byte[] { 5, 1, 4, 2, 3 };

            // Вызов алгоритма сортировки Byte[]
            Array.Sort<Byte>(byteArray);

            // Вызов алгоритма двоичного поиска Byte[]
            Int32 i = Array.BinarySearch<Byte>(byteArray, 1);

            Console.WriteLine(i); // Выводит "0"
        }

        static void InternalSealedDictionaryStringKey()
        {
            Object o = null;

            // Dictionary<,> — открытый тип с двумя параметрами типа
            Type t = typeof(Dictionary<,>);

            // Попытка создания экземпляра этого типа (неудачная)
            o = CreateInstance(t);
            Console.WriteLine();

            // DictionaryStringKey<> — открытый тип с одним параметром типа
            t = typeof(DictionaryStringKey<>);
            // Попытка создания экземпляра этого типа (неудачная)
            o = CreateInstance(t);
            Console.WriteLine();

            // DictionaryStringKey<Guid> — это закрытый тип
            t = typeof(DictionaryStringKey<Guid>);
            // Попытка создания экземпляра этого типа (удачная)
            o = CreateInstance(t);
            // Проверка успешности попытки
            Console.WriteLine("Object type=" + o.GetType());
        }

        private static Object CreateInstance(Type t)
        {
            Object o = null;

            try
            {
                o = Activator.CreateInstance(t);
                Console.Write("Created instance of {0}", t.ToString());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            return o;
        }

        private static void SameDataLinkedList()
        {
            Node<Char> head = new Node<Char>('C');
            head = new Node<Char>('B', head);
            head = new Node<Char>('A', head);

            Console.WriteLine(head.ToString()); // Выводится "ABC"
        }

        private static void DifferentDataLinkedList()
        {
            Node head = new TypedNode<Char>('.');
            head = new TypedNode<DateTime>(DateTime.Now, head);
            head = new TypedNode<String>("Today is ", head);
            Console.WriteLine(head.ToString()); // Выводится  Today is "Время".
        }

        //Предположим, что существует следующий тип делегата:
        /*Здесь параметр-тип T помечен словом in, делающим его контравариантным,
        а параметр-тип TResult помечен словом out, делающим его ковариантным.*/
        public delegate TResult Func<in T, out TResult>(T arg);

        /*Ее можно привести к типу Func с другими параметрами-типами:*/
        static void DelegateImplicitParam()
        {
            //Пусть объявлена следующая переменная:
            Func<Object, ArgumentException> fn1 = null;

            Func<String, Exception> fn2 = fn1; // Явного приведения типа не требуется
            Exception e = fn2("");
        }

        static void InterfaceImplicitParam()
        {
            // Этот вызов передает IEnumerable<String> в Count
            Int32 c = Count(new[] { "Grant" });
        }

        // Этот метод допускает интерфейс IEnumerable любого ссылочного типа
        static int Count(IEnumerable<object> collection) { return 0; }

        private static void Swap<T>(ref T o1, ref T o2)
        {
            T temp = o1;
            o1 = o2;
            o2 = temp;
        }

        //Теперь вызывать Swap из кода можно следующим образом:
        private static void CallingSwap()
        {
            Int32 n1 = 1, n2 = 2;
            Console.WriteLine("n1={0}, n2={1}", n1, n2);
            Swap<Int32>(ref n1, ref n2);
            Console.WriteLine("n1={0}, n2={1}", n1, n2);

            String s1 = "Aidan", s2 = "Grant";
            Console.WriteLine("s1={0}, s2={1}", s1, s2);
            Swap<String>(ref s1, ref s2);
            Console.WriteLine("s1={0}, s2={1}", s1, s2);
        }

        private static void CallingSwapUsingInference()
        {
            Int32 n1 = 1, n2 = 2;
            Swap(ref n1, ref n2); // Вызывает Swap<Int32>
            
            String s1 = "Aidan";
            Object s2 = "Grant";
            //Swap(ref s1, ref s2); // Ошибка, невозможно вывести тип
        }

        private static void Display(String s)
        {
            Console.WriteLine(s);
        }

        private static void Display<T>(T o)
        {
            Display(o.ToString()); // Вызывает Display(String)
        }

        static void CallDDisplay() 
        { 
            //Метод Display можно вызвать несколькими способами:
            Display("Jeff"); // Вызывает Display(String)
            Display(123); // Вызывает Display<T>(T)
            Display<String>("Aidan"); // Вызывает Display<T>(T)
        }

        private static Boolean MethodTakingAnyType<T>(T o)
        {
            T temp = o;
            Console.WriteLine(o.ToString());
            Boolean b = temp.Equals(o);
            return b;
        }

        private static T MinOne<T>(T o1, T o2)
        {
            //error CS0117: 'T' does not contain a definition for 'CompareTo'
            //if (o1.CompareTo(o2) < 0) 
                return o1;
            return o2;
        }

        public static T Min<T>(T o1, T o2) where T : IComparable<T>
        {
            if (o1.CompareTo(o2) < 0) 
                return o1;
            return o2;
        }

        private static void CallMin()
        {
            Object o1 = "Jeff", o2 = "Richter";
            //Object oMin = Min<object>(o1, o2); // Ошибка CS0311
        }

        //Дополнительные ограниение
        private static List<TBase> ConvertIList<T, TBase>(IList<T> list) where T : TBase
        {
            List<TBase> baseList = new List<TBase>(list.Count);
            for (Int32 index = 0; index < list.Count; index++)
            {
                baseList.Add(list[index]);
            }
            return baseList;
        }

        /*В методе ConvertIList определены два параметра-типа, из которых параметр T
        ограничен параметром типа TBase.Это значит, что какой бы аргумент-тип ни был
        задан для T, он должен быть совместим с аргументом-типом, заданным для TBase.
        В следующем методе показаны допустимые и недопустимые вызовы ConvertIList:*/
        private static void CallingConvertIList()
        {
            // Создает и инициализирует тип List<String> (реализующий IList<String>)
            IList<String> ls = new List<String>();
            ls.Add("A String");
            
            // Преобразует IList<String> в IList<Object>
            IList<Object> lo = ConvertIList<String, Object>(ls);

            // Преобразует IList<String> в IList<IComparable>
            IList<IComparable> lc = ConvertIList<String, IComparable>(ls);

            // Преобразует IList<String> в IList<IComparable<String>>
            IList<IComparable<String>> lcs = ConvertIList<String, IComparable<String>>(ls);

            // Преобразует IList<String> в IList<String>
            IList<String> ls2 = ConvertIList<String, String>(ls);

            // Преобразует IList<String> в IList<Exception>
            //IList<Exception> le = ConvertIList<String, Exception>(ls); // Ошибка
        }

        private static void CastingAGenericTypeVariable1<T>(T obj) 
        {
            /*
            Int32 x = (Int32)obj; // Ошибка
            String s = (String)obj; // Ошибка
            */

            //НоCLR все равно может сгенерировать исключение InvalidCastException.
            Int32 x = (Int32)(Object)obj; // Ошибки нет
            String s = (String)(Object)obj; // Ошибки нет

            //Лучше использовать as
            String sTow = obj as String; // Ошибки нет
        }

        private static void SettingAGenericTypeVariableToNull<T>()
        {
            //T temp = null;// CS0403: нельзя привести null к параметру типа T
                            // because it could be a value type...
                            // (Ошибка CS0403: нельзя привести null к параметру типа Т,
                            // поскольку T может иметь значимый тип...)

            T temp = default(T); // Работает
        }

        private static void ComparingAGenericTypeVariableWithNull<T>(T obj)
        {
            if (obj == null)
            { /* Этот код никогда не исполняется для значимого типа */ }
        }

        private static void ComparingTwoGenericTypeVariables<T>(T o1, T o2)
        {
            //if (o1 == o2) { } // Ошибка
        }


        /*Это существенно ограничивает поддержку обобщений в среде CLR, и многие
разработчики (особенно из научных, финансовых и математических областей)
испытали глубокое разочарование. Многие пытались создать методы, призванные
обойти это ограничение, прибегая к отражению, примитивному типу dynamic, 
перегрузке операторов и т. п. Однако все эти решения сильно снижают производительность 
или ухудшают читабельность кода. Остается надеяться, что в следующих версиях CLR 
и компиляторов компания Microsoftустранит этот недостаток.*/
        private static T Sum<T>(T num) where T : struct
        {
            T sum = default(T);
            /*
            for (T n = default(T); n < num; n++)
                sum += n;
            s*/
            return sum;
        }
    }

    public interface IEnumerator<out T> : IEnumerator
    {
        Boolean MoveNext();
        T Current { get; }
    }


    internal sealed class GenericType<T>
    {
        private T m_value;

        public GenericType(T value) { m_value = value; }

        public TOutput Converter<TOutput>()
        {
            TOutput result = (TOutput)Convert.ChangeType(m_value, typeof(TOutput));
            return result;
        }
    }

    // Можно определить следующие типы:
    internal sealed class AType { }
    internal sealed class AType<T> { }
    /*
    internal sealed class AType<T1, T2> { }
    // Ошибка: конфликт с типом AType<T>, у которого нет ограничений.
    internal sealed class AType<T> where T : IComparable<T> { }
    // Ошибка: конфликт с типом AType<T1, T2>
    internal sealed class AType<T3, T4> { }
    */

    internal sealed class AnotherType
    {
        // Можно определить следующие методы:
        private static void M() { }
        private static void M<T>() { }
        /*
        private static void M<T1, T2>() { }
        // Ошибка: конфликт с типом M<T>, у которого нет ограничений
        private static void M<T>() where T : IComparable<T> { }
        // Ошибка: конфликт с типом M<T1, T2>.
        private static void M<T3, T4>() { }
        */
    }

    internal class Base
    {
        public virtual void M<T1, T2>() where T1 : struct where T2 : class {}
    }

    internal sealed class Derived : Base
    {
        public override void M<T3, T4>(){ }

        //public override void M<T3, T4>() where T3 : EventArgs /* Ошибка */ where T4 : class /* Ошибка */{ }
    }

    internal sealed class PrimaryConstraintOfStream<T> where T : Stream
    {
        public void M(T stream)
        {
            stream.Close();// OK
        }
    }

    internal sealed class PrimaryConstraintOfClass<T> where T : class
    {
        public void M()
        {
            T temp = null;// Допустимо, потому что тип T должен быть ссылочным
        }
    }

    internal sealed class PrimaryConstraintOfStruct<T> where T : struct
    {
        public static T Factory()
        {
            // Допускается, потому что у каждого значимого типа неявно
            // есть открытый конструктор без параметров
            return new T();
        }
    }

    internal sealed class ConstructorConstraint<T> where T : new()
    {
        public static T Factory()
        {
            // Допустимо, потому что у всех значимых типов неявно
            // есть открытый конструктор без параметров, и потому что
            // это ограничение требует, чтобы у всех указанных ссылочных типов
            // также был открытый конструктор без параметров
            return new T();
        }
    }


}
