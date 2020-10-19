﻿using SOLID._5.DependencyInversionPrinciple.GoodPractice.Interfaces;
using System;

namespace SOLID._5.DependencyInversionPrinciple.GoodPractice.Models
{
    class ConsolePrinter : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine("Печать на консоли");
        }
    }
}
