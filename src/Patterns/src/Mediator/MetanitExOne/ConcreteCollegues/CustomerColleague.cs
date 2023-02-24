using Mediator.MetanitExOne.Abstract;
using System;

namespace Mediator.MetanitExOne
{
    // класс заказчика
    class CustomerColleague : Colleague
    {
        public CustomerColleague(MediatorAbstract mediator): base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение заказчику: " + message);
        }
    }
}
