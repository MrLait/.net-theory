using System;
using System.Text;
public static class Program
{
    public static void Main()
    {
        // Кодируемая строка
        String s = "Hi there.";
        // Получаем объект, производный от Encoding, который "умеет" выполнять
        // кодирование и декодирование с использованием UTF-8
        Encoding encodingUTF8 = Encoding.UTF8;
        // Выполняем кодирование строки в массив байтов
        Byte[] encodedBytes = encodingUTF8.GetBytes(s);
        // Показываем значение закодированных байтов
        Console.WriteLine("Encoded bytes: " +
        BitConverter.ToString(encodedBytes));
        // Выполняем декодирование массива байтов обратно в строку
        String decodedString = encodingUTF8.GetString(encodedBytes);
        // Показываем декодированную строку
        Console.WriteLine("Decoded string: " + decodedString);

        foreach (EncodingInfo ei in Encoding.GetEncodings())
        {
            Encoding e = ei.GetEncoding();
            Console.WriteLine("{1}{0}" +
            "\tCodePage={2}, WindowsCodePage={3}{0}" +
            "\tWebName={4}, HeaderName={5}, BodyName={6}{0}" +
            "\tIsBrowserDisplay={7}, IsBrowserSave={8}{0}" +
            "\tIsMailNewsDisplay={9}, IsMailNewsSave={10}{0}",
            Environment.NewLine,
            e.EncodingName, e.CodePage, e.WindowsCodePage,
            e.WebName, e.HeaderName, e.BodyName,
            e.IsBrowserDisplay, e.IsBrowserSave,
            e.IsMailNewsDisplay, e.IsMailNewsSave);
        }

        // Получаем набор из 10 байт, сгенерированных случайным образом
        Byte[] bytes = new Byte[10];
        new Random().NextBytes(bytes);
        // Отображаем байты
        Console.WriteLine(BitConverter.ToString(bytes));
        // Декодируем байты в строку в кодировке base-64 и выводим эту строку
        String s1 = Convert.ToBase64String(bytes);
        Console.WriteLine(s1);
        // Кодируем строку в кодировке base-64 обратно в байты и выводим их
        bytes = Convert.FromBase64String(s1);
        Console.WriteLine(BitConverter.ToString(bytes));

    }
}