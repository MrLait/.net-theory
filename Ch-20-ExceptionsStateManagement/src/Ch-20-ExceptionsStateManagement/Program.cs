using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Ch_20_ExceptionsStateManagement
{
    public class Program
    {
        public static void Main()
        {
            Demo1();
            Demo2();
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

        private static void Demo2()
        {
            // Подготавливаем код в блоке finally
            RuntimeHelpers.PrepareConstrainedRegions(); 
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


        private void SomeMethodOne()
        {
            try
            {
                // Код, требующий корректного восстановления
                // или очистки ресурсов
            }
            catch (InvalidOperationException)
            {
                // Код восстановления работоспособности
                // после исключения InvalidOperationException
            }
            catch (IOException)
            {
                // Код восстановления работоспособности
                // после исключения IOException
            }
            catch
            {
                // Код восстановления работоспособности после остальных исключений.
                // После перехвата исключений их обычно генерируют повторно
                // Эта тема будет рассмотрена позже
                throw;
            }
            finally
            {
                // Здесь находится код, выполняющий очистку ресурсов
                // после операций, начатых в блоке try. Этот код
                // выполняется ВСЕГДА вне зависимости от наличия исключения
            }
            // Код, следующий за блоком finally, выполняется, если в блоке try
            // не генерировалось исключение или если исключение было перехвачено
            // блоком catch, а новое не генерировалось
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

        public static void TextException()
        {
            try
            {
                throw new Exception<DiskFullExceptionArgs>(new DiskFullExceptionArgs(@"C:\"), "The disk is full");
            }
            catch (Exception<DiskFullExceptionArgs> e)
            {
                Console.WriteLine(e.Message);
            }
        }


        [Serializable]
        public sealed class Exception<TExceptionArgs> : Exception, ISerializable where TExceptionArgs : ExceptionArgs
        {
            private const String c_args = "Args"; // Для (де)сериализации
            private readonly TExceptionArgs m_args;

            public TExceptionArgs Args { get { return m_args; } }
            public Exception(String message = null, Exception innerException = null) : this(null, message, innerException) { }
            public Exception(TExceptionArgs args, String message = null, Exception innerException = null) : base(message, innerException)
            {
                m_args = args;
            }

            // Конструктор для десериализации; так как класс запечатан, конструктор
            // закрыт. Для незапечатанного класса конструктор должен быть защищенным
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
            private Exception(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                m_args = (TExceptionArgs)info.GetValue(
                c_args, typeof(TExceptionArgs));
            }

            // Метод для сериализации; он открыт из-за интерфейса ISerializable
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue(c_args, m_args);
                base.GetObjectData(info, context);
            }

            public override String Message
            {
                get
                {
                    String baseMsg = base.Message;
                    return (m_args == null) ? baseMsg : baseMsg + " (" + m_args.Message + ")";
                }
            }

            public override Boolean Equals(Object obj)
            {
                Exception<TExceptionArgs> other = obj as Exception<TExceptionArgs>;
                if (obj == null) return false;
                return Object.Equals(m_args, other.m_args) && base.Equals(obj);
            }

            public override int GetHashCode() => base.GetHashCode();
        }

        [Serializable]
        public abstract class ExceptionArgs
        {
            public virtual String Message { get { return String.Empty; } }
        }

        [Serializable]
        public sealed class DiskFullExceptionArgs : ExceptionArgs
        {
            private readonly String m_diskpath; // закрытое поле, задается
                                                // во время создания
            public DiskFullExceptionArgs(String diskpath) { m_diskpath = diskpath; }

            // Открытое предназначенное только для чтения свойство, которое возвращает поле
            public String DiskPath { get { return m_diskpath; } }

            // Переопределение свойства Message для включения в него нашего поля
            public override String Message
            {
                get
                {
                    return (m_diskpath == null) ? base.Message : "DiskPath=" + m_diskpath;
                }
            }
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

        public class Type2
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

    }
}