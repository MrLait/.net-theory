using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Windows;

namespace Ch_14_CharStringsAndWordProcessing
{
    public class Program
    {
        public static void Main()
        {
            CharGetNumericValue();
            CharThreeWayToConvert();

            StringIntert();

            // Следующая строка содержит комбинированные символы
            String s = "a\u0304\u0308bc\u0327";
            SubstringByTextElements(s);
            EnumTextElements(s);
            EnumTextElementIndexes(s);
        }

        public static void CharGetNumericValue()
        {
            Double d; // '\u0033' – это "цифра 3"
            d = Char.GetNumericValue('\u0033'); // Параметр '3'
                                                // даст тот же результат
            Console.WriteLine(d.ToString()); // Выводится "3"
                                             // '\u00bc' — это "простая дробь одна четвертая ('1/4')"
            d = Char.GetNumericValue('\u00bc');
            Console.WriteLine(d.ToString()); // Выводится "0.25"
                                             // 'A' — это "Латинская прописная буква A"
            d = Char.GetNumericValue('A');
            Console.WriteLine(d.ToString()); // Выводится "-1"
        }

        public static void CharThreeWayToConvert()
        {
            Char c;
            Int32 n;

            // Преобразование "число - символ" посредством приведения типов C#
            c = (Char)65;
            Console.WriteLine(c); // Выводится "A"
            n = (Int32)c;
            Console.WriteLine(n); // Выводится "65"
            c = unchecked((Char)(65536 + 65));
            Console.WriteLine(c); // Выводится "A"

            // Преобразование "число - символ" с помощью типа Convert
            c = Convert.ToChar(65);
            Console.WriteLine(c); // Выводится "A"
            n = Convert.ToInt32(c);
            Console.WriteLine(n); // Выводится "65"
            // Демонстрация проверки диапазона для Convert
            try
            {
                c = Convert.ToChar(70000); // Слишком много для 16 разрядов
                Console.WriteLine(c); // Этот вызов выполняться НЕ будет
            }
            catch (OverflowException)
            {
                Console.WriteLine("Can't convert 70000 to a Char.");
            }

            // Преобразование "число - символ" с помощью интерфейса IConvertible
            c = ((IConvertible)65).ToChar(null);
            Console.WriteLine(c); // Выводится "A"
            n = ((IConvertible)c).ToInt32(null);
            Console.WriteLine(n); // Выводится "65"
        }

        public static void StringDeclaration()
        {
            /*
            String s = new String("Hi there."); // Ошибка
            Console.WriteLine(s);
            */

            String sOne = "Hi there.";
            Console.WriteLine(sOne);

            // String содержит символы конца строки и перевода каретки
            String sTwo = "Hi\r\nthere.";

            /*Чтобы приведенный код работал на любой платформе, перепишите
            его следующим образом:*/
            String sThree = "Hi" + Environment.NewLine + "there.";

            // Конкатенация трех литеральных строк образует одну литеральную строку
            String sFour = "Hi" + " " + "there.";

        }

        public static void StringVerbatimStrings()
        {
            // Задание пути к приложению
            String fileOne = "C:\\Windows\\System32\\Notepad.exe";

            // Задание пути к приложению с помощью буквальной строки
            String fileTwo = @"C:\Windows\System32\Notepad.exe";
        }

        public static void StringImmutableStrings()
        {
            String s = "asdasdads.EXE";
            if (s.ToUpperInvariant().Substring(10, 21).EndsWith("EXE"))
                s = s;

        }

        public static void StringCultureInfo()
        {
            String s1 = "Strasse";
            String s2 = "Straße";
            Boolean eq;

            // CompareOrdinal возвращает ненулевое значение
            eq = String.Compare(s1, s2, StringComparison.Ordinal) == 0;
            Console.WriteLine("Ordinal comparison: '{0}' {2} '{1}'", s1, s2, eq ? "==" : "!=");

            // Сортировка строк для немецкого языка (de) в Германии (DE)
            CultureInfo ci = new CultureInfo("de-DE");
            // Compare возвращает нуль
            eq = String.Compare(s1, s2, true, ci) == 0;
            Console.WriteLine("Cultural comparison: '{0}' {2} '{1}'", s1, s2, eq ? "==" : "!=");

            /*
            В результате компоновки и выполнения кода получим следующее:
            Ordinal comparison: 'Strasse' != 'Straße'
            Cultural comparison: 'Strasse' == 'Straße'
             */
        }

