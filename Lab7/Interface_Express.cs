using System;
namespace Lab5
{
    //интерфейс для экспресса 
    public interface Interface_Express
    {
        int DragCoef { get; set; } //коэффициент лобового сопротивления

        string SpeedUpBy();
        void DoSomething();
    }
}
