using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9
{
    //Создать класс Пользователь с событиями upgrade и work. В main
    //создать некоторое количество объектов (ПО). Подпишите объекты
    //на события произвольным образом. Реакция на события может
    //быть следующая: обновление версии, вывод сообщений и т.п.
    //Проверить результаты изменения объектов после наступления
    //событий.
    class Users
    {
        public const int EVENTADD = 0;
        public const int EVENTMESSAGE = 1;

        public delegate void Add(int number);
        public event Add EventAdd;

        public delegate void Message(string message);
        public event Message EventMessage;

        public Add cw = Class.Work;
        public Add ncw = new Add(Class.Work);

        int LevelUp { get; set; }

        public void Call(int eventConst, int value = 0, string message = "")
        {
            switch (eventConst)
            {
                case EVENTADD:
                    {
                        EventAdd(value);
                        break;
                    }
                case EVENTMESSAGE:
                    {
                        EventMessage(message);
                        break;
                    }
            }
        }

        public static string AddDollars(string str) 
        {
            string symbol = "$";
            symbol = symbol + str + symbol;
            return symbol;
        }

        public static string ToLowerCase(string str) => str.ToLower();

        public static string WordSeparator(string str) 
        {
            string separator = "";
            foreach(char item in str)
            {
                if (item == ' ')
                {
                    separator += "|";
                }
                if (item == '!' || item == ',' || item == '.')
                {
                    continue;
                }
                separator += item;
            }
            return separator;
        }
        public static string WithoutSpaceAndSpec(string str)
        {
            string nospace = "";
            foreach (char item in str)
            {
                if (item == ' ' || item == '|')
                {
                    continue;
                }
                nospace += item;
            }
            return nospace;
        }

    }
}