        public static void StringCompareInfo()
        {
            String output = String.Empty;
            String[] symbol = new String[] { "<", "=", ">" };
            Int32 x;
            CultureInfo ci;

            // Следующий код демонстрирует, насколько отличается результат
            // сравнения строк для различных региональных стандартов
            String s1 = "coté";
            String s2 = "côte";

            // Сортировка строк для французского языка (Франция)
            ci = new CultureInfo("fr-FR");
            x = Math.Sign(ci.CompareInfo.Compare(s1, s2));
            output += String.Format("{0} Compare: {1} {3} {2}", ci.Name, s1, s2, symbol[x + 1]);
            output += Environment.NewLine;

            // Сортировка строк для японского языка (Япония)
            ci = new CultureInfo("ja-JP");
            x = Math.Sign(ci.CompareInfo.Compare(s1, s2));
            output += String.Format("{0} Compare: {1} {3} {2}", ci.Name, s1, s2, symbol[x + 1]);
            output += Environment.NewLine;

            // Сортировка строк по региональным стандартам потока
            ci = Thread.CurrentThread.CurrentCulture;
            x = Math.Sign(ci.CompareInfo.Compare(s1, s2));
            output += String.Format("{0} Compare: {1} {3} {2}", ci.Name, s1, s2, symbol[x + 1]);
            output += Environment.NewLine + Environment.NewLine;

            // Следующий код демонстрирует использование дополнительных возможностей
            // метода CompareInfo.Compare при работе с двумя строками
            // на японском языке
            // Эти строки представляют слово "shinkansen" (название
            // высокоскоростного поезда) в разных вариантах письма:
            // хирагане и катакане
            s1 = " "; // ("\u3057\u3093\u304b\u3093\u305b\u3093")
            s2 = " "; // ("\u30b7\u30f3\u30ab\u30f3\u30bb\u30f3")

            // Результат сравнения по умолчанию
            ci = new CultureInfo("ja-JP");
            x = Math.Sign(String.Compare(s1, s2, true, ci));
            output += String.Format("Simple {0} Compare: {1} {3} {2}", ci.Name, s1, s2, symbol[x + 1]);
            output += Environment.NewLine;

            // Результат сравнения, который игнорирует тип каны
            CompareInfo compareInfo = CompareInfo.GetCompareInfo("ja-JP");
            x = Math.Sign(compareInfo.Compare(s1, s2, CompareOptions.IgnoreKanaType));
            output += String.Format("Advanced {0} Compare: {1} {3} {2}", ci.Name, s1, s2, symbol[x + 1]);
            Console.WriteLine(output, "Comparing Strings For Sorting");
            MessageBox.Show(output, "Comparing Strings For Sorting");
        }

        static void StringIntert()
        {
            String s1 = "Hello";
            String s2 = "Hello";
            Console.WriteLine(Object.ReferenceEquals(s1, s2)); // Должно быть 'False'

            s1 = String.Intern(s1);
            s2 = String.Intern(s2);
            Console.WriteLine(Object.ReferenceEquals(s1, s2)); // 'True'

            /*
            Однако если выполнить этот код в CLR
            версии 4.5, будет выведено значение True. Дело в том, что эта версия 
            CLR игнорирует атрибут/флаг, созданный компилятором C#
             */
        }

        private static Int32 NumTimesWordAppearsEquals(String word, String[] wordlist)
        {
            Int32 count = 0;

            for (Int32 wordnum = 0; wordnum < wordlist.Length; wordnum++)
            {
                if (word.Equals(wordlist[wordnum], StringComparison.Ordinal))
                    count++;
            }

            return count;
        }

