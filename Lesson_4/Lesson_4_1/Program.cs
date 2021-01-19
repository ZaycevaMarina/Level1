//Зайцева Марина
//Урок 4. Задание 1.
//Дан целочисленный  массив  из 20 элементов.  Элементы  массива  могут принимать  целые  значения  от –10 000 до 10 000 включительно. 
//Заполнить случайными числами.  Написать программу, позволяющую найти и вывести количество пар элементов массива, 
//    в которых только одно число делится на 3. 
//В данной задаче под парой подразумевается два подряд идущих элемента массива. 
//    Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.

using System;

namespace Lesson_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----Подсчёт количества пар элементов массива, в которых только одно число делится на 3-----\n");
            Random rnd = new Random();
            int N = 20;
            int[] massiv = new int[N];
            for (int i = 0; i < massiv.Length; i++)
                massiv[i] = rnd.Next(-10_000, 10_001);//от –10 000 до 10 000 включительно
            Console.Write("Массив целых значений от –10 000 до 10 000:\n");
            foreach (int count in massiv)
                Console.Write($"{count} ");
            Console.WriteLine();
            int count_pairs = 0;
            for(int i = 0; i < massiv.Length; i++)
            {
                if(i+1 < massiv.Length)
                {
                    if (massiv[i] % 3 == 0 ^ massiv[i + 1] % 3 != 0 )//(massiv[i] % 3 == 0 && massiv[i + 1] % 3 != 0 || massiv[i] % 3 != 0 && massiv[i + 1] % 3 == 0)
                    {
                        count_pairs++;
                        //Console.WriteLine($"Пара {massiv[i]} и {massiv[i + 1]}");
                    }
                }
            }
            Console.WriteLine($"Количество пар: {count_pairs}");
            Console.WriteLine("Для завершения  любую кнопку...");
            Console.ReadKey();
        }
    }
}
