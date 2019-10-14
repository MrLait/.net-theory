using System;
public static class Program
{
    public static void Main()
    {
        /************************* Первый пример *************/
        Base b = new Base();
        // Console.WriteLine("Вызов реализации Dispose в типе b: Dispose класса Base"); 
        b.Dispose();
        // Console.WriteLine("Вызов реализации Dispose в типе объекта b: Dispose класса Base");
        ((IDisposable)b).Dispose();
        /************************* Второй пример ************************/
        Derived d = new Derived();
        // Console.WriteLine("Вызов реализации Dispose в типе d: Dispose класса Derived"); 
        d.Dispose();
        // Console.WriteLine("Вызов реализации Dispose в типе объекта d: Dispose класса Derived"); 
        ((IDisposable)d).Dispose();
        /************************* Третий пример *************************/
        b = new Derived();
        // Console.WriteLine("Вызов реализации Dispose в типе b: Dispose класса Base");
        b.Dispose();
        // Console.WriteLine("Вызов реализации Dispose в типе объекта b: Dispose класса Derived"); 
        ((IDisposable)b).Dispose();
    }
}

// Этот класс является производным от Object и реализует IDisposable
internal class Base : IDisposable
{
    // Этот метод неявно запечатан и его нельзя переопределить
    public void Dispose()
    {
        Console.WriteLine("Base's Dispose");
    }
}
// Этот класс наследует от Base и повторно реализует IDisposable
internal class Derived : Base, IDisposable
{
    // Этот метод не может переопределить Dispose из Base.
    // Ключевое слово 'new' указывает на то, что этот метод
    // повторно реализует метод Dispose интерфейса IDisposable
    new public void Dispose()
    {
        Console.WriteLine("Derived's Dispose)");
        // ПРИМЕЧАНИЕ: следующая строка кода показывает,
        // как вызвать реализацию базового класса (если нужно)s
        //base.Dispose(); 
    }
}
