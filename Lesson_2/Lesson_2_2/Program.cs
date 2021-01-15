/*Зайцева Марина
  Урок 2. Задание 2
  Написать метод подсчета количества цифр числа.
*/

using System;

namespace Lesson_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            Console.WriteLine("Метод подсчета количества цифр числа");
            Console.WriteLine("Введите число: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine($"количества цифр числа: {CountDigits(a)}");
            Console.ReadKey();
        }

        /// <summary>
        /// Подсчета количества цифр числа
        /// </summary>
        /// <param name="a">целое</param>
        /// <returns></returns>
        private static int CountDigits(int a)
        {
            int count = 0;
            while (a != 0)
            {
                a = a / 10;
                count++;
            }
            return count;
        }
    }
}
