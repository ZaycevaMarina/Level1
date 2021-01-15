/* Зайцева Марина
 * Библиотека для задания 5 урока 4.
 * Библиотека с классом для работы с двумерным массивом. 
 * Содержит: конструктор, заполняющий массив случайными числами. 
           * метод, возвращающий сумму всех элементов массива,
           * метод, возвращающий сумму всех элементов массива больше заданного числа,
           * свойство, возвращающее минимальный элемент массива,
           * свойство, возвращающее максимальный элемент массива,
           * метод, возвращающий индексы максимального элемента массива (через параметры, используя модификатор ref или out).
           ** конструктор и методы, которые загружают данные из файла и записывают данные в файл.
 * Обработывает возможные исключительные ситуации при работе с файлами.   
*/
using System;
using System.IO;
/// <summary>
/// Библиотека с классом для работы с двумерным массивом
/// </summary>
namespace Array_2_dimensional
{
    /// <summary>
    /// Класс для работы с двумерным массивом
    /// </summary>
    public class Array_2Dim
    {
        int[,] array;
        /// <summary>
        /// Конструктор, заполняющий массив N*M случайными числами
        /// </summary>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <param name="max">Максимальное значение элементов массива</param>
        public Array_2Dim(int N, int M, int max)
        {
            array = new int[N, M];
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    array[i,j] = rnd.Next(max);
        }
        /// <summary>
        /// метод, возвращающий сумму всех элементов массива
        /// </summary>
        /// <returns></returns>
        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    sum += array[i, j];
            return sum;
        }
        /// <summary>
        /// Метод, возвращающий сумму всех элементов массива больше заданного
        /// </summary>
        /// <param name="current_value"></param>
        /// <returns></returns>
        public int Sum(int current_value)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if (array[i, j] > current_value)
                        sum += array[i, j];
            return sum;
        }
        /// <summary>
        /// Свойство, возвращающее минимальный элемент массива
        /// </summary>
        public int Min
        {
            get
            {
                int min = array[0,0];
                for (int i = 0; i < array.GetLength(0); i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                        if (min > array[i, j])
                            min = array[i, j];
                return min;
            }
        }
        /// <summary>
        /// Свойство, возвращающее максимальный элемент массива
        /// </summary>
        public int Max
        {
            get
            {
                int max = array[0, 0];
                for (int i = 0; i < array.GetLength(0); i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                        if (max < array[i, j])
                            max = array[i, j];
                return max;
            }
        }
        /// <summary>
        /// Метод, возвращающий индексы максимального элемента массива (через параментры)
        /// </summary>
        /// <param name="_i"></param>
        /// <param name="_j"></param>
        public void Max_index(out int _i, out int _j)
        {
            int max = Max;
            _i = -1;
            _j = -1;
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if (max == array[i, j])
                    {
                        _i = i;
                        _j = j;
                    }
        }
        /// <summary>
        /// Запись элементов массива в файл
        /// </summary>
        /// <param name="file_name"></param>
        public void WriteToFile(string file_name)
        {
            StreamWriter sw = new StreamWriter(file_name);
            if (sw == null)
                throw new FileLoadException($"Не удалось загрузить файл {file_name}.");
            sw.WriteLine(array.GetLength(0));//Запись размеров массива в файл в первых двух строках
            sw.WriteLine(array.GetLength(1));
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    sw.WriteLine(array[i, j]);
            sw.Close();
        }
        /// <summary>
        /// Заполнение двумерного массива данными из файла
        /// </summary>
        /// <param name="file_name"></param>
        public void ReadFromFile(string file_name)
        {
            try
            {
                StreamReader sr = new StreamReader(file_name);
                int N, M;
            
                int.TryParse(sr.ReadLine(), out N);//В первых двух строках - размер двумерного массива, записанного в файле
                int.TryParse(sr.ReadLine(), out M);
                if (N <= 0 || M <= 0)
                    throw new FormatException($"Размер двумерного массива в файле {file_name} не является положительным числом.");
                array = new int[N, M];
                for (int i = 0; i < N; i++)
                    for (int j = 0; j < M; j++)
                        int.TryParse(sr.ReadLine(), out array[i, j]);
                sr.Close();
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException($"Файл {file_name} не найден.");
            }
            catch (EndOfStreamException)
            {
                throw new EndOfStreamException($"Конец файла {file_name} достигнут ранее считывания всех элементов двумерного массива");
            }
            catch (ArgumentException)
            {
                throw new ArgumentException($"Файл {file_name} содержит строки не являющиеся целыми числами.");
            }
        }
        /// <summary>
        /// Заполнение двумерного массива данными из файла
        /// </summary>
        /// <param name="file_name"></param>
        public Array_2Dim(string file_name)
        {
            StreamReader sr = new StreamReader(file_name);
            if (sr == null)
                throw new FileNotFoundException("Указанный файл не найден.");
            int N, M;
            try
            {
                int.TryParse(sr.ReadLine(), out N);//В первых двух строках - размер двумерного массива, записанного в файле
                int.TryParse(sr.ReadLine(), out M);
                if (N <= 0 || M <= 0)
                    throw new FormatException($"Размер двумерного массива в файле {file_name} не является положительным числом.");
                array = new int[N, M];
                for (int i = 0; i < N; i++)
                    for (int j = 0; j < M; j++)
                        int.TryParse(sr.ReadLine(), out array[i, j]);
            }
            catch (EndOfStreamException)
            {
                throw new EndOfStreamException($"Конец файла {file_name} достигнут ранее считывания всех элементов двумерного массива");
            }
            catch (ArgumentException)
            {
                throw new ArgumentException($"Файл {file_name} содержит строки не являющиеся целыми числами.");
            }
            sr.Close();
        }
        /// <summary>
        /// Вывод двумерного массива на экран
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write($"{array[i, j]} ");
                Console.WriteLine();
            }
        }
    }
}
