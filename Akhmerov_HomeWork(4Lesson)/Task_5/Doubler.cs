namespace Task_5
{
    using System;
    using Sepo;

    public class Doubler
    {
        private int current;
        private int finish;
        private int undo;
        private int undoSel;
        private int tryCount;
        private int undoTryCount;
        private int[] undoNums;


        private static bool retryBool;
        private bool exit = false;
        SepoHelper sh = new SepoHelper();

        public static void Main()
        {
            var startD = new Doubler();
            startD.Menu();
        }

        private int Current => current;

        private int Finish => finish;

        private int Undo => undo;

        void Menu()
        {

            while (sh.retryTask)
            {
                var sel = 0;
                Console.WriteLine("\n\n1)Начать игру\n2)Правила\n3)Выход");
                try
                {
                    sel = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    continue;
                }
                finally
                {

                    Console.Clear();
                    switch (sel)
                    {
                        case 1:
                            while (sh.retryTask)
                            {
                                Game();
                            }
                            break;
                        case 2:
                            Rules();
                            Console.Clear();
                            Main();
                            break;
                        case 3:
                            sh.retryTask = false;
                            break;
                    }
                }
            }
        }

        public Doubler()
        {
            var rnd = new Random();
            finish = rnd.Next(10, 101);
            undo = 5;
            current = 1;
            tryCount = 0;
            undoTryCount = 0;
            undoNums = new int[30];
        }

        void Game()
        {
            var doubler = new Doubler();

            while (true)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 16, 3);
                Console.Write("Вас приветствует игра ");
                ColorText(ConsoleColor.Cyan, "Удвоитель");
                doubler.Help();

                if (doubler.current != doubler.finish && doubler.current < doubler.finish)
                {
                    doubler.UserValue();
                    Console.Clear();
                }
                else
                {
                    doubler.GameOver();
                    sh.ExitTask();
                    break;
                }
            }
        }

        void GameOver()
        // Окончание игры
        {
            if (current == finish)
            {
                Console.SetCursorPosition(10, Console.CursorTop + 2);
                Console.Write("Поздравляю, Вы выйграли! Число попыток: ");
                ColorText(ConsoleColor.Green, $"{tryCount}");
            }
            else
            {
                Console.SetCursorPosition(10, Console.CursorTop + 2);
                Console.Write("Увы, Вы проиграли... Число попыток: ");
                ColorText(ConsoleColor.Green, $"{tryCount}");
            }
        }

        void Help()
        // Справка
        {
            HelpText(26, "plus", "' для увеличения текущего значения на 1");
            HelpText(26, "multi", "' для умножения текущего значения на 2");
            HelpText(20, "reset", "' для сброса значения до 1");
            HelpText(34, "undo", $"' для отмены последнего действия (доступно ");
            UndoText();
            Console.Write(" попыток).");
            Console.SetCursorPosition(10, Console.CursorTop + 2);
            Console.Write("Текущее значение: ");
            ColorText(ConsoleColor.Cyan, $"{current}");
            Console.SetCursorPosition(Console.CursorLeft + 20, Console.CursorTop);
            Console.Write("Необходимое значение: ");
            ColorText(ConsoleColor.Cyan, $"{finish}");
            Console.WriteLine("\n");
        }

        void UserValue()
        {
            var exitUV = false;
            while (!exitUV)
            {
                switch (Console.ReadLine())
                {
                    case "plus":
                        if (undo > 0)
                        {
                            undoNums[tryCount] = current;
                        }
                        current++;
                        undoSel = 1;
                        tryCount++;
                        undoTryCount++;
                        exitUV = true;
                        break;
                    case "multi":
                        if (undo > 0)
                        {
                            undoNums[tryCount] = current;
                        }
                        current *= 2;
                        undoSel = 2;
                        tryCount++;
                        undoTryCount++;
                        exitUV = true;
                        break;
                    case "reset":
                        if (undo > 0)
                        {
                            undoNums[tryCount] = current;
                        }
                        current = 1;
                        undoSel = 3;
                        tryCount++;
                        undoTryCount++;
                        exitUV = true;
                        break;
                    case "undo":
                        if (undo > 0)
                        {
                            undoTryCount--;
                            current = undoNums[undoTryCount];
                            
                            undo--;
                            tryCount++;
                        }
                        exitUV = true;
                        break;
                }
            }
        }

        void HelpText(int halfTextSize, string command, string helpText)
        // Текст справки
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - halfTextSize, Console.CursorTop + 2);
            Console.Write("Введите '");
            ColorText(ConsoleColor.Yellow, command);
            Console.Write(helpText);
        }

        void UndoText()
        // Отмена действия
        {
            if (undo > 4)
                ColorText(ConsoleColor.Green, $"{undo}");
            else if (undo < 5 && undo > 1)
            {
                ColorText(ConsoleColor.Yellow, $"{undo}");
            }
            else
            {
                ColorText(ConsoleColor.Red, $"{undo}");
            }
        }

        void ColorText(ConsoleColor color, string text)
        // Покраска цвета
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        void Rules()
        // Правила
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 38, Console.WindowHeight / 2 - 1);
            Console.Write("Вводя прибавляя к числу 1 и умножая его на 2 нужно достичь конечного числа.");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 17, Console.WindowHeight / 2 + 1);
            Console.WriteLine("Можно отменить ход 5 раз за игру.");
            Console.ReadLine();
        }
    }
}
