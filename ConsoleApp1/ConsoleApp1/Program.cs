using System;
using System.IO;
using System.Reflection;
public static class Program
{
    [Flags] // Компилятор C# допускает значение "Flags" или "FlagsAttribute"
    internal enum Actions
    {
        None = 0,
        Read = 0x0001,
        Write = 0x0002,
        ReadWrite = Actions.Read | Actions.Write,
        Delete = 0x0004,
        Query = 0x0008,
        Sync = 0x0010
    }

    public static void Main()
    {
        // Так как Query определяется как 8, 'a' получает начальное значение 8
        Actions a = (Actions)Enum.Parse(typeof(Actions), "Query", true);
        Console.WriteLine(a.ToString()); // "Query"
                                         // Так как у нас определены и Query, и Read, 'a' получает
                                         // начальное значение 9
        Enum.TryParse<Actions>("Query, Read", false, out a);
        Console.WriteLine(a.ToString()); // "Read, Query"
                                         // Создаем экземпляр перечисления Actions enum со значением 28
        a = (Actions)Enum.Parse(typeof(Actions), "28", false);
        Console.WriteLine(a.ToString()); // "Delete, Query, Sync"
    }

}