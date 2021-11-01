using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Lab4
{
    class Program
    {
        
        
       
        //----------------------------------------------------------------------------
        //1. Создайте обобщенный интерфейс с операциями добавить, удалить, просмотреть
        //----------------------------------------------------------------------------
        public interface GenerInter<T>   // Обобщенный интерфейс
        {
            void Add(T var);      // Добавить элемент в конец массива
            void Delete(int var); // Удалить элемент с позиции var
        }

        //----------------------------------------------------------------------------
        //2. Возьмите за основу лабораторную № 4 «Перегрузка операций» и
        //сделайте из нее обобщенный тип(класс) CollectionType<T>, в который
        //вложите обобщённую коллекцию.Наследуйте в обобщенном классе интерфейс
        //из п.1. Реализуйте необходимые методы(добавления, удаления, поиска по предикату).
        //----------------------------------------------------------------------------
                                               /*ограничение обобщений */
        public class CollectionType<T> : GenerInter<T> //where T : new()
        {
            private int size;
            public List<T> items;
            public CollectionType()
            {
                items = new List<T>();
            }
            public void Print()
            {
                foreach (T item in items)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }
            public void Add(T var)
            {
                items.Add(var);
                size++;
            }

            public void Delete(int index)
            {
                
                try
                {
                    items.RemoveAt(index);
                    size--;
                }
                catch 
                {
                    Console.Write("Удалить значение можно только в пределах заданного диапазона [0-"+size+"]");
                }

                //----------------------------------------
                // Добавьте обработку исключений c finally.
                //----------------------------------------
                finally
                {
                    Console.Write("[finally]");
                }
            }
        }

        static void Main(string[] args)
        {

            //----------------------------------------------------------------------------
            //3.Проверьте использование обобщения для стандартных типов данных(в качестве
            //стандартных типов использовать целые, вещественные и т.д.).
            //----------------------------------------------------------------------------
            CollectionType<int> colInt = new CollectionType<int>();
            CollectionType<float> colFloat = new CollectionType<float>();
            CollectionType<double> colDouble = new CollectionType<double>();
            CollectionType<string> colString = new CollectionType<string>();

            Console.Write("Данные до преобразований: ");
            colInt.Print();

            Console.Write("Данные после добавления значений: \n");
            colInt.Add(1);
            colInt.Add(2);
            colInt.Add(3);
            colInt.Print();

            Console.Write("Данные после удаления 0го элемента: \n");
            colInt.Delete(0);
            Console.Write("\n");
            colInt.Print();

            //------------------------------------------------------------------------
            //2.Возьмите за основу лабораторную № 4 «Перегрузка операций» и
            //сделайте из нее обобщенный тип(класс) CollectionType<T>, в который
            //вложите обобщённую коллекцию.
            //------------------------------------------------------------------------
            CollectionType<Owner> collectCompany = new CollectionType<Owner>();
            collectCompany.Add(new Owner(123, "SEI", "KateCompany"));

            //------------------------------------------------------------------------
            //4.Определить пользовательский класс, который будет использоваться в
            //качестве параметра обобщения. Для пользовательского типа взять класс из
            //лабораторной №5 «Наследование». 
            //------------------------------------------------------------------------
            CollectionType<Car> CarList = new CollectionType<Car>();
            CarList.Add(new Car("Pejo", 175, 115));
            CarList.Add(new Car("Nisan", 185, 125));

            //------------------------------------------------------------------------
            //5.Добавьте методы сохранения объектов обобщённого типа
            //CollectionType<T> в файл и чтения из него(на выбор: текстовый | xml | json).
            //------------------------------------------------------------------------

            //string writePath = @"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\8\8\4\Text.txt";

            //using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            //{
            //    foreach (T item in items)
            //    {
            //        sw.WriteLine(item);
            //    }
            //    sw.WriteLine();
            //}
            //Console.WriteLine("Запись выполнена");
        }
    }
}