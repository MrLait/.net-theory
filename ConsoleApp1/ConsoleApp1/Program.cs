using System;

public static class Programm
{
    private static Int32 s_n = 0;
    
    public static void Main()
    {
        // 1. Аналогично: M(9, "A", default(DateTime), new Guid());
        M();
        // 2. Аналогично: M(8, "X", default(DateTime), new Guid());
        M(8, "X");
        // 3. Аналогично: M(5, "A", DateTime.Now, Guid.NewGuid());
        M(5, dt: DateTime.Now, guid: Guid.NewGuid());
        // 4. Аналогично: M(0, "1", default(DateTime), new Guid());
        M(s_n++, s_n++.ToString());
        // 5. Аналогично: String t1 = "2"; Int32 t2 = 3;
        M(s: s_n++.ToString(), x: s_n++);
        Console.WriteLine(MakePath());
        Console.WriteLine(MakePath2());
        
        // Вызов метода:
        Int32 a = 5;
        M2(x: ref a);
    }
    // Объявление метода:
    private static void M2(ref Int32 x)
    {
        Console.WriteLine("x = {0}", x);
    }

    // Не делайте так:
    private static String MakePath(String filename = "Untitled")
    {
        return String.Format(@"C:\{0}.txt", filename);
    }
    // Используйте следующее решение:
    private static String MakePath2(String fileName = null)
    {
        // Здесь применяется оператор, поддерживающий
        // значение null (??); см. главу 19
        return String.Format(@"C:\{0}.txt", fileName ?? "Untitled");
    }
    private static void M(Int32 x = 9, String s = "A",
        DateTime dt = default(DateTime), Guid guid = new Guid())
    //или так Guid guid = default(Guid)
    //или даже так Guid guid = default
    {
        Console.WriteLine("x={0}, s={1}, dt={2}, guid={3}", x, s, dt, guid);
    }
}

