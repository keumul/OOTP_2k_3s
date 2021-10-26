using System;
using System.Collections;
using System.Collections.Generic;

//ОРГАНИЗАЦИЯ ПО ПРОИЗВОДСТВУ ТРАНСПОРТНЫХ СРЕДСТВ

namespace Lab5
{
    class Organization
    {

        public struct Title
        {
            public string name;
            public int id;

            public Title(string name, int id)
            {
                if (name == "") //если имени нет, то ошибка
                {
                    throw new Organization_Exception("Организация не может не иметь имени :/", name, id);
                }
                this.name = name;
                this.id = id;
            }
        }

        public List<Vehicle> park; //создаем лист/список парк

        //перегруженные ф-ии, связанные с Организацией
        public Organization()
        {
            park = new List<Vehicle>(); 
            Title title = new Title("default", 0);
        }

        public Organization(string titleName, int titleId)
        {
            park = new List<Vehicle>();
            Title title = new Title(titleName, titleId);
        }
        //---
        //удаляем элемент с индексом index
        public void Delete(int index)
        {
            park.RemoveAt(index);
        }
        //добавляем в конец к park item
        public void Add(Vehicle item)
        {
            park.Add(item);
        }

        //получаем массу
        public int GetCommonWeight()
        {
            int commonWeight = 0;
            foreach (Vehicle item in park)
            {
                //проходимся по циклу и добавляем в commonWeight массу item
                return commonWeight += item.Weight;
            }
            return commonWeight;
        }
    }
}
