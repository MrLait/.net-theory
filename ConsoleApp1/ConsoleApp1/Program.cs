using System;
using System.Threading;

internal sealed class AClass1
{
    public static void CallbackWithoutNewingADelegateObject()
    {
        ThreadPool.QueueUserWorkItem(SomeAsyncTask, 5);
    }
    private static void SomeAsyncTask(Object o)
    {
        Console.WriteLine(o);
    }
}
internal sealed class AClass2
{
    public static void CallbackWithoutNewingADelegateObject()
    {
        ThreadPool.QueueUserWorkItem(obj => Console.WriteLine(obj), 5);
    }
}
internal sealed class AClass3
{
    private static String sm_name; // Статическое поле
    public static void CallbackWithoutNewingADelegateObject()
    {
        ThreadPool.QueueUserWorkItem(
        // Код обратного вызова может обращаться к статическим членам
        obj => Console.WriteLine(sm_name + ": " + obj),
        5);
    }
}
internal sealed class AClass
{
    private String m_name; // Поле экземпляра
                           // Метод экземпляра
    public void CallbackWithoutNewingADelegateObject()
    {
        ThreadPool.QueueUserWorkItem(
        // Код обратного вызова может ссылаться на члены экземпляра
        obj => Console.WriteLine(m_name + ": " + obj),
        5);
    }
}
public sealed class Program
{
    //определение делегата
    delegate void Bar(out Int32 z);
    public static void Main()
    {
        // Если делегат не содержит аргументов, используйте круглые скобки
        Func<String> f = () => "Jeff";
        // Для делегатов с одним и более аргументами
        // можно в явном виде указать типы
        Func<Int32, String> f2 = (Int32 n) => n.ToString();
        Func<Int32, Int32, String> f3 = (Int32 n1, Int32 n2) => (n1 + n2).ToString();
        // Компилятор может самостоятельно определить типы для делегатов
        // с одним и более аргументами
        Func<Int32, String> f4 = (n) => n.ToString();
        Func<Int32, Int32, String> f5 = (n1, n2) => (n1 + n2).ToString();
        // Если аргумент у делегата всего один, круглые скобки можно опустить
        Func<Int32, String> f6 = n => n.ToString();
        // Для аргументов ref/out нужно в явном виде указывать ref/out и тип
        Bar b = (out Int32 n) => n = 5;

        Func<Int32, Int32, String> f7 = (n1, n2) => {
            Int32 sum = n1 + n2; return sum.ToString();
        };
    }

}
