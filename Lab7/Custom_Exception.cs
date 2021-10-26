using System;
namespace Lab5
{
    class Custom_Exception : Exception 
    {
        public string ErrorClass { get; set; }

        public Custom_Exception(string message, string errorClass)
            : base(message) // сообщение об ошибке Класса
        {
            this.ErrorClass = errorClass;
        }
    }
}

