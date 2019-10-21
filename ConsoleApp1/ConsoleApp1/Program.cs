using System;
using System.Drawing;
using System.IO;

public static class Program
{

    public static void Main()
    {
        // Пример простого для понимания кода
        Appointment[] appointments = GetAppointmentsForToday();

        for (Int32 a = 0; a < appointments.Length; a++)
        {
        }

        // Пример более сложного кода
        Appointment[] appointments = GetAppointmentsForToday();
        if (appointments != null)
        {
            for (Int32 a = 0, a < appointments.Length; a++)
            {
                // Выполняем действия с элементом appointments[a]
            }
        }
}