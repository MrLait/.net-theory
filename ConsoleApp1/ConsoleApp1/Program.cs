using System;
using System.Drawing;

public static class Program
{
    public static void Main()
    {
        // Создание одномерного массива из массивов типа Point
        Point[][] myPolygons = new Point[3][];
        // myPolygons[0] ссылается на массив из 10 экземпляров типа Point
        myPolygons[0] = new Point[10];
        // myPolygons[1] ссылается на массив из 10 экземпляров типа Point
        myPolygons[1] = new Point[20];
        // myPolygons[3] ссылается на массив из 10 экземпляров типа Point
        myPolygons[2] = new Point[30];
        // вывод точек первого многоугольника
        for (Int32 x = 0; x < myPolygons[0].Length; x++)
            Console.WriteLine(myPolygons[0][x]);
    }
}