using System;
public sealed class SomeType
{
    private static String Name
    {
        get { return null; }
        set { }
    }
    public static void Main()
    {
        // При попытке скомпилировать следующую строку
        // компилятор вернет сообщение об ошибке:
        // error CS0206: A property or indexer may not
        // be passed as an out or ref parameter.
        MethodWithOutParam(out Name);
    }
    static void MethodWithOutParam(out String n) { n = null; }

}

