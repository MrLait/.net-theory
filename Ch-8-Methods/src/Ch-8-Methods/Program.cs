using System;
using System.Collections.Generic;
using System.Text;

namespace Ch_8_Methods
{
    public class Program
    {
        public static void Main()
        {
            MethodsOperatorConversion();
            ExctencionMethods();
        }

        public static void MethodsOperatorConversion()
        {
            Rational r1 = 5; // Неявное приведение Int32 к Rational
            Rational r2 = 2.5F; // Неявное приведение Single к Rational
            Int32 x = (Int32)r1; // Явное приведение Rational к Int32
            Single s = (Single)r2; // Явное приведение Rational к Single
        }

        public static void ExctencionMethods()
        {
            // Инициализирующая строка
            StringBuilder sb = new StringBuilder("Hello. My name is Jeff.");
            // Замена точки восклицательным знаком
            // и получение номера символа в первом предложении (5)
            Int32 index = StringBuilderExtensionsOne.IndexOf(sb.Replace('.', '!'), '!');


            Action<Object> action = o => Console.WriteLine(o.GetType());
            // Выдает NullReferenceException
            action.InvokeAndCatch<NullReferenceException>(null);
            // Поглощает NullReferenceException

            // Cоздание делегата Action, ссылающегося на статический метод расширения
            // ShowItems; первый аргумент инициализируется ссылкой на строку "Jeff"
            Action a = "Jeff".ShowItems;
             // Вызов делегата, вызывающего ShowItems и передающего
             // ссылку на строку "Jeff"
             a();
        }

    }

    public class SomeTypeImplicit { }
    //Это определение идентично определению:
    public class SomeTypeExplicit
    {
        public SomeTypeExplicit() : base() { }
    }

    internal sealed class SomeTypeOne
    {
        private Int32 m_x = 5;
    }

    internal sealed class SomeTypeTwo
    {
        private Int32 m_x = 5;
        private String m_s = "Hi there";
        private Double m_d = 3.14159;
        private Byte m_b;
        // Это конструкторы
        public SomeTypeTwo() { }
        public SomeTypeTwo(Int32 x) { }
        public SomeTypeTwo(String s) { m_d = 10; }
    }

    internal sealed class SomeTypeThree
    {
        // Здесь нет кода, явно инициализирующего поля
        private Int32 m_x;
        private String m_s;
        private Double m_d;
        private Byte m_b;

        // Код этого конструктора инициализирует поля значениями по умолчанию
        // Этот конструктор должен вызываться всеми остальными конструкторами
        public SomeTypeThree()
        {
            m_x = 5;
            m_s = "Hi there";
            m_d = 3.14159;
            m_b = 0xff;
        }

        // Этот конструктор инициализирует поля значениями по умолчанию,
        // а затем изменяет значение m_x
        public SomeTypeThree(Int32 x) : this()
        {
            m_x = x;
        }

        // Этот конструктор инициализирует поля значениями по умолчанию,
        // а затем изменяет значение m_s
        public SomeTypeThree(String s) : this()
        {
            m_s = s;
        }

        // Этот конструктор инициализирует поля значениями по умолчанию,
        // а затем изменяет значения m_x и m_s
        public SomeTypeThree(Int32 x, String s) : this()
        {
            m_x = x;
            m_s = s;
        }
    }

    internal struct PointOne
    {
        public Int32 m_x, m_y;
    }
    internal sealed class RectangleOne
    {
        public PointOne m_topLeft, m_bottomRight;
    }

    internal struct PointTwo
    {
        public Int32 m_x, m_y;
        public PointTwo(Int32 x, Int32 y)
        {
            m_x = x;
            m_y = y;
        }
    }
    internal sealed class RectangleTwo
    {
        public PointTwo m_topLeft, m_bottomRight;
        public RectangleTwo()
        {
            // В C# оператор new, использованный для создания экземпляра значимого
            // типа, вызывает конструктор для инициализации полей значимого типа
            m_topLeft = new PointTwo(1, 2);
            m_bottomRight = new PointTwo(100, 200);
        }
    }

    internal struct PointThree
    {
        public Int32 m_x, m_y;
        //error CS0568: Structs cannot contain explicit parameterless constructors
        //public PointThree()
        //{
        //    m_x = m_y = 5;
        //}
    }
    internal sealed class RectangleThree
    {
        public PointThree m_topLeft, m_bottomRight;
        public RectangleThree()
        {
        }
    }

    internal struct SomeValTypeOne
    {
        // В значимый тип нельзя подставлять инициализацию экземплярных полей
        //error CS0573: 'SomeValType.m_x': cannot have instance field initializers in structs
        //private Int32 m_x = 5;
    }

    internal struct SomeValTypeTwo
    {
        private Int32 m_x, m_y;
        /* C# допускает наличие у значимых типов конструкторов с параметрами
        //error CS0171: Field 'SomeValType.m_y' must be fully assigned before control leaves
        the constructor
        public SomeValTypeTwo(Int32 x)
        {
            m_x = x;
    // Обратите внимание: поле m_y здесь не инициализируется
        }
        */
    }

    internal struct SomeValTypeThree
    {
        private Int32 m_x, m_y;

        // C# позволяет значимым типам иметь конструкторы с параметрами
        public SomeValTypeThree(Int32 x)
        {
            // Выглядит необычно, но компилируется прекрасно,
            // и все поля инициализируются значениями 0 или null
            this = new SomeValTypeThree();
            m_x = x; // Присваивает m_x значение x
                     // Обратите внимание, что поле m_y было инициализировано нулем
        }
    }


    internal sealed class SomeRefTypeOne
    {
        static SomeRefTypeOne()
        {
            // Исполняется при первом обращении к ссылочному типу SomeRefType
        }
    }

    internal struct SomeValTypeFour
    {
        // C# на самом деле допускает определять для значимых типов
        // конструкторы без параметров
        static SomeValTypeFour()
        {
            // Исполняется при первом обращении к значимому типу SomeValType
        }
    }

    /*Внимание
    Хотя конструктор типа можно определить в значимом типе, этого никогда не следует
    делать, так как иногда CLR не вызывает статический конструктор значимого типа.
    Например:*/
    internal struct SomeValTypeFive
    {
        static SomeValTypeFive()
        {
            Console.WriteLine("This never gets displayed");
        }
        public Int32 m_x;
    }

    internal sealed class SomeTypeFour
    {
        private static Int32 s_x = 5;
    }

    internal sealed class SomeTypeFive
    {
        private static Int32 s_x;
        static SomeTypeFive() { s_x = 5; }
    }

    internal sealed class SomeTypeSix
    {
        private static Int32 s_x = 5;
        static SomeTypeSix() { s_x = 10; }
    }

    public sealed class Complex
    {
        public static Complex operator +(Complex c1, Complex c2) { return (c1 + c2); }
        public static Complex Add(Complex c1, Complex c2) { return (c1 + c2); }
    }

    public sealed class Rational
    {
        // Создает Rational из Int32
        public Rational(Int32 num) { /* ... */ }

        // Создает Rational из Single
        public Rational(Single num) { /* ... */ }

        // Преобразует Rational в Int32
        public Int32 ToInt32() { /* ... */ return 0; }

        // Преобразует Rational в Single
        public Single ToSingle() { /* ... */ return 0; }

        // Неявно создает Rational из Int32 и возвращает полученный объект
        public static implicit operator Rational(Int32 num)
        {
            return new Rational(num);
        }
        // Неявно создает Rational из Single и возвращает полученный объект
        public static implicit operator Rational(Single num)
        {
            return new Rational(num);
        }
        // Явно возвращает объект типа Int32, полученный из Rational
        public static explicit operator Int32(Rational r)
        {
            return r.ToInt32();
        }
        // Явно возвращает объект типа Single, полученный из Rational
        public static explicit operator Single(Rational r)
        {
            return r.ToSingle();
        }
    }

    public static class StringBuilderExtensionsOne
    {
        public static Int32 IndexOf(StringBuilder sb, Char value)
        {
            for (Int32 index = 0; index < sb.Length; index++)
                if (sb[index] == value) return index;
            return -1;
        }
    }

    public static class StringBuilderExtensionsTwo
    {
        public static Int32 IndexOf(this StringBuilder sb, Char value)
        {
            for (Int32 index = 0; index < sb.Length; index++)
                if (sb[index] == value) return index;
            return -1;
        }

        /* вы можете определять методы расширения для
        интерфейсных типов, как в следующем программном коде:*/
        public static void ShowItems<T>(this IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Console.WriteLine(item);
        }

        /*Методы расширения также можно определять и для типов-делегатов, например:*/
        public static void InvokeAndCatch<TException>(this Action<Object> d, Object o) where TException : Exception
        {
            try { d(o); }
            catch (TException) { }
        }

    }



}