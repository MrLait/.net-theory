using SOLID._5.DependencyInversionPrinciple.GoodPractice.Interfaces;

namespace SOLID._5.DependencyInversionPrinciple.GoodPractice.Models
{
    /*Теперь абстракция печати книги отделена от конкретных реализаций. 
     * В итоге и класс Book и класс ConsolePrinter зависят от абстракции IPrinter. 
     * Кроме того, теперь мы также можем создать дополнительные низкоуровневые 
     * реализации абстракции IPrinter и динамически применять их в программе:*/
    class Book
    {
        public string Text { get; set; }
        public IPrinter Printer { get; set; }

        public Book(IPrinter printer)
        {
            Printer = printer;
        }

        public void Print()
        {
            Printer.Print(Text);
        }
    }
}
