/* Зайцева Марина
 * Урок 6. Задание 1 * 
 * Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double). 
 * Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x). */
using System;

namespace Lesson_6_1
{
    class Program
    {
        static private double f1(double x, double a) => a * Math.Pow(x, 2);

        static private double f2(double x, double a) => a * Math.Sin(x);

        delegate double function(double x, double a);
        /// <summary>
        /// Вывод на консоль значений функции с параметром "а" на промежутке от min до max с шагом step
        /// </summary>
        /// <param name="f">Функция типа double (double, double)</param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="step"></param>
        /// <param name="a"></param>
        static void PrintFunctionValues(function f, double min, double max, double step, double a)
        {
            for (double x = min; x <= max; x+=step)
            {
                Console.WriteLine($"f({Math.Round(x, 2):F1}; {a}) = {Math.Round(f(x, a), 2)}");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            double min = -1, max = 1, step = 0.1, a = 2;
            Console.WriteLine($"Таблица значений функции f(x,{a}) = {a}*x^2 на интервале от {min} до {max} с шагом {step}.");
            PrintFunctionValues(f1, min, max, step, 2);
            Console.WriteLine($"Таблица значений функции f(x,{a}) = {a}*sin(x) на интервале от {min} до {max} с шагом {step}.");
            PrintFunctionValues(f2, min, max, step, 2);

            Console.WriteLine("Для завершения нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
