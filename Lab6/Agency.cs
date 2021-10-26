using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5
{
    
    public class Agency
    {
        public List<Agency> agencyy;
        public List<Agency> AgencyList { get; private set; }
        private readonly int _budget;
        private readonly string _name;
        public int Weight { get; set; } // масса
        public Agency()
        {
            _budget = 11000;
            _name = "Weekly Idol";
            AgencyList = new List<Agency>();
        }

        public Agency(int budget)
        {
            _budget = budget;
            _name = "Idol Room";
            AgencyList = new List<Agency>();
        }

        public Agency(int budget, string name, params Agency[] items)
        {
            var agencyList = items.ToList();

            _budget = budget;
            _name = name;
           // AgencyList = agencyList;
            //CurrentCapacity = items.Length;
            //IsEquiped = CurrentCapacity >= _demandCapacity;

           // SortInventoryList();
        }
        
        public bool IsEquiped { get; private set; }

        public void PrintAgencyList()
        { 
            Console.WriteLine($"\n  Agency: budget - {_budget}, name - {_name}");
            foreach (var item in AgencyList) Console.WriteLine(item.ToString());
        }

        public void Add(Agency item)
        {

            AgencyList.Add(item);
            //SortInventoryList();
        }

        public void Delete(Agency item)
        {
            AgencyList.Remove(item);
           // SortInventoryList();
        }

        //private void SortInventoryList()
        //{
        //    AgencyList = AgencyList.OrderBy(x => x.Cost).ToList();
        //}
    }
}