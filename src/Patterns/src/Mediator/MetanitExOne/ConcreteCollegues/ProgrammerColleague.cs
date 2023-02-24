using Mediator.MetanitExOne.Abstract;
using System;

namespace Mediator.MetanitExOne
{
    // класс программиста
    class ProgrammerColleague : Colleague
    {
        public ProgrammerColleague(MediatorAbstract mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение программисту: " + message);
        }
    }
}
