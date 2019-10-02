using System;

public sealed class Programm
{
    public sealed class SomeType
    {
        // Статическое неизменяемое поле. Его значение рассчитывается
        // и сохраняется в памяти при инициализации класса во время выполнения
        public static readonly Random s_random = new Random();
        // Статическое изменяемое поле
        private static Int32 s_numberOfWrites = 0;
        //Неизменяемое экземплярное поле
        public readonly String Pathname = "Untitled";
        // Изменяемое экземплярное поле
        private System.IO.FileStream m_fs;

        public SomeType(String patname)
        {
            // Эта строка изменяет значение неизменяемого поля
            // В данном случае это возможно, так как показанный далее код
            // расположен в конструкторе
            Pathname = patname;
        }
        public String DoSomething()
        {
            // Эта строка читает и записывает значение статического изменяемого поля
            s_numberOfWrites = s_numberOfWrites + 1;
            // Эта строка читает значение неизменяемого экземплярного поля
            return Pathname;
        }
    }
    public static void Main()
    {
        Console.ReadKey();
    }
}