using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ВАГОН
namespace Lab5
{
    
    //2) Один из классов сделайте partial и разместите его в разных файлах.
    public partial class Van
    {
        public List<Van> van;
        public int Length { get; } //длина
        public int Height { get; } //высота 

        public Van(int lenght, int height)
        {
            this.Length = lenght;
            this.Height = height;
        }
    }
}
