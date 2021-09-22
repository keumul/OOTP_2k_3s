//Создать класс Train: Пункт назначения, Номер поезда,
//Время отправления, Число мест (общих, купе, плацкарт,
//люкс). Свойства и конструкторы должны обеспечивать 
//проверку корректности. Добавить метод вывода общего 
//числа мест в поезде.

//Создать массив объектов. Вывести:
//a) список поездов, следующих до заданного пункта 
//назначения;
//b) список поездов, следующих до заданного пункта назначения 
//и отправляющихся после заданного часа;

//ВАРИАНТ 11 (в подгруппе)
using System;
using System.IO;

namespace Lab3
{
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
        public int Obsh { private get; set; }
        public int Cupe { private get; set; }
        public int Plac { private get; set; }
        public int Lux { private get; set; }
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

        public Train(string destination, string trainNumber, int obsh, int cupe, int plac, int lux, double departureTime )
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
