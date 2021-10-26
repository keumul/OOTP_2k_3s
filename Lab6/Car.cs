using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//МАШИНЫ

namespace Lab5
{
    //1)... добавьте к существующим классам перечисление.
    enum TypeOfCar
    {
        BMW,
        Audi,
        Honda,
        Kia,
        Mazda,
        Peugeot
    }
    class Car : Vehicle //Машина является транспортным средством 
    {
        int Length { get; } //длина 

        public Car(CarE engine, int weight, int length) //Car с параметрами двигатель, ширина, длина
            : base(engine, weight) 
        {
            if (length < 0) //если длина меньше 0 - ошибка
            {
                throw new Custom_Exception("Длина < 0 - error", "Car");
            }
            this.Length = length; // указываем на длину 
        }

        public override void PlaySound() //музычка
        {
            Console.WriteLine("Три кота, три хвоста... Два кота и одна кошечка. Мяяяу");
        }
    }
}

