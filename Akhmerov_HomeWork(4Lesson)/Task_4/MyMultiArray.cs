using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    public class MyMultiArray
    {
        static bool retryBool;
        static string path = string.Empty;
        static int selFileWork = 0;

        public static void Main()
        {
            Task4();
            ExitTask();
        }

        public static void Task4()
        {
            do
            {
                Console.WriteLine("Будете ли вы работать с текстовым файлом (загрузка из файла/запись в файл)?\n0) Передумать и вернуться в главное меню\n1) Буду\n2) Продолжить без использования файлов");

                try
                {
                    selFileWork = int.Parse(Console.ReadLine());
                    if (selFileWork == 0)
                    {
                        Console.Clear();
                        break;
                    }
                    else if (selFileWork == 1)
                    {
                        FileWorking();
                        break;
                    }
                    else if (selFileWork == 2)
                    {
                        CreateMultiArray();
                        break;
                    }

                }
                catch
                {
                    Console.Clear();
                }
            } while (true);
        }

        public static void CreateMultiArray()
        // Создание двумерного массива
        {
            MyMultiArray b = new MyMultiArray();
            Console.Write("Введите через пробел 1-е и 2-е измерение двумерного массива: ");
            try
            {
                int[] i = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                b = new MyMultiArray(i[0], i[1]);
                Console.Clear();
                MultiArrAction(b);
            }
            catch
            {
                Console.Clear();
                Main();
            }
        }

        public static void MultiArrAction(MyMultiArray arr)
        // Работа с массивом
        {

            Console.WriteLine("\n\nВаш двумерный массив:");
            arr.Print();
            Console.WriteLine($"\n\nСумма всех элементов массива: {arr.MultiSum()}\n");
            var nums = arr.SumMoreThan();
            Console.WriteLine($"Сумма элементов массива, которые больше {nums[0]} - {nums[1]}");
            var indexMax = new int[2];
            arr.OutMultiMaxIndex(out indexMax);
            Console.WriteLine($"Максимальное число в массиве - {arr.MultiMax} и его индекс равен [{indexMax[0]},{indexMax[1]}]");
            var indexMin = new int[2];
            arr.OutMultiMinIndex(out indexMin);
            Console.WriteLine($"Минимальное число в массиве - {arr.MultiMin} и его индекс равен [{indexMin[0]},{indexMin[1]}]");
            if (File.Exists(path) && selFileWork == 1)
            {
                arr.WriteMyMultiArray(path);
            }

        }

        public int MultiSum()
        {

            var sum = 0;
            for (var i = 0; i < a.GetLength(0); i++)
            {
                for (var j = 0; j < a.GetLength(1); j++)
                {
                    sum += a[i, j];
                }
            }

            return sum;
        }

        public int[] SumMoreThan()
        // Сложение чисел в массиве больше случайного, взятого из массива
        {
            var rand = new Random();
            var ret = new int[2];
            ret[0] = a[rand.Next(0, a.GetLength(0)), rand.Next(0, a.GetLength(1))];

            for (var i = 0; i < a.GetLength(0); i++)
            {
                for (var j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] > ret[0])
                    {
                        ret[1] += a[i, j];
                    }
                }
            }

            return ret;
        }

        public int MultiMin
        // минимальное число в массиве
        {
            get
            {
                var min = 100;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        if (min > a[i, j])
                        {
                            min = a[i, j];
                        }
                    }
                }

                return min;
            }
        }


        public void OutMultiMaxIndex(out int[] maxIndex)
        // Индекс максимального числа в массиве
        {
            var temp = new int[2];
            var max = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (var j = 0; j < a.GetLength(1); j++)
                {
                    if (max < a[i, j])
                    {
                        max = a[i, j];
                        temp[0] = i;
                        temp[1] = j;
                    }
                }
            }

            maxIndex = temp;
        }

        public void OutMultiMinIndex(out int[] minIndex)
        // Индекс минимального значения в массиве
        {
            var temp = new int[2];
            var min = 100;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (var j = 0; j < a.GetLength(1); j++)
                {
                    if (min > a[i, j])
                    {
                        min = a[i, j];
                        temp[0] = i;
                        temp[1] = j;
                    }
                }
            }

            minIndex = temp;
        }

        public int MultiMax
        // максимальное число в массиве
        {
            get
            {
                var max = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        if (max < a[i, j])
                        {
                            max = a[i, j];
                        }
                    }
                }

                return max;
            }
        }

        private int[,] a;

        public MyMultiArray()
        {

        }

        public MyMultiArray(int fDimensLength, int sDimensLength)
        // Конструктор двумерного массива
        {
            var rnd = new Random();
            a = new int[fDimensLength, sDimensLength];
            for (var i = 0; i < fDimensLength; i++)
            {
                for (var j = 0; j < sDimensLength; j++)
                {
                    a[i, j] = rnd.Next(1, 101);
                }
            }
        }

        public MyMultiArray(string filename)
        // Чтение массива из файла
        {
            var ss = File.ReadAllLines(filename);
            a = new int[ss.Length, ss[0].Split(' ').Length];
            for (var i = 0; i < a.GetLength(0); i++)
            {
                for (var j = 0; j < a.GetLength(1); j++)
                    a[i, j] = int.Parse(ss[i].Split(' ')[j]);
            }
        }

        public void WriteMyMultiArray(string s)
        // запись массива в файл
        {
            var strArr = new string[a.GetLength(0)];

            for (var i = 0; i < a.GetLength(0); i++)
            {
                var intArr = new int[a.GetLength(1)];
                for (var j = 0; j < a.GetLength(1); j++)
                {
                    intArr[j] = a[i, j];
                }
                strArr[i] = string.Join(" ", intArr);
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

        public void Print()
        // Вывод массива
        {
            for (var i = 0; i < a.GetLength(0); i++)
            {
                for (var j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write($"{a[i, j]} ");
                }
                Console.WriteLine();
            }
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
                        Main();
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

        private static void FileWorking()
        {
            var b = new MyMultiArray();

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
                        CreateMultiArray();
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
                                    b = new MyMultiArray(path);
                                    MultiArrAction(b);
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
                                                CreateMultiArray();
                                            }
                                            else if (choiseRF == 2)
                                            {
                                                Console.Clear();
                                                Main();
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
                                CreateMultiArray();
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

        private static void errMsg(string s)
        // Сообщение об ошибке
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 23, 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
            //cont = false;
        }
    }
}
