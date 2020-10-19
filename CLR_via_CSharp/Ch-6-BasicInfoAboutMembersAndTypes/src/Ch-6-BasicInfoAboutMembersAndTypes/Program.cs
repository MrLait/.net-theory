using System;

namespace Ch_6_BasicInfoAboutMembersAndTypes
{
    public class Program
    {
        public Int32 GetFive() { return 5; }

        public static void Main()
        {
           // Program p = null;
           // Int32 x = p.GetFive(); // В C# выдается NullReferenceException

            CompanyB.BetterPhone phone = new CompanyB.BetterPhone();
            phone.Dial();
            Console.WriteLine();

            CompanyB.With.New.One.BetterPhone betterPhoneOne = new CompanyB.With.New.One.BetterPhone();
            betterPhoneOne.Dial();
            Console.WriteLine();

            CompanyB.With.New.Two.BetterPhone betterPhoneTwo = new CompanyB.With.New.Two.BetterPhone();
            betterPhoneTwo.Dial();
            Console.WriteLine();

            CompanyB.Without.Dial.BetterPhone betterPhoneWithoutDial = new CompanyB.Without.Dial.BetterPhone();
            betterPhoneWithoutDial.Dial();
            Console.WriteLine();
        }

    }

    public class ClassWithAllTypes
    {
        //Const
        const int constInt = 10;
        const SomeType someType = null;

        //Field
        static int staticField = 10;
        int instanceField = 10;
        readonly int readonlyField = 10;

        //ctor
        public ClassWithAllTypes() { }
        static ClassWithAllTypes() { }

        //Property
        public int IntProperty { get; set; }
        public static int IntStaticProperty { get; set; }
        public virtual int IntVirtualProperty { get; set; }

        //Indexator
        public Int32 this[String s] { get { return 0; } set { } }
        public virtual Int32 this[int s] { get { return 0; } set { } }

        //event
        public event EventHandler SomeEvent;
        public static event EventHandler SomeStaticEvent;
        public virtual event EventHandler SomeVirtualEvent;

        //Methods
        public void InstanceVoidM(){}
        public int InstanceM(){ return 0; }
        public virtual int VirtualM(){ return 0; }
        public static int StaticM() { return 0; }

    }


    public sealed class SomeType                                // 1
    {
        // Вложенный класс
        private class SomeNestedType { }                        // 2

        // Константа, неизменяемое и статическое изменяемое поле
        private const Int32 c_SomeConstant = 1;                 // 3
        private readonly String m_SomeReadOnlyField = "2";      // 4
        private static Int32 s_SomeReadWriteField = 3;          // 5 

        // Конструктор типа
        static SomeType() { }                                   // 6

        // Конструкторы экземпляров
        public SomeType(Int32 x) { }                            // 7
        public SomeType() { }                                   // 8

        // Экземплярный и статический методы
        private String InstanceMethod() => null;                // 9
        public static void TwoMain() { }                           // 10

        // Необобщенное экземплярное свойство
        public Int32 SomeProp                                   // 11
        {
            get;                                                // 12
            set;                                                // 13
        }

        // Индексатор объекта
        public Int32 this[String s]                             // 14
        {
            get { return 0; }                                   // 15
            set { }                                             // 16
        }

        // Экземплярное событие
        public event EventHandler SomeEvent;                    // 17

        // Cобытие типа
        public static event EventHandler SomeStaticEvent;       // 18
    }

    // Открытый тип доступен из любой сборки
    public class ThisIsAPublicType { }
    // Внутренний тип доступен только из собственной сборки
    internal class ThisIsAnInternalType { }
    // Это внутренний тип, так как модификатор доступа не указан явно
    class ThisIsAlsoAnInternalType { }

    internal sealed class SomeInternalType { }
    internal sealed class AnotherInternalType { }

    internal sealed class Foo
    {
        private static Object SomeMethod()
        {
            // Эта сборка Wintellect получает доступ к внутреннему типу
            // другой сборки, как если бы он был открытым
            SomeInternalType sit = new SomeInternalType();
            return sit;
        }
    }

