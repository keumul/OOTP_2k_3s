using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//транспортное средство
namespace Lab14
{
    [Serializable]
    abstract class Vehicle
    {
        public Interface_Engine Engine { get; set; } //двигатель
        public int Weight { get; set; } // масса

        public Vehicle(Interface_Engine engine, int weight)
        {
            this.Engine = engine;
            if (weight > 0) //если масса >0
            {
                this.Weight = weight; //указатель
            }
            else
            {
                throw new Vehicle_Exсeption("Масса < 0 - error", weight);
            }
        }

        public abstract void PlaySound();
        public virtual int GetMaxSpeed() //максимальная скорость
        {
            return Engine.HorsePower / Weight; //лошадиные силы на массу
        }
    }


    //запуск машин
    interface Interface_Engine
    {
        int HorsePower { get; }

        void Start();
        void Stop();
    }

    [Serializable]
    class Vehicle_Exсeption : Custom_Exception
    {
        public int ErrorWeight { get; set; } //ошибка массы

        public Vehicle_Exсeption(string message, int errorWeight)
            : base(message, "Vehicle") //сообщение об ошибке
        {
            this.ErrorWeight = errorWeight;
        }
    }
    [Serializable]
    class Custom_Exception : Exception
    {
        public string ErrorClass { get; set; }

        public Custom_Exception(string message, string errorClass)
            : base(message) // сообщение об ошибке Класса
        {
            this.ErrorClass = errorClass;
        }
    }


}
