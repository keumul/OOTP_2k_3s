using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Задайте массив типа string, содержащий 12 месяцев (June, July, May,
            //December, January ….). Используя LINQ to Object напишите запрос выбирающий 
            //последовательность месяцев с длиной строки равной n, запрос возвращающий 
            //только летние и зимние месяцы, запрос вывода месяцев в алфавитном порядке,
            //запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4-х..

            string[] Array = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

            var len = from item in Array
                      where item.Length == 5
                      select item;
            Console.WriteLine("\n[len]\n");
            foreach (string item in len)
            {
                Console.WriteLine(item);
            }

            var sesons = from item in Array
                                where item.Equals("Июнь") || item.Equals("Июль") || item.Equals("Август") || item.Equals("Ноябрь") || item.Equals("Декабрь") || item.Equals("Январь")
                                select item;
            Console.WriteLine("\n[seson]\n");
            foreach (string item in sesons)
            {
                Console.WriteLine(item);
            }

            var alphabet = from item in Array
                           orderby item //сортировка по возрастанию
                           select item;
            Console.WriteLine("\n[alphabet]\n");
            foreach (string item in alphabet)
            {
                Console.WriteLine(item);
            }

            var special = from item in Array
                          where item.Contains("ь") && item.Length > 4
                          select item;
            Console.WriteLine("\n[special]\n");
            foreach (string item in special)
            {
                Console.WriteLine(item);
            }


            //2. Создайте коллекцию List<T> и параметризируйте ее типом (классом) 
            //из лабораторной №3 (при необходимости реализуйте нужные интерфейсы). 
            //Заполните ее минимум 10 элементами. 
            //Если в задании указано свойство, которым ваш класс не обладает, то его 
            //нужно расширить, чтобы класс соответствовал условию. Один из запросов 
            //реализуйте используя язык LINQ и используя методы расширения LINQ.

            List<Train> train = new List<Train>();
            
            train.Add(new Train());
            train.Add(new Train("Minsk", "12345", 50, 15, 15, 20, 12.00 ));
            train.Add(new Train("Brest", "6789", 50, 20, 15, 15, 2.00));
            train.Add(new Train("Vitebsk", "123789", 50, 12, 18, 20, 18.00));
            train.Add(new Train("Gomel", "98765", 60, 25, 15, 20, 6.00));
            train.Add(new Train("Grodno", "54321", 50, 20, 10, 20, 8.00));
            train.Add(new Train("Minsk", "54321", 50, 20, 10, 20, 8.00));
            //3. На основе LINQ сформируйте следующие запросы по вариантам. 
            //При необходимости добавьте в класс T (тип параметра) свойства.

            //        Вывести:
            //            список поездов, следующих до заданного пункта назначения;
            //            список поездов, следующих до заданного пункта назначения и
            //            отправляющихся после заданного часа;
            //            максимальный поезд по количеству мест
            //            последние пять поездов по времени отправления
            //            упорядоченный список поездов по пункту назначения в
            //            алфавитном порядке

            var Where = from item in train
                        where item.Destination == "Minsk"
                        select item.Destination;

            var WhereAndWhen = from item in train
                               where item.Destination == "Minsk" && item.DepartureTime > 9.00
                               select item;

            var Max = from item in train
                      where item.Obsh == 60
                      select item;

            var Alphabet = from item in train
                           orderby item.Destination
                           select item;

            //4.Придумайте и напишите свой собственный запрос, в котором было 
            //бы не менее 5 операторов из разных категорий: условия, проекций, 
            //упорядочивания, группировки, агрегирования, кванторов и разбиения.

            var AnotherOne = from item in train
                             where item.Cupe == 15 || item.Destination == "Brest" || item.DepartureTime > 8.00
                             select item;
            var AnotherTwo = from item in train
                             orderby item.Destination
                             select item;

            Console.WriteLine("Другое: \n");
            var any = train.Any(item => item.Cupe == 15);
            Console.WriteLine(any);

            var all = train.All(item => item.Lux == 15);
            Console.WriteLine(all);

            var average = train.Average(item => item.Plac);
            Console.WriteLine(average);


            //5. Придумайте запрос с оператором Join
            List<Country> contry = new List<Country>()
        {
            new Country { Name = "Франция", Car ="Pejo" },
            new Country { Name = "Япония", Car ="Toyoto" }
        };
            List<Car> car = new List<Car>()
        {
            new Car {Name="Vag", Country="Германия"},
            new Car {Name="Honda Motor", Country="Япония"},
        };

            var result = from pl in car
                         join t in contry on pl.Country equals t.Name
                         select new { Name = pl.Name, Country = pl.Country, Car = t.Car };

            foreach (var item in result)
                Console.WriteLine($"{item.Name} - {item.Country} (также {item.Car})"); //смысла в программе нет, но как бы суть должна быть понятна
        }
    }
    class Country
    {
        public string Name { get; set; }
        public string Car { get; set; }
    }
    class Car
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    public partial class Train
        {
            //Поля
            private string trainNumber;
            private double PI = 3.14;
            private readonly int trainID;

            public static int TrainCounter { get; private set; }

            // В блоке get мы возвращаем значение поля, а в блоке set устанавливаем.
            // Параметр value представляет передаваемое значение.
            public string TrainNumber
            {
                get => trainNumber;
                set
                {
                    if (value.Length > 0)
                    {
                        trainNumber = value;
                    }
                }
            }

            public string Destination { get; set; } //пункт назначения
            public int Obsh { get; set; }
            public int Cupe { get; set; }
            public int Plac { get; set; }
            public int Lux { get; set; }
            public double DepartureTime { get; set; } //время отправления

            //Конструкторы
            static Train()
            {
                TrainCounter = 0;
            }

            //Пункт назначения, Номер поезда, Время отправления, Число мест (общих, купе, плацкарт, люкс).
            //Destination, Departure time, Number of seats (obsh, cupe, plac, lux).
            public Train()
            {
                Destination = "Default destination";
                Obsh = 0;
                Cupe = 0;
                Plac = 0;
                Lux = 0;
                DepartureTime = 0.0;

                trainID = GetHashCode();
                Train.TrainCounter++;
            }

            public Train(string destination, string trainNumber, int obsh, int cupe, int plac, int lux, double departureTime)
            {
                if (trainNumber.Length > 0)
                {
                    Destination = destination;
                    Obsh = obsh;
                    Cupe = cupe;
                    Plac = plac;
                    Lux = lux;
                    DepartureTime = departureTime;
                    trainID = GetHashCode();

                    Train.TrainCounter++;
                }
                else
                { throw new ArgumentException(); }
            }

            private Train(int busId)
            {
                Destination = "Default destination";
                Obsh = 0;
                Cupe = 0;
                Plac = 0;
                Lux = 0;
                DepartureTime = 0;

                Train.TrainCounter++;
            }


            //Методы
            public void ShowClassInfo()
            {
                Console.WriteLine(this.ToString());
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }

            //получаем кол-во мест
            public int GetNumberOfLuxSeats()
            {
                return Lux;
            }

            //Ключевое слово ref позволяет передавать аргумент (параметр) по ссылке, а не по значению.
            public static void AddTime(ref double departureTime)
            {
                //отодвигаем время отправки
                departureTime++;
            }

            //Ключевое слово out также используется для передачи аргументов (параметров) по ссылке. Оно похоже на ключевое слово ref,
            //за исключением того, что ref требует инициализации переменной перед ее передачей.
            public static void ChangeDestination(out string dest, string newDest)
            {
                //меняем место назначения
                dest = newDest;
            }

            public static Train CreateTrain(int ID)
            {
                return new Train(ID);
            }
        
    }
}
