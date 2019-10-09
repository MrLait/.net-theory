﻿using System;
using System.Collections.Generic;
using System.Threading;
// Этот класс нужен для поддержания безопасности типа
// и кода при использовании EventSet
public sealed class EventKey : Object { }
public sealed class EventSet
{
    // Закрытый словарь служит для отображения EventKey -> Delegate
    private readonly Dictionary<EventKey, Delegate> m_events =
        new Dictionary<EventKey, Delegate>();
    // Добавление отображения EventKey -> Delegate, если его не существует
    // И компоновка делегата с существующим ключом EventKey
    public void Add(EventKey eventKey, Delegate handler)
    {
        Monitor.Enter(m_events);
        Delegate d;
        m_events.TryGetValue(eventKey, out d);
        m_events[eventKey] = Delegate.Combine(d, handler);
        Monitor.Exit(m_events);
    }
    // Удаление делегата из EventKey (если он существует)
    // и разрыв связи EventKey -> Delegate при удалении последнего делегата
    public void Remove(EventKey eventKey, Delegate handler)
    {
        Monitor.Enter(m_events);
        Delegate d;
        if (m_events.TryGetValue(eventKey, out d))
        {
            d = Delegate.Remove(d, handler);
            // Если делегат остается, то установить новый ключ EventKey,
            // иначе – удалить EventKey
            if (d != null) m_events[eventKey] = d;
            else m_events.Remove(eventKey);
        }
        Monitor.Exit(m_events);
    }
    // Информирование о событии для обозначенного ключа EventKey
    public void Raise(EventKey eventKey, Object sender, EventArgs e)
    {
        // Не выдавать исключение при отсутствии ключа EventKey
        Delegate d;
        Monitor.Enter(m_events);
        m_events.TryGetValue(eventKey, out d);
        Monitor.Exit(m_events);
        if (d != null)
        {
            // Из-за того что словарь может содержать несколько разных типов
            // делегатов, невозможно создать вызов делегата, безопасный по
            // отношению к типу, во время компиляции. Я вызываю метод
            // DynamicInvoke типа System.Delegate, передавая ему параметры метода
            // обратного вызова в виде массива объектов. DynamicInvoke будет
            // контролировать безопасность типов параметров для вызываемого
            // метода обратного вызова. Если будет найдено несоответствие типов,
            // выдается исключение.
            d.DynamicInvoke(new Object[] { sender, e });
        }
    }
}
// Определение типа, унаследованного от EventArgs для этого события
public class FooEventArgs : EventArgs { }
public class TypeWithLotsOfEvents
{
    // Определение закрытого экземплярного поля, ссылающегося на коллекцию.
    // Коллекция управляет множеством пар "Event/Delegate"
    // Примечание: Тип EventSet не входит в FCL,
    // это мой собственный тип
    private readonly EventSet m_eventSet = new EventSet();
    // Защищенное свойство позволяет производным типам работать с коллекцией
    protected EventSet EventSet { get { return m_eventSet; } }
    #region Code to support the Foo event (repeat this pattern for additional events)
    // Определение членов, необходимых для события Foo.
    // 2a. Создайте статический, доступный только для чтения объект
    // для идентификации события.
    // Каждый объект имеет свой хеш-код для нахождения связанного списка
    // делегатов события в коллекции.
    protected static readonly EventKey s_fooEventKey = new EventKey();
    // 2b. Определение для события методов доступа для добавления
    // или удаления делегата из коллекции.
    public event EventHandler<FooEventArgs> Foo
    {
        add { m_eventSet.Add(s_fooEventKey, value); }
        remove { m_eventSet.Remove(s_fooEventKey, value); }
    }
    // 2c. Определение защищенного виртуального метода On для этого события.
    protected virtual void OnFoo(FooEventArgs e)
    {
        m_eventSet.Raise(s_fooEventKey, this, e);
    }
    // 2d. Определение метода, преобразующего входные данные этого события
    public void SimulateFoo() { OnFoo(new FooEventArgs()); }
    #endregion
}

public sealed class Program
{
    public static void Main()
    {
        TypeWithLotsOfEvents twle = new TypeWithLotsOfEvents();

        // Добавление обратного вызова
        twle.Foo += HandleFooEvent;

        // Проверяем работоспособность
        twle.SimulateFoo();
    }
    private static void HandleFooEvent(object sender, FooEventArgs e)
    {
        Console.WriteLine("Handling Foo Event here...");
    }
}