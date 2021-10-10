using System;
namespace Lab5
{
    //АКТИВНОСТЬ МАШИН
    public class CarE : Interface_Engine 
    {
        public int HorsePower { get; } //лошадиные силы
        public string Developer { get; } 


        public CarE()
        {
            HorsePower = 180; //кол-во лошадиных сил
            Developer = "Makar Tumenov"; 
        }

        public CarE(int horsePower, string developer)
        {
            //указатели
            this.HorsePower = horsePower; 
            this.Developer = developer;
        }

        public void Start()
        {
            Console.WriteLine("Машина заведена :)");
        }

        public void Stop()
        {
            Console.WriteLine("Машина остановлена :(");
        }
    }
}

