using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public class MyArray
    {
        static bool cont;
        static bool retryBool;
        public static void Main()
        {
            Task2();

        }

        public static void Task2()
        {
            cont = false;
            var b = new MyArray(0);

            do
            {

                Console.Write(
                    "\n\nВведите через ПРОБЕЛ количество переменных в массиве и \n(при желании) начальное значение массива и значение шага, \nна которое увеличатся остальные значения переменных: ");
                var userVaule = Console.ReadLine();
                try
                {

                    var a = Array.ConvertAll(userVaule.Split(' '), int.Parse);
                    if (a[0] < 1)
                    {
                        errMsg("Размер массива не может быть меньше 1");
                        continue;
                    }

                    if (a.Length == 1)
                    {
                        b = new MyArray(a[0]);
                    }
                    else if (a.Length == 3)
                    {
                        b = new MyArray(a[0], a[1], a[2]);
                    }
                    else
                    {
                        errMsg("Введите 1 или 3 переменные");
                        continue;
                    }

                    Console.Clear();
                    cont = true;
                }
                catch
                {
                    try
                    {
                        if (File.Exists(userVaule))
                        {
                            b = new MyArray(userVaule);
                        }
                        else
                        {
                            errMsg("Файл не найден");
                            continue;
                        }
                    }
                    catch
                    {
                        errMsg("Неизвестная ошибка");
                        continue;
                    }

                    Console.Clear();
                    cont = true;
                }
            } while (!cont);

            var next = false;
            var multiNum = 0;
            do
            {
                Console.Clear();
                Console.Write("Ваш массив: ");
                b.Print();
                Console.WriteLine($"\n\nКоличество положительных чисел в массиве: {b.CountPositiv}");
                Console.WriteLine($"\nМинимальное значение в массиве: {b.Min}");
                Console.WriteLine($"\nМаксимальных чисел: {b.MinCount()}");
                Console.WriteLine($"\nМаксимальное значение в массиве: {b.Max}");
                Console.WriteLine($"\nМаксимальных чисел: {b.MaxCount()}");
                Console.WriteLine($"\nСумма всех элементов массива равна : {b.Sum}");
                var c = b.CopyTo(b);
                Console.WriteLine("\nТеперь я сделал ваш массив отрицательным: ");
                c.Negative();
                c.Print();
                Console.Write("\n\nВведите число, на которое будет умножен каждый элемент массива: ");
                try
                {
                    multiNum = int.Parse(Console.ReadLine());
                    next = true;
                }
                catch
                {
                    next = false;
                }


                b.Multi(multiNum);
                Console.WriteLine($"\nВсе эелементы были умножены на {multiNum}, теперь массива стал таким:\n");
                b.Print();
                var brEx = false;
                do
                {
                    
                    Console.WriteLine(
                        "Введите путь до файла, в который вы хотите сохранить массив. Если не желаете этого делать, введите 'Exit'\nПуть(или Exit):");
                    var text = Console.ReadLine();
                    if (text == "Exit")
                    {
                        next = true;
                        break;
                    }
                    else
                    {
                        try
                        {
                            b.WriteMyArray(text);
                            
                            next = true;
                            break;
                        }
                        catch
                        {
                            brEx = false;
                        }
                        
                        
                    }
                    Console.Clear();

                } while (brEx);

            } while (!next);





            ExitTask();
        }

        private int[] a;

        private static void errMsg(string s)
        // Сообщение об ошибке
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 23, 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
            cont = false;

        }

        public MyArray CopyTo(MyArray arr)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                a[i] = arr[i];
            }

            return new MyArray(a);
        }

        private static void ExitTask()
        // Запрос при выходе
        {
            do
            {
                int retryNum;
                Console.WriteLine("1) Повторить задание.\n2) Возврат к главному меню.");
                try
                {
                    retryNum = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    retryNum = 0;
                }

                switch (retryNum)
                {
                    case 1:
                        Console.Clear();
                        Task2();
                        break;
                    case 2:
                        Console.Clear();
                        retryBool = false;
                        break;
                    default:
                        Console.Clear();
                        retryBool = true;
                        break;
                }
            } while (retryBool);

            retryBool = false;
        }

        public MyArray(int[] b)
        // Пустой конcтруктор
        {
            a = new int[b.Length];
            b.CopyTo(a, 0);
        }

        public MyArray(int n, int startNum, int stepNum)
        // Создание массива указанного размера заполняющийся числами от начального значения с заданным шагом.
        {
            a = new int[n];

            for (int i = 0, j = startNum; i < a.Length; i++, j += stepNum)
            {
                a[i] = j;
            }
        }

        public MyArray(int n)
        // Создание и заполнение массива случайными числами от 1 до 100 (включительно)
        {

            var rnd = new Random();
            a = new int[n];
            for (var i = 0; i < n; i++)
            {
                a[i] = rnd.Next(1, 101);
            }
        }

        public void WriteMyArray(string s)
        {
            var strArr = new string[a.Length];

            for (var i = 0; i < a.Length; i++)
            {
                strArr[i] = a[i].ToString();
            }

            try
            {
                if (!File.Exists(s))
                {
                    File.Create(s);
                }
                File.WriteAllLines(s, strArr);
            }
            catch
            {
                errMsg("Произошла ошибка");
            }
        }

        public int MaxCount()
        {
            var max = a.Max();
            var count = 0;
            foreach (var i in a)
            {
                if (i == max)
                {
                    count++;
                }
            }

            return count;
        }

        public int MinCount()
        {
            var min = a.Min();
            var count = 0;
            foreach (var i in a)
            {
                if (i == min)
                {
                    count++;
                }
            }

            return count;
        }

        public MyArray(string filename)
        // Чтение массива из файла
        {
            var ss = File.ReadAllLines(filename);
            a = new int[ss.Length];
            for (var i = 0; i < a.Length; i++)
            {
                a[i] = int.Parse(ss[i]);
            }
        }

        public int Sum
        // Сумма всех элементов массива
        {
            get
            {
                var sum = 0;
                foreach (var i in a)
                {
                    sum += i;
                }

                return sum;
            }
        }

        public void Multi(int i)
        // Умножение элементов массива на указанное число
        {
            for (var j = 0; j < a.Length; j++)
            {
                a[j] *= i;
            }
        }

        public void Negative()
        // Превращение массива в отрицательный
        {
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] > 0)
                {
                    a[i] *= -1;
                }
            }
        }

        public void Print()
        // Вывод массива
        {
            foreach (var i in a)
            {
                Console.Write($"{i} ");
            }
        }

        public int Min => a.Min(); // Вывод минимального значения в массиве

        public int Max => a.Max(); // Вывод максимального значения в массиве

        public int Length => a.Length; // Размер массива


        public int CountPositiv
        // Вывод количества положительных чисел в массиве
        {
            get
            {
                var count = 0;
                foreach (var i in a)
                {
                    if (i > 0)
                    {
                        count++;
                    }
                }

                return count;
            }
        }

        public int this[int i]
        // Индексация
        {
            get => a[i];
            set => a[i] = value;
        }

    }
}
