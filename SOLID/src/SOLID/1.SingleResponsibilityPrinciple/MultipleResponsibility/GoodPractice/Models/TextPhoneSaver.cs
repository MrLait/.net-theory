using SOLID.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Interfaces;

namespace SOLID.SingleResponsibilityPrinciple.MultipleResponsibility.GoodPractice.Models
{
    class TextPhoneSaver : IPhoneSaver
    {
        public void Save(Phone phone, string fileName)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName, true))
            {
                writer.WriteLine(phone.Model);
                writer.WriteLine(phone.Price);
            }
        }
    }
}
