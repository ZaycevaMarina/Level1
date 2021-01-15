/* Зайцева Марина
 * Урок 5. Задание 1.
 * Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов, 
 * содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
    а) без использования регулярных выражений;
    б) **с использованием регулярных выражений. 
 */
using System;
using System.Text.RegularExpressions;

namespace Lesson_5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----Проверка корректности ввода логина-----");
            Console.WriteLine(@"Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой");
            Console.WriteLine("Введите логин:");
            string login = Console.ReadLine();

            #region а)
            Console.WriteLine("а) Без использования регулярных выражений:");
            if (LoginCheck(login))
                Console.WriteLine("Логин корректен.");
            #endregion

            #region б)
            Console.WriteLine("б) С использованием регулярных выражений:");
            if(CheckLoginRegex(login))
                Console.WriteLine("Логин корректен.");
            else
                Console.WriteLine("Не выполнено хотя бы одно условие.");
            #endregion

            Console.WriteLine("Для завершения нажмите на любую кнопку...");
            Console.ReadKey();
        }
        /// <summary>
        /// Проверка корректности ввода логина с использованием регулярных выражений
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        private static bool CheckLoginRegex(string login)
        {
            Regex rg = new Regex(@"^[A-Za-z]+[A-Za-z0-9]{1,9}$");
            if (!rg.IsMatch(login))
                return false;
            return true;
        }

        /// <summary>
        /// Проверка корректности ввода логина без использования регулярных выражений
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        private static bool LoginCheck(string login)
        {
            if (login.Length < 2 || login.Length > 10)
            {
                Console.WriteLine($"Логин \"{login}\" не удовлетворяет условию: длина строки от 2 до 10 символов.");
                return false;
            }
            else if ((login[0] < 'A' || login[0] > 'Z') && (login[0] < 'a' || login[0] > 'z'))
            {
                Console.WriteLine($"Логин \"{login}\" не удовлетворяет условию: первая буква только из латинского алфавита.");
                return false;
            }
            else
            {
                foreach (char c in login)
                {
                    if (!Char.IsDigit(c) && (c < 'A' || c > 'Z') && (c < 'a' || c > 'z'))
                    {
                        Console.WriteLine($"Логин \"{login}\" не удовлетворяет условию: только буквы латинского алфавита или цифры.");
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
