using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lesson_4_3
{
    /// <summary>
    /// Класс для работы с одномерным массивом
    /// </summary>
    class Array
    {
        int[] array;
        /// <summary>
        /// Конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом
        /// </summary>
        public Array(int N, int min_value, int step)
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
        public Array Inverse()
        {
            Array inverse_arr = new Array(array.Length, 0, 0);
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
                    if(max < array[i])
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
    }
}
