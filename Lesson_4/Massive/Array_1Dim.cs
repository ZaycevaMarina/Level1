/* Зайцева Марина
 * Библиотека для задания 3 урока 4.
 * Библиотека, содержащая класс для работы с массивом.
 * Содержит: конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом.
           * свойство Sum, которое возвращает сумму элементов массива, 
           * метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива
           * метод Multi, умножающий каждый элемент массива на определённое число, 
           * свойство MaxCount, возвращающее количество максимальных элементов. 
           * метод, считающий частоту вхождения каждого элемента в массив
*/
using System;
using System.Collections.Generic;
/// <summary>
/// Библиотека, содержащая класс для работы с массивом
/// </summary>
namespace Array_1_dimensional
{
    /// <summary>
    /// Класс для работы с одномерным массивом
    /// </summary>
    public class Array_1Dim
    {
        int[] array;
        /// <summary>
        /// Конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом
        /// </summary>
        public Array_1Dim(int N, int min_value, int step)
        {
            array = new int[N];
            for (int i = 0; i < N; i++)
                array[i] = min_value + step * i;
        }
        /// <summary>
        /// Возвращает сумму элементов массива
        /// </summary>
        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < array.Length; i++)
                    sum += array[i];
                return sum;
            }
        }
        /// <summary>
        /// Возвращающий новый массив с измененными знаками у всех элементов массива (старый массив, остается без изменений),  
        /// </summary>
        public Array_1Dim Inverse()
        {
            Array_1Dim inverse_arr = new Array_1Dim(array.Length, 0, 0);
            for (int i = 0; i < inverse_arr.array.Length; i++)
                inverse_arr.array[i] = -array[i];
            return inverse_arr;
        }
        /// <summary>
        /// Умножает каждый элемент массива на определённое число, 
        /// </summary>
        /// <returns></returns>
        public void Multi(int constant)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] *= constant;
        }
        /// <summary>
        /// Возвращает количество максимальных элементов
        /// </summary>
        public int MaxCount
        {
            get
            {
                if (array.Length == 0)
                    return 0;
                int max = array[0];
                for (int i = 1; i < array.Length; i++)
                    if (max < array[i])
                        max = array[i];
                int maxCount = 0;
                foreach (int count in array)
                    if (max == count)
                        maxCount++;
                return maxCount;
            }
        }
        /// <summary>
        /// Вывод всех элементов массива
        /// </summary>
        public void Print()
        {
            foreach (int count in array)
                Console.Write($"{count} ");
            Console.WriteLine();
        }
        /// <summary>
        /// Подсчёт частоты вхождения каждого элемента в массив
        /// </summary>
        /// <returns></returns>
        public void FrequencyOfOccurrence(out Dictionary<int, int> dct)
        {
            dct = new Dictionary<int, int>();
            foreach (int count in array)
            {
                if (!dct.ContainsKey(count))
                    dct[count] = 1;
                else
                    dct[count]++;
            }
        }
    }
}