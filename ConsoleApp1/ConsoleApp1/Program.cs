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
        e.Raise(this, ref NewMail);
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
//Уведомление о событии, безопасное в отношении потоков
public static class EventArgExtensions
{
    public static void Raise<TEventArgs>(this TEventArgs e,
        Object sender, ref EventHandler<TEventArgs> eventDelegate)
    {
        // Копирование ссылки на поле делегата во временное поле
        // для безопасности в отношении потоков
        EventHandler<TEventArgs> temp = Volatile.Read(ref eventDelegate);
        // Если зарегистрированный метод заинтересован в событии, уведомите его
        if (temp != null) temp(sender, e);
    }
}
internal sealed class Fax
{
    // Передаем конструктору объект MailManager
    public Fax(MailManager mm)
    {
        // Создаем экземпляр делегата EventHandler<NewMailEventArgs>,
        // ссылающийся на метод обратного вызова FaxMsg
        // Регистрируем обратный вызов для события NewMail объекта MailManager
        mm.NewMail += FaxMsg;
    }
    // MailManager вызывает этот метод для уведомления
    // объекта Fax о прибытии нового почтового сообщения
    private void FaxMsg(object sender, NewMailEventArgs e)
    {
        // 'sender' используется для взаимодействия с объектом MailManager,
        // если потребуется передать ему какую-то информацию

        // 'e' определяет дополнительную информацию о событии,
        // которую пожелает предоставить MailManager

        // Обычно расположенный здесь код отправляет сообщение по факсу
        // Тестовая реализация выводит информацию на консоль
        Console.WriteLine("Faxing mail message:");
        Console.WriteLine("From={0}, To={1}, Subject={2}",
        e.From, e.To, e.Subject);
    }
    // Этот метод может выполняться для отмены регистрации объекта Fax
    // в качестве получтеля уведомлений о событии NewMail
    public void Unregister(MailManager mm)
    {
        // Отменить регистрацию на уведомление о событии NewMail объекта
        mm.NewMail -= FaxMsg;
    }
}

