using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//транспортное средство
namespace Lab5
{
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
}
