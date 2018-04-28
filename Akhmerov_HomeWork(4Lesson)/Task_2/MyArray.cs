namespace Task_2
{
    using System;
    using System.IO;
    using System.Linq;

    public class MyArray
    {
        static string path = string.Empty;
        static bool cont;
        static bool retryBool;
        static MyArray b = new MyArray(0);
        public static void Main()
        {
            Task2();

        }

        public static void Task2()
        {
            do
            {
                Console.WriteLine("Будете ли вы работать с текстовым файлом (загрузка из файла/запись в файл)?\n0) Передумать и вернуться в главное меню\n1) Буду\n2) Продолжить без использования файлов");

                try
                {
                    var selFileWork = int.Parse(Console.ReadLine());
                    if (selFileWork == 0)
                    {
                        Console.Clear();
                        break;
                    }
                    else if (selFileWork == 1)
                    {
                        FileWorking();
                        ExitTask();
                        break;
                    }
                    else if (selFileWork == 2)
                    {
                        ArrWork();
                        ExitTask();
                        break;
                    }
                }
                catch
                {
                    Console.Clear();
                }
            } while (true);
        }

        private static void FileWorking()
        // Работа с файлом
        {
            var exit = false;
            path = string.Empty;
            do
            {
                Console.Write(
                    "Введите путь до текстового файла куда будут сохраняться и загружаться данные из массива: ");
                path = Console.ReadLine();


                if (!File.Exists(path))
                {
                    try
                    {
                        File.Create(path);
                        Console.Clear();
                        ArrWork();
                        break;
                    }
                    catch
                    {
                        errMsg("Неизвестная ошибка");
                    }
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Хотите загрузить данные из файла?\n1) Загрузить\n2) Продолжить без загрузки");
                        try
                        {
                            var selLoadN = int.Parse(Console.ReadLine());
                            if (selLoadN == 1)
                            {

                                try
                                {
                                    Console.Clear();
                                    b = new MyArray(path);
                                    ArrAction();
                                    exit = true;
                                    break;
                                }
                                catch
                                {
                                    bool nextRF = false;
                                    do
                                    {
                                        errMsg("Массив имеет некоректные данные.");
                                        Console.WriteLine("\nОчистить файл для записи по-новой?\n1) Очистить \n2) Начать заново\n");

                                        try
                                        {
                                            var choiseRF = int.Parse(Console.ReadLine());
                                            if (choiseRF == 1)
                                            {
                                                File.Create(path);
                                                nextRF = true;
                                                exit = true;
                                                Console.Clear();
                                                ArrWork();
                                            }
                                            else if (choiseRF == 2)
                                            {
                                                Console.Clear();
                                                Task2();
                                                nextRF = true;
                                                exit = true;
                                            }
                                        }
                                        catch
                                        {
                                            nextRF = false;
                                        }
                                    } while (!nextRF);
                                }
                                Console.Clear();
                                break;
                            }
                            else if (selLoadN == 2)
                            {
                                Console.Clear();
                                ArrWork();
                                exit = true;
                                break;
                            }
                            else
                            {
                                Console.Clear();
                            }
                        }
                        catch
                        {
                            errMsg("Ошибка, попробуйте еще раз.");
                        }
                    } while (true);
                }


            } while (!exit);
        }

        private static void ArrWork()
        // Создание массива
        {
            var arrLength = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("\nСоздание массива\n");
                Console.Write("\n1) Введите размер массива: ");

                try
                {
                    arrLength = int.Parse(Console.ReadLine());
                    if (arrLength > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Размер не может быть меньше 1.");
                    }
                }
                catch
                {
                    Console.Clear();
                }
            } while (true);

            do
            {
                Console.Write("\nВведите 0 для создания массива с указанным размером (" + arrLength +
                              ").\nОн автоматически заполнится числами от 1 до 100.\nИли введите через пробел начальный элемент массива и \nзначение на которое будет увеличиваться каждое следующее значение: ");

                try
                {
                    var arrVal = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                    if (arrVal.Length == 1 && arrVal[0] == 0)
                    {
                        Console.Clear();
                        b = new MyArray(arrLength);
                        ArrAction();
                        break;
                    }
                    else if (arrVal.Length == 2)
                    {
                        Console.Clear();
                        b = new MyArray(arrLength, arrVal[0], arrVal[1]);
                        ArrAction();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        errMsg("Что-то введено неверно.");
                    }
                }
                catch
                {
                    Console.Clear();
                }
            } while (true);
        }

        private static void ArrAction()
        // Действие над массивом
        {
            var rand = new Random();
            Console.Write("\nВаш массив: ");
            b.Print();
            Console.WriteLine($"\n\nКоличество положительных чисел в массиве: {b.CountPositiv}");
            Console.WriteLine($"\nМинимальное значение в массиве: {b.Min}");
            Console.WriteLine($"\nМинимальных чисел: {b.MinCount()}");
            Console.WriteLine($"\nМаксимальное значение в массиве: {b.Max}");
            Console.WriteLine($"\nМаксимальных чисел: {b.MaxCount()}");
            Console.WriteLine($"\nСумма всех элементов массива равна : {b.Sum}");
            Console.WriteLine("\nВаш массив, умноженный на случайное число от 1 до 10:");
            b.Multi(rand.Next(1, 11));
            b.Print();
            Console.WriteLine("\n\nВаш массив, только теперь с отрицательными элементами:");
            b.Negative();
            b.Print();
            if (File.Exists(path))
            {
                b.WriteMyArray(path);
            }
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

        }

        public MyArray CopyTo(MyArray arr)
        // Копирование из класса в класс
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
                Console.WriteLine("\n\n1) Повторить задание.\n2) Возврат к главному меню.");
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
        // Конструктор с копированием
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
        // запись массива в файл
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
        // Количество максимальных значений
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
        // Количество минимальных значений
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
