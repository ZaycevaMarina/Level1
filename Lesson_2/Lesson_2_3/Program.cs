/*Зайцева Марина
 * Урок 2. Задание 3
 * С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
*/
using System;

namespace Lesson_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Подсчёт суммы всех нечетных положительных чисел");
            Console.WriteLine("Введие целые числа. 0 - конец ввода");
            int a, sum = 0;
            do
            {
                a = int.Parse(Console.ReadLine());
                if ((a > 0) && (a % 2 == 1))
                    sum += a;
            } while (a != 0);
            Console.WriteLine($"Сумма всех нечетных положительных чисел: {sum}");
        }
    }
}
