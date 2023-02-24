using System;

namespace CommandPattern.RefactoringGuru
{
    // Отправитель связан с одной или несколькими командами. Он отправляет
    // запрос команде.
    class Invoker
    {
        private ICommand _onStart;

        private ICommand _onFinish;

        // Инициализация команд
        public void SetOnStart(ICommand command)
        {
            _onStart = command;
        }

        public void SetOnFinish(ICommand command)
        {
            _onFinish = command;
        }

        // Отправитель не зависит от классов конкретных команд и получателей.
        // Отправитель передаёт запрос получателю косвенно, выполняя команду.
        public void DoSomethingImportant()
        {
            if (_onStart is ICommand)
            {
                _onStart.Execute();
            }

            if (_onFinish is ICommand)
            {
                _onFinish.Execute();
            }
        }
    }
}
