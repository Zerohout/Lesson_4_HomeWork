namespace Task_5
{
    using System;

    public class Doubler
    {
        private int current;
        private int finish;
        private int undo;
        private int undoSel;
        private int tryCount;
        private int tempCurrent;
        private static bool retryBool;
        private bool exit = false;
        public static void Main()
        {
            var doubler = new Doubler();
            switch (Menu())
            {
                case 1:
                    Console.Clear();
                    doubler.Game();
                    break;
                case 2:
                    Console.Clear();
                    doubler.Rules();
                    Console.Clear();
                    Main();
                    break;
                case 3:
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Main();
                    break;
            }
        }

        private int Current => current;

        private int Finish => finish;

        private int Undo => undo;

        static int Menu()
        {

            Console.WriteLine("\n\n1)Начать игру\n2)Правила\n3)Выход");
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                return 0;
            }
        }

        public Doubler()
        {
            var rnd = new Random();
            finish = rnd.Next(10, 101);
            undo = 5;
            current = 1;
            tryCount = 0;
        }

        void Game()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 16, 3);
            Console.Write("Вас приветствует игра ");
            ColorText(ConsoleColor.Cyan, "Удвоитель");
            Help();

            while (current != finish || current < finish)
            {
                UserValue();
            }

            if (!exit)
            {
                GameOver();
                ExitTask();
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
            if (!exit)
            {
                switch (Console.ReadLine())
                {
                    case "plus":
                        current++;
                        undoSel = 1;
                        tryCount++;
                        Console.Clear();
                        Game();
                        break;
                    case "multi":
                        current *= 2;
                        undoSel = 2;
                        tryCount++;
                        Console.Clear();
                        Game();
                        break;
                    case "reset":
                        tempCurrent = current;
                        current = 1;
                        undoSel = 3;
                        tryCount++;
                        Console.Clear();
                        Game();
                        break;
                    case "undo":
                        if (undo > 0)
                        {
                            if (undoSel == 1)
                            {
                                current--;
                            }
                            else if (undoSel == 2)
                            {
                                current /= 2;
                            }
                            else if (undoSel == 3)
                            {
                                current = tempCurrent;
                            }

                            undo--;
                            tryCount++;
                        }
                        Console.Clear();
                        Game();
                        break;
                    default:
                        Console.Clear();
                        Game();
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

        private void ExitTask()
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
                        exit = true;
                        break;
                    default:
                        Console.Clear();
                        retryBool = true;
                        break;
                }
            } while (retryBool);

            retryBool = false;
        }
    }

}
