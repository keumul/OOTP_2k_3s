using System;
namespace Lab5
{
    class Organization_Exception : Custom_Exception
    {

        public string ErrorName { get; set; } //ошибка имени
        public int ErrorId { get; set; } //ошибка id

        public Organization_Exception(string message, string errorName, int errorId)
            : base(message, "Organization") //сообщение об ошибке
        {
            this.ErrorName = errorName;
            this.ErrorId = errorId;
        }
    }
}

