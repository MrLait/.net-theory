using System;
using System.Threading;
// Этап 1. Определение типа для хранения информации,
// которая передается получателям уведомления о событии
internal class NewMailEventArgs : EventArgs
{
    private readonly String m_from, m_to, m_subject;
    public NewMailEventArgs(String from, String to, String subject)
    {
        m_from = from; m_to = to; m_subject = subject;
    }
    public String From { get { return m_from; } }
    public String To { get { return m_to; } }
    public String Subject { get { return m_subject; } }
}
// Этап 2. Определение члена-события
internal class MailManager
{
    //Здесь NewMail — имя события, а типом события 
    //является EventHandler <NewMailEventArgs>. 
    public event EventHandler<NewMailEventArgs> NewMail;

    // Этап 3. Определение метода, ответственного за уведомление
    // зарегистрированных объектов о событии
    // Если этот класс изолированный, нужно сделать метод закрытым
    // или невиртуальным
    protected virtual void OnNewMail(NewMailEventArgs e)
    {
        // Сохранить ссылку на делегата во временной переменной
        // для обеспечения безопасности потоков
        EventHandler<NewMailEventArgs> temp = Volatile.Read(ref NewMail);
        // Если есть объекты, зарегистрированные для получения
        // уведомления о событии, уведомляем их
        if (temp != null) temp(this, e);
    }
}
//Уведомление о событии, безопасное в отношении потоков
public static class EventArgExtensions
{
    public static void Raise<TEventArgs>(this EventArgs e,
        Object sender, ref EventHandler<TEventArgs> eventDelegate)
    {
        // Копирование ссылки на поле делегата во временное поле
        // для безопасности в отношении потоков
        EventHandler<TEventArgs> temp = Volatile.Read(ref eventDelegate);
        if (temp != null) temp(sender, e);
    }
}

