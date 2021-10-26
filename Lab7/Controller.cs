using System;
using System.Collections;

namespace Lab5
{
    class Controller
    {
        //поиск по обьемам  
        public static ArrayList SearchByWeight(Organization organization, int startWeight, int endWeight)
        {
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
        //сортировка по обьемам
        public static void SortByWeight(Organization organization)
        {
            organization.park.Sort();
        }
    }
}
