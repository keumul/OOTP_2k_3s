using System;

namespace Lab3
{
    internal class main
    {
        private static void Main(string[] args)
        {
            Task2();
            Task3();
        }

        private static void Task2()
        {
            // 2)Создайте несколько объектов вашего типа. Выполните вызов конструкторов, свойств, методов, сравнение объекты, проверьте тип созданного объекта и т.п.

            var train_1 = new Train();
            //Пункт назначения, Номер поезда, Число мест (общих, купе, плацкарт, люкс), Время отправления
            var train_2 = new Train("Minsk", "1111", 30, 12, 8, 10, 13);

            //Равны ли train_1 и train_2?
            Console.WriteLine($"Train №1 == train №2? - {train_1.Equals(train_2)}");
            //Тип train_2
            Console.WriteLine($"Train_2 type: {train_1.GetType()}");

            train_2.ShowClassInfo();

            Console.WriteLine("Ref&Out:");
            double departureTime = train_1.DepartureTime;
            Train.AddTime(ref departureTime);
            train_1.DepartureTime = departureTime;
            Console.WriteLine(train_1.DepartureTime);

            Train.ChangeDestination(out string dest, "Grodno");
            train_1.Destination = dest;
            Console.WriteLine(train_1.Destination);
        }

        private static void Task3()
        {
            /*Создайте  массив  объектов  вашего  типа. И  выполните задание, выделенное курсивом в таблице*/
            var Trains = new Train[3];
            Trains[0] = new Train("Minsk", "1111", 30, 12, 12, 6, 13.30);
            Trains[1] = new Train("Brest", "2222", 30, 14, 6, 10, 18.00);
            Trains[2] = new Train("Minsk", "3333", 30, 10, 19, 1, 08.25);

            // a) список поездов, следующих до заданного пункта назначения;
            foreach (var train in Trains)
                if (train.Destination == "Minsk")
                    Console.WriteLine(train.TrainNumber);

            // b) список поездов, следующих до заданного пункта назначения
            // и отправляющихся после заданного часа

            foreach (var train in Trains)
                if (train.DepartureTime > 10.00)
                  { Console.WriteLine(train.TrainNumber); }
        }

        private static void Task4()
        {
            //Создайте и выведите анонимный тип(по образцу вашего класса)
            var dest = new { City = "Minsk", Station = "Vostok" };
            Console.WriteLine($"City: {dest.City}\n" + $"Station: {dest.Station}\n");
        }
    }
}
