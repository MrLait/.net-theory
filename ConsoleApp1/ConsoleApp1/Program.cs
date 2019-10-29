using System;
using System.Threading;
internal sealed class AClass
{
    public static void UsingLocalVariablesInTheCallbackCode(Int32 numToDo)
    {
        // Локальные переменные
        Int32[] squares = new Int32[numToDo];
        AutoResetEvent done = new AutoResetEvent(false);
        // Выполнение задач в других потоках
        for (Int32 n = 0; n < squares.Length; n++)
        {
            ThreadPool.QueueUserWorkItem(
            obj =>
            {
                Int32 num = (Int32)obj;
                // Обычно решение этой задачи требует больше времени
                squares[num] = num * num;
                // Если это последняя задача, продолжаем выполнять главный поток
                if (Interlocked.Decrement(ref numToDo) == 0)
                    done.Set();
            },
            n);
        }
        // Ожидаем завершения остальных потоков
        done.WaitOne();
        // Вывод результатов
        for (Int32 n = 0; n < squares.Length; n++)
            Console.WriteLine("Index {0}, Square={1}", n, squares[n]);
    }
}

public sealed class Program
{
    //определение делегата
    delegate void Bar(out Int32 z);
    public static void Main()
    {
        AClass.UsingLocalVariablesInTheCallbackCode(4);
        Console.ReadKey();

        // Создание и инициализация массива String
        String[] names = { "Jeff", "Kristin", "Aidan", "Grant" };
        // Извлечение имен со строчной буквой 'a'
        Char charToFind = 'a';
        names = Array.FindAll(names, name => name.IndexOf(charToFind) >= 0);
        // Преобразование всех символов строки в верхний регистр
        names = Array.ConvertAll(names, name => name.ToUpper());
        // Вывод результатов
        Array.ForEach(names, Console.WriteLine);


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

        Func<Int32, Int32, String> f7 = (n1, n2) =>
        {
            Int32 sum = n1 + n2; return sum.ToString();
        };
    }

}
