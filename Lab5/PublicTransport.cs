using System;
namespace Lab5
{
    class PublicTransport : Van, Interface_Express
    {

        private int dragCoef;  //коэффициент лобового сопротивления
        public int DragCoef
        {
            get => dragCoef;

            set
            {
                if (value < 25) //если меньше 25 значение, то коэффициент имеет это значение
                {
                    dragCoef = value;
                }
            }
        }

        public int NumOfPlaces { get; } //номер места
        public string Color { get; set; } //цвет вагона
        public string NameOfСonductor { get; set; } //имя кондуктора

        //одно имя-разные параметры
        public PublicTransport(int length, int heigth, int numOfPlaces, string color, string nameOfConductor)
            : base(length, heigth)
        {
            this.NumOfPlaces = numOfPlaces;
            this.Color = color;
            this.NameOfСonductor = nameOfConductor;
        }

        public PublicTransport()
            : base(10, 3)
        {
            this.NumOfPlaces = 123;
            this.Color = "Pink";
            this.NameOfСonductor = "Olga Mihailovna";
        }
        //информация о транспорте
        public void GetInfo()
        {
            Console.WriteLine("Number of Places: {0}, Color of Van: {1}, Name of conductor: {2}.", NumOfPlaces, Color, NameOfСonductor);
        }

        public string SpeedUpBy()
        {
            return "Уменьшение коэффициента сопротивления воздуха и модернизация колес";
        }

        void Interface_Express.DoSomething()
        {
            Console.WriteLine(1);
        }

        public override void DoSomething()
        {
            Console.WriteLine(2);
        }
    }
}
