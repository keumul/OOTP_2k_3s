using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace Lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Определите и выведите на консоль/ в файл все запущенные процессы:id, имя, приоритет, 
            //время запуска, текущее состояние, сколько всего времени использовал процессор и т.д.
            var process = Process.GetProcesses();
            foreach(var proc in process)
            {
                try
                {
                    Console.WriteLine(
                        $"ID: {proc.Id} Имя: {proc.ProcessName} Приоритет: {proc.BasePriority}" +
                        $" Размер виртуальной памяти: {proc.VirtualMemorySize64}");
                    Console.WriteLine(
                        $" Начальное время: {proc.StartTime} Все время использования процессором: {proc.TotalProcessorTime}\n"
                        );
                }
                catch
                {
                    Console.WriteLine();
                }
            }

            //2.Исследуйте текущий домен вашего приложения: имя, детали конфигурации, все сборки,
            //загруженные в домен.Создайте новый домен.Загрузите туда сборку.Выгрузите домен.
            var domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Имя: {domain.FriendlyName}\nДетали конфигурации: {domain.SetupInformation}\nБазовые директории: {domain.BaseDirectory}\n");
            Console.WriteLine("Сборки: \n");

            foreach (var assem in domain.GetAssemblies()) 
            {
                Console.WriteLine(assem.FullName);
            }

            //var newDomain = AppDomain.CreateDomain("Domain");
            //newDomain.Load(Assembly.GetExecutingAssembly().GetName());
            //AppDomain.Unload(newDomain);

            //3.Создайте в отдельном потоке следующую задачу расчета(можно сделать sleep для
            //задержки) и записи в файл и на консоль простых чисел от 1 до n(задает пользователь). 
            //Вызовите методы управления потоком(запуск, приостановка, возобновление и т.д.) Во
            //время выполнения выведите информацию о статусе потока, имени, приоритете, числовой
            //идентификатор и т.д.
           
            var first = new Thread(SimpleNumbers);
            first.Start();
            first.Name = "SimpleNumbersThread";
            first.Join();
            Console.WriteLine();

            //4.Создайте два потока. Первый выводит четные числа, второй нечетные до n и
            //записывают их в общий файл и на консоль. Скорость расчета чисел у потоков – разная.
            //a.Поменяйте приоритет одного из потоков.
            //b.Используя средства синхронизации организуйте работу потоков, таким образом, 
            //чтобы
            //i.выводились сначала четные, потом нечетные числа
            //ii.последовательно выводились одно четное, другое нечетное.

            Console.WriteLine("\n");
            var even = new Thread(EvenNumbers) { Priority = ThreadPriority.Highest };
            var odd = new Thread(OddNumbers);
            even.Start();
            odd.Start();
            even.Join();
            odd.Join();

            Console.WriteLine("\n");
            EvenBeforeOdd();
            Console.WriteLine("\n");
            OneByOne();

            //5.Придумайте и реализуйте повторяющуюся задачу на основе класса Timer

        }
        private static void ThreadInfo(object thread)
        {
            var currentThread = thread as Thread;
            Console.WriteLine($"Имя: {currentThread.Name}");
            Console.WriteLine($"Id: {currentThread.ManagedThreadId}");
            Console.WriteLine($"Приоритет: {currentThread.Priority}");
            Console.WriteLine($"Статус: {currentThread.ThreadState}");
        }
        private static void SimpleNumbers()
        {

            var first = new Thread(ThreadInfo);
            first.Start(Thread.CurrentThread);
            first.Join();
            Console.WriteLine("Введите n: ");
            int n = int.Parse(Console.ReadLine());
            for (var i = 1; i <= n; i++)
            {
                var isSimple = true;
                for (var j = 2; j <= i / 2; j++)
                {
                    if (i % j == 0)
                    {
                        isSimple = false;
                        break;
                    }
                }

                if (isSimple)
                {
                    Console.Write($"{i}");
                }

            }
        }

        private static void OneByOne()
        {
            //инструмент управления синхронизацией потоков представляет класс Mutex
            var mutex = new Mutex();
            var even = new Thread(EvenNumbers);
            var odd = new Thread(OddNumbers);
            odd.Start();
            even.Start();
            even.Join();
            odd.Join();

            void EvenNumbers()
            {
                for (var i = 0; i < 10; i++)
                {
                    mutex.WaitOne();
                    if(i % 2 == 0)
                    {
                        Console.Write(i + " ");
                    }
                    mutex.ReleaseMutex();
                }
            }

            void OddNumbers()
            {
                for (var i = 0; i < 10; i++)
                {
                    mutex.WaitOne();
                    Thread.Sleep(100);
                    if (i % 2 != 0)
                    {
                        Console.Write(i + " ");
                    }
                    mutex.ReleaseMutex();
                }
            }
        }
        private static void EvenBeforeOdd()
        {
            // lock работает на порядки быстрее чем Mutex, но к нему невозможно получить доступ из другого процесса, а вот к Mutex ...
            var objLock = new object();
            var even = new Thread(EvenNumbers);
            var odd = new Thread(OddNumbers);
            even.Start();
            odd.Start();
            even.Join();
            odd.Join();

            void EvenNumbers()
            {
                lock(objLock)
                {
                    for(var i = 0; i < 10; i++)
                    {
                        if (i % 2 == 0)
                        {
                            Console.Write(i + " ");
                        }
                    }
                }
            }

            void OddNumbers()
            {
                for (var i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                    if (i % 2 != 0)
                    {
                        Console.Write(i + " ");
                    }
                }
            }
        }
        private static void EvenNumbers()
        {
            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                if (i % 2 == 0)
                {
                    Console.Write(i + " ");
                }
            }
        }

        private static void OddNumbers()
        {
            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                if (i % 2 != 0)
                {
                    Console.Write(i + " ");
                }
            }
        }

    }

}
