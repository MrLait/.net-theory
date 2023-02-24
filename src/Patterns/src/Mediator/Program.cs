using Mediator.MetanitExTwo.Abstract;
using Mediator.MetanitExTwo.ConcreteCollegues;
using System;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            //ManagerMediator mediator = new ManagerMediator();
            //Colleague customer = new CustomerColleague(mediator);
            //Colleague programmer = new ProgrammerColleague(mediator);
            //Colleague tester = new TesterColleague(mediator);
            //mediator.Customer = customer;
            //mediator.Programmer = programmer;
            //mediator.Tester = tester;
            //customer.Send("Есть заказ, надо сделать программу");
            //programmer.Send("Программа готова, надо протестировать");
            //tester.Send("Программа протестирована и готова к продаже");

            //Console.Read();



            Manager manager = new Manager();

            Colleague client = new ClientColleague(manager);
            Colleague employee = new EmployeeColleague(true, manager);
            Colleague deliveryman = new DeliverymanColleague(manager);

            manager.Client = client;
            manager.Employee = employee;
            manager.Deliveryman = deliveryman;

            client.Send("Слышь, поищи товар на складе");
            employee.Send((employee as EmployeeColleague).IsExistenceProduct ? "Отправь по братски товар" : "Извиняй братишка, товара на складе нету");
            deliveryman.Send("Товар был отправлен, ожидайте его прибытия");

            Console.WriteLine(new string('*', 10));

            (employee as EmployeeColleague).IsExistenceProduct = false;

            client.Send("Слышь, поищи товар на складе");
            employee.Send((employee as EmployeeColleague).IsExistenceProduct ?
                "Отправь по братски товар" : "Извиняй братишка, товара на складе нету");
            deliveryman.Send("Товар был отправлен, ожидайте его прибытия");

            Console.Read();
        }
    }
}
