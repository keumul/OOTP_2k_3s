using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    //информация из 5 лабораторной
    public class Car
    {
        public string Name { get; set; }
        public int Lenght { get; set; }
        public int Weight { get; set; }
        public Car()
        {
            Name = "Mazda";
        }

        public Car(string name, int lenght, int weight)
        {
            Name = name;
            Lenght = lenght;
            Weight = weight;
        }
    }
}
