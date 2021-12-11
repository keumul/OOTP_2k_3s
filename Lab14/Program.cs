using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.
            var car = new CarE(15, "Kate");
            CarE ForBinary = new CarE();
            Serializer.SerializeBinary(car);
            Serializer.DeserializeBinary(ref ForBinary);
            Console.WriteLine($"[bin] {ForBinary.ToString()} {ForBinary.FieldToBeNotSeriazable}");

            CarE ForSOAP = new CarE();
            Serializer.SerializeSoap(car);
            Serializer.DeserializeSoap(ref ForSOAP);
            Console.WriteLine($"[soap] {ForSOAP.ToString()} {ForSOAP.FieldToBeNotSeriazable}");

            CarE ForXML = new CarE();
            Serializer.SerializeXml(car);
            Serializer.DeserializeXml(ref ForXML);
            Console.WriteLine($"[xml] {ForXML.ToString()} {ForXML.FieldToBeNotSeriazable}");

            CarE ForJSON = new CarE();
            Serializer.SerializeJson(car);
            Serializer.DeserializeJson(ref ForJSON);
            Console.WriteLine($"[json] {ForJSON.ToString()} {ForJSON.FieldToBeNotSeriazable}");

            //2
            //2.Создайте коллекцию(массив) объектов и выполните
            //сериализацию / десериализацию.
            //* Усложненное задание:
            //Создайте клиент и сервер на синхронных сокетах.
            //Нужно сериализованные данные(объект) отправить по сокету и
            //десериализовать на стороне клиента.

            var items = new List<Interface_Engine>();
            var itemsFile = new List<Interface_Engine>();
            
            var first = new CarE(120, "Kate");
            var second = new CarE(123, "Sasha");
            var third = new CarE(126, "Nastya");

            items.Add(first);
            items.Add(second);
            items.Add(third);

            Serializer.SerializeJson(items);
            Serializer.DeserializeJson(ref itemsFile);

            foreach(var engine in itemsFile)
            {
                Console.WriteLine(engine.ToString());
            }

            //3.Используя XPath напишите два селектора для вашего XML документа.

            XmlDocument xml = new XmlDocument();
            xml.Load(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\14\14\14\Xml.xml");
            var xRoot = xml.DocumentElement;

            var selectNodes = xRoot.SelectNodes("*"); //"*" выбор всех дочерних узлов текущего узла
            foreach (object node in selectNodes) Console.WriteLine((node as XmlNode).Name);

            Console.WriteLine();
            var nameNodes = xRoot.SelectNodes("Name");
            foreach (object nameNode in nameNodes) Console.WriteLine((nameNode as XmlNode).InnerText);

            //4.Используя Linq to XML(или Linq to JSON) создайте новый xml(json) -
            //документ и напишите несколько запросов.

            XDocument Pencils = new XDocument();
            XElement root = new XElement("Карандаши");

            XElement pencil;
            XElement color;
            XAttribute id;

            pencil = new XElement("pencil");
            color = new XElement("color");
            color.Value = "Голубой";
            id = new XAttribute("id", "123");
            
            pencil.Add(color);
            pencil.Add(id);
            root.Add(pencil);

            pencil = new XElement("pencil");
            color = new XElement("color");
            color.Value = "Молочный";
            id = new XAttribute("id", "124");

            pencil.Add(color);
            pencil.Add(id);
            root.Add(pencil);

            Pencils.Add(root);
            Pencils.Save(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\14\14\14\NewXml.xml");

            Console.WriteLine("Введите id карандаша для поиска цвета: ");
            string idXML = Console.ReadLine();
            var allPencils = root.Elements("pencil");

            foreach (var item in allPencils)
            {
                if(item.Attribute("id").Value == idXML)
                {
                    Console.WriteLine(item.Value);
                }
            }


        }
    }

    //1. Из лабораторной №5 выберите класс с наследованием и/или
    //композицией/агрегацией для сериализации. Выполните
    //сериализацию/десериализацию объекта используя форматы:
    //a.Binary,
    //b.SOAP,
    //c.JSON,
    //d.XML.
    //Запретите сериализацию одного из членов вашего класса и
    //продемонстрируйте отсутствие данного элемента в результате работы
    //сериализаторов

//* Усложненное задание:
//Создайте класс CustomSerializer, который обеспечивает сериализацию и
//десериализацию любых объектов любых типов всеми
//вышеперечисленными способами.Интерфейс класса и параметры
//методов продумайте самостоятельно.
    class Serializer
    {
        public static void SerializeBinary<T>(T obj) where T:class
        {
            var formatter = new BinaryFormatter();
    //FileMode.OpenOrCreate "указывает, что операционная система должна открыть файл, если он существует; в противном случае должен быть создан новый файл"
            using (var fs = new FileStream(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\14\14\14\Binary.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }

        public static void DeserializeBinary<T>(ref T cont) where T : class
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\14\14\14\Binary.bin", FileMode.OpenOrCreate))
            {
                cont = formatter.Deserialize(fs) as T;
            }
        }

        public static void SerializeSoap<T>(T obj) where T : class
        {
            var formatter = new SoapFormatter();
            using (var fs = new FileStream(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\14\14\14\Soap.soap", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }

        public static void DeserializeSoap<T>(ref T cont) where T : class
        {
            var formatter = new SoapFormatter();
            using (var fs = new FileStream(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\14\14\14\Soap.soap", FileMode.OpenOrCreate))
            {
                cont = formatter.Deserialize(fs) as T;
            }
        }


        public static void SerializeXml<T>(T obj) where T : class 
        {
            var formatter = new XmlSerializer(typeof(T));
            using (var fs = new FileStream(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\14\14\14\Xml.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }

        public static void DeserializeXml<T>(ref T cont) where T : class
        {
            var formatter = new XmlSerializer(typeof(T));
            using (var fs = new FileStream(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\14\14\14\Xml.xml", FileMode.OpenOrCreate))
            {
                cont = formatter.Deserialize(fs) as T;
            }
        }

        public static void SerializeJson<T>(T obj) where T : class
        {
            var sett = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            string serializing = JsonConvert.SerializeObject(obj, sett);
            using (var fs = new StreamWriter(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\14\14\14\Json.json"))
            {
                fs.Write(serializing);
            }
        }

        public static void DeserializeJson<T>(ref T cont) where T : class
        {
            var sett = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            using (var fs = new StreamReader(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\14\14\14\Json.json"))
            {
                string json = fs.ReadToEnd();
                cont = JsonConvert.DeserializeObject<T>(json, sett);
            }
        }
    }
    
}
