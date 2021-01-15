/* Зайцева Марина
 * Урок 4. Задание 4
 * Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. 
 * Создайте структуру Account, содержащую Login и Password.
     * Задача с логинами из урока 2:
     * Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. 
     * На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
     * Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, 
     * программа пропускает его дальше или не пропускает. 
     * С помощью цикла do while ограничить ввод пароля тремя попытками. * 
 */
using System;
using System.IO;

namespace Lesson_4_4
{
    class Program
    {
        public struct Account
        {
            string login;
            string password;
            public Account(string _login, string _password)
            {
                login = _login;
                password = _password;
            }
            public string Login
            { 
                get { return login; }
            }
            public string Password
            { 
                get { return password; }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("-----Проверка логина и пароля-----");
            Account Account_user;
            Account[] Registered_Accounts;
            string file_name = "Accounts.txt";
            try
            {
                Registered_Accounts = ReadFromFile(file_name);
                string user_login, user_password;
                int i = 1;//Пользователю предоставлено 3 попытки для авторизации
                do
                {
                    Console.WriteLine("Введите логин: ");
                    user_login = Console.ReadLine();
                    Console.WriteLine("Введите пароль: ");
                    user_password = Console.ReadLine();
                    Account_user = new Account(user_login, user_password);
                    if (Authorization(Account_user, Registered_Accounts) == true)
                    {
                        Console.WriteLine("Авторизация пройдена");
                        break;
                    }
                    else
                        Console.WriteLine("Неверные логин или пароль.");
                    i++;
                } while (i <= 3);
                if (i == 4)
                    Console.WriteLine("Три попытки завершены.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("\nДля завершения  любую кнопку...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Проверка авторизации
        /// </summary>
        /// <param name="user_login"></param>
        /// <param name="user_password"></param>
        /// <returns></returns>
        private static bool Authorization(Account account_user, Account[] accounts)
        {
            foreach(Account account in accounts)
            {
                if (account_user.Login == account.Login && account_user.Password == account.Password)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Чтение аккаунтов зарегистрированных пользователей из файла
        /// </summary>
        /// <param name="file_name"></param>
        /// <returns></returns>
        public static Account[] ReadFromFile(string file_name)
        {
            if (File.Exists(file_name))
            {
                string[] massiv_string = File.ReadAllLines(file_name);
                Account[] Registered_users = new Account[massiv_string.Length];
                string login, password;
                for (int i = 0; i < massiv_string.Length; i++)
                {//massiv_string[i] - строка вида "Login Password"
                    if (massiv_string[i].IndexOf(' ') == -1)
                        throw new FormatException($"Неподдерживаемый формат файла {file_name}: файл должен строки вида \"Login Password\"");
                    login = massiv_string[i].Substring(0, massiv_string[i].IndexOf(' '));
                    password = massiv_string[i].Substring(massiv_string[i].IndexOf(' ') + 1, massiv_string[i].Length - massiv_string[i].IndexOf(' ') - 1);
                    Registered_users[i] = new Account(login, password);
                }
                return Registered_users;
            }
            else
                throw new FileNotFoundException($"Не найден файл аккаунтов зарегистрированных пользователей: \'{file_name}\'");            
        }
    }
}
