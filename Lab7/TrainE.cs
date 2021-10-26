using System;
namespace Lab5
{//ДВИГАТЕЛЬ ПОЕЗДА
    public class TrainE : Interface_Engine
    {
        public int HorsePower { get; } 
        public int Waste { get; }


        public TrainE()
        {
            HorsePower = 1500;
            Waste = 50;
        }

        public TrainE(int horsePower, int waste)
        {
            this.HorsePower = horsePower;
            this.Waste = waste;
        }

        public void Start()
        {
            Console.WriteLine("Двигатель поезда работает.");
        }

        public void Stop()
        {
            Console.WriteLine("Двигатель поезда не работает.");
        }
    }
}