        private static Int32 NumTimesWordAppearsIntern(String word, String[] wordlist)
        {
            // В этом методе предполагается, что все элементы в wordlist
            // ссылаются на интернированные строки
            word = String.Intern(word);

            Int32 count = 0;

            for (Int32 wordnum = 0; wordnum < wordlist.Length; wordnum++)
            {
                if (Object.ReferenceEquals(word, wordlist[wordnum]))
                    count++;
            }

            return count;
        }


        private static void SubstringByTextElements(String s)
        {
            String output = String.Empty;
            StringInfo si = new StringInfo(s);

            for (Int32 element = 0; element < si.LengthInTextElements; element++)
            {
                output += String.Format
                (
                    "Text element {0} is '{1}'{2}", element, si.SubstringByTextElements(element, 1), Environment.NewLine
                );
            }

            MessageBox.Show(output, "Result of SubstringByTextElements");
        }
        private static void EnumTextElements(String s)
        {
            String output = String.Empty;
            TextElementEnumerator charEnum = StringInfo.GetTextElementEnumerator(s);

            while (charEnum.MoveNext())
            {
                output += String.Format
                (
                    "Character at index {0} is '{1}'{2}", charEnum.ElementIndex, charEnum.GetTextElement(), Environment.NewLine
                );
            }

            MessageBox.Show(output, "Result of GetTextElementEnumerator");
        }
        private static void EnumTextElementIndexes(String s)
        {
            String output = String.Empty;
            Int32[] textElemIndex = StringInfo.ParseCombiningCharacters(s);

            for (Int32 i = 0; i < textElemIndex.Length; i++)
            {
                output += String.Format
                (
                    "Character {0} starts at index {1}{2}", i, textElemIndex[i], Environment.NewLine
                );
            }

            MessageBox.Show(output, "Result of ParseCombiningCharacters");
        }

        private static void StringBuildderDeclarete()
        {
            StringBuilder sb = new StringBuilder();
            String s = sb.AppendFormat("{0} {1}", "Jeffrey", "Richter").Replace(' ', '-').Remove(4, 3).ToString();
            Console.WriteLine(s); // "Jeff-Richter"
        }

        static void StringBuilderWorkWithString()
        {
            // Создаем StringBuilder для операций со строками
            StringBuilder sb = new StringBuilder();

            // Выполняем ряд действий со строками, используя StringBuilder
            sb.AppendFormat("{0} {1}", "Jeffrey", "Richter").Replace(" ", "-");

            // Преобразуем StringBuilder в String,
            // чтобы сделать все символы прописными
            String s = sb.ToString().ToUpper();

            // Очищаем StringBuilder (выделяется память под новый массив Char)
            sb.Length = 0;

            // Загружаем строку с прописными String в StringBuilder
            // и выполняем остальные операции
            sb.Append(s).Insert(8, "Marc-");

            // Преобразуем StringBuilder обратно в String
            s = sb.ToString();

            // Выводим String на экран для пользователя
            Console.WriteLine(s); // "JEFFREY-Marc-RICHTER"
        }

        static void StringDecimalFormating()
        {
            Decimal priceOne = 123.54M;
            String sOne = priceOne.ToString("C", new CultureInfo("vi-VN"));
            MessageBox.Show(sOne);

            Decimal price = 123.54M;
            String s = price.ToString("C", CultureInfo.InvariantCulture);
            MessageBox.Show(s);
        }

        static void StringFormatInLine()
        {
            String sOne = String.Format("On {0}, {1} is {2} years old.", new DateTime(2012, 4, 22, 14, 35, 5), "Aidan", 9);
            Console.WriteLine(sOne);

            String s = String.Format("On {0:D}, {1} is {2:E} years old.", new DateTime(2012, 4, 22, 14, 35, 5), "Aidan", 9);
            Console.WriteLine(s);
        }

        public static void GetBoldInt32s()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(new BoldInt32s(), "{0} {1} {2:M}", "Jeff", 123, DateTime.Now);
            Console.WriteLine(sb);
        }

