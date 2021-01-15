/* Зайцева Марина
 * Урок 2. Задание 7
 * a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
   б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
*/
using System;

namespace Lesson_2_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вывод на экран числа от a до b");
            int a = 0, b = 0;
            do
            {
                Console.WriteLine("Введите число a:");
            }
            while (int.TryParse(Console.ReadLine(), out a) == false);
            do
            {
                Console.WriteLine("Введите число b (a < b):");
            }
            while (int.TryParse(Console.ReadLine(), out b) == false || a >= b);
            //a)
            Console.WriteLine($"Числа от {a} до {b}:");
            PrintNumbers(a, b);
            //б)
            Console.WriteLine($"Сумма чисел от {a} до {b}: {SumNumbers(a, b)}");
        }

        /// <summary>
        /// Подсчёт суммы чисел от a до b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static int SumNumbers(int a, int b)
        {
            int sum = a;
            if(a < b) 
                sum += SumNumbers(a + 1, b);                
            return sum;
        }

        /// <summary>
        /// Вывод на экран числа от a до b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private static void PrintNumbers(int a, int b)
        {
            Console.Write($"{a} ");
            if (a < b)
                PrintNumbers(a + 1, b);
            else
                Console.WriteLine();
        }
    }
}
