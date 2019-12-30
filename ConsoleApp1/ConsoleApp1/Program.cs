using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;

public sealed class Program
{
    static void Main(string[] args)
    {
        Demo1();
        Demo2();
        //Console.ReadKey();
    }

    public sealed class Item { /* ... */ }
    //public sealed class ShoppingCart
    //{
    //    private List<Item> m_cart = new List<Item>();
    //    private Decimal m_totalCost = 0;
    //    public ShoppingCart()
    //    {
    //    }
    //    public void AddItem(Item item)
    //    {
    //        AddItemHelper(m_cart, item, ref m_totalCost);
    //    }
    //    private static void AddItemHelper(
    //    List<Item> m_cart, Item newItem, ref Decimal totalCost)
    //    {
    //        // Предусловия:
    //        Contract.Requires(newItem != null);
    //        Contract.Requires(Contract.ForAll(m_cart, s => s != newItem));
    //        // Постусловия:
    //        Contract.Ensures(Contract.Exists(m_cart, s => s == newItem));
    //        Contract.Ensures(totalCost >= Contract.OldValue(totalCost));
    //        Contract.EnsuresOnThrow<IOException>(
    //        totalCost == Contract.OldValue(totalCost));
    //        // Какие-то операции (способные сгенерировать IOException)
    //        m_cart.Add(newItem);
    //        totalCost += 1.00M;
    //    }
    //    // Инвариант
    //    [ContractInvariantMethod]
    //    private void ObjectInvariant()
    //    {
    //        Contract.Invariant(m_totalCost >= 0);
    //    }
    //}

    public static class Contract
    {
        // Методы с предусловиями: [Conditional("CONTRACTS_FULL")]
        //public static void Requires(Boolean condition);
        //public static void EndContractBlock();
        //// Предусловия: Always
        //public static void Requires<TException>(
        //Boolean condition) where TException : Exception;
        //// Методы с постусловиями: [Conditional("CONTRACTS_FULL")]
        //public static void Ensures(Boolean condition);
        //public static void EnsuresOnThrow<TException>(Boolean condition)
        //where TException : Exception;
        //// Специальные методы с постусловиями: Always
        //public static T Result<T>();
        //public static T OldValue<T>(T value);
        //public static T ValueAtReturn<T>(out T value);
        //// Инвариантные методы объекта: [Conditional("CONTRACTS_FULL")]
        //public static void Invariant(Boolean condition);
        //// Квантификаторные методы: Always
        //public static Boolean Exists<T>(
        //IEnumerable<T> collection, Predicate<T> predicate);
        //public static Boolean Exists(
        //Int32 fromInclusive, Int32 toExclusive, Predicate<Int32> predicate);
        //public static Boolean ForAll<T>(
        //IEnumerable<T> collection, Predicate<T> predicate);
        //public static Boolean ForAll(
        //Int32 fromInclusive, Int32 toExclusive,
        //Predicate<Int32> predicate);
        //// Вспомогательные методы:
        //// [Conditional("CONTRACTS_FULL")] или [Conditional("DEBUG")]
        //public static void Assert(Boolean condition);
        //public static void Assume(Boolean condition);
        // Инфраструктурное событие: обычно в коде это событие не используется
        public static event EventHandler<ContractFailedEventArgs> ContractFailed;
    }

    private static void Demo2()
    {
        // Подготавливаем код в блоке finally
        RuntimeHelpers.PrepareConstrainedRegions(); // Пространство имен
                                                    // System.Runtime.CompilerServices
        try
        {
            Console.WriteLine("In try");
        }
        finally
        {
            // Неявный вызов статического конструктора Type2
            Type2.M();
        }
    }

    private sealed class Type2
    {
        static Type2()
        {
            Console.WriteLine("Type2's static ctor called");
        }
        // Используем атрибут, определенный в пространстве имен
        // System.Runtime.ConstrainedExecution
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static void M() { }
    }

    private sealed class Type1
    {
        static Type1()
        {
            // В случае исключения M не вызывается
            Console.WriteLine("Type1's static ctor called");
        }
        public static void M() { }
    }

    private static void Demo1()
    {
        try
        {
            Console.WriteLine("In try");
        }
        finally
        {
            // Неявный вызов статического конструктора Type1
            Type1.M();
        }
    }

    private static void Reflection(Object o)
    {
        try
        {
            // Вызов метода DoSomething для этого объекта
            var mi = o.GetType().GetMethod("DoSomething");
            mi.Invoke(o, null); // Метод DoSomething может сгенерировать исключение
        }
        catch (System.Reflection.TargetInvocationException e)
        {
            // CLR преобразует его в TargetInvocationException
            throw e.InnerException; // Повторная генерация исходного исключения
        }
    }

