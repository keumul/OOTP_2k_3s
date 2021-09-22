using System;

namespace Lab3
{
    public partial class Train
    {
        //Destination, Departure time, Number of seats+.
        public override string ToString() =>
            $"Class Fields:\n" +
            $"trainID:{this.trainID}\n " +
            $"trainNumber:{this.trainNumber}\n " +
            $"destination:{this.Destination}\n" +
            $"DepartureTime:{this.DepartureTime}\n " +
            $"Number of all seats:{this.Obsh}\n " +
            $"Number of cupe seats:{this.Cupe}\n " +
            $"Number of plackart seats:{this.Plac}\n " +
            $"Number of lux seats:{this.Lux}\n " +
            $"Methods:\n " +
            $"ShowClassInfo\n " +
            $"GetNumberOfSeats\n" +
            $"GetNumberOfSeats\n" +
            $"GetNumberOfSeats\n" +
            $"CreateTrain";

        //переопределение
        public override bool Equals(object obj)
        {
            if (obj == null){ throw new NullReferenceException(); }

            Train bus = obj as Train;
            if (bus == null)
            { return false; }
            return bus.trainID == this.trainID;
        }
        //Высчитываем ID
        public override int GetHashCode()
        {
            return (int)(this.Obsh * this.DepartureTime * this.PI);
        }

    }
}
