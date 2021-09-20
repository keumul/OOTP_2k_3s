using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            types1();
            types2();
            types3();
            types4();
            types5();
            str1();
            str2();
            str3();
            str4();
            arrays1();
            arrays2();
            arrays3();
            arrays4();
            tuples();
            task6_checked();
            task6_unchecked();

        }

        // 1 ТИПЫ
        /*Определите переменные всех возможных примитивных типов С# и проинициализируйте их. Осуществите ввод и вывод их значений используя 
         консоль.*/

        static void types1()
        {
            bool a = true;
            // true - false 
            Console.WriteLine("bool a: " + a);

            byte b = 254;
            // 0 - 255
            Console.WriteLine("byte b: " + b);

            sbyte c = 126;
            //-128 - 127
            Console.WriteLine("sbyte c: " + c);

            char d = 'A';
            //16 bit 
            Console.WriteLine("char d: " + d);

            decimal e = 12345;
            //16 bytes
            Console.WriteLine("decimal e: " + e);

            double f = 12.345;
            //8 bytes
            Console.WriteLine("double f: " + f);

            float g = (float)3.4;
            //4 bytes
            Console.WriteLine("float g: " + g);

            int h = 12345;
            //32 bit
            Console.WriteLine("int h: " + h);

            uint i = 11111111;
            //unsigned 32 bit 
            Console.WriteLine("uint i: " + i);

            long j = 123456789;
            //64 bit
            Console.WriteLine("long j: " + j);

            ulong k = 123456789;
            //unsigned 64 bit
            Console.WriteLine("ulong k: " + k);

            short l = 12345;
            //16 bit 
            Console.WriteLine("short l: " + l);

            ushort m = 12121;
            //unsigned 16 bit
            Console.WriteLine("ushort m: " + m);

            Console.WriteLine("Enter a string, please:");
            string n = Console.ReadLine();
            Console.WriteLine("You're string is '" + n + "'");
        }

        /*Выполните 5 операций явного и 5 неявного приведения. Изучите возможности класса Convert.*/
        static void types2()
        {
            // Явное привидение типов
            byte n = 123;
            Console.WriteLine("(byte) " + n + " int -> " + (int)n);
            Console.WriteLine("(int) " + (int)n + " long -> " + (long)n);
            Console.WriteLine("(byte) " + n + " double -> " + (double)n);
            Console.WriteLine("(double) " + (double)n + " float -> " + (float)n);
            Console.WriteLine("(byte) " + n + " ulong -> " + (ulong)n);

            // Неявное привидение типов
            int a = 123;
            double b = a; //  int -> double
            float c = a;  //  int -> float

            double d = 12.34;
            double e = d + a;

            //  Привидение с помощью класса Convert
            // (True)
            bool f = System.Convert.ToBoolean(a);
            Console.WriteLine("Convert.ToBoolean() : " + f);

            // ("12.34")
            string g = System.Convert.ToString(d);
            Console.WriteLine("Convert.ToString() : " + g);
        }

        /*Выполните упаковку и распаковку значимых типов.*/
        static void types3()
        {
            // Упаковка-преобразование и распаковка-преобразование

            /*Упаковка - процесс преобразования типа значения в тип object или в любой другой тип интерфейса, реализуемый этим типом значения. 
             * Когда тип значения упаковывается общеязыковой средой 
             * выполнения (CLR), он инкапсулирует значение внутри 
             * экземпляра System.Object и сохраняет его в управляемой 
             * куче. Операция распаковки извлекает тип значения из объекта. 
             * Упаковка является неявной; распаковка является явной
             * . Понятия упаковки и распаковки лежат в основе единой 
             * системы типов C#, в которой значение любого типа можно 
             * рассматривать как объект.
             */

            // Упаковка
            int i = 123;
            object o = i;

            // Распаковка
            o = 123;
            i = (int)o;

            // Явная упаковка 
            o = (object)i;
        }


        /*Продемонстрируйте работу с неявно типизированной переменной.*/
        static void types4()
        {
            var a = 3; // int

            var hi = "Hello World"; // string

            var yes = true; // bool

            // Операции с неявно типизированной переменной
            if (yes) Console.WriteLine(hi + "!!!");

            var arr = new[] { 1, 2, 3 };
            foreach (var element in arr) a += element;
        }

        /*Продемонстрируйте пример работы с Nullable переменной*/
        static void types5()
        {
            // Nullable
            /* Если после типа переменной поставить ?, то это означает что эта переменная может принимать значение null*/

            int? a = null; // int a = null будет ругаться

            // если после переменной поставить ??, то она будет проверятьсяна null значение, и если оно так и есть, оно вернёт значение
            // переменной после ?? символа
            string? hi = null;
            Console.WriteLine(hi ?? "Hello World");
        }


        /*Определите переменную типа var и присвойте ей любое значение. Затем следующей инструкцией присвойте ей значение другого типа. 
          Объясните причину ошибки.*/
        static void types6()
        {
            /* 
             * var a = 123;
             * a = 12.34;
             
             * Этот код выдаст ошибку, т.к. при инициализации а в первой строке, она получает тип int и уже остаётся int
             * и неявное привидение к другому типу не будет выполнено
            */
        }


        // 2 STRING

        /*Объявите строковые литералы. Сравните их.*/
        static void str1()
        {
            string str1 = "Hello World";
            string str2 = "Hello";
            string str3 = "Hello World";

            Console.WriteLine(str1 == str2); // false
            Console.WriteLine(str1 == str3); // true
        }

        /*Создайте три строки на основе String. Выполните: сцепление, копирование, выделение подстроки, разделение строки на слова, вставки подстроки 
        в заданную позицию, удаление заданной подстроки. Продемонстрируйте интерполирование строк.*/
        static void str2()
        {
            string str1 = "Hello world. ";
            string str2 = "My name is Kate. ";
            string str3 = "I am 18. ";

            str1 += str2; // сцепление

            string str4 = str1; // копирование

            string word = str1.Substring(0, 5); // выделение подстроки и её копирование

            string[] words = str2.Split(); // разделение строки на слова
            Console.WriteLine(words[1]); // output: name

            // вставка в определенную позицию
            string message = "Hello ";
            string hi = "World";
            // Insert(pos, str);
            Console.WriteLine(message.Insert(message.Length, hi));

            // удаление
            string question = "Hey, How are you?";
            question.Remove(0, 4); // output: How are you?
                                   // или короче question.Replace("Hey, ", "");

            // интерполирование строк
            Console.WriteLine($"Hello {hi}! {str3}"); // output: Hello World! My name is Kate.
        }


        /*Создайте пустую и null строку. Продемонстрируйте использование метода string.IsNullOrEmpty. Продемонстрируйте, что еще можно 
         выполнить с такими строками*/
        static void str3()
        {
            string hi = null;
            string bye = String.Empty;

            // простейший пример использования isNullOrEmpty
            // null вернет true, empty - false
            if (String.IsNullOrEmpty(hi)) Console.WriteLine("This string is null");
            else Console.WriteLine("This string is empty");

            if (String.IsNullOrEmpty(bye)) Console.WriteLine("This string is null");
            else Console.WriteLine("This string is empty");
        }

        /*Создайте строку на основе StringBuilder. Удалите определенные позиции и добавьте новые символы в начало и конец строки.*/
        static void str4()
        {
            var sb = new System.Text.StringBuilder();

            for (int i = 0; i < 10; i++)
            {sb.Append(i);}

            Console.WriteLine(sb.ToString()); // 0123456789

            sb[5] = sb[2];

            Console.WriteLine(sb.ToString()); // 3123456789
        }



        // 3 ARRAYS
        /*Создайте целый двумерный массив и выведите его на консоль в отформатированном виде (матрица).*/

        static void arrays1()
        {
            int[,] arr = { { 1, 2, 3 }, { 3, 2, 1 }, { 1, 2, 3 } };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{arr[i, j]}\t");
                }
                Console.Write("\n");
            }
        }

        /*Создайте одномерный массив строк. Выведите на консоль его содержимое, длину массива. Поменяйте произвольный 
        элемент (пользователь определяет позицию и значение).*/
        static void arrays2()
        {
            string[] str = { "Hello", "My name is", "Kate" };
            Console.WriteLine("Содержание массива:");
            for (int i = 0; i < str.Length; i++)
                Console.WriteLine($"({i}). {str[i]}");

            Console.WriteLine("Введите номер строки, которую хотите заменить: ");
            int a = System.Convert.ToInt32(Console.ReadLine());

            if (a < str.Length)
            {
                Console.WriteLine("Напишите предложение: ");
                string answer = Console.ReadLine();
                str[a] = answer;
                for (int i = 0; i < str.Length; i++)
                    Console.WriteLine($"({i}). {str[i]}");
            }
            else Console.WriteLine("Вы ввели неправильное число :(");
        }
        
        
        /*Создайте ступечатый (не выровненный) массив вещественных чисел с 3-мя строками, в каждой из которых 2, 3 и 4 столбцов соответственно. 
         Значения массива введите с консоли.*/
        static void arrays3()
        {
            byte arraySize = 4;
            int[][] array = new int[arraySize][];

            for (int i = 0; i < arraySize; i++)
            {
                array[i] = new int[i + 1];
                Console.WriteLine($"Заполните массив {i} из {arraySize - 1}");
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write($"{array[i][j]}\t");
                }
                Console.Write("\n");
            }
        }

       /*Создайте неявно типизированные переменные для хранения массива и строки.*/
        static void arrays4()
        {
            var arr = new[] { 1, 2, 3, 4 };  // неявно типизированный массив чисел
            var str = new[] { "Hello", "World" }; // неявно типизированная строка
        }


        // 4 КОРТЕЖИ

        static void tuples()
        {

            //Задайте кортеж из 5 элементов с типами int, string, char, string, ulong.
            (int, string, char, string, ulong) tuple = (12, "str", 'a', "abcdef", 12345);
            
            //Выведите кортеж на консоль целиком и выборочно ( например 1, 3, 4 элементы)
            Console.WriteLine(tuple);
            Console.Write($"{tuple.Item1} {tuple.Item2} {tuple.Item3} {tuple.Item4} {tuple.Item5}");
           
            //Выполните распаковку кортежа в переменные. Продемонстрируйте различные способы распаковки кортежа. Продемонстрируйте
            //использование переменной(_). (доступно начиная с C#7.3)
            string hi;
            int how;

            (string hi, ushort how) hello = ("Hello", 11);

            hi = hello.hi;
            how = hello.how; // из ushort к int без потерь памяти

            (hi, _, _) = tuplesReturn(); 

            Console.WriteLine(hello == ("Hello", 11)); // true
            Console.WriteLine(hello == ("Hello", 22)); // false
        }

        static (string, ushort, char) tuplesReturn() // return info (string hi, ushort how, char lit)
        {
            return ("Hello", 33, 'a');
        }



        //  5 TASK
        /*Формальные параметры функции – массив целых и строка. Функция должна вернуть кортеж, содержащий: максимальный и минимальный 
         * элементы массива, сумму элементов массива и первую букву строки .*/

        /*(int max, int min, int sum, char firstLetter) tuple;
        int[] array = { 1, 2, 3, 4, 5, 813, 0, 738};
        string name = "Lerka";
        tuple = task5(array, name);
        Console.WriteLine($"Max num: {tuple.max}\n" +
                          $"Min num: {tuple.min}\n" +
                          $"Sum: {tuple.sum}\n" +
                          $"First letter: {tuple.firstLetter}");
        */
        // TASK 5 : LOCAL FUNCTION
        /*Формальные параметры функции – массив целых и строка. Функция должна вернуть кортеж, содержащий: максимальный и минимальный 
         * элементы массива, сумму элементов массива и первую букву строки .*/

        static (int max, int min, int sum, char letter) task5(int[] a, string str)
        {

            if ((a is null || a.Length == 0) || (str is null || str.Length == 0))
            {
                throw new ArgumentException("Array or string is null");
            }

            int min = int.MaxValue;
            int max = int.MinValue;
            int sum = 0;

            foreach (int i in a)
            {
                sum += i;

                if (i < min)
                {
                    min = i;
                }

                if (i > max)
                {
                    max = i;
                }
            }

            char letter = str[0];

            return (max, min, sum, letter);
        }


        // 6 TASK
        /*a. Определите две локальные функции.
        b. Разместите в одной из них блок checked, в котором определите переменную типа int с максимальным возможным значением этого типа. 
        Во второй функции определите блок unchecked с таким же содержимым.
        c. Вызовите две функции. Проанализируйте результат.*/
       
        static void task6_checked()
        {
            checked
            {
                int i = int.MaxValue;
            }
        }

        static void task6_unchecked()
        {
            unchecked
            {
                int i = int.MaxValue + 1;
            }
        }
}
}
