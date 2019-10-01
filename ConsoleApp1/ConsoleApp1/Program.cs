using System;

//Открытый тип доступен из любой сборки
public class ThisIsPublicType { }
//Внутренний тип доступен только из собственной сборки
internal class ThisIsAnInternalType { }
//Это внетренний тип т.к модификатор доступа не указан явно
class ThisIsAlsoAnInternalType { }

public sealed class SomeType
{
    //Вложенный класс
    private class SomeNestedType { };
    // Константа, неизменяемое и статическое изменяемое поле
    // Constant, readonly, and static read/write field
    private const Int32 c_SomeConstant = 1;
    private readonly String m_SomeReadOnlyField = "2";
    private static Int32 s_SomeReadWriteField = 3;
    //Конструктор типа
    static SomeType() { }
    //Конструкторы экземпляров
    public SomeType(Int32 x) { }
    public SomeType() { }
    //экземплярный и статический методы
    private String InstanceMethod() { return null; }
    public static void Main() { }
    //Необобщенное экземплярное свойство
    public Int32 SomeProp
    {
        get { return 0; }
        set { }
    }
    //Обобщенное экземплярное свойство
    public Int32 this[String s]
    {
        get { return 0; }
        set { }
    }
    //Экземплярное событие
    public event EventHandler SomeEvent;
}