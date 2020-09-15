using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ch_9_Parameters
{
    public class Program
    {
        private static Int32 s_n = 0;

        public static void Main()
        {
            OptionalAndNamedParameters();
            OutOne();
            RefOne();
            SomeMethodOne();
            SomeMethodTwo();
            ParamsOne();
            ParamsTWo();
            ParamsThree();
        }

        static void OptionalAndNamedParameters()
        {
            // 1. Аналогично: M(9, "A", default(DateTime), new Guid());
            MOne();
            // 2. Аналогично: M(8, "X", default(DateTime), new Guid());
            MOne(8, "X");
            // 3. Аналогично: M(5, "A", DateTime.Now, Guid.NewGuid());
            MOne(5, guid: Guid.NewGuid(), dt: DateTime.Now);
            // 4. Аналогично: M(0, "1", default(DateTime), new Guid());
            MOne(s_n++, s_n++.ToString());
            // 5. Аналогично: String t1 = "2"; Int32 t2 = 3;
            // M(t2, t1, default(DateTime), new Guid());
            MOne(s: (s_n++).ToString(), x: s_n++);

            // Вызов метода:
            Int32 a = 5;
            MTwo(x: ref a);
        }



        private static void MOne(Int32 x = 9, String s = "A", DateTime dt = default(DateTime), Guid guid = new Guid())
        {
            Console.WriteLine("x={0}, s={1}, dt={2}, guid={3}", x, s, dt, guid);
        }

        // Не делайте так:
        private static String MakePathOne(String filename = "Untitled")
        {
            return String.Format(@"C:\{0}.txt", filename);
        }
        // Используйте следующее решение:
        private static String MakePathTwo(String filename = null)
        {
            // Здесь применяется оператор, поддерживающий   
            // значение null (??); см. главу 19
            return String.Format(@"C:\{0}.txt", filename ?? "Untitled");
        }

        // Объявление метода:
        private static void MTwo(ref Int32 x) { }


        private static void ImplicitlyTypedLocalVariables()
        {
            var name = "Jeff";
            ShowVariableType(name); // Вывод: System.String

            // var n = null; // Ошибка
            var x = (String)null; // Допустимо, хотя и бесполезно

            ShowVariableType(x); // Вывод: System.String

            var numbers = new Int32[] { 1, 2, 3, 4 };
            ShowVariableType(numbers); // Вывод: System.Int32[]

            // Меньше символов при вводе сложных типов
            var collection = new Dictionary<String, Single>() { { "Grant", 4.0f } };

            // Вывод: System.Collections.Generic.Dictionary`2[System.String,System.Single]
            ShowVariableType(collection);
            
            foreach (var item in collection)
            {
             // Вывод: System.Collections.Generic.KeyValuePair`2 [System.String, System.Single]
                ShowVariableType(item);
            }
         }

        private static void ShowVariableType<T>(T t)
        {
            Console.WriteLine(typeof(T));
        }

        private static void GetVal(out Int32 v)
        {
            v = 10; // Этот метод должен инициализировать переменную V
        }

        static void OutOne()
        {
            Int32 x; // Инициализация x
            GetVal(out x); // Инициализация x не обязательна
            Console.WriteLine(x); // Выводится 10
        }

        private static void AddVal(ref Int32 v)
        {
            v += 10; // Этот метод может использовать инициализированный параметр v
        }

        static void RefOne()
        {
            Int32 x = 5; // Инициализация x
            AddVal(ref x); // x требуется инициализировать
            Console.WriteLine(x); // Выводится 15
        }
               
        public sealed class PointOne
        {
            static void Add(PointOne p) { /**/ }

            //в 'Add' нельзя определять перегруженных методов, отличных от ref и out):
            static void Add(ref PointOne p) { /**/ }
            //static void Add(out Point p) { /**/ }
        }


        public static void SomeMethodOne()
        {
            String s1 = "Jeffrey";
            String s2 = "Richter";

            // Тип передаваемых по ссылке переменных должен
            // соответствовать ожидаемому
            Object o1 = s1, o2 = s2;
            SwapOne(ref o1, ref o2);

            // Приведение объектов к строковому типу
            s1 = (String)o1;
            s2 = (String)o2;

            Console.WriteLine(s1); // Выводит "Richter"
            Console.WriteLine(s2); // Выводит "Jeffrey"
        }

        public static void SwapOne(ref Object a, ref Object b)
        {
            Object t = b;
            b = a;
            a = t;
        }

        public static void SomeMethodTwo()
        {
            String s1 = "Jeffrey";
            String s2 = "Richter";
            Swap(ref s1, ref s2);
            Console.WriteLine(s1); // Выводит "Richter"
            Console.WriteLine(s2); // Выводит "Jeffrey"
        }
        public static void Swap<T>(ref T a, ref T b)
        {
            T t = b;
            b = a;
            a = t;
        }

        static Int32 AddOne(params Int32[] values)
        {
            // ПРИМЕЧАНИЕ: при необходимости этот массив
            // можно передать другим методам
            Int32 sum = 0;
            if (values != null)
            {
                for (Int32 x = 0; x < values.Length; x++)
                    sum += values[x];
            }
            return sum;
        }

        public static void ParamsOne()
        {
            // Выводит "15"
            Console.WriteLine(AddOne(new Int32[] { 1, 2, 3, 4, 5 }));
        }

        public static void ParamsTWo()
        {
            // Выводит "15"
            Console.WriteLine(AddOne(1, 2, 3, 4, 5));
        }

        public static void ParamsThree()
        {
            DisplayTypes(new Object(), new Random(), "Jeff", 5);
        }

        private static void DisplayTypes(params Object[] objects)
        {
            if (objects != null)
            {
                foreach (Object o in objects)
                    Console.WriteLine(o.GetType());
            }
        }

        // Рекомендуется в этом методе использовать параметр слабого типа
        public void ManipulateItems<T>(IEnumerable<T> collection) { /**/ }
        // Не рекомендуется в этом методе использовать параметр сильного типа
        public void ManipulateItems<T>(List<T> collection) { /**/ }

        // Рекомендуется в этом методе использовать параметр мягкого типа
        public void ProcessBytes(Stream someStream) { /**/ }
        // Не рекомендуется в этом методе использовать параметр сильного типа
        public void ProcessBytes(FileStream fileStream) { /**/ }

        // Рекомендуется в этом методе использовать
        // сильный тип возвращаемого объекта
        public FileStream OpenFileTwo() { /**/ return default(FileStream); }
        // Не рекомендуется в этом методе использовать
        // слабый тип возвращаемого объекта
        public Stream OpenFileThree() { /**/ return default(Stream); }

        // Гибкий вариант: в этом методе используется
        // мягкий тип возвращаемого объекта
        public IList<String> GetStringCollectionOne() { /**/ return default(IList<string>); }
        // Негибкий вариант: в этом методе используется
        // сильный тип возвращаемого объекта
        public List<String> GetStringCollectionTwo() { /**/ return default(List<string>); }

    }

}