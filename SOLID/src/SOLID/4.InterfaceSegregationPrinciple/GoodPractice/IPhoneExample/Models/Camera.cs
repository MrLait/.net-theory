using SOLID._4.InterfaceSegregationPrinciple.GoodPractice.IPhoneExample.Interfaces;
using System;

namespace SOLID._4.InterfaceSegregationPrinciple.GoodPractice.IPhoneExample.Models
{
    class Camera : IPhoto
    {
        public void TakePhoto()
        {
            Console.WriteLine("Фотографируем с помощью фотокамеры");
        }
    }
}
