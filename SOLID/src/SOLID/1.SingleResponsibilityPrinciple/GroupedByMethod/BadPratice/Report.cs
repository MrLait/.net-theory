using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SingleResponsibilityPrinciple.BadPratice
{
    //Bad practice
    class Report
    {
        public string Text { get; set; }

        //Navigation
        public void GoToFirstPage() => Console.WriteLine("Переход к первой странице");
        public void GoToLastPage() => Console.WriteLine("Переход к последней странице");
        public void GoToPage(int pageNumber) => Console.WriteLine("Переход к странице {0}", pageNumber);

        //But it is method for Printing 
        public void Print()
        {
            Console.WriteLine("Печать отчета");
            Console.WriteLine(Text);
        }
    }
}
