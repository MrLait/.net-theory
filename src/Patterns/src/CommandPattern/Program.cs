using CommandPattern.Metanit;
using CommandPattern.RefactoringGuru;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pult pult = new Pult(); //Invoker: инициатор команды -вызывает команду для выполнения определенного запроса
            //TV tv = new TV(); //Receiver: получатель команды. Определяет действия, которые должны выполняться в результате запроса.
            //TVOnCommand tVOnCommand = new TVOnCommand(tv); //ConcreteCommand: конкретная реализация команды, реализует метод Execute(),
            //                                               //в котором вызывается определенный метод, определенный в классе Receiver
            //pult.SetCommand(tVOnCommand); //Подкинули конкретную реализацию команд
            //pult.PressButton();
            //pult.PressUndo();

            Invoker invoker = new Invoker();
            Receiver receiver = new Receiver();
            ComplexCommand complexCommand = new ComplexCommand(receiver, "a", "b");

            invoker.SetOnStart(complexCommand);
            invoker.SetOnStart(complexCommand);
            invoker.SetOnFinish(complexCommand);

            invoker.DoSomethingImportant();

            System.Console.Read();
        }
    }
}
