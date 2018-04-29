using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sepo
{
    public class SepoHelper
    {
        public static string accsPath = Directory.GetCurrentDirectory() + @"\Accounts\";
        public static string accountPath = "";
        public static bool exit = false;
        public static bool access = false;
        public static bool unregistered = false;
        public bool retryTask = true;

        static void Main()
        {
        }

        public void ExitTask()
        // Запрос при выходе
        {
            bool retryBool = true;
            while (retryBool)
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
                        retryBool = false;
                        retryTask = true;
                        break;
                    case 2:
                        Console.Clear();
                        retryBool = false;
                        retryTask = false;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
