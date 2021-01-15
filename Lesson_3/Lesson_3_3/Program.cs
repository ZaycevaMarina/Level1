/* Зайцева Марина
 * Урок 3. Задание 3.
 * *Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел. 
 * Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
 * Написать программу, демонстрирующую все разработанные элементы класса. 
 * Добавить свойство типа int для доступа к числителю и знаменателю.
 * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа.
 * *Добавить проверку, чтобы знаменатель не равнялся 0. 
 * Выбрасывать исключение 
 *                      ArgumentException("Знаменатель не может быть равен 0").
 * Добавить упрощение дробей.
*/
using System;

namespace Lesson_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction a = new Fraction(1, 6);
            Fraction b = new Fraction(5, 6);            
            Console.WriteLine($"Дробь 1: {a}");//Вызовится метод строкового представления данных ToString()
            Console.WriteLine($"Дробь 2: {b}");

            Fraction c = a.Sum(b);
            Console.WriteLine($"\nСумма: {c}");
            c.Simplify();
            Console.WriteLine($"После упрощения: {c}");
            Console.WriteLine($"В десятичном представлении: {c.Decimal:F2}");

            c = b.Difference(a);
            Console.WriteLine($"\nРазность: {c}");
            c.Simplify();
            Console.WriteLine($"После упрощения: {c}");
            Console.WriteLine($"В десятичном представлении: {c.Decimal:F2}");

            c = a.Multiplication(b);
            Console.WriteLine($"\nПроизведение: {c}");
            c.Simplify();
            Console.WriteLine($"После упрощения: {c}");
            Console.WriteLine($"В десятичном представлении: {c.Decimal:F2}");

            c = b.Division(a);
            Console.WriteLine($"\nЧастное: {c}");
            c.Simplify(); 
            Console.WriteLine($"После упрощения: {c}");
            Console.WriteLine($"В десятичном представлении: {c.Decimal:F2}");


            Console.WriteLine("Нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
