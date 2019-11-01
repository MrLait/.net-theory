using System;
using System.IO;

public sealed class Program
{
    public static void Main()
    {
    }
    private void SomeMethod()
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