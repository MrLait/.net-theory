using SOLID._4.InterfaceSegregationPrinciple.BadPractice.IPhoneExample.Interfaces;
using System;

namespace SOLID._4.InterfaceSegregationPrinciple.BadPractice.IPhoneExample.Models
{
    class Phone : IPhone
    {
        public void Call() => Console.WriteLine("Звоним");

        public void TakePhoto() => Console.WriteLine("Фотографируем");

        public void MakeVideo() => Console.WriteLine("Снимаем видео");

        public void BrowseInternet() => Console.WriteLine("Серфим в интернете");
    }
}