    public static class AStaticClass
    {
        static AStaticClass() { }

        public static void AStaticMethodQ() { }

        public static String AStaticProperty
        {
            get { return s_AStaticField; }
            set { s_AStaticField = value; }
        }

        private static String s_AStaticField;

        public static event EventHandler AStaticEvent;
    }

    class B
    {
        public virtual int MyProperty { get; set; }

        public virtual event EventHandler AStaticEvent;


        public virtual void M() { }
        public static void MStatic() { }
    }

    class A : B
    {
        public sealed override event EventHandler AStaticEvent;

        sealed public override int MyProperty { get => base.MyProperty; set => base.MyProperty = value; }
        sealed public override void M()
        {
            base.M();
            MStatic();
        }
    }

    class C : A
    {
    }

    internal class Employee
    {
        // Невиртуальный экземплярный метод
        public Int32 GetYearsEmployed() => 0;
        // Виртуальный метод (виртуальный - значит, экземплярный)
        public virtual String GetProgressReport() => "0";
        // Статический метод
        public static Employee Lookup(String name) => new Employee();
    }
}

//namespace CompanyA
//{
//    public class Phone
//    {
//        public void Dial()
//        {
//            Console.WriteLine("Phone.Dial");
//            // Выполнить действия по набору телефонного номера
//        }
//    }
//}

namespace CompanyA
{
    public class Phone
    {
        public void Dial()
        {
            Console.WriteLine("Phone.Dial.A");
            EstablishConnection();
            // Выполнить действия по набору телефонного номера
        }
        protected virtual void EstablishConnection()
        {
            Console.WriteLine("Phone.EstablishConnection.A");
            // Выполнить действия по установлению соединения
        }
    }
}

namespace CompanyB
{
    public class BetterPhone : CompanyA.Phone
    {
        public void Dial()
        {
            Console.WriteLine("BetterPhone.Dial.B");
            EstablishConnection();
            base.Dial();
        }
        protected virtual void EstablishConnection()
        {
            Console.WriteLine("BetterPhone.EstablishConnection.B");
            // Выполнить действия по набору телефонного номера
        }
    }
}

namespace CompanyB.With.New.One
{
    public class BetterPhone : CompanyA.Phone
    {
        // Этот метод Dial никак не связан с одноименным методом класса Phone
        public new void Dial()
        {
            Console.WriteLine("BetterPhone.Dial.B.One");
            EstablishConnection();
            base.Dial();
        }
        protected virtual void EstablishConnection()
        {
            Console.WriteLine("BetterPhone.EstablishConnection.B.One");
            // Выполнить действия по установлению соединения
        }
    }
}

namespace CompanyB.With.New.Two
{
    public class BetterPhone : CompanyA.Phone
    {
        // Ключевое слово 'new' оставлено, чтобы указать,
        // что этот метод не связан с методом Dial базового типа
        public new void Dial()
        {
            Console.WriteLine("BetterPhone.Dial.B.Two");
            EstablishConnection();
            base.Dial();
        }
        // Ключевое слово 'new' указывает, что этот метод
        // не связан с методом EstablishConnection базового типа
        protected new virtual void EstablishConnection()
        {
            Console.WriteLine("BetterPhone.EstablishConnection.B.Two");
            // Выполнить действия для установления соединения
        }
    }
}

namespace CompanyB.Without.Dial
{
    public class BetterPhone : CompanyA.Phone
    {
        // Метод Dial удален (так как он наследуется от базового типа)
        // Здесь ключевое слово new удалено, а модификатор virtual заменен
        // на override, чтобы указать, что этот метод связан с методом
        // EstablishConnection из базового типа
        protected override void EstablishConnection()
        {
            Console.WriteLine("BetterPhone.EstablishConnection.B.Without.Dial");
            // Выполнить действия по установлению соединения
        }
    }
}

