using System;
using System.Collections;
using System.Collections.Generic;

public static class Program
{
    public static void Main()
    {
        MarioPizzeria mP = new MarioPizzeria();
        // Эта строка вызывает открытый метод GetMenu класса MarioPizzeria
        mP.GetMenu();
        IWindow window = mP;
        IRestaurant restaurant = mP;
        window.GetMenu();
        restaurant.GetMenu();
    }

    public interface IWindow
    {
        Object GetMenu();
    }
    public interface IRestaurant
    {
        Object GetMenu();
    }
    // Этот тип является производным от System.Object
    // и реализует интерфейсы IWindow и IRestaurant
    public sealed class MarioPizzeria : IWindow, IRestaurant
    {
        // Реализация метода GetMenu интерфейса IWindow
        Object IWindow.GetMenu()
        {
            return null;
        }
        // Реализация метода GetMenu интерфейса IRestaurant
        Object IRestaurant.GetMenu()
        {
            return null;
        }
        // Метод GetMenu (необязательный),
        // не имеющий отношения к интерфейсу
        public Object GetMenu() 
        {
            return null;
        }
    }


}

