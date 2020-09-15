using System;
using System.Threading;

namespace Ch_11_Events
{
    internal class MailManager
    {
        // Этап 2. Определение члена-события
        public event EventHandler<NewMailEventArgs> NewMail;


        // Этап 3. Определение метода, ответственного за уведомление
        // зарегистрированных объектов о событии
        // Если этот класс изолированный, нужно сделать метод закрытым
        // или невиртуальным
        protected virtual void OnNewMail(NewMailEventArgs e)
        {
            // Сохранить ссылку на делегата во временной переменной
            // для обеспечения безопасности потоков
            Volatile.Read(ref NewMail)?.Invoke(this, e);
        }

        // Этап 4. Определение метода, преобразующего входную
        // информацию в желаемое событие
        public void SimulateNewMail(String from, String to, String subject)
        {
            // Создать объект для хранения информации, которую
            // нужно передать получателям уведомления
            NewMailEventArgs e = new NewMailEventArgs(from, to, subject);
            // Вызвать виртуальный метод, уведомляющий объект о событии
            // Если ни один из производных типов не переопределяет этот метод,
            // объект уведомит всех зарегистрированных получателей уведомления
            OnNewMail(e);
        }
    }
}
