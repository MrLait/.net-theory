using System;

public sealed class Programm
{
    public sealed class SomeLibraryType
    {
        // Модификатор static необходим, чтобы поле
        // ассоциировалось с типом, а не экземпляром
        public static readonly Int32 MaxEntriesInList = 50;
    }
    public static void Main()
    {
        Console.WriteLine("Max entries supported in list: "
        + SomeLibraryType.MaxEntriesInList);

        Console.ReadKey();
    }
}