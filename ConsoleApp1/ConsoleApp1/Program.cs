using System;
using System.IO;

public sealed class Program
{
    public static void Main()
    {
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