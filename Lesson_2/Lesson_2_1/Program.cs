/*Зайцева Марина
  Урок 2. Задание 1
  Написать метод, возвращающий минимальное из трёх чисел.
 */

using System;

namespace Lesson_2_1
{
    class Program
    {        
        static void Main(string[] args)
        {
            double a, b, c;
            Console.WriteLine("Введите первое число: ");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            b = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите третье число: ");
            c = double.Parse(Console.ReadLine());            
            Console.WriteLine($"Минимальное значение: {Min(a, b, c)}");
            Console.ReadKey();
        }

        /// <summary>
        /// Минимальное из трёх чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private static double Min(double a, double b, double c)
        {
            double min;
            if (a <= b)
                min = a;
            else
                min = b;
            if (min > c)
                min = c;
            return min;
        }
    }
}
