using System;
using System.IO;

public static class Program
{
    public static void Main()
    {
        Int32[] myIntegers; // Объявление ссылки на массив
        myIntegers = new Int32[100]; // Создание массива типа Int32 из 100 элементов

        Control[] myControls; // Объявление ссылки на массив
        myControls = new Control[50]; // Создание массива из 50 ссылок
                                      // на переменную Control

        myControls[1] = new Button();
        myControls[2] = new TextBox();
        myControls[3] = myControls[2]; // Два элемента ссылаются на один объект
        myControls[46] = new DataGrid();
        myControls[48] = new ComboBox();
        myControls[49] = new Button();

    }
