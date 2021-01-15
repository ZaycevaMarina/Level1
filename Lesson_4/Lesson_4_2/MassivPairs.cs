using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lesson_4_2
{
    static class StaticClass
    {
        /// <summary>
        /// Вычисление количества пар элементов массива, в которых только одно число делится на 3
        /// </summary>
        /// <param name="massiv"></param>
        /// <returns></returns>
        public static int CountPairs(int[] massiv)
        {
            int count_pairs = 0;
            for (int i = 0; i < massiv.Length; i++)
            {
                if (i + 1 < massiv.Length)
                {
                    if (massiv[i] % 3 == 0 ^ massiv[i + 1] % 3 != 0)
                    {
                        count_pairs++;
                        //Console.WriteLine($"Пара {massiv[i]} и {massiv[i + 1]}");
                    }
                }
            }

            return count_pairs;
        }
        /// <summary>
        /// Считывание массива из текстового файла
        /// </summary>
        /// <param name="file_name"></param>
        /// <returns></returns>
        public static int[] ReadFromFile(string file_name)
        {
            int[] massiv = null;
            if (File.Exists(file_name))
            {
                string[] massive_string = File.ReadAllLines(file_name);
                massiv = new int[massive_string.Length];
                for (int i = 0; i < massive_string.Length; i++)
                {
                    if (!int.TryParse(massive_string[i], out massiv[i]))
                    {
                        throw new FormatException("Выбранный файл имеет другой формат данных.");
                    }
                }
            }
            else
                throw new FileNotFoundException("Выбранный файл не найден.");
            return massiv;
        }
    }
}
