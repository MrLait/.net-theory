using System;

namespace StatePattern.RefactoringGuru
{
    // Базовый класс Состояния объявляет методы, которые должны реализовать все
    // Конкретные Состояния, а также предоставляет обратную ссылку на объект
    // Контекст, связанный с Состоянием. Эта обратная ссылка может
    // использоваться Состояниями для передачи Контекста другому Состоянию.
    abstract class State
    {
        protected Context _context;

        public void SetContext(Context context)
        {
            _context = context;
        }

        public abstract void Handle1();

        public abstract void Handle2();
    }

    // Конкретные Состояния реализуют различные модели поведения, связанные с
    // состоянием Контекста.
    class ConcreteStateA : State
    {
        public override void Handle1()
        {
            Console.WriteLine("ConcreteStateA handles request1.");
            Console.WriteLine("ConcreteStateA wants to change the state of the context.");
            _context.TransitionTo(new ConcreteStateB());
        }

        public override void Handle2()
        {
            Console.WriteLine("ConcreteStateA handles request2.");
        }
    }

    class ConcreteStateB : State
    {
        public override void Handle1()
        {
            Console.Write("ConcreteStateB handles request1.");
        }

        public override void Handle2()
        {
            Console.WriteLine("ConcreteStateB handles request2.");
            Console.WriteLine("ConcreteStateB wants to change the state of the context.");
            _context.TransitionTo(new ConcreteStateA());
        }
    }

}
