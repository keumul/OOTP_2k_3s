using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{ 
    //запуск машин
    interface Interface_Engine
    {
        int HorsePower { get; }

        void Start();
        void Stop();
    }
}