#region
/*Зайцева Марина
 * Урок 1. Задание 2
 * Ввести вес и рост человека. Расчитать и вывести индекс массы тела по формуле 
 * l = m / (h * h), где m - масса тела в кг, h - рост в метрах 
 */
#endregion
using System;

namespace Lesson_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double weight, height, index;
            Console.WriteLine("Вычисление индекса массы тела");
            Console.WriteLine("Введите массу тела в кг");
            weight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите рост в метрах");
            height = Convert.ToDouble(Console.ReadLine());
            
            index = weight / (height * height);
            Console.WriteLine($"Индекс массы тела: {index:F2}");
        }
    }
}
