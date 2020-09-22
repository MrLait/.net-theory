using SOLID.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice;
using SOLID.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Interfaces;
using SOLID.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Models;

namespace SOLID
{
    class AssociationBetweenClasses /*: IMethod*/
    {
        //Ассоциация
        public Phone Phone { get; set; }

        public IPhoneReader Reader { get; set; } // Для агрегации
        public IPhoneBinder Binder { get; set; } //Для композиции

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
