using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using Sepo;



namespace Task3
{
    public class AccountManager
    {
        private static bool exitSel;

        public static void Main()
        {
            AccountManager am = new AccountManager();
            am.EnterToProg();
        }

        public void EnterToProg()
        {
            if (!Directory.Exists(SepoHelper.accsPath))
            {
                Directory.CreateDirectory(SepoHelper.accsPath);
            }

            var accounts = Directory.GetDirectories(SepoHelper.accsPath);

            if (accounts.Length == 0)
            {
                Registration();
            }
            else
            {
                SelLogInOrSignIn();
            }

        }


        void SelLogInOrSignIn()
        {
            while (true)
            {
                Console.Clear();
                var sel = 0;
                Console.WriteLine(
                    "\n\n\nВыберите необходимое действие:\n\n1) Войти в программу используя логин и пароль\n\n2) Зарегистрироваться\n\n3) Продолжить без регистрации\n\n4) Выйти из программы");
                try
                {
                    sel = int.Parse(Console.ReadLine());
                }
                catch
                {
                    continue;
                }
                finally
                {
                    switch (sel)

                    {
                        case 1:
                            Login();
                            break;
                        case 2:
                            Registration();
                            break;
                        case 3:
                            SepoHelper.unregistered = true;
                            break;
                        case 4:
                            SepoHelper.exit = true;
                            break;
                    }
                }

                if (sel > 0 && sel < 5)
                {
                    break;
                }
            }
        }

        void Login()
        // Вход с логином и паролем
        {
            while (true)
            {
                Console.Clear();
                string[] readUserData = new string[2];
                string[] currentUserData = new string[2];
                Console.WriteLine("\n\n\nВведите через пробел логин и пароль или Exit для выхода:");

                try
                {
                    currentUserData = Console.ReadLine().Split(' ');
                }
                catch
                {
                    continue;
                }
                finally
                {
                    if (currentUserData[0] != "Exit")
                    {
                        SepoHelper.accountPath = SepoHelper.accsPath + currentUserData[0];
                        try
                        {
                            readUserData = File.ReadAllLines($"{SepoHelper.accountPath}\\{currentUserData[0]}.txt");
                            if (currentUserData[0] == readUserData[0] && currentUserData[1] == readUserData[1])
                            {
                                SepoHelper.access = true;
                            }
                            else
                            {
                                Console.Clear();
                                Console.Write("Неверный логин или пароль");
                                SepoHelper.access = false;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка чтения данных");
                        }
                    }

                }

                if (SepoHelper.access || currentUserData[0] == "Exit")
                {
                    break;
                }
            }

        }

        void Registration()
        // Регистрация
        {
            
            while (true)
            {
                Console.Clear();
                string[] userData = new string[2];
                Console.WriteLine("\n\nВведите через пробел Логин и Пароль для регистрации \nили Exit для выхода.\n");
                try
                {
                    userData = Console.ReadLine().Split(' ');
                }
                catch
                {
                    continue;
                }
                finally
                {
                    if (userData[0] != "Exit")
                    {
                        SepoHelper.accountPath = SepoHelper.accsPath + userData[0];
                        try
                        {
                            if (Directory.Exists(SepoHelper.accountPath))
                            {
                                Console.WriteLine("\n\nДанный аккаунт уже существует");
                            }
                            else
                            {

                                Directory.CreateDirectory(SepoHelper.accountPath);
                                FileStream fs = File.Create($"{SepoHelper.accountPath}\\{userData[0]}.txt");
                                fs.Close();
                                File.WriteAllLines($"{SepoHelper.accountPath}\\{userData[0]}.txt", userData);
                                SepoHelper.access = true;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка считывания/записи данных");
                        }

                    }
                }

                if (SepoHelper.access || userData[0] == "Exit")
                {
                    break;
                }
            }
        }
    }
}
