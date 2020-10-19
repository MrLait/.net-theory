using System;

namespace Ch_11_Events
{
    public class Program
    {
        public static void Main()
        {
            MailManager mailManager = new MailManager();
            Fax fax = new Fax(mailManager);
            Pager pager = new Pager(mailManager);

            mailManager.SimulateNewMail("A", "B", "T");

            TypeWithLotsOfEvents twle = new TypeWithLotsOfEvents();
            // Добавление обратного вызова
            twle.Foo += HandleFooEvent;
            // Проверяем работоспособность
            twle.SimulateFoo();
        }

        private static void HandleFooEvent(object sender, FooEventArgs e)
        {
            Console.WriteLine("Handling Foo Event here...");
        }
    }
}