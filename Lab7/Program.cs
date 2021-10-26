using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Organization organization = new Organization("Meow Intertaiment", 12345);
                Car a = new Car(new CarE(), 220, 200);
                Train b = new Train(new TrainE(), 220, 200);

                //--------------------------Проверка на ошибочки--------------------------------

                 Organization a1 = new Organization("", 123); //- отсутствует имя
                // Car c = new Car(new CarE(), -1, 200); // - масса меньше 0
                // Train d = new Train(new TrainE(), 220, -1); // - 0 вагонов 

                //------------------------------------------------------------------------------

                organization.Add(a);
                organization.Add(b);
                Dop();
            }

            //       1) Создайте иерархию классов исключений(собственных) – 3 типа и более.
            //          Сделайте наследование пользовательских типов исключений от
            //          стандартных классов .Net(например, Exception, IndexOutofRange).

            //       2) Смоделируйте и обработайте как минимум пять различных
            //          исключительных ситуаций на основе своих и стандартных исключений.
            //          Например, не позволять при инициализации объектов передавать
            //          неверные данные, обрабатывать ошибки при работе с памятью и ошибки
            //          работы с файлами, деление на ноль, неверный индекс, нулевой указатель
            //          и т. д.
            //       3) В конце поставьте универсальный обработчик catch.
            //       4) Используйте классический вид try-catch-finally.
            //       5) Продемонстрируйте возможность многоразовой обработки одного
            //          исключения и проброс его выше по стеку вызовов.
            //       6) Обработку исключений вынести в main.При обработке выводить
            //          специфическую информацию о месте, диагностику и причине
            //          исключения.Последним должен быть блок, который отлавливает все
            //          исключения(finally).
            //       7) Добавьте код в одной из функций макрос Assert. Объясните что он
            //          проверяет, как будет выполняться программа в случае не выполнения
            //          условия.Объясните назначение Assert.

            catch (Organization_Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message} in Class {ex.ErrorClass}, Name: {ex.ErrorName}, ID: {ex.ErrorId}");
            }
            catch (Vehicle_Exсeption ex)
            {
                Console.WriteLine($"Error: {ex.Message} - {ex.ErrorWeight}");
            }
            catch (Custom_Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}, in Class {ex.ErrorClass}");
            }
            catch
            {

            }
            finally
            {
                Console.WriteLine("[finally]");
            }
            Console.ReadKey();
            //Проверяет состояние; если условие равно false, выводит сообщения и отображает окно сообщения, которое показывает стек вызовов
            //Debug.Assert(false); 
        }

        private static void Dop()
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

            try
            {
                Organization organization = new Organization("Meow Intertaiment", 12345);

            }
            catch (Organization_Exception ex)
            {
                Logger.LogErrorinFile(ex);
                Logger.LogErrorinConsole(ex);
            }
        }
    }
}
