using System;
using System.IO;
public sealed class Programm
{
    public static void Main()
    {
        FileStream fs = null; // Обязательное присвоение
                              // начального значения null
        // Открытие первого файла для обработки
        ProcessingFiles(ref fs);
        // Продолжаем, пока остаются файлы для обработки
        for (;  fs != null; ProcessingFiles(ref fs))
        {
            Byte[] bytes = new Byte[fs.Length];
            //Обработка файла
            fs.Read(bytes);
        }
    }
    private static void ProcessingFiles(ref FileStream fs)
    {
        // Если предыдущий файл открыт, закрываем его
        if (fs != null) fs.Close(); // Закрыть последний обрабатываемый файл
        // Открыть следующий файл или вернуть null, если файлов больше нет
        if (noMoreFilesToProcess) fs = null;
        else fs = new FileStream("newPath", FileMode.Open); 
    }
}

