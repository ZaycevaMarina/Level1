/* Зайцева Марина
 * Урок 4. Задание 3
 * а) Дописать класс для работы с одномерным массивом.
 * Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом.
 * Создать свойство Sum, которое возвращает сумму элементов массива, 
         * метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива (старый массив, остается без изменений),  
         * метод Multi, умножающий каждый элемент массива на определённое число, 
         * свойство MaxCount, возвращающее количество максимальных элементов. 
 * б)** Создать библиотеку, содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
 * в) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)
 */
using System;
using System.Collections.Generic;
using Array_1_dimensional;

namespace Lesson_4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            #region а)
            Console.WriteLine("------Класс для работы с одномерным массивом------");
            Console.WriteLine("Массив из 20 элементов с начальным значением 0 и шагом 2:");
            Array arr = new Array(20, 0, 2);
            arr.Print();
            Console.WriteLine($"Сумма всех элементов массива: {arr.Sum}");
            Console.WriteLine($"Новый массив с измененными знаками у всех элементов: ");
            arr.Inverse().Print();
            int multi = 5;
            Console.WriteLine($"После умножения исходного массива на число {multi}:");
            arr.Multi(multi);
            arr.Print();
            Console.WriteLine($"Количество максимальных элементов массива: {arr.MaxCount}");
            #endregion
            Console.WriteLine("\nДля перхода к пункту б) нажмите любую кнопку...");
            Console.ReadKey();
            Console.Clear();
            #region б)
            Console.WriteLine("------Библиотека Array_1_dimensional, содержащая класс для работы с массивом------");
            Console.WriteLine("Массив из 20 элементов с начальным значением 0 и шагом -2:");
            Array_1Dim array_1Dim = new Array_1Dim(20, 0, -2);
            array_1Dim.Print();
            Console.WriteLine($"Сумма всех элементов массива: {array_1Dim.Sum}");
            Console.WriteLine($"Новый массив с измененными знаками у всех элементов: ");
            array_1Dim.Inverse().Print();
            int multi2 = 10;
            Console.WriteLine($"После умножения исходного массива на число {multi2}:");
            array_1Dim.Multi(multi2);
            array_1Dim.Print();
            Console.WriteLine($"Количество максимальных элементов массива: {array_1Dim.MaxCount}");
            #endregion
            Console.WriteLine("\nДля перхода к пункту в) нажмите любую кнопку...");
            Console.ReadKey();
            Console.Clear();
            #region в)
            Console.WriteLine("------Подсчёт частоты вхождения каждого элемента в массив------");
            Console.WriteLine("Исходный массив:");
            array_1Dim.Print();
            Dictionary<int, int> dct;
            array_1Dim.FrequencyOfOccurrence(out dct);
            foreach (var line in dct)
                Console.WriteLine($"Число {line.Key} встречается {line.Value} раз(а)");
            #endregion
            Console.WriteLine("\nДля завершения нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
