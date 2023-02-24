using Mediator.MetanitExTwo.ConcreteCollegues;

namespace Mediator.MetanitExTwo.Abstract
{
    internal class Manager : MediatorAbstract
    {
        public Colleague Client { get; set; }
        public Colleague Employee { get; set; }
        public Colleague Deliveryman { get; set; }

        public override void Send(string message, Colleague colleague)
        {
            if (colleague == Client)
                Employee?.Notify(message);
            else if (colleague == Employee)
            {
                if (Employee is EmployeeColleague e)
                    if (e.IsExistenceProduct)
                        Deliveryman.Notify(message);
                    else
                        Client?.Notify(message);
            }
            else if (colleague == Deliveryman && Employee is EmployeeColleague e && e.IsExistenceProduct)
                Client?.Notify(message);
        }
    }
}
