using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace _10
{
    class Program
    {

        static void Main(string[] args)
        {

            //=========================================================================================
            //      1.Создайте класс по варианту, определите в нем свойства и методы, реализуйте
            //      указанный интерфейс и другие при необходимости, соберите объекты класса в
            //      коллекцию(можно сделать специальных класс с вложенной коллекцией и
            //      методами ею управляющими), продемонстрируйте работу с ней (добавление/ удаление / поиск / вывод
            //=========================================================================================

            var FirstCollection = new FirstCollection<GeoFigure>();
            var SecondCollection = FirstCollection;
            var geo0 = new GeoFigure[5];

            Console.WriteLine("Исходная коллекция: \n");

            FirstCollection.Add("Triangle");
            FirstCollection.Add("Square");
            FirstCollection.Add("Circle");
            Console.WriteLine("\nКоллекция после добавления элементов: ");
            FirstCollection.Print();
            
            FirstCollection.Delete(2);
            Console.WriteLine("\nКоллекция после удаления 3 элемента: ");
            FirstCollection.Print();

            //=========================================================================================
            //      2.Создайте универсальную коллекцию в соответствии с вариантом задания и
            //      заполнить ее данными встроенного типа.Net(int, char,…).
            //      a.Выведите коллекцию на консоль
            //      b.Удалите из коллекции n последовательных элементов
            //      c.Добавьте другие элементы(используйте все возможные методы добавления для вашего типа коллекции).
            //      d.Создайте вторую коллекцию(из таблицы выберите другой тип коллекции) и заполните ее данными из первой коллекции.
            //      e.Выведите вторую коллекцию на консоль.В случае не совпадения количества параметров(например, LinkedList<T> и Dictionary<Tkey,
            //      TValue>), при нехватке -генерируйте ключи, в случае избыточности – оставляйте TValue.
            //      f.Найдите во второй коллекции заданное значение.
            //=========================================================================================

            var universalCollection = new ConcurrentDictionary<string, int>();
            var secondCollection = new Dictionary<string, int>();
            universalCollection.TryAdd("Oval", 11);
            universalCollection.GetOrAdd("Cube", 12);
            foreach (var keyValuePair in universalCollection)
            {
                Console.WriteLine($"Key: {keyValuePair.Key}, Value: {keyValuePair.Value}");
            }

            int temp;
            universalCollection.TryRemove("Oval", out temp);
            Console.WriteLine($"\nПопытка удалить 'Oval': {temp}");

            foreach (var keyValuePair in universalCollection) { secondCollection.Add(keyValuePair.Key, keyValuePair.Value); }
            foreach (var keyValuePair in secondCollection) { Console.WriteLine($"Key: {keyValuePair.Key}, Value: {keyValuePair.Value}"); }

            Console.WriteLine(secondCollection.ContainsValue(14));

            //=========================================================================================
            //      3.Создайте объект наблюдаемой коллекции ObservableCollection<T>. Создайте
            //      произвольный метод и зарегистрируйте его на событие CollectionChange.
            //      Напишите демонстрацию с добавлением и удалением элементов.В качестве
            //      типа T используйте свой класс из таблицы
            //=========================================================================================
            var thisCollection = new ObservableCollection<GeoFigure>();
            thisCollection.CollectionChanged += SayChange;

            thisCollection.Add(new GeoFigure("Parallelogram"));
            thisCollection.Add(new GeoFigure("Hexagon"));
            thisCollection.Add(new GeoFigure("Trapezoid"));

            thisCollection.Remove(1);
        }
        private static void SayChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                Console.WriteLine("|Add comlete|");
            else if (e.Action == NotifyCollectionChangedAction.Remove) Console.WriteLine("|Remove complete|");
        }
    }
    public class GeoFigure
    {
        GeoFigure()
        {
        }
        string Name { get; set; } = "Default";
        public GeoFigure(string name)
        {
            Name = name;
        }

    }
    interface IEnumerator
    {

    }

    public class FirstCollection<T> : IEnumerator
    {
        private List<string> list ;
        private T[] pop;
        int count { get; set; }
        public FirstCollection()
        {
            list = new List<string>();
        }
        public void Add(string item)
        {
            list.Add(item);
            count++;
        }

        public void Delete(int index)
        {
            list.RemoveAt(index);
            count--;
        }

        public bool Remove(T item)
        {
            int numIndex = Array.IndexOf(pop, item);
            pop = pop.Where((val, idx) => idx != numIndex).ToArray();
            count--;
            return true;
        }
        public void Print()
        {
            foreach(string item in list)
            {
                Console.WriteLine(item);
            }
        }
       
    }
    
}
