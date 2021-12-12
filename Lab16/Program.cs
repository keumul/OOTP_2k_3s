using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Lab16
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Используя TPL создайте длительную по времени задачу(на основе
            //Task)
            //поиск простых чисел(желательно взять «решето Эратосфена»), 
            //1) Выведите идентификатор текущей задачи, проверьте во время
            //выполнения – завершена ли задача и выведите ее статус.
            //2) Оцените производительность выполнения используя объект
            //Stopwatch на нескольких прогонах.
            
            var task1 = new Task<uint>(() => SimpleNumbers(100));
            Console.WriteLine($"Task ID: {task1.Id}, status: {task1.Status}");
            var SW = new Stopwatch();
            
            task1.Start();
            SW.Start();
            Console.WriteLine($"Task ID: {task1.Id}, status: {task1.Status}");
           
            task1.Wait();
            SW.Stop();
            Console.WriteLine($"Task ID: {task1.Id}, status: {task1.Status}");
            Console.WriteLine($"Task работает {SW.ElapsedMilliseconds} мс");
            Console.WriteLine($"Простые числа от 1 до 100: {task1.Result}");
            
            SW.Restart();
            uint mainResult = SimpleNumbers(100);
            SW.Stop();
            Console.WriteLine($"Thread работает {SW.ElapsedMilliseconds} мс ");
            Console.WriteLine($"Простые числа от 1 до 100: {mainResult}\n");

            //2.Реализуйте второй вариант этой же задачи с токеном отмены
            //CancellationToken и отмените задачу.

            var cancel = new CancellationTokenSource();
            Task task2 = Task.Factory.StartNew(SimpleNumbersCancellingToken, cancel.Token, cancel.Token);
            try
            {
                cancel.Cancel();
                task2.Wait();
            }
            catch( AggregateException e)
            {
                if(task2.IsCanceled)
                {
                    Console.WriteLine($"{task2.Id} canceled! \n");
                }
            }

            //3.Создайте три задачи с возвратом результата и используйте их для
            //выполнения четвертой задачи. Например, расчет по формуле.
            var first = new Task<int>(() => new Random().Next(1, 5) * 15);
            var second = new Task<int>(() => new Random().Next(5, 8) * 10);
            var third = new Task<int>(() => new Random().Next(1, 9) * 5);

            first.Start();
            second.Start();
            third.Start();

            first.Wait();
            second.Wait();
            third.Wait();

            var f_s_t = new Task<int>(() => first.Result + second.Result + third.Result);
            f_s_t.Start();
            Console.WriteLine($"[first + second + third = {f_s_t.Result}]");

            //4.Создайте задачу продолжения(continuation task) в двух вариантах:
            //1) C ContinueWith -планировка на основе завершения множества
            //предшествующих задач
            //2) На основе объекта ожидания и методов GetAwaiter(),GetResult();
            
            var something = new Task<int>(() => 123 + 12 + 1);
            var somethingCW = something.ContinueWith(s => Console.WriteLine($"[123 + 12 + 1 = {something.Result} (something)]"));
            something.Start();

            var something_else = new Task<int>(() => 321 + 32 + 3);
            var awaiter = something_else.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                awaiter.GetResult();
                Console.WriteLine($"Задача на основе GetAwaiter(),GetResult(): {something_else.Result}\n");
            });
            something_else.Start();
            something_else.Wait();

            //5.Используя Класс Parallel распараллельте вычисления циклов For(),
            //ForEach().Например, на выбор: обработку(преобразования)
            //последовательности, генерация нескольких массивов по 1000000
            //элементов, быстрая сортировка последовательности, обработка текстов
            //(удаление, замена). Оцените производительность по сравнению с
            //обычными циклами
            var arr1 = new int[1000000];
            var arr2 = new int[1000000];
            var arr3 = new int[1000000];

            var sw = new Stopwatch();
            sw.Start();
            Parallel.For(0, 1000000, Array);
            sw.Stop();
            Console.WriteLine($"Распараллеливанный For() работает {sw.ElapsedMilliseconds} мс");

            sw.Restart();
            for (var i = 0; i < 1000000; i++)
            {
                arr1[i] = 1;
                arr2[i] = 2;
                arr3[i] = 3;
            }
            sw.Stop();
            Console.WriteLine($"Просто For() работает {sw.ElapsedMilliseconds} мс");

            int sum = 0;
            sw.Restart();
            Parallel.ForEach(arr1, Sum);
            sw.Stop();
            Console.WriteLine($"Распараллеливанный ForEach() работает {sw.ElapsedMilliseconds} мс");

            sum = 0;
            sw.Restart();
            foreach(int item in arr1)
            {
                sum += item;
            }
            sw.Stop();
            Console.WriteLine($"Просто ForEach() работает {sw.ElapsedMilliseconds} мс");

            void Sum(int x)
            {
                sum += x;
            }

            void Array(int x)
            {
                arr1[x] = 1;
                arr2[x] = 2;
                arr3[x] = 3;
            }

            //6.Используя Parallel.Invoke() распараллельте выполнение блока
            //операторов.
            Parallel.Invoke
            (
                () => {
                    for(var i = 0; i < 1000000; i++)
                    {
                    arr1[i] = i;
                    }},

                () => {
                    for (var i = 0; i < 1000000; i++)
                    {
                        arr2[i] = i;
                    }},

                () => {
                    for (var i = 0; i < 1000000; i++)
                    {
                        arr3[i] = i;
                    }}
            );

            //7.Используя Класс BlockingCollection реализуйте следующую задачу:
            //Есть 5 поставщиков бытовой техники, они завозят уникальные товары
            //на склад(каждый по одному) и 10 покупателей – покупают все подряд, 
            //если товара нет - уходят. В вашей задаче: cпрос превышает
            //предложение.Изначально склад пустой. У каждого поставщика своя
            //скорость завоза товара. Каждый раз при изменении состоянии склада
            //выводите наименования товаров на складе.

            BlockingCollection<string> suppliers = new BlockingCollection<string>(5);
            Task[] buyers = new Task[10]
            {
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(800);
                        suppliers.Add("Пылесос");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(800);
                        suppliers.Add("Чайник");
                    }
                }),new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(800);
                        suppliers.Add("Духовой шкаф");
                    }
                }),new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(800);
                        suppliers.Add("Тостер");
                    }
                }),new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(800);
                        suppliers.Add("Миксер");
                    }
                }),new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(800);
                        suppliers.Add("Мультиварка");
                    }
                }),new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(800);
                        suppliers.Add("Микроволновая печь");
                    }
                }),new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(800);
                        suppliers.Add("Кофемолка");
                    }
                }),new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(800);
                        suppliers.Add("Стиральная машина");
                    }
                }),new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(800);
                        suppliers.Add("Посудомоечная машина");
                    }
                })
            };

            Task[] suppliers_ = new Task[5]
            {
                    new Task(() =>
                    {
                        while(true)
                        {
                            Thread.Sleep(100);
                            suppliers.Take();
                        }
                    }),
                    new Task(() =>
                    {
                        while (true)
                        {
                            Thread.Sleep(200);
                            suppliers.Take();
                        }
                    }),
                    new Task(() =>
                    {
                        while (true)
                        {
                            Thread.Sleep(300);
                            suppliers.Take();
                        }
                    }),
                    new Task(() =>
                    {
                        while (true)
                        {
                            Thread.Sleep(400);
                            suppliers.Take();
                        }
                    }),
                    new Task(() =>
                    {
                        while (true)
                        {
                            Thread.Sleep(100);
                            suppliers.Take();
                        }
                    })
            };

            foreach (var item in buyers)
            {
                if (item.Status != TaskStatus.Running)
                {
                    item.Start();
                }
            }

            foreach (var item in suppliers_)
            {
                if (item.Status != TaskStatus.Running)
                {
                    item.Start();
                }
            }

            //int count = 1;
            ////чтобы склады не зацикливались и можно было спокойно проверять последующий код
            //int stopcycle = 0;
            //while (true)
            //{
            //    if(suppliers.Count != count && suppliers.Count != 0 && stopcycle < 10)
            //    {
            //        count = suppliers.Count;
            //        Thread.Sleep(200);
            //        Console.WriteLine("\nСклад: \n");
            //        foreach (var item in suppliers)
            //        {
            //            Console.WriteLine(item);
            //        }
            //        stopcycle++;
            //    }
            //}
            
            //8.Используя async и await организуйте асинхронное выполнение любого
            //метода.
            void Summa()
            {
                int result = 1;
                for (int i = 1; i < 20; i++)
                {
                    result += i;
                }
                Thread.Sleep(500);
                Console.WriteLine($"Сумма первых 20 целых чисел: {result}");
            }
            async void AsyncSumma()
            {
                Console.WriteLine("Aсинхронное выполнение summa началось");
                await Task.Run(() => Summa());
                Console.WriteLine("Aсинхронное выполнение summa завершилось");
            }
            AsyncSumma();
            Console.ReadKey();
        }

        private static uint SimpleNumbers(uint N)
        {
            var numbers = new List<uint>();
            for(var i = 2u; i < N; i++)
            {
                numbers.Add(i);
            }
            
            for(var i = 0; i < numbers.Count; i++)
            {
                for(var j = 2u; j < N; j++)
                {
                    numbers.Remove(numbers[i] * j);
                }
            }

            return (uint)numbers.Count;
        }

        private static uint SimpleNumbersCancellingToken(object obj)
        {
            var numbers = new List<uint>();
            var token = (CancellationToken)obj;
            for (var i = 2u; i < 100; i++)
            {
                numbers.Add(i);
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                if(token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана токеном");
                    token.ThrowIfCancellationRequested();
                    return 0;
                }
                for (var j = 2u; j < 100; j++)
                {
                    numbers.Remove(numbers[i] * j);
                }
            }

            return (uint)numbers.Count;
        }
    }
}
