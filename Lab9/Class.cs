using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9
{
    class Class
    {
        public static void Work(int experience) => Console.WriteLine($"Пользователь работает {experience} дней.");
        public static void Upgrade(int levelup)
        {
            Console.WriteLine($"Пользователь продвинулся до {levelup} уровня");
        }
        public static void PrintSomething(string message) 
        {
            Console.WriteLine(message);
        }
    }
}
