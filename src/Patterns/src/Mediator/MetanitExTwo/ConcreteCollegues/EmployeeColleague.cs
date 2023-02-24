using Mediator.MetanitExTwo.Abstract;
using System;

namespace Mediator.MetanitExTwo.ConcreteCollegues
{
    class EmployeeColleague : Colleague
    {
        public bool IsExistenceProduct { get; set; }
        public EmployeeColleague(bool isExistenceProduct, MediatorAbstract mediator) : base(mediator)
            => IsExistenceProduct = isExistenceProduct;

        public override void Notify(string message)
            => Console.WriteLine("Работнику: " + message);
    }
}
