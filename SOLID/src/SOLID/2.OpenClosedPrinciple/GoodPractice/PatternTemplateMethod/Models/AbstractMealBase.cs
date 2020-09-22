namespace SOLID._2.OpenClosedPrinciple.GoodPractice.PatternTemplateMethod.Models
{
    abstract class AbstractMealBase
    {
        public void Make()
        {
            Prepare();
            Cook();
            FinalSteps();
        }

        protected abstract void Prepare();
        protected abstract void Cook();
        protected abstract void FinalSteps();
    }
}
