using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


namespace Lab4
{
    public class MyList
    {
        private readonly Owner owner; 
        private readonly Date date;
        private List<string> collection;

        public int Size { get; }
       
        public MyList(int ownerID, string ownerFIO, string ownerOrg )
        {
            this.owner = new Owner(ownerID, ownerFIO, ownerOrg);
            this.date = new Date();
            this.collection = new List<string>();
        }
        public List<string> GetList()
        {
            return collection;
        }

        public Owner GetOwner()
        {
            return owner;
        }

        public void AddItem(string item)
        {
            collection.Add(item);
        }

        public int GetSize()
        {
            int size = 0;
            foreach (string item in collection)
            {
                size++;
            }
            return size;
        }

        public string GetItemByIndex(int index)
        {
            if (index > this.GetSize() - 1)
                throw new Exception("GetItemByIndex: OutOfRange");

            int size = -1;
            foreach (string item in collection)
            {
                size++;
                if (size == index)
                    return item;
            }
            return "";
        }

        public override bool Equals(object obj)
        {
            if (obj is MyList)
            {
                MyList tmp = (MyList)obj;

                foreach (string item1 in this.collection)
                {
                    foreach (string item2 in tmp.collection)
                    {
                        if (item1 != item2)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            int counter = 0;
            foreach (string item in collection)
            {
                counter += item.Length;
            }

            return counter * this.GetSize();
        }

        //public void WriteToFile<T>()
        //{
        //    using (StreamWriter sw = new StreamWriter(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\8\8\4\Text.txt"))
        //    {
        //        var temp = Head;
        //        while (temp.Next != null)
        //        {
        //            sw.Write($"{temp.Data} --> ");
        //            temp = temp.Next;
        //        }
        //        sw.WriteLine(temp.Data);
        //    }
        //}
        //public T[] ReadFromFile<T>()
        //{
        //    using (StreamReader sr = new StreamReader(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\8\8\4\Text.txt"))
        //    {
        //        string[] items = sr.ReadToEnd().Split(" => ");

        //        T[] outputItems = new T[items.Length];

        //        int counter = 0;
        //        foreach (string item in items)
        //        {
        //            outputItems[counter] = (T)Convert.ChangeType(item, typeof(T));
        //            counter++;
        //        }

        //        return outputItems;
        //    }
        //}
        public static MyList operator +(MyList list, string item)
        {
            list.collection.Add(item);
            return list;
        }

        public static MyList operator +(MyList listOne, MyList listTwo)
        {
            foreach (string item in listTwo.collection)
            {
                listOne.AddItem(item);
            }

            return listOne;
        }

        public static MyList operator --(MyList list)
        {
            list.collection.RemoveAt(list.GetSize() - 1);
            return list;
        }
        
        public static bool operator !=(MyList listOne, MyList listTwo)
        {
            foreach (string item1 in listOne.collection)
            {
                foreach (string item2 in listTwo.collection)
                {
                    if (item1 != item2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
        public static bool operator ==(MyList listOne, MyList listTwo)
        {
            foreach (string item1 in listOne.collection)
            {
                foreach (string item2 in listTwo.collection)
                {
                    if (item1 != item2)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public class Date
        {
            public readonly DateTime time;

            public Date()
            {
                time = DateTime.Now;
            }
        }
    }
}