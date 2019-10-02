using System;

public sealed class Programm
{
    public sealed class SomeLibraryType
    {
        // ПРИМЕЧАНИЕ: C# не позволяет использовать для констант модификатор
        // static, поскольку всегда подразумевается, что константы являются
        // статическими
        public const Int32 MaxEntriesInList = 50;
    }
    public static void Main()
    {
        Console.WriteLine("Max entries supported in list: "
        + SomeLibraryType.MaxEntriesInList);
        
        Console.ReadKey();
    }
}