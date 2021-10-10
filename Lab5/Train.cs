using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Train : Vehicle
    {
        public int NumOfVan { get; set; }

        public Train(TrainE engine, int weight, int numOfVan)
            : base(engine, weight)
        {
            if (numOfVan < 0) //если вагона нет
            {
                throw new Custom_Exception("Должен быть хотя бы 1 вагон :( ", "Train");
            }
            this.NumOfVan = numOfVan;
        }

        public override void PlaySound() //музычка
        {
            Console.WriteLine("Собачки лают Гав-гав-гав, кошки мяукают мяу-мяу-мяяу");
        }
    }
}
