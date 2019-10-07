using System;
using System.IO;
public sealed class Programm
{
    public static void Main()
    {
        FileStream fs; // Объект fs не инициализирован
        // Первый файл открывается для обработки
        StartProcessingFiles(out fs);
        // Продолжаем, пока остаются файлы для обработки
        for (;  fs != null; ContinueProcessingFiles(ref fs))
        {
            Byte[] bytes = new Byte[fs.Length];
            //Обработка файла
            fs.Read(bytes);
        }
    }
    private static void StartProcessingFiles(out FileStream fs)
    {
        fs = new FileStream("Path", FileMode.Open); // в этом методе объект fs
                                                    // должен инициализироваться
    }
    private static void ContinueProcessingFiles(ref FileStream fs)
    {
        fs.Close(); // Закрытие последнего обрабатываемого файла
        // Открыть следующий файл или вернуть null, если файлов больше нет
        if (noMoreFilesToProcess) fs = null;
        else fs = new FileStream("newPath", FileMode.Open);
    }
}

