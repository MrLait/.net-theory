using SOLID._4.InterfaceSegregationPrinciple.GoodPractice.IPhoneExample.Interfaces;

namespace SOLID._4.InterfaceSegregationPrinciple.GoodPractice.IPhoneExample.Models
{
    /*Теперь изменим код клиента - класса фотографа:*/
    class Photograph
    {
        public void TakePhoto(IPhoto photoMaker) => photoMaker.TakePhoto();
    }
    /*
     * Теперь фотографу не важно, что передается в метод TakePhoto - фотокамера или телефон, 
     * главное, что этот объект обладается только всем необходимым для фотографирования функционалом и больше ничем.
     */
}
