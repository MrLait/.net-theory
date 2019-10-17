using System;
using System.Text;
using System.Globalization;

public static class Program
{
    public static void Main()
    {
        StringBuilder sb1 = new StringBuilder();
        String s1 = sb1.AppendFormat("{0} {1}", "Jeffrey", "Richter").
            Replace(' ', '-').Remove(4, 3).ToString();
        Console.WriteLine(s1);

        // Создаем StringBuilder для операций со строками
        StringBuilder sb = new StringBuilder();
        // Выполняем ряд действий со строками, используя StringBuilder
        sb.AppendFormat("{0} {1}", "Jeffrey", "Richter").Replace(" ", "-");
        // Преобразуем StringBuilder в String,
        // чтобы сделать все символы прописными
        String s = sb.ToString().ToUpper();
        // Очищаем StringBuilder (выделяется память под новый массив Char)
        sb.Length = 0;
        // Загружаем строку с прописными String в StringBuilder
        // и выполняем остальные операции
        sb.Append(s).Insert(8, "Marc-");
        // Преобразуем StringBuilder обратно в String
        s = sb.ToString();
        // Выводим String на экран для пользователя
        Console.WriteLine(s); // "JEFFREY-Marc-RICHTER"


    }

}

