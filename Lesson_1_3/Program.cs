#region
/*Зайцева Марина
 * Урок 1. Задание 3.
 * Подсчет расстояния между точками с координатами x1, y1, x2, y2 по формуле
 * r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)).
 * Вывести результат с двумя знаками после запятой
 * Оформить задание в виде метода
 */
#endregion
using System;

namespace Lesson_1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1, x2, y1, y2, r;
            Console.WriteLine("Подсчет расстояния между точками");
            Console.WriteLine("Введите координату x1;");
            x1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите координату y1;");
            y1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите координату x2;");
            x2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите координату y2;");
            y2 = double.Parse(Console.ReadLine());
            r = Distance(x1, x2, y1, y2);
            Console.WriteLine($"Расстояние между точками: {r:F2}");
        }

        private static double Distance(double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}