        public static void GetParseOne()
        {
            /* генерируется исключение System.FormatException, так как в начале 
            разбираемой строки находится пробел:

            Int32 x = Int32.Parse(" 123", NumberStyles.None, null);
            */

            /*Чтобы «пропустить» пробел, надо вызвать Parse с другим параметром style:*/
            Int32 xOne = Int32.Parse(" 123", NumberStyles.AllowLeadingWhite, null);

            /*Вот пример синтаксического разбора строки шестнадцатеричного числа:*/
            Int32 x = Int32.Parse("1A", NumberStyles.HexNumber, null);
            Console.WriteLine(x); // Отображает "26".
        }


        public static void StringEncoding()
        {
            // Кодируемая строка
            String s = "Hi there.";

            // Получаем объект, производный от Encoding, который "умеет" выполнять
            // кодирование и декодирование с использованием UTF-8
            Encoding encodingUTF8 = Encoding.UTF8;

            // Выполняем кодирование строки в массив байтов
            Byte[] encodedBytes = encodingUTF8.GetBytes(s);

            // Показываем значение закодированных байтов
            Console.WriteLine("Encoded bytes: " + BitConverter.ToString(encodedBytes));

            // Выполняем декодирование массива байтов обратно в строку
            String decodedString = encodingUTF8.GetString(encodedBytes);

            // Показываем декодированную строку
            Console.WriteLine("Decoded string: " + decodedString);
        }

        public static void DecoddingStringInBase64()
        {
            // Получаем набор из 10 байт, сгенерированных случайным образом
            Byte[] bytes = new Byte[10];
            new Random().NextBytes(bytes);

            // Отображаем байты
            Console.WriteLine(BitConverter.ToString(bytes));

            // Декодируем байты в строку в кодировке base-64 и выводим эту строку
            String s = Convert.ToBase64String(bytes);
            Console.WriteLine(s);

            // Кодируем строку в кодировке base-64 обратно в байты и выводим их
            bytes = Convert.FromBase64String(s);
            Console.WriteLine(BitConverter.ToString(bytes));
        }

        public static void StringSecureString()
        {
            using (SecureString ss = new SecureString())
            {
                Console.Write("Please enter password: ");

                while (true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);

                    if (cki.Key == ConsoleKey.Enter)
                        break;

                    // Присоединить символы пароля в конец SecureString
                    ss.AppendChar(cki.KeyChar);
                    Console.Write("*");
                }

                Console.WriteLine();

                // Пароль введен, отобразим его для демонстрационных целей
                DisplaySecureString(ss);
            }

            // После 'using' SecureString обрабатывается методом Disposed,
            // поэтому никаких конфиденциальных данных в памяти нет
        }

        // Этот метод небезопасен, потому что обращается к неуправляемой памяти
        private unsafe static void DisplaySecureString(SecureString ss)
        {
            Char* pc = null;
            try
            {
                // Дешифрование SecureString в буфер неуправляемой памяти
                pc = (Char*)Marshal.SecureStringToCoTaskMemUnicode(ss);
                // Доступ к буферу неуправляемой памяти,
                // который хранит дешифрованную версию SecureString
                for (Int32 index = 0; pc[index] != 0; index++)
                    Console.Write(pc[index]);
            }
            finally
            {
                // Обеспечиваем обнуление и освобождение буфера неуправляемой памяти,
                // который хранит расшифрованные символы SecureString
                if (pc != null)
                    Marshal.ZeroFreeCoTaskMemUnicode((IntPtr)pc);
            }
        }
    }

    internal sealed class BoldInt32s : IFormatProvider, ICustomFormatter
    {
        public Object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) 
                return this;
            return Thread.CurrentThread.CurrentCulture.GetFormat(formatType);
        }

        public String Format(String format, Object arg, IFormatProvider formatProvider)
        {
            String s;
            IFormattable formattable = arg as IFormattable;

            if (formattable == null) 
                s = arg.ToString();
            else 
                s = formattable.ToString(format, formatProvider);

            if (arg.GetType() == typeof(Int32))
                return "<B>" + s + "</B>";

            return s;
        }
    }


}