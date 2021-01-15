#region
/*Зайцева Марина
 * Урок 1. Заание 4.
 * Обмен значениями двух переменных
 * а) с использованием третей переменной
 * б) без спользования
 */
#endregion
using System;

namespace Lesson_1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("Обмен значениями переменных");
            Console.WriteLine("Введите число а");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите число b");
            b = int.Parse(Console.ReadLine());
            //а)
            Exchange(ref a, ref b);
            Console.WriteLine($"После обмена значениями: a = {a}, b = {b}");

            //Возвращаем значения исходных данных для пункта б)
            Exchange(ref a, ref b);
            //б)
            ExchangeMod(ref a, ref b);
            Console.WriteLine($"После обмена значениями вторым способом: a = {a}, b = {b}");
        }

        private static void ExchangeMod(ref int a, ref int b)
        {            
            a = a + b;
            b = a - b;
            a = a - b;
        }

        private static void Exchange(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
