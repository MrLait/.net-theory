using System;

namespace StatePattern.RefactoringGuru
{
    // Контекст определяет интерфейс, представляющий интерес для клиентов. Он
    // также хранит ссылку на экземпляр подкласса Состояния, который отображает
    // текущее состояние Контекста.
    class Context
    {
        // Ссылка на текущее состояние Контекста.
        private State _state = null;

        public Context(State state)
        {
            TransitionTo(state);
        }

        // Контекст позволяет изменять объект Состояния во время выполнения.
        public void TransitionTo(State state)
        {
            Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
            _state = state;
            _state.SetContext(this);
        }

        // Контекст делегирует часть своего поведения текущему объекту
        // Состояния.
        public void Request1()
        {
            _state.Handle1();
        }

        public void Request2()
        {
            _state.Handle2();
        }
    }
}
