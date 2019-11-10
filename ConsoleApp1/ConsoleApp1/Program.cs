using System;
using System.IO;

public sealed class Program
{
    static void Main(string[] args)
    {
        int x = 10;

        int z;

        Sum(x, 15, out z);

        Console.WriteLine(z);

        Console.ReadKey();
    }
    static void Sum(int x, int y, out int a)
    {
        Console.WriteLine(x + y);
    }

    private void SomeMethod()
    {
        try { /*...*/ }
        catch (Exception e)
        {
            //...
            throw; // CLR не меняет информацию о начальной точке исключения.
                   // FxCop НЕ сообщает об ошибке
        }
    }

    private void SomeMethod2()
    {
        try { /*...*/ }
        catch (Exception e)
        {
            //...
            throw e; // CLR считает, что исключение возникло тут
                     // FxCop сообщает об ошибке
        }
    }

    private void SomeMethod3()
    {
        Boolean trySucceeds = false;
        try
        {
            //...
            trySucceeds = true;
        }
        finally
        {
            if (!trySucceeds) { /* код перехвата исключения */ }
        }
    }

    private void SomeMethod4()
    {
        try
        {
            // Внутрь блока try помещают код, требующий корректного
            // восстановления работоспособности или очистки ресурсов
        }
        catch (Exception e)
        {
            // До C# 2.0 этот блок перехватывал только CLS-совместимые исключения
            // В C# 2.0 этот блок научился перехватывать также
            // CLS-несовместимые исключения
            throw; // Повторная генерация перехваченного исключения
        }
        catch
        {
            // Во всех версиях C# этот блок перехватывает
            // и совместимые, и несовместимые с CLS исключения
            throw; // Повторная генерация перехваченного исключения
        }
    }

    private void ReadData(String pathname)
    {
        FileStream fs = null;
        try
        {
            fs = new FileStream(pathname, FileMode.Open);
            // Обработка данных в файле
        }
        catch (IOException)
        {
            // Код восстановления после исключения IOException
        }
        finally
        {
            // Файл обязательно следует закрыть
            if (fs != null) fs.Close();
        }
    }
}