namespace Task_1
{
    using System;

    public class Task_1
    {
        static bool retryBool;
        public static void Main()
        {
            Task1();
        }

        static void Task1()
        {

            Console.Write("Нажмите Enter и программа сделает свое дело (ДЗ №4 п.1):");
            Console.ReadLine();
            ArrFindNums();
        }

        static void ArrAddNums(int[] array)
        {
            var rnd = new Random();

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-10000, 10001);
            }
        }

        static void ArrFindNums()
        {
            var fNum = 0;
            var sNum = 1;
            var count = 0;
            var arrCount = 0;
            
            var arr = new int[20];

            ArrAddNums(arr);

            while (true)
            {
                if (sNum == arr.Length)
                {
                    break;
                }
                if (arr[fNum] % 3 == 0 || arr[sNum] % 3 == 0)
                {
                    count++;
                }
                fNum++;
                sNum++;
            }

            Console.WriteLine($"\nЧисла, находящиеся в массиве:\n");

            foreach (var i in arr)
            {
                Console.Write($"{i} ");
                arrCount++;
                if (arrCount == 10)
                {
                    Console.Write("\n");
                }
            }

            Console.WriteLine($"\n\nВ массиве {count} пар с числом, которое делится на 3.\n");

            ExitTask();
        }

        private static void ExitTask()
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
                        ArrFindNums();
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
        }
    }
}

