using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akhmerov_HomeWork_4Lesson
{
    using Task_1;
    using Task_2;
    using Task_4;
    using Task_5;
    class Start
    {
        static bool exit;
        static void Main()
        {
            while (!exit)
            {
                switch (SelectTask())
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        Task_1.Main();
                        break;
                    case 2:
                        MyArray.Main();
                        break;
                    case 4:
                        MyMultiArray.Main();
                        break;
                    case 5:
                        Doubler.Main();
                        break;
                }
            }
            ExitProg();
        }

        static int SelectTask()
        {
            int selTask;

            do
            {
                Console.WriteLine(
                    "\n\n\n0) Выход из программы\n\n1) Задание №1 (поиск пар)\n\n2) Задание №2 (Мой одномерный массив)\n\n4) Задание №4 (Мой двумерный массив)\n\n5) Задание №5 (Игра Удвоитель)\n\n");
                try
                {
                    selTask = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    selTask = 7;
                }
                Console.Clear();
            } while (selTask < 0 || selTask > 6);

            return selTask;
        }

        static void ExitProg()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 14, Console.WindowHeight / 2);
            Console.Write("Для Вас старался ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Фарит Ахмеров.\n");
            Console.ResetColor();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 + 1);
            Console.WriteLine("Для выхода нажмите 'Enter'.");

            #region Пасхалочка
            do
            {
                var cki = Console.ReadKey();
                if (cki.Key != ConsoleKey.Enter)
                {
                    Changer();
                }
                else
                {
                    break;
                }

            } while (true);
            #endregion
        }

        static void Changer()
        {
            var rnd = new Random();
            var colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
            do
            {
                Console.SetCursorPosition(rnd.Next(1, Console.WindowWidth - 2),
                    rnd.Next(1, Console.WindowHeight - 1));

            } while ((Console.CursorLeft > Console.WindowWidth / 2 - 16 &&
                      Console.CursorLeft < Console.WindowWidth / 2 + 18)
                     && (Console.CursorTop >= Console.WindowHeight / 2 - 1 &&
                         Console.CursorTop <= Console.WindowHeight / 2 + 2));

            Console.ForegroundColor = colors[rnd.Next(0, colors.Length)];
            Console.BackgroundColor = colors[rnd.Next(0, colors.Length)];
        }

    }
}
