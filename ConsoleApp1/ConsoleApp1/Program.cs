using System;
using System.IO;
using System.Reflection;
public static class Program
{
    //[Flags] // Компилятор C# допускает значение "Flags" или "FlagsAttribute"
    internal enum Actions
    {
        None = 0
        Read = 0x0001,
        Write = 0x0002,
        ReadWrite = Actions.Read | Actions.Write,
        Delete = 0x0004,
        Query = 0x0008,
        Sync = 0x0010
    }

    public static void Main()
    {
        String file = Assembly.GetEntryAssembly().Location;
        FileAttributes attributes = File.GetAttributes(file);
        Console.WriteLine("Is {0} hidden? {1}", file, (
         attributes & FileAttributes.Hidden) != 0);

        //File.SetAttributes(file, FileAttributes.ReadOnly | FileAttributes.Hidden);

        Actions actions = Actions.Read | Actions.Delete;
        Console.WriteLine(actions.ToString()); // "Read, Delete"
        Console.WriteLine(actions.ToString("F")); // "Read, Delete"
    }

}