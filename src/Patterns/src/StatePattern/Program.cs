using StatePattern.Metanit;
using StatePattern.RefactoringGuru;
using System;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Water water = new Water(new LiquidWaterState());
            water.Heat();
            water.Frost();
            water.Frost();

            Console.WriteLine();

            State state = new ConcreteStateA();
            Context context = new Context(state);
            context.Request1();
            context.Request2();



            Console.Read();
        }
    }
}
