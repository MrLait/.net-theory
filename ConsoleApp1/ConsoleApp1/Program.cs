using System;

public sealed class Program
{
    public static void Main()
    {
        NullCoalescingOperator();
        Func<String> f = () => SomeMethod() ?? "Untitled";
        //тоже самое но не так куто
        Func<String> f = () => {
            var temp = SomeMethod();
            return temp != null ? temp : "Untitled";
        };

        String s = SomeMethod1() ?? SomeMethod2() ?? "Untitled";
        //тоже самое но не так куто
        String s;
        var sm1 = SomeMethod1();
        if (sm1 != null) s = sm1;
        else
        {
            var sm2 = SomeMethod2();
            if (sm2 != null) s = sm2;
            else s = "Untitled";
        }

    }
    private static void NullCoalescingOperator()
    {
        Int32? b = 5;
        // Приведенная далее инструкция эквивалентна следующей:
        // x = (b.HasValue) ? b.Value : 123
        Int32 x = b ?? 123;
        Console.WriteLine(x);

        // Приведенная далее в инструкции строка эквивалентна следующему коду:
        // String temp = GetFilename();
        // filename = (temp != null) ? temp : "Untitled";
        //String filename = GetFilename() ?? "Untitled";
    }
}