using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace Lab5
{   
    class Controller
    {
        //Подсчитать стоимость всех транспортных средств.
        //У меня нет цены транспортных средств, поэтому подсчитываем длину вагонов
        public static ArrayList NoCostButLenght(Van van, int Lenght)
        {
            ArrayList returnedArray = new ArrayList(); 
            foreach (Van item in van.van)
            {
                returnedArray.Add(item);
            }
            return returnedArray;
        }
        //поиск по обьемам  
        public static ArrayList SearchByWeight(Organization organization, int startWeight, int endWeight)
        {
            //Найти транспортное в компании, соответствующий заданному
            //диапазону параметров скорости.
            ArrayList returnedArray = new ArrayList(); //выделяем память под 
            foreach (Vehicle item in organization.park) //проходим по циклу и ищем item 
            {
                if (item.Weight > startWeight || item.Weight < endWeight)
                {
                    //если ширина элемента больше начальной ширины и меньше конечной (т.е находится в допустимых границах),
                    //то добавляем в конец этого нового листа наш item
                    returnedArray.Add(item);
                }
            }
            return returnedArray; //возвращаем наш лист
        }

        public ArrayList SearchByWeightAgency(Agency agency, int startWeight, int endWeight)
        {
            //Найти транспортное в компании, соответствующий заданному
            //диапазону параметров скорости.
            ArrayList returnedArray = new ArrayList(); //выделяем память под 
            foreach (Agency item in agency.agencyy) //проходим по циклу и ищем item 
            {
                if (item.Weight > startWeight || item.Weight < endWeight)
                {
                    //если ширина элемента больше начальной ширины и меньше конечной (т.е находится в допустимых границах),
                    //то добавляем в конец этого нового листа наш item
                    returnedArray.Add(item);
                }
            }
            return returnedArray; //возвращаем наш лист
        } 
        //ДОПЫ
        /* Добавьте  в  класс-контроллер  метод,  считывающий  построчно текстовый файл, в котором хранятся данные вашего класса и инициализирует таким образом коллекцию.*/
        public void CreateAgencyFromTextFile(Agency agency)
        {
            var stream = new StreamReader(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\6\5\text.txt");
            while (stream.ReadLine() is string line)
                switch (line)
                {
                    case "CatsInt":
                        agency.Add(new Agency());
                        break;
                    case "Invent":
                        agency.Add(new Agency());
                        break;
                    case "Weekls":
                        agency.Add(new Agency());
                        break;
                    case "Strawberry":
                        agency.Add(new Agency());
                        break;
                }
        }

        /*2. Реализуйте еще один метод, который будет считывать данные из json файла и инициализировать коллекцию*/
        public void CreateAgencyFromJSONFile(Agency agency)
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            using var stream = new StreamReader(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\6\5\text.json");
            string JsonData = stream.ReadToEnd();
            var deserializedList = JsonConvert.DeserializeObject<List<Agency>>(JsonData, settings);
            foreach (var item in deserializedList) agency.Add(item);
        }
        // Провести сортировку автомобилей по расходу топлива. (л.р 6)
        public static void SortByWeight(Organization organization)
        {
            organization.park.Sort();
        }
    }
}
