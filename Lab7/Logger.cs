using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab5
{
    public class Logger
    {
        //Дополнительное задание
        //1. Создайте класс Logger, который будет заниматься логгированием 
        //различных событий и исключений. Логгер должен уметь логгировать
        //ошибки/исключения, предупреждения и просто какую-то информацию. 
        //2. Логгер должен записывать лог в виде: время, тип_записи_лога:
        //дополнительное сообщение. 27.10.2019 02:36, INFO: Test log message.
        //3.Создайте 2 реализации логгера: FileLogger и ConsoleLogger. FileLogger
        //будет записывать сообщения лога в файл, добавляя записи к уже существующим. 
        //ConsoleLogger – выводить сообщения на консоль. 
        //4. Добавьте в классы из л.р. 6 логгер так, чтобы его возможно было быстро 
        //заменить во время выполнения другим и вместо простого вывода на консоль 
        //сообщения об ошибке, используйте свой логгер
        public static void LogErrorinFile(Exception e)
        {
            using var stream = new StreamWriter(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\7\5\5\Text.txt", true);
            stream.WriteLine($"Time: {DateTime.Now}");
            stream.WriteLine($"Info: {e.GetType()} - {e.Message}\n");
        }
        public static void LogErrorinConsole(Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Time: {DateTime.Now}");
            Console.WriteLine($"Info: {e.GetType()} - {e.Message}");
        }
    }
}
