using SOLID._4.InterfaceSegregationPrinciple.BadPractice.IPhoneExample.Models;

namespace SOLID._4.InterfaceSegregationPrinciple.BadPractice.IPhoneExample
{
    /*Но пусть у нас есть также класс клиента, который использует объект Phone для фотографирования:*/
    class Photograph
    {
        public void TakePhoto(Phone phone) => phone.TakePhoto();
    }
}
