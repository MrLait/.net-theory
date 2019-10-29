﻿using System;
using System.Text;
internal sealed class Light
{
    // Метод возвращает состояние объекта Light
    public String SwitchPosition()
    {
        return "The light is off";
    }
}
internal sealed class Fan
{
    public String Speed()
    {
        throw new InvalidOperationException("The fan broke due to overheating");
    }
}
internal sealed class Speaker
{
    public String Volume()
    {
        return "The volume is loud";
    }
}
public sealed class Program
{
    // Определение делегатов, позволяющих запрашивать состояние компонентов
    private delegate String GetStatus();
    public static void Main()
    {
        // Объявление пустой цепочки делегатов
        GetStatus getStatus = null;
        // Создание трех компонентов и добавление в цепочку
        // методов проверки их состояния
        getStatus += new GetStatus(new Light().SwitchPosition);
        getStatus += new GetStatus(new Fan().Speed);
        getStatus += new GetStatus(new Speaker().Volume);
        Console.WriteLine(GetComponentStatusReport(getStatus));
    }
    private static String GetComponentStatusReport(GetStatus status)
    {
        // Если цепочка пуста, ничего делать не нужно
        if (status == null) return null;
        // Построение отчета о состоянии
        StringBuilder report = new StringBuilder();
        // Создание массива из делегатов цепочки
        Delegate[] arrayOfDelegates = status.GetInvocationList();
        // Циклическая обработка делегатов массива
        foreach (GetStatus getStatus in arrayOfDelegates)
        {
            try
            {
                // Получение строки состояния компонента и добавление ее в отчет
                report.AppendFormat("{0}{1}{1}", getStatus(), Environment.NewLine);
            }
            catch (InvalidOperationException e)
            {
                // В отчете генерируется запись об ошибке для этого компонента
                Object component = getStatus.Target;
                report.AppendFormat(
                "Failed to get status from {1}{2}{0} Error: {3}{0}{0}",
                Environment.NewLine,
                ((component == null) ? "" : component.GetType() + "."),
                getStatus.Method.Name,
                e.Message);
            }
        }
        // Возвращение сводного отчета вызывающему коду
        return report.ToString();
    }
}
