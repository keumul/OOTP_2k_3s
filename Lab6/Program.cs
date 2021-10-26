using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

//1) К предыдущей лабораторной работе (л.р. 5) добавьте к существующим
//классам перечисление и структуру.

//2) Один из классов сделайте partial и разместите его в разных файлах.

//3) Определить класс-Контейнер (указан в вариантах жирным шрифтом)
//для хранения разных типов объектов (в пределах иерархии) в виде
//списка или массива (использовать абстрактный тип данных). Класс -
//контейнер должен содержать методы get и set для управления
//списком/массивом, методы для добавления и удаления объектов в
//список/массив, метод для вывода списка на консоль.

//4) Определить управляющий класс-Контроллер, который управляет
//объектом- Контейнером и реализовать в нем запросы по варианту. При
//необходимости используйте стандартные интерфейсы (IComparable,
//ICloneable,….)

//Вариант 11
//Создать частое Транспортное агентство.
//Подсчитать стоимость всех транспортных средств. Провести
//сортировку автомобилей по расходу топлива. Найти
//транспортное в компании, соответствующий заданному
//диапазону параметров скорости.

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Organization organization = new Organization("Meow Intertaiment", 12345);
                Car a = new Car(new CarE(), 220, 200);
                Train b = new Train(new TrainE(), 220, 200);

                //--------------------------Проверка на ошибочки--------------------------------

                // Organization a1 = new Organization("", 123); //- отсутствует имя
                // Car c = new Car(new CarE(), -1, 200); // - масса меньше 0
                // Train d = new Train(new TrainE(), 220, -1); // - 0 вагонов 

                //------------------------------------------------------------------------------

                //organization.Add(a);
                //organization.Add(b);

                //перечисление enum
                TypeOfCar type;
                type = TypeOfCar.Audi;
                Console.WriteLine(type);

                // 3)Определить класс-Контейнер(указан в вариантах жирным шрифтом) для хранения разных типовобъектов
                // (в пределах иерархии)  в виде списка или массива (использовать абстрактный тип данных).
                // Класс-контейнер  должен  содержать  методы  get  и  set  для управления списком/массивом,  методы  для добавления
                // и  удаления  объектов  в список/массив, метод для вывода списка на консоль. 

                var firstItem = new Agency(1110, "Weekls");
                var secondItem = new Agency(22000, "Audi");
                var thirdItem = new Agency(10500, "Nisan");
                var fourthItem = new Agency(11230, "JerJery");
                var fifthItem = new Agency(2800, "KatKaty");

                var agenncy = new Agency(1200, "Meow", firstItem, secondItem, thirdItem);
                agenncy.PrintAgencyList();
                agenncy.Delete(firstItem);
                agenncy.PrintAgencyList();
                agenncy.Add(fourthItem);
                agenncy.Add(fifthItem);
                agenncy.Add(firstItem);
                agenncy.PrintAgencyList();

                //4) Определить управляющий класс-Контроллер, который управляет
                //объектом- Контейнером и реализовать в нем запросы по варианту. При
                //необходимости используйте стандартные интерфейсы (IComparable,
                //ICloneable,….)

                var controller = new Controller();
            
                foreach (var item in controller.SearchByWeightAgency(agenncy, 100, 2500)) Console.WriteLine(item.ToString());

                //---------------------------------------ДОПЫ---------------------------------------------------------------------------
                /*1.  Добавьте  в  класс-контроллер  метод,  считывающий  построчно текстовый файл, в котором хранятся данные вашего класса и инициализирует таким образом коллекцию*/
                var agency = new Agency(1200, "Meow");
                controller.CreateAgencyFromTextFile(agency);
                agency.PrintAgencyList();
                /*2. Реализуйте еще один метод, который будет считывать данные из json файла и инициализировать коллекцию (https://www.newtonsoft.com/json).*/
                var agencyy = new Agency();
                controller.CreateAgencyFromJSONFile(agencyy);
                agencyy.PrintAgencyList();

            }
            //отлавливаем ошибки разных типов
            catch (Organization_Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message} in Class {ex.ErrorClass}, Name: {ex.ErrorName}, ID: {ex.ErrorId}");
            }
            catch (Vehicle_Exсeption ex)
            {
                Console.WriteLine($"Error: {ex.Message} - {ex.ErrorWeight}");
            }
            catch (Custom_Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}, in Class {ex.ErrorClass}");
            }
            //catch (Exception ex)
            //{

            //}
            finally
            {
                Console.WriteLine("[finally]");
            }
            Console.ReadKey();
        }
    }
}
