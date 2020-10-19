using SOLID._4.InterfaceSegregationPrinciple.BadPractice.IPhoneExample.Interfaces;
using System;

namespace SOLID._4.InterfaceSegregationPrinciple.BadPractice.IPhoneExample
{
    /*Объект Photograph, который представляет фотографа, теперь может фотографировать, 
     * используя объект Phone. Однако более для фотосъемки можно использовать 
     * также и обычную фотокамеру, которая не обладает множеством возможностей телефона. 
     * И мы хотели бы, чтобы фотограф мог бы также использовать и фотокамеру для фотосъемки. 
     * В этом случае мы могли взять общий интерфейс IPhone и реализовать его метод TakePhoto в классе фотокамеры:*/
    class Camera : IPhone
    {
        public void Call() { }
        public void TakePhoto()
        {
            Console.WriteLine("Фотографируем");
        }
        public void MakeVideo() { }
        public void BrowseInternet() { }
    }

    /*Однако здесь мы опять сталкиваемся с тем, что клиент - класс Camera зависит от методов, 
     * которые он не использует - то есть методов Call, MakeVideo, BrowseInternet.*/
}
