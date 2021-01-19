/* Зайцева Марина
 * Урок 2. Задание 6
 * *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. 
 * «Хорошим» называется число, которое делится на сумму своих цифр. 
 * Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
*/
using System;

namespace Lesson_2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Подсчет количества «хороших» чисел в диапазоне от 1 до 1 000 000 000\n" +
                "«Хорошим» называется число, которое делится на сумму своих цифр.");
            int count = 0;
            DateTime date_start = DateTime.Now;
            for(int number = 1; number < 1000000000; number++)
            {
                if (number % SumDigits(number) == 0)
                    count++;
                //Console.Write($"\rЧисло {number}. общее количество {count}");
            }
            Console.WriteLine($"Количество составляет: {count}.\nЗатрачено времени: {DateTime.Now- date_start}");


            Console.ReadKey();
        }

        /// <summary>
        /// Вычисление суммы цифр числа
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static int SumDigits(int number)
        {
            int sumDigits = 0;
            while (number != 0)
            {
                sumDigits += number % 10;
                number = number / 10;
            }

            return sumDigits;
        }
    }
}
