using SOLID._1.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Interfaces;
using SOLID._1.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Models;
using SOLID._1.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Services;

namespace SOLID.RelationshipsBetweenClassesObjects
{
    class AssociationBetweenClasses /*: IMethod*/
    {
        //Ассоциация
        public Phone Phone { get; set; }

        public IPhoneReader Reader; // Для агрегации
        public IPhoneBinder Binder; //Для композиции

        public AssociationBetweenClasses(IPhoneReader reader)
        {
            //Агрегация
            Reader = reader;

            //Композиция
            Binder = new GeneralPhoneBinder();
        }

        //Реализация
        /*
         void IMethod.Method(){}
         */
    }
}
