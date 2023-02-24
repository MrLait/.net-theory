using Mediator.MetanitExTwo.Abstract;
using System;

namespace Mediator.MetanitExTwo.ConcreteCollegues
{
    class DeliverymanColleague : Colleague
    {
        public DeliverymanColleague(MediatorAbstract mediator) : base(mediator) { }

        public override void Notify(string message)
            => Console.WriteLine("Доставщику: " + message);
    }
}
