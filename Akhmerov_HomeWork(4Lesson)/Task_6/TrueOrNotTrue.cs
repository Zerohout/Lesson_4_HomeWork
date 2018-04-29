using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sepo;

namespace Task_6
{
    public class TrueOrNotTrue
    {
        private int rightAnswer = 0;
        static public void Main()
        {
            var sh = new SepoHelper();
            var start = new TrueOrNotTrue();
            while (sh.retryTask)
            {
                start.StartProgram();
                sh.ExitTask();
            }
        }

        void StartProgram()
        {
            Console.WriteLine("Вас приветствует игра \"Верю-не Верю\".\n\nОтвечайте на вопросы только 'Да' или 'Нет'.\n\nДля начала нажмите 'Enter'");
            Console.ReadLine();
            Game();
        }

        void Game()
        {
            var gameTasks = GetRanTasks(ReadTasks());
            Console.Clear();
            foreach (var q in gameTasks)
            {
                var tempTask = q.Split('|');
                while (true)
                {
                    
                    Console.WriteLine($"\n\n\n{tempTask[0]}");

                    var answer = Console.ReadLine();

                    if (answer != "Да" && answer != "Нет") continue;
                    if (answer == tempTask[1])
                    {
                        rightAnswer++;
                        Console.Write("Верно! Для продолжения нажмите Enter");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.Write("Не верно... Для продолжения нажмите Enter");
                        Console.ReadLine();
                        break;
                    }
                }
                Console.Clear();
            }
            GameOver();
        }

        void GameOver()
        {
            Console.Write($"Игра окончена! Правильных ответов {rightAnswer}.");
        }

        string[] GetRanTasks(string[] tas)
        {
            var rnd = new Random();
            var tasks = new string[5];

            for (var i = 0; i < 5; i++)
            {
                int num;
                do
                {
                    num = rnd.Next(0, tas.Length);
                } while (tasks.Contains(tas[num]));

                tasks[i] = tas[num];
            }

            return tasks;

        }

        string[] ReadTasks()
        {
            if (!Directory.Exists(SepoHelper.tasksPath))
            {
                WriteTasks();
            }

            return File.ReadAllLines($"{SepoHelper.tasksPath}Tasks.txt");
        }

        void WriteTasks()
        {
            if (!Directory.Exists(SepoHelper.tasksPath))
            {
                Directory.CreateDirectory(SepoHelper.tasksPath);
            }
            if (!File.Exists($"{SepoHelper.tasksPath}Tasks.txt"))
            {
                var fs = File.Create($"{SepoHelper.tasksPath}Tasks.txt");
                fs.Close();
            }

            File.WriteAllLines($"{SepoHelper.tasksPath}Tasks.txt", taskList);

        }

        static readonly string[] taskList =
              {
                "В Японии ученики на доске пишут кисточкой с цветными чернилами?|Да",
                "В Австралии практикуется применение одноразовых школьных досок?|Нет",
                "Авторучка была изобретена еще в Древнем Египте?|Да",
                "Шариковая ручка сначала применялась только военными летчиками?|Да",
                "В Африке выпускаются витаминизированные карандаши для детей, имеющих обыкновение грызть что попало?|Да",
                "В некоторые виды цветных карандашей добавляется экстракт моркови для большей прочности грифеля?|Нет",
                "Римляне носили штаны?|Нет",
                "Если пчела ужалит кого-либо, то она погибнет?|Да",
                "Правда ли что, пауки питаются собственной паутиной?|Да",
                "В одном корейском цирке двух крокодилов научили танцевать вальс.|Нет",
                "На зиму пингвины улетают на север?|Нет",
                "Если камбалу положить на шахматную доску, она тоже станет клетчатой.|Да",
                "Спартанские воины перед битвой опрыскивали волосы духами.|Да",
                "Мыши подрастая становятся крысами?|Нет",
                "Некоторые лягушки умеют летать?|Да",
                "Дети могут слышать более высокие звуки, чем взрослые?|Да",
                "Глаз наполнен воздухом?|Нет",
                "Утром вы выше ростом, чем вечером?|Да",
                "В некоторых местах люди по-прежнему моются с помощью оливкового масла?|Да",
                "Летучие мыши могут принимать радиосигналы?|Нет",
                "Совы не могут вращать глазами?|Да",
                "Лось является разновидностью оленя?|Да",
                "Жирафы по ночам отыскивают с помощью эха листья, которыми питаются?|Нет",
                "Дельфины — это маленькие киты?|Да",
                "Рог носорога обладает магической силой?|Нет",
                "В некоторых странах жуков-светляков используют в качестве осветительных приборов?|Да",
                "Мартышка обычно бывает размером с котенка?|Да",
                "Счастливая монета Скруджа была достоинством в 10 центов?|Да",
                "Дуремар занимался продажей лягушек?|Нет",
                "Мойву эскимосы сушат и едят вместо хлеба?|Да",
                "Радугу можно увидеть и в полночь?|Да",
                "Больше всего репы выращивают в России?|Нет",
                "Слон, встречаясь с незнакомым сородичем, здоровается следующим образом — кладет ему хобот в рот?|Да",
                "Настоящее имя Ганса Христиана Андерсена было Свенсен?|Нет",
                "В медицине диагноз «синдром Мюнхгаузена» ставится пациенту, который много врет? 36.|Нет",
                "Рост Конька — Горбунка составляет два вершка?|Нет",
                "Первое место среди причин гибели от несчастных случаев в Японии в 1995г. заняли туфли на высоком каблуке?|Да"
            };


    }
}
