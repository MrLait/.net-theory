using System;

public static class Program
{
    public static void Main()
    {

        String s = new String("Hi there."); //Ошибка
        //Вместо этого используется более простой синтаксис:
        String s1 = "Hi there";
        // String содержит символы конца строки и перевода каретки
        String s2 = "Hi\r\nthere.";
        //Чтобы приведенный код работал на любой платформе,
        String s3 = "Hi" + Environment.NewLine + "there.";
        // Конкатенация трех литеральных строк образует одну литеральную строку
        String s4 = "Hi" + " " + "there.";
        // Задание пути к приложению
        String file = "C:\\Windows\\System32\\Notepad.exe";
        // Задание пути к приложению с помощью буквальной строки
        String file1 = @"C:\Windows\System32\Notepad.exe";
        if (file.Substring(10, 21).EndsWith("EXE"))
        {
        }
    }
}

