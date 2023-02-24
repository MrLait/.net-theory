using Mediator.MetanitExOne.Abstract;
using System;

namespace Mediator.MetanitExOne
{
    // класс тестера
    class TesterColleague : Colleague
    {
        public TesterColleague(MediatorAbstract mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение тестеру: " + message);
        }
    }
}
