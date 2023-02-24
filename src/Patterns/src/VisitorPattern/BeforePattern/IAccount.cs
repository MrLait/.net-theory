using System;

namespace VisitorPattern.BeforePattern
{
    interface IAccount
    {
        void ToHtml();
    }
    // физическое лицо
    class Person : IAccount
    {
        public string FIO { get; set; } //Фамилия Имя Отчество
        public string AccNumber { get; set; } // номер счета

        public void ToHtml()
        {
            string result = "<table><tr><td>Свойство<td><td>Значение</td></tr>";
            result += "<tr><td>FIO<td><td>" + FIO + "</td></tr>";
            result += "<tr><td>Number<td><td>" + AccNumber + "</td></tr></table>";
            Console.WriteLine(result);
        }
    }
    // юридическое лицо
    class Company : IAccount
    {
        public string Name { get; set; } // название
        public string RegNumber { get; set; } // гос регистрационный номер
        public string Number { get; set; } // номер счета

        public void ToHtml()
        {
            string result = "<table><tr><td>Свойство<td><td>Значение</td></tr>";
            result += "<tr><td>Name<td><td>" + Name + "</td></tr>";
            result += "<tr><td>RegNumber<td><td>" + RegNumber + "</td></tr>";
            result += "<tr><td>Number<td><td>" + Number + "</td></tr></table>";
            Console.WriteLine(result);
        }
    }
}
