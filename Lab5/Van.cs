using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ВАГОН
namespace Lab5
{
    abstract class Van
    {
        public int Length { get; } //длина
        public int Height { get; } //высота 

        public Van(int lenght, int height)
        {
            this.Length = lenght;
            this.Height = height;
        }

        public abstract void DoSomething();
    }
}
