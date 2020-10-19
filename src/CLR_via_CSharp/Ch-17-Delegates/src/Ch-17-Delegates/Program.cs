using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;

namespace Ch_17_Delegates
{
    public class Program
    {
        // Объявление делегата; экземпляр ссылается на метод
        // с параметром типа Int32, возвращающий значение void
        internal delegate void Feedback(Int32 value);

        public static void Main()
        {
            StaticDelegateDemo();
            InstanceDelegateDemo();
            ChainDelegateDemo1(new Program());
            ChainDelegateDemo2(new Program());


            // Объявление пустой цепочки делегатов
            GetStatus getStatus = null;
            // Создание трех компонентов и добавление в цепочку
            // методов проверки их состояния
            getStatus += new GetStatus(new Light().SwitchPosition);
            getStatus += new GetStatus(new Fan().Speed);
            getStatus += new GetStatus(new Speaker().Volume);
            // Сводный отчет о состоянии трех компонентов
            Console.WriteLine(GetComponentStatusReport(getStatus));


        }

        private static void StaticDelegateDemo()
        {
            Console.WriteLine("----- Static Delegate Demo -----");
            Counter(1, 3, null);
            Counter(1, 3, new Feedback(Program.FeedbackToConsole));
            Counter(1, 3, new Feedback(FeedbackToMsgBox)); // Префикс "Program."
                                                           // не обязателен
            Console.WriteLine();
        }

        private static void InstanceDelegateDemo()
        {
            Console.WriteLine("----- Instance Delegate Demo -----");
            Program p = new Program();
            Counter(1, 3, new Feedback(p.FeedbackToFile));
            Console.WriteLine();
        }

        private static void ChainDelegateDemo1(Program p)
        {
            Console.WriteLine("----- Chain Delegate Demo 1 -----");
            Feedback fb1 = new Feedback(FeedbackToConsole);
            Feedback fb2 = new Feedback(FeedbackToMsgBox);
            Feedback fb3 = new Feedback(p.FeedbackToFile);
            Feedback fbChain = null;
            fbChain = (Feedback)Delegate.Combine(fbChain, fb1);
            fbChain = (Feedback)Delegate.Combine(fbChain, fb2);
            fbChain = (Feedback)Delegate.Combine(fbChain, fb3);
            Counter(1, 2, fbChain);
            Console.WriteLine();
            fbChain = (Feedback)
            Delegate.Remove(fbChain, new Feedback(FeedbackToMsgBox));
            Counter(1, 2, fbChain);
        }

        private static void ChainDelegateDemo2(Program p)
        {
            Console.WriteLine("----- Chain Delegate Demo 2 -----");
            Feedback fb1 = new Feedback(FeedbackToConsole);
            Feedback fb2 = new Feedback(FeedbackToMsgBox);
            Feedback fb3 = new Feedback(p.FeedbackToFile);
            Feedback fbChain = null;
            fbChain += fb1;
            fbChain += fb2;
            fbChain += fb3;
            Counter(1, 2, fbChain);
            Console.WriteLine();
            fbChain -= new Feedback(FeedbackToMsgBox);
            Counter(1, 2, fbChain);
        }

        private static void Counter(Int32 from, Int32 to, Feedback fb)
        {
            for (Int32 val = from; val <= to; val++)
            {
                // Если указаны методы обратного вызова, вызываем их
                if (fb != null)
                    fb(val);
            }
        }

        private static void FeedbackToConsole(Int32 value)
        {
            Console.WriteLine("Item=" + value);
        }

        private static void FeedbackToMsgBox(Int32 value)
        {
            MessageBox.Show("Item=" + value);
        }

        private void FeedbackToFile(Int32 value)
        {
            using (StreamWriter sw = new StreamWriter("Status", true))
            {
                sw.WriteLine("Item=" + value);
            }
        }

        // Определение делегатов, позволяющих запрашивать состояние компонентов
        private delegate String GetStatus();


        // Метод запрашивает состояние компонентов и возвращает информацию
        private static String GetComponentStatusReport(GetStatus status)
        {
            // Если цепочка пуста, ничего делать не нужно
            if (status == null)
                return null;

            // Построение отчета о состоянии
            StringBuilder report = new StringBuilder();

            // Создание массива из делегатов цепочки
            Delegate[] arrayOfDelegates = status.GetInvocationList();

            // Циклическая обработка делегатов массива
            foreach (GetStatus getStatus in arrayOfDelegates)
            {
                try
                {
                    // Получение строки состояния компонента и добавление ее в отчет
                    report.AppendFormat("{0}{1}{1}", getStatus(), Environment.NewLine);
                }
                catch (InvalidOperationException e)
                {
                    // В отчете генерируется запись об ошибке для этого компонента
                    Object component = getStatus.Target;
                    report.AppendFormat(
                    "Failed to get status from {1}{2}{0} Error: {3}{0}{0}", Environment.NewLine, ((component == null) ? "" : component.GetType() + "."),
                    getStatus.Method.Name,
                    e.Message);
                }
            }
            // Возвращение сводного отчета вызывающему коду
            return report.ToString();
        }
    }

    // Определение компонента Light
    internal sealed class Light
    {
        // Метод возвращает состояние объекта Light
        public String SwitchPosition()
        {
            return "The light is off";
        }
    }
    // Определение компонента Fan
    internal sealed class Fan
    {
        // Метод возвращает состояние объекта Fan
        public String Speed()
        {
            throw new InvalidOperationException("The fan broke due to overheating");
        }
    }
    // Определение компонента Speaker
    internal sealed class Speaker
    {
        // Метод возвращает состояние объекта Speaker
        public String Volume()
        {
            return "The volume is loud";
        }
    }

    internal sealed class AClassOne
    {
        public static void CallbackWithoutNewingADelegateObject()
        {
            ThreadPool.QueueUserWorkItem(SomeAsyncTask, 5);
        }

        private static void SomeAsyncTask(Object o)
        {
            Console.WriteLine(o);
        }
    }

    internal sealed class AClassTwo
    {
        public static void CallbackWithoutNewingADelegateObject()
        {
            ThreadPool.QueueUserWorkItem(obj => Console.WriteLine(obj), 5);
        }
    }

    internal sealed class AClass
    {
        public static void UsingLocalVariablesInTheCallbackCode(Int32 numToDo)
        {
            // Локальные переменные
            Int32[] squares = new Int32[numToDo];
            AutoResetEvent done = new AutoResetEvent(false);

            // Выполнение задач в других потоках
            for (Int32 n = 0; n < squares.Length; n++)
            {
                ThreadPool.QueueUserWorkItem(
                obj =>
                {
                    Int32 num = (Int32)obj;
                    // Обычно решение этой задачи требует больше времени
                    squares[num] = num * num;
                    // Если это последняя задача, продолжаем выполнять главный поток
                    if (Interlocked.Decrement(ref numToDo) == 0)
                        done.Set();
                },
                n);
            }
            // Ожидаем завершения остальных потоков
            done.WaitOne();
            // Вывод результатов
            for (Int32 n = 0; n < squares.Length; n++)
                Console.WriteLine("Index {0}, Square={1}", n, squares[n]);
        }
    }

}