/* Зайцева Марина
 * Урок 4. Задание 5
 * *а) Реализовать библиотеку с классом для работы с двумерным массивом. 
     * Реализовать конструктор, заполняющий массив случайными числами. 
     * Создать метод, возвращающий сумму всех элементов массива, 
             * метод, возвращающий сумму всех элементов массива больше заданного числа, 
             * свойство, возвращающее минимальный элемент массива, 
             * свойство, возвращающее максимальный элемент массива, 
             * метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
*   *б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
*   *в) Обработать возможные исключительные ситуации при работе с файлами.
*/
using System;
using Array_2_dimensional;

namespace Lesson_4_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----Демонстрация реализованной библиотеки <Array_2_dimensional> с классом для работы с двумерным массивом-----");
            Array_2Dim array_2Dim = new Array_2Dim(3, 5, 100);
            Console.WriteLine("Массив размером 3*5 со значениями не более 100");
            array_2Dim.Print();
            Console.WriteLine($"Сумма всех элементов массива: {array_2Dim.Sum()}");
            Console.WriteLine($"Сумма всех элементов массива больше 50: {array_2Dim.Sum(50)}");
            Console.WriteLine($"Минимальный элемент массива: {array_2Dim.Min}");
            Console.WriteLine($"Максимальный элемент массива: {array_2Dim.Max}");
            array_2Dim.Max_index(out int i, out int j);
            Console.WriteLine($"Индексы максимального элемента массива: {i}, {j}");
            string file_name = "Array_2Dim.txt";
            try
            {
                array_2Dim.WriteToFile(file_name);
                Console.WriteLine($"Двумерный массив записан в файл: {file_name}");
                array_2Dim.ReadFromFile(file_name);
                Console.WriteLine($"Двумерный массив загружен из файла: {file_name} с помощью метода:");
                array_2Dim.Print();
                Array_2Dim array_2Dim1 = new Array_2Dim(file_name);
                Console.WriteLine($"Двумерный массив загружен из файла: {file_name} с помощью конструктора:");
                array_2Dim1.Print();
            }
            catch (System.IO.FileLoadException ex) { Console.WriteLine(ex.Message); }
            catch (System.IO.FileNotFoundException ex) { Console.WriteLine(ex.Message); }            
            catch (System.IO.EndOfStreamException ex) { Console.WriteLine(ex.Message); }
            catch (FormatException ex) { Console.WriteLine(ex.Message); }
            catch (ArgumentException ex) { Console.WriteLine(ex.Message); }

            Console.WriteLine("\nДля завершения нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
