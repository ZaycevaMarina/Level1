#region 
//Зайцева Марина
//Урок 1. Задание 1
//Написать программу "Анкета". Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес).
//В результате информация выводится в одну строчку:
//  а) используя склеивание;
//  б) используя форматированный вывод;
//  в) используя вывод со знаком $
#endregion

using System;

namespace Lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name, surname, age, height, weight;
            Console.WriteLine("Программа \"Анкета\"");
            Console.WriteLine("Введите Ваше имя:");
            name = Console.ReadLine();
            Console.WriteLine("Введите фамилию:");
            surname = Console.ReadLine();
            Console.WriteLine("Введите возраст:");
            age = Console.ReadLine();
            Console.WriteLine("Введите рост:");
            height = Console.ReadLine();
            Console.WriteLine("Введите вес:");
            weight = Console.ReadLine();
            //a)
            Console.WriteLine("Ваше имя: " + name + ", фамилия " + surname + ", возраст " + age + ", рост " + height + ", вес " + weight);
            //б)
            Console.WriteLine("Ваше имя: {0}, фамилия {1}, возраст {2}, рост {3}, вес {4}", name, surname, age, height, weight);
            //в)
            Console.WriteLine($"Ваше имя: {name}, фамилия {surname}, возраст {age}, рост {height}, вес {weight}");

          
        }
    }
}
