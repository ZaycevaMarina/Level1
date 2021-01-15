/* Зайцева Марина
 * Урок 3. Задание 2
 * а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке). 
 * Требуется подсчитать сумму всех нечетных положительных чисел. 
 * Сами числа и сумму вывести на экран, используя tryParse;
 * б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные. 
 * При возникновении ошибки вывести сообщение. Напишите соответствующую функцию.
*/
using System;

namespace Lesson_3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Подсчёт суммы всех нечетных положительных чисел.");
            Console.WriteLine("Введите положительные чисела. 0 - конец ввода.");
            int count, odd_count_sum = 0;
            do
            {
                while (!int.TryParse(Console.ReadLine(), out count))
                    Console.WriteLine("Вводите целые числа.");//б)
                Console.WriteLine($"Введено число: {count}");
                
                if (IsOdd(count))//а)
                    odd_count_sum += count;
            } while (count != 0);
            Console.WriteLine($"Сумма нечетных чисел:" + odd_count_sum);

            Console.WriteLine("Нажмите на любую кнопку.");
            Console.ReadKey();
        }

        /// <summary>
        /// Вычисление нечётности числа
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private static bool IsOdd(int count)
        {
            return count % 2 == 1;
        }

        /// <summary>
        /// Чтение целого числа с клавиатуры
        /// </summary>
        /// <param name="a"></param>
        private static void ReadInt(ref int a)
        {
            while (!int.TryParse(Console.ReadLine(), out a))
                Console.WriteLine("Вводите целые числа.");
        }
    }
}
