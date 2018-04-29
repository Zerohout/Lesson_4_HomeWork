using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sepo;



namespace Task3
{
    public class AccountManager
    {
        public static void Main()
        {

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
                // Запрос регистрации
            }
            else
            {
                // Запрос залогинится или зарегистрироваться
            }

        }


        void SelLogInOrSignIn()
        {
            while (true)
            {
                int sel = 0;
                Console.WriteLine(
                    "\n\n\nВыберите необходимое действие:\n\n1) Войти в программу используя логин и пароль\n\n2) Зарегистрироваться\n\n3) Выйти из программы");
                try
                {
                    sel = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.ReadLine();
                    continue;
                }
                finally
                {
                    switch (sel)

                    {
                        case 1:
                            // Вход в программу с логином и паролем
                            break;
                        case 2:
                            // Регистрация
                            break;
                        case 3:
                            break;
                    }
                }
            }
        }
    }
}
