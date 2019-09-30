using System;
using System.IO;

public sealed class Program
{
    public static void Main()
    {
        int a1 = 0;                     // Самый удобный синтаксис
        System.Int32 a2 = 0;            // Удобный синтаксис
        int a3 = new Int32();           // Неудобный синтаксис
        System.Int32 a4 = new Int32();  // Самый неудобный синтаксис

    //Примитивный тип 
                //FCL - тип 
                                //Совместимость с CLS  
                                               //Описание
    sbyte   a5 = new System.SByte();    //Нет   //8 - разрядное значение со знаком
    byte    a6 = new System.Byte();     //Да    //8 - разрядное значение без знака
    short   a7 = new System.Int16();    //Да    //16 - разрядное значение со знаком
    ushort  a8 = new System.UInt16();   //Нет   //16 - разрядное значение без знака
    int     a9 = new System.Int32();    //Да    //32 - разрядное значение со знаком
    uint    a10 = new System.UInt32();  //Нет   //32 - разрядное значение без знака
    long    a11 = new System.Int64();   //Да    //64 - разрядное значение со знаком
    ulong   a12 = new System.UInt64();  //Нет   //64 - разрядное значение без знака
    char    a13 = new System.Char();    //Да    //16 - разрядный символ Unicode
    float   a14 = new System.Single();  //Да    //32 - разрядное значение с плавающей точкой в стандарте IEEE
    double  a15 = new System.Double();  //Да    //64 - разрядное значение с плавающей точкой в стандарте IEEE
    bool    a16 = new System.Boolean(); //Да    //Булево значение(true или false)
    decimal a17 = new System.Decimal(); //Да    //128 - разрядное значение с плавающей точкой повышенной точности, 
                                        //часто используемое для финансовых расчетов, где недопустимы ошибки 
                                        //округления. Первый разряд числа — это знак, в следующих 96 разрядах 
                                        //помещается само значение, следующие 8 разрядов — степень числа 10, 
                                        //на которое делится 96 - разрядное число(может быть в диапазоне от 0 до 28).
                                        //Остальные разряды не используются
    string a18 = new System.String(""); //Да    //Массив символов
    object a19 = new System.Object();   //Да    //Базовый тип для всех типов
    dynamic a20 = new System.Object();  //Да    //Для CLR тип dynamic идентичен типу object. Однако 
                                        //компилятор С# позволяет переменным типа dynamic участвовать
                                        //в динамическом разрешении типа с упрощенным синтаксисом.

        try
        {
            BinaryReader br = new BinaryReader(File.Open("path", FileMode.Open));
            float a21 = br.ReadSingle();    // Код правильный, но выглядит странно
            Single a22 = br.ReadSingle();   // Код правильный и выглядит нормально
        }
        catch (Exception)
        {

            Console.WriteLine("path is not found");
        }
        
        Int32 a23 = 5;   //Неявное приведение Int32 к Int32
        Int64 a24 = a23; //Неявное приведение Int32 к Int64
        Single a25 = a23;//Неявное приведение Int32 к Single
        Int32 a26 = (Int32)5; //Явное приведение Int32 к Int32
        Byte a27 = (Byte)a23; //Явное приведение Int32 к Byte
        Single a28 = (Single)a23;//Явное приведение Int32 к Single
        Int16 a29 = (Int16)a28; //Явное приведение Single к Int16

        Console.WriteLine(123.ToString() + 456.ToString()); //123456

        Boolean found1 = false; //В готовом коде found присваивается 0
        Int32 a30 = 100 + 20 + 1; //В готовом коде х присваивается 121
        String s = "abc" + "d"; //В готовом коде s присваивается abcd

        Int32 a31 = 100; // Опператор присваивания
        Int32 a32 = a31 + 30; // Опператор суммирования
        Boolean found2 = (a32 < 100); //Опператор присваивания и "меньше чем"

        Byte a33 = 100;
        a33 = (byte)(200 + a33); //После этого b равно 44 (2C в шестнадцатеричной записи)

        //UInt32 invalid = unchecked(UInt32 - 1); // OK
        Byte a34 = 100;
        //a34 = checked((Byte)(200 + a34)); //Выдается исключение OverflowException

        Byte a35 = 100;
        a35 = (Byte)unchecked(200 + a35); //a35 содержит 44; нет OverflowException

        unchecked // Начало проверяемого блока
        {
            Byte a36 = 100;
            a36 = (Byte)(200 + a36); // Это выражение проверяется на переполнение
        }                            // Конец проверяемого блока
        
        checked
        {
            byte a37 = 100;
            a37 +=200;
        }
    }
}