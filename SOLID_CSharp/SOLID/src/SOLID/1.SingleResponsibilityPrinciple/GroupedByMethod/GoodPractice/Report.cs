using System;

namespace SOLID._1.SingleResponsibilityPrinciple.GroupedByMethod.GoodPractice
{
    class Report
    {
        public string Text { get; set; }

        //Navigation
        public void GoToFirstPage() => Console.WriteLine("Переход к первой странице");
        public void GoToLastPage() => Console.WriteLine("Переход к последней странице");
        public void GoToPage(int pageNumber) => Console.WriteLine("Переход к странице {0}", pageNumber);

        public void Print(IPrinter printer)
        {
            printer.Print(this.Text);
        }
    }
}
