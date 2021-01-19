/* Зайцева Марина
 * Урок 6. Задание 2
 * Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
б) Используйте массив (или список) делегатов, в котором хранятся различные функции.
в) *Переделайте функцию Load, чтобы она возвращала массив считанных значений. 
Пусть она возвращает минимум через параметр.
*/
using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson_6_2
{
    class Program
    {
        private static double F1(double x)
        {
            return x * x - 50 * x + 10;
        }

        delegate double Function(double x);

        /// <summary>
        /// Сохранение значений функции в бинарный файл на промежутке от a до b с шагом h
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="h"></param>
        static void SaveFunctionValues(Function f, string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(f(x));
                x += h;
            }
            bw.Close();
            fs.Close();
        }      
        static double[] LoadToGetFunctionMinimum(string fileName, ref double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double[] function_values = new double[fs.Length / sizeof(double)];
            for (int i = 0; i < function_values.Length; i++)
            {
                function_values[i] = bw.ReadDouble();
                if (function_values[i] < min)
                    min = function_values[i];
            }
            bw.Close();
            fs.Close();
            return function_values;
        }

        static void Main(string[] args)
        {
            string file_name = "data.bin";            
            int user_case;
            double a = 0, b = 0, h = 0;
            double min = double.MaxValue;
            IList<Function> Functions = new List<Function>();
            Functions.Add(F1);
            Functions.Add(Math.Tan);
            Functions.Add(Math.Cos);
            do
            {
                do
                {
                    Console.WriteLine("Выбирите функцию:\n" +
                    "0 - Выход из цикла запроса\n" +
                    "1 - f(x)= x^2-50*x+10 на промежутке от -10 до 10 с шагом 0.5\n" +
                    "2 - f(x)= tan(x) на промежутке от -1 до 1 с шагом 0.1\n" +
                    "3 - f(x)= cos(x) на промежутке от -1 до 1 с шагом 0.05\n");
                    int.TryParse(Console.ReadLine(), out user_case);
                } while (user_case < 0 || user_case > 3);
                if (user_case == 0)
                    break;
                switch (user_case)
                {
                    case 1:
                        Console.WriteLine("f(x)= x^2-50*x+10");
                        a = -10; b = 10; h = 0.5;
                        break;
                    case 2:
                        Console.WriteLine("f(x)= tan(x)");
                        a = -1; b = 1; h = 0.1;
                        break;
                    case 3:
                        Console.WriteLine("f(x)= cos(x)");
                        a = -1; b = 1; h = 0.05;
                        break;
                }
                min = double.MaxValue;
                SaveFunctionValues(Functions[user_case - 1], file_name, a, b, h);
                LoadToGetFunctionMinimum(file_name, ref min);
                Console.WriteLine($"Минимум функции на промежутке от {a} до {b} с шагом {h}: {min:F2}\n");
            } while (user_case != 0);

            Console.WriteLine("Для завершения нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
