using Mediator.MetanitExTwo.Abstract;
using System;

namespace Mediator.MetanitExTwo.ConcreteCollegues
{
    public class ClientColleague : Colleague
    {
        public ClientColleague(MediatorAbstract mediator) : base(mediator) { }

        public override void Notify(string message)
        {
            Console.WriteLine($"Клиент: {message}");
        }
    }
}
