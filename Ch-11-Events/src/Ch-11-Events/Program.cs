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
        }
    }
}