    private static void SomeMethod7(string fileName)
    {
        try
        {
            // Какие-то операции
        }
        catch (IOException e)
        {
            // Добавление имени файла к объекту IOException
            e.Data.Add("FileName", fileName);
            throw; // повторное генерирование того же исключения
        }
    }


    private String m_pathname; // Путь к файлу с телефонами
                               // Выполнение других методов
    public String GetPhoneNumber(String name)
    {
        String phone = string.Empty;
        FileStream fs = null;
        
        try
        {
            fs = new FileStream(m_pathname, FileMode.Open);
            // Чтение переменной fs до обнаружения нужного имени
            phone = "/* номер телефона найден */";
        }
        catch (FileNotFoundException e)
        {
            // Генерирование другого исключения, содержащего имя абонента,
            // с заданием исходного исключения в качестве внутреннего

            //throw new NameNotFoundException(name, e);
        }
        catch (IOException e)
        {
            // Генерирование другого исключения, содержащего имя абонента,
            // с заданием исходного исключения в качестве внутреннего
            // throw new NameNotFoundException(name, e);
        }
        finally
        {
            if (fs != null) fs.Close();
        }

        return phone;
    }

    private void SerializeObjectGraph(FileStream fs, IFormatter formatter, Object rootObj)
    {
        // Сохранение текущей позиции в файле
        Int64 beforeSerialization = fs.Position;
        try
        {
            // Попытка сериализовать граф объекта и записать его в файл
            formatter.Serialize(fs, rootObj);
        }
        catch
        { // Перехват всех исключений
          // При ЛЮБОМ повреждении файл возвращается в нормальное состояние
            fs.Position = beforeSerialization;
            // Обрезаем файл
            fs.SetLength(fs.Position);
            // ПРИМЕЧАНИЕ: предыдущий код не помещен в блок finally,
            // так как сброс потока требуется только при сбое сериализации
            // Уведомляем вызывающий код о происходящем,
            // снова генерируя ТО ЖЕ САМОЕ исключение
            throw;
        }
    }


    private String CalculateSpreadSheetCell(Int32 row, Int32 column)
    {
        String result;
        try
        {
            result = " /* Код для расчета значения ячейки электронной таблицы */";
 }
        catch (DivideByZeroException)
        {
            result = "Нельзя отобразить значение: деление на ноль";
        }
        catch (OverflowException)
        {
            result = "Нельзя отобразить значение: оно слишком большое";
        }
        return result;
    }

    private void SomeMehod6()
    {
        using (FileStream fileStream = new FileStream(@"asdads", FileMode.Open))
        {
            // Вывод частного от деления 100 на первый байт файла
            Console.WriteLine(100 / fileStream.ReadByte());
        }
}

    private void SomeMethod5()
    {
        FileStream fileStream = new FileStream(@"C:\Data.bin", FileMode.Open);
        try
        {
            // Вывод частного от деления 100 на первый байт файла
            Console.WriteLine(100 / fileStream.ReadByte());
        }
        finally
        {
            // В блоке finally размещается код очистки, гарантирующий
            // закрытие файла независимо от того, возникло исключение
            // (например, если первый байт файла равен 0) или нет
            fileStream.Close();
        }
    }

    private void SomeMethod()
    {
        try { /*...*/ }
        catch (Exception e)
        {
            //...
            throw; // CLR не меняет информацию о начальной точке исключения.
                   // FxCop НЕ сообщает об ошибке
        }
    }

    private void SomeMethod2()
    {
        try { /*...*/ }
        catch (Exception e)
        {
            //...
            throw e; // CLR считает, что исключение возникло тут
                     // FxCop сообщает об ошибке
        }
    }

    private void SomeMethod3()
    {
        Boolean trySucceeds = false;
        try
        {
            //...
            trySucceeds = true;
        }
        finally
        {
            if (!trySucceeds) { /* код перехвата исключения */ }
        }
    }

    private void SomeMethod4()
    {
        try
        {
            // Внутрь блока try помещают код, требующий корректного
            // восстановления работоспособности или очистки ресурсов
        }
        catch (Exception e)
        {
            // До C# 2.0 этот блок перехватывал только CLS-совместимые исключения
            // В C# 2.0 этот блок научился перехватывать также
            // CLS-несовместимые исключения
            throw; // Повторная генерация перехваченного исключения
        }
        catch
        {
            // Во всех версиях C# этот блок перехватывает
            // и совместимые, и несовместимые с CLS исключения
            throw; // Повторная генерация перехваченного исключения
        }
    }

    private void ReadData(String pathname)
    {
        FileStream fs = null;
        try
        {
            fs = new FileStream(pathname, FileMode.Open);
            // Обработка данных в файле
        }
        catch (IOException)
        {
            // Код восстановления после исключения IOException
        }
        finally
        {
            // Файл обязательно следует закрыть
            if (fs != null) fs.Close();
        }
    }
}