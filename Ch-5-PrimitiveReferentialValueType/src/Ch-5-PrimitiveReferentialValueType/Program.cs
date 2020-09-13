using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace Ch_5_PrimitiveReferentialValueType
{
    class Program
    {
        static void Main(string[] args)
        {
            //Primitive types;
            ConvenientInconvenientSyntax();
            ExplicitImplicit();
            Literals();
            //CheckedUncheckedOpperatorsForPrimitiveTypes();

            //Referance and Value types;
            ValueTypeDemo();
            BoxingUnboxingValueTypes();

            //Struct 
            PointTwoMain();
            ChangingFieldsInBoxingValueTypeWithoutInterface();
            ChangingFieldsInBoxingValueTypeWithInterface();

            //Dinamic
            DynamicDemo();

            //Excel 
            ExcelAutomation();
        }

        static void ConvenientInconvenientSyntax()
        {
            int aOne = 0; // Самый удобный синтаксис
            System.Int32 aTwo = 0; // Удобный синтаксис
            int aThree = new int(); // Неудобный синтаксис
            System.Int32 aFour = new System.Int32(); // Самый неудобный синтаксис
        }

        static void ExplicitImplicit()
        {
            Int32 i = 5; //неяввное привидение int32 k int32;
            Int64 l = i; //неявное привидение int32 k int64;
            Single s = i; // Неявное приведение Int32 к Single

            Byte b = (Byte)i; // Явное приведение Int32 к Byte
            Int16 v = (Int16)s; // Явное приведение Single к Int16
        }

        static void Literals()
        {
            Console.WriteLine(123.ToString() + 456.ToString()); // "123456"

            Boolean found = false; // В готовом коде found присваивается 0
            Int32 x = 100 + 20 + 3; // В готовом коде x присваивается 123
            String s = "a " + "bc"; // В готовом коде s присваивается "a bc"

            Int32 xTwo = 100; // Оператор присваивания
            Int32 y = xTwo + 23; // Операторы суммирования и присваивания
            Boolean lessThanFifty = (y < 50); // Операторы "меньше чем" и присваивания
        }

        static void CheckedUncheckedOpperatorsForPrimitiveTypes()
        {
            Byte bOne = 100;
            bOne = (Byte)(bOne + 200); // После этого b равно 44 (2C в шестнадцатеричной записи)

            UInt32 invalid = unchecked((UInt32)UInt32.MinValue - 1); // OK

            Byte b = 100;
            b = checked((Byte)(b + 200)); // OverflowException

            b = (Byte)checked(b + 200); // b содержит 44; нет OverflowException

            checked
            { // Начало проверяемого блока
                Byte bTwo = 100;
                bTwo = (Byte)(bTwo + 200); // Это выражение проверяется на переполнение
            } // Конец проверяемого блока
        }

        // Ссылочный тип (поскольку 'class')
        class SomeRef { public Int32 x; }
        // Значимый тип (поскольку 'struct')
        struct SomeVal { public Int32 x; }

        static void ValueTypeDemo()
        {
            SomeRef r1 = new SomeRef(); // Размещается в куче
            SomeVal v1 = new SomeVal(); // Размещается в стеке
            r1.x = 5; // Разыменовывание указателя
            v1.x = 5; // Изменение в стеке
            Console.WriteLine(r1.x); // Отображается "5"
            Console.WriteLine(v1.x); // Также отображается "5"
                                     // В левой части рис. 5.2 показан результат
                                     // выполнения предыдущих строк
            SomeRef r2 = r1; // Копируется только ссылка (указатель)
            SomeVal v2 = v1; // Помещаем в стек и копируем члены
            r1.x = 8; // Изменяются r1.x и r2.x
            v1.x = 9; // Изменяется v1.x, но не v2.x
            Console.WriteLine(r1.x); // Отображается "8"
            Console.WriteLine(r2.x); // Отображается "8"
            Console.WriteLine(v1.x); // Отображается "9"
            Console.WriteLine(v2.x); // Отображается "5"
                                     // В правой части рис. 5.2 показан результат
                                     // выполнения ВСЕХ предыдущих строк
        }

        // Объявляем значимый тип
        struct Point
        {
            public Int32 x, y;
        }

        static void BoxingUnboxingValueTypes()
        {
            ArrayList a = new ArrayList();
            Point p; // Выделяется память для Point (не в куче)

            //Boxing
            for (Int32 i = 0; i < 10; i++)
            {
                p.x = p.y = i; // Инициализация членов в нашем значимом типе
                a.Add(p); // Упаковка значимого типа и добавление
                          // ссылки в ArrayList
            }

            //Unboxing
            Point pTwo = (Point)a[0];

            //----------------------------
            Int32 x = 5;
            Object o = x;
            // Int16 y = (Int16)o; //InvalidCastException

            // Вот как выглядит правильный вариант:
            Int16 yTwo = (Int16)(Int32)o; // Распаковка, а затем приведение типа

            //----------------------------
            Point pThree;
            pThree.x = pThree.y = 1;
            Object oThree = pThree; // Упаковка p; o указывает на упакованный объект
            pThree = (Point)oThree; // Распаковка o и копирование полей из экземпляра в стек

            //----------------------------
            Point pFour;
            pFour.x = pFour.y = 1;
            Object oFour = pFour; // Упаковка p; o указывает на упакованный экземпляр

            // Изменение поля x структуры Point (присвоение числа 2).
            pFour = (Point)oFour;   // Распаковка o и копирование полей из экземпляра
                                    // в переменную в стеке
            pFour.x = 2; // Изменение состояния переменной в стеке
            oFour = pFour; // Упаковка p; o ссылается на новый упакованный экземпляр

            //----------------------------
            Int32 vFive = 5; // Создание неупакованной переменной значимого типа o
            Object oFive = vFive; // указывает на упакованное Int32, содержащее 5
            vFive = 123; // Изменяем неупакованное значение на 123
            Console.WriteLine(vFive + ", " + (Int32)oFive); // Отображается "123, 5"

            //vFive не будет упакован
            Console.WriteLine(vFive.ToString() + ", " + (Int32)oFive); // Отображается "123, 5"

            //----------------------------
            Int32 vSix = 5; // Создаем неупакованную переменную значимого типа
            Object oSix = vSix; // o указывает на упакованную версию v
            vSix = 123; // Изменяет неупакованный значимый тип на 123
            Console.WriteLine(vSix); // Отображает "123"
            vSix = (Int32)oSix; // Распаковывает и копирует o в v
            Console.WriteLine(vSix); // Отображает "5"
        }

        public static void INEFFICIENT()
        {
            Int32 v = 5; // Создаем переменную упакованного значимого типа
#if INEFFICIENT
             // При компиляции следующей строки v упакуется
             // три раза, расходуя и время, и память
             Console.WriteLine("{0}, {1}, {2}", v, v, v);
#else
            // Следующие строки дают тот же результат,
            // но выполняются намного быстрее и расходуют меньше памяти
            Object o = v; // Упакуем вручную v (только единожды)
                          // При компиляции следующей строки код упаковки не создается
            Console.WriteLine("{0}, {1}, {2}", o, o, o);
#endif
        }

        internal struct PointTwo : IComparable
        {
            private Int32 m_x, m_y;
            // Конструктор, просто инициализирующий поля
            public PointTwo(Int32 x, Int32 y)
            {
                m_x = x;
                m_y = y;
            }

            // Переопределяем метод ToString, унаследованный от System.ValueType
            public override String ToString()
            {
                // Возвращаем Point как строку (вызов ToString предотвращает упаковку)
                return String.Format("({0}, {1})", m_x.ToString(), m_y.ToString());

            }

            // Безопасная в отношении типов реализация метода CompareTo
            public Int32 CompareTo(PointTwo other)
            {
                // Используем теорему Пифагора для определения точки,
                // наиболее удаленной от начала координат (0, 0)
                return Math.Sign(Math.Sqrt(m_x * m_x + m_y * m_y)
                - Math.Sqrt(other.m_x * other.m_x + other.m_y * other.m_y));
            }

            // Реализация метода CompareTo интерфейса IComparable
            public Int32 CompareTo(Object o)
            {
                if (GetType() != o.GetType())
                {
                    throw new ArgumentException("o is not a Point");
                }
                // Вызов безопасного в отношении типов метода CompareTo
                return CompareTo((PointTwo)o);
            }
        }

        static void PointTwoMain()
        {
            // Создаем в стеке два экземпляра Point
            PointTwo p1 = new PointTwo(10, 10);
            PointTwo p2 = new PointTwo(20, 20);
            // p1 НЕ пакуется для вызова ToString (виртуальный метод)
            Console.WriteLine(p1.ToString()); // "(10, 10)"

            // p1 ПАКУЕТСЯ для вызова GetType (невиртуальный метод)
            Console.WriteLine(p1.GetType()); // "Point"

            // p1 НЕ пакуется для вызова CompareTo
            // p2 НЕ пакуется, потому что вызван CompareTo(Point)
            Console.WriteLine(p1.CompareTo(p2)); // "-1"

            // p1 пакуется, а ссылка размещается в c
            IComparable c = p1;
            Console.WriteLine(c.GetType()); // "Point"

            // p1 НЕ пакуется для вызова CompareTo
            // Поскольку в CompareTo не передается переменная Point,
            // вызывается CompareTo(Object), которому нужна ссылка
            // на упакованный Point
            // c НЕ пакуется, потому что уже ссылается на упакованный Point
            Console.WriteLine(p1.CompareTo(c)); // "0"

            // c НЕ пакуется, потому что уже ссылается на упакованный Point
            // p2 ПАКУЕТСЯ, потому что вызывается CompareTo(Object)
            Console.WriteLine(c.CompareTo(p2));// "-1"

            // c пакуется, а поля копируются в p2
            p2 = (PointTwo)c;
            // Убеждаемся, что поля скопированы в p2
            Console.WriteLine(p2.ToString());// "(10, 10)"
        }

        // Point - значимый тип.
        internal struct PointThree
        {
            private Int32 m_x, m_y;
            public PointThree(Int32 x, Int32 y)
            {
                m_x = x;
                m_y = y;
            }
            public void Change(Int32 x, Int32 y)
            {
                m_x = x; m_y = y;
            }
            public override String ToString()
            {
                return String.Format("({0}, {1})", m_x.ToString(), m_y.ToString());
            }
        }

        public static void ChangingFieldsInBoxingValueTypeWithoutInterface()
        {
            PointThree p = new PointThree(1, 1);
            Console.WriteLine(p);
            p.Change(2, 2);
            Console.WriteLine(p);
            Object o = p;
            Console.WriteLine(o);
            ((PointThree)o).Change(3, 3);
            Console.WriteLine(o);
        }

        // Интерфейс, определяющий метод Change
        internal interface IChangeBoxedPoint
        {
            void Change(Int32 x, Int32 y);
        }
        // Point - значимый тип
        internal struct PointWithInterface : IChangeBoxedPoint
        {
            private Int32 m_x, m_y;
            public PointWithInterface(Int32 x, Int32 y)
            {
                m_x = x;
                m_y = y;
            }
            public void Change(Int32 x, Int32 y)
            {
                m_x = x; m_y = y;
            }
            public override String ToString()
            {
                return String.Format("({0}, {1})", m_x.ToString(), m_y.ToString());

            }
        }

        static void ChangingFieldsInBoxingValueTypeWithInterface()
        {
            PointWithInterface p = new PointWithInterface(1, 1);
            Console.WriteLine(p);
            p.Change(2, 2);
            Console.WriteLine(p);
            Object o = p;
            Console.WriteLine(o);
            ((PointWithInterface)o).Change(3, 3);
            Console.WriteLine(o);
            ((PointWithInterface)o).Change(3, 3);
            Console.WriteLine(o);
            // p упаковывается, упакованный объект изменяется и освобождается
            ((IChangeBoxedPoint)p).Change(4, 4);
            Console.WriteLine(p);
            // Упакованный объект изменяется и выводится
            ((IChangeBoxedPoint)o).Change(5, 5);
            Console.WriteLine(o);
            // Упакованный объект изменяется и выводится
            ((IChangeBoxedPoint)o).Change(15, 15);
            Console.WriteLine(o);
        }

        public virtual Boolean EqualsStandart(Object obj)
        {
            // Если обе ссылки указывают на один и тот же объект,
            // значит, эти объекты равны
            if (this == obj) return true;
            // Предполагаем, что объекты не равны
            return false;
        }

        /*Учитывая это, компания Microsoft должна была бы реализовать метод Equals
        типа Object примерно так: */
        public virtual Boolean Equals(Object obj)
        {
            // Сравниваемый объект не может быть равным null
            if (obj == null)
                return false;
            // Объекты разных типов не могут быть равны
            if (this.GetType() != obj.GetType())
                return false;
            // Если типы объектов совпадают, возвращаем true при условии,
            // что все их поля попарно равны.
            // Так как в System.Object не определены поля,
            // следует считать, что поля равны
            return true;
        }

        public static Boolean ReferenceEquals(Object objA, Object objB)
        {
            return (objA == objB);
        }

        static void DynamicDemo()
        {
            dynamic value;
            for (Int32 demo = 0; demo < 2; demo++)
            {
                value = (demo == 0) ? (dynamic)5 : (dynamic)"A";
                value = value + value;
                M(value);
            }
        }

        static void M(Int32 n) => Console.WriteLine("M(Int32): " + n); 
        static void M(String s) => Console.WriteLine("M(String): " + s); 

        static void DynamicDemoBoxingUnboxing()
        {
            Object o1 = 123; // OK: Неявное приведение Int32 к Object (упаковка)
            //Int32 n1 = o1; // Ошибка: Нет неявного приведения Object к Int32
            Int32 n2 = (Int32)o1; // OK: Явное приведение Object к Int32 (распаковка)
            dynamic d1 = 123; // OK: Неявное приведение Int32 к dynamic (упаковка)
            Int32 n3 = d1; // OK: Неявное приведение dynamic к Int32 (распаковка)

            dynamic d = 123;
            var result = M(d); // 'var result' - то же, что 'dynamic result'

            dynamic dTwo = 123;
            var x = (Int32)dTwo; // Конвертация: 'var x' одинаково с 'Int32 x'
            var dt = new DateTime(dTwo); // Создание: 'var dt' одинаково с 'DateTime dt'

        }

        private static void ExcelAutomation()
        {
            var excel = new Application();
            excel.Visible = true;
            excel.Workbooks.Add(Type.Missing);
            ((Range)excel.Cells[1, 1]).Value = "Text in cell A1";  // Put a string in cell A1
            excel.Cells[1, 1].Value = "Text in cell A1";  // Put a string in cell A1
        }

        private static void Contains()
        {
            Object target = "Jeffrey Richter";
            Object arg = "ff";

            // Находим метод, который подходит по типам аргументов
            Type[] argTypes = new Type[] { arg.GetType() };
            MethodInfo method = target.GetType().GetMethod("Contains", argTypes);

            // Вызываем метод с желаемым аргументом
            Object[] arguments = new Object[] { arg };
            Boolean result = Convert.ToBoolean(method.Invoke(target, arguments));
        }

        /*Если использовать тип C# dynamic, этот код можно значительно улучшить
с точки зрения синтаксиса.*/

        private static void ContainsDynemic()
        {
            dynamic target = "Jeffrey Richter";
            dynamic arg = "ff";
            Boolean result = target.Contains(arg);
        }

        //--------------------------------------------------------------

        internal sealed class StaticMemberDynamicWrapper : DynamicObject
        {
            private readonly TypeInfo m_type;

            public StaticMemberDynamicWrapper(Type type) => m_type = type.GetTypeInfo();

            public override IEnumerable<String> GetDynamicMemberNames() =>  m_type.DeclaredMembers.Select(mi => mi.Name);
            
            public override Boolean TryGetMember(GetMemberBinder binder, out object result)
            {
                result = null;
                var field = FindField(binder.Name);

                if (field != null) 
                { 
                    result = field.GetValue(null); 
                    return true; 
                }

                var prop = FindProperty(binder.Name, true);
                if (prop != null) 
                { 
                    result = prop.GetValue(null, null); 
                    return true; 
                }

                return false;
            }

            public override Boolean TrySetMember(SetMemberBinder binder, object value)
            {
                var field = FindField(binder.Name);
         
                if (field != null) 
                { 
                    field.SetValue(null, value); 
                    return true; 
                }

                var prop = FindProperty(binder.Name, false);
                
                if (prop != null) 
                { 
                    prop.SetValue(null, value, null); 
                    return true; 
                }

                return false;
            }

            public override Boolean TryInvokeMember(InvokeMemberBinder binder, Object[]args, out Object result)
            {
                MethodInfo method = FindMethod(binder.Name, args.Select(x => x.GetType()).ToArray());

                if (method == null) 
                { 
                    result = null; 
                    return false; 
                }

                result = method.Invoke(null, args);
                return true;
            }

            private MethodInfo FindMethod(String name, Type[] paramTypes)
            {
                return m_type.DeclaredMethods.FirstOrDefault(mi => mi.IsPublic 
                && mi.IsStatic
                && mi.Name == name
                && ParametersMatch(mi.GetParameters(), paramTypes));
            }

            private Boolean ParametersMatch(ParameterInfo[] parameters, Type[] paramTypes)
            {
                if (parameters.Length != paramTypes.Length) 
                    return false;

                for (Int32 i = 0; i < parameters.Length; i++)
                    if (parameters[i].ParameterType != paramTypes[i]) 
                        return false;

                return true;
            }
            private FieldInfo FindField(String name)
            {
                return m_type.DeclaredFields.FirstOrDefault(fi => fi.IsPublic && fi.IsStatic
                && fi.Name == name);
            }

            private PropertyInfo FindProperty(String name, Boolean get)
            {
                if (get)
                    return m_type.DeclaredProperties.FirstOrDefault
                        ( 
                            pi => pi.Name == name && pi.GetMethod != null 
                            && pi.GetMethod.IsPublic && pi.GetMethod.IsStatic
                        );

                return m_type.DeclaredProperties.FirstOrDefault(
                pi => pi.Name == name && pi.SetMethod != null &&
                pi.SetMethod.IsPublic && pi.SetMethod.IsStatic);
            }
        }

    }
}

