
using System;
namespace Lab4
{
    public class Owner
    {
        private readonly int id;
        private readonly string fio;
        private readonly string org;

        public Owner(int id, string fio, string org)
        {
            this.id = id;
            this.fio = fio;
            this.org = org;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Owner – ID: {id}, FIO: {fio}, Organisation: {org}.");
        }
    }
}