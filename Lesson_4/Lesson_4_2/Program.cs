/* Зайцева Марина
 * Урок 4. Задание 2.
 * Реализуйте задачу 1 в виде статического класса StaticClass;
 * а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
 * б) *Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
 * в)**Добавьте обработку ситуации отсутствия файла на диске.
 */
using System;

namespace Lesson_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----Подсчёт количества пар элементов массива, в которых только одно число делится на 3-----\n");
            #region a)
            Random rnd = new Random();
            int N = 20;
            int[] massiv = new int[N];
            //Заполяняем массив целые значения от –10 000 до 10 000 включительно
            for (int i = 0; i < massiv.Length; i++)
                massiv[i] = rnd.Next(-10_000, 10_001);//от –10 000 до 10 000 включительно
            Console.Write("Массив целых значений от –10 000 до 10 000:\n");
            Print(massiv);
            int count_pairs = StaticClass.CountPairs(massiv);//Решение задачи 1
            Console.WriteLine($"Количество пар: {count_pairs}");
            #endregion
            Console.WriteLine("\n-----Пункт б) Cчитывание массива из текстового файла-----");
            #region б)

            string file_name = "data.txt";
            int[] massiv_b = StaticClass.ReadFromFile(file_name);
            if (massiv_b != null)
            {
                Console.WriteLine($"Считанный массив из файла: {file_name}");
                Print(massiv_b);
                count_pairs = StaticClass.CountPairs(massiv);//Решение задачи 1
                Console.WriteLine($"Количество пар: {count_pairs}");
            }
            #endregion
            Console.WriteLine("\n-----Пункт в) Обработка ситуации отсутствия файла на диске-----");
            #region в)
            file_name = "NoFile.txt";
            int[] massiv_c = null;
            try
            {
                massiv_c = StaticClass.ReadFromFile(file_name);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion
            Console.WriteLine("\nДля завершения  любую кнопку...");
            Console.ReadKey();
        }        
        /// <summary>
        /// Вывод массива на экран
        /// </summary>
        /// <param name="massiv"></param>
        static private void Print(int[] massiv)
        {
            foreach (int count in massiv)
                Console.Write($"{count} ");
            Console.WriteLine();
        }
    }
}
