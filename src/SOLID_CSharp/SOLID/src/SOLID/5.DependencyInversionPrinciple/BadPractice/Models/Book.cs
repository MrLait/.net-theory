namespace SOLID._5.DependencyInversionPrinciple.BadPractice.Models
{
    /*
     * Класс Book, представляющий книгу, использует для печати класс ConsolePrinter. 
     * При подобном определении класс Book зависит от класса ConsolePrinter. 
     * Более того мы жестко определили, что печать книгу можно только на консоли с помощью класса ConsolePrinter. 
     * Другие же варианты, например, вывод на принтер, вывод в файл или 
     * с использованием каких-то элементов графического интерфейса - все это в данном случае исключено. 
     * Абстракция печати книги не отделена от деталей класса ConsolePrinter. 
     * Все это является нарушением принципа инверсии зависимостей.
     */
    class Book
    {
        public string Text { get; set; }
        public ConsolePrinter Printer { get; set; }

        public void Print()
        {
            Printer.Print(Text);
        }
    }
}
