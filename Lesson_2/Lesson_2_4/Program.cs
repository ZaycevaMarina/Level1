/* Зайцева Марина
 * Урок 2. Задание 4
 * Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. 
 * На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
 * Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, 
 * программа пропускает его дальше или не пропускает. 
 * С помощью цикла do while ограничить ввод пароля тремя попытками.
 */
using System;

namespace Lesson_2_4
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.WriteLine("Проверка логина и пароля");
            string user_login = "", user_password = "";            
            int i = 1;
            do
            {
                Console.WriteLine("Введите логин: ");
                user_login = Console.ReadLine();
                Console.WriteLine("Введите пароль: ");
                user_password = Console.ReadLine();
                if (Authorization(user_login, user_password) == true)
                {
                    Console.WriteLine("Авторизация пройдена");
                    break;
                }
                else
                    Console.WriteLine("Неверные логин или пароль.");
                i++;
            } while (i <= 3);
            if(i == 4)
                Console.WriteLine("Три попытки завершены. Нажмите любую кнопку");
            Console.ReadLine();        
        }

        /// <summary>
        /// Проверка авторизации
        /// </summary>
        /// <param name="user_login"></param>
        /// <param name="user_password"></param>
        /// <returns></returns>
        private static bool Authorization(string user_login, string user_password)
        {
            return user_login == "root" && user_password == "GeekBrains";
        }
    }
}
