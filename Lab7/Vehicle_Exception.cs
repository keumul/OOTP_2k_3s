using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Vehicle_Exсeption : Custom_Exception
    {
        public int ErrorWeight { get; set; } //ошибка массы

        public Vehicle_Exсeption(string message, int errorWeight)
            : base(message, "Vehicle") //сообщение об ошибке
        {
            this.ErrorWeight = errorWeight;
        }
    }
}
