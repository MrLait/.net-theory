using SOLID._4.InterfaceSegregationPrinciple.GoodPractice.IPhoneExample.Interfaces;
using System;

namespace SOLID._4.InterfaceSegregationPrinciple.GoodPractice.IPhoneExample.Models
{
    /*Для применения принципа разделения интерфейсов опять же интерфейс класса Phone 
     * разделяется на группы связанных методов (в данном случае получается 4 группы, 
     * в каждой по одному методу). Затем каждая группа обертывается в отдельный интерфейс 
     * и используется самостоятельно.*/
    class Phone : ICall, IPhoto, IVideo, IWeb
    {
        public void Call() => Console.WriteLine("Звоним");

        public void TakePhoto() => Console.WriteLine("Фотографируем с помощью смартфона");

        public void MakeVideo() => Console.WriteLine("Снимаем видео");

        public void BrowseInternet() => Console.WriteLine("Серфим в интернете");
    }
}
