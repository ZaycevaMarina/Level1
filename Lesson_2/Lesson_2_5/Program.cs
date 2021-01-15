/* Зайцева Марина
 * Урок 2. Задание 5
 а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы 
    и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
 б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
*/
using System;

namespace Lesson_2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Индекс массы тела");
            double weight = 0, hight = 0;
            while (weight <= 0 || weight >=250)
            {
                Console.WriteLine("Ввеите Ваш вес в кг (число от 0 до 250). ");
                weight = double.Parse(Console.ReadLine());
            }
            while (hight <= 0 || hight >= 2.5)
            {
                Console.WriteLine("Ввеите Ваш рост в метрах (число от 0 до 2,5). ");
                hight = double.Parse(Console.ReadLine());
            }
            double bodyMassIndex = weight / (hight * hight);
            Console.WriteLine($"Индекс массы тела: {bodyMassIndex:F2}");
            //а)
            if (bodyMassIndex <= 16)
                Console.WriteLine("Выраженный дефицит массы тела");
            else if (bodyMassIndex > 16 && bodyMassIndex <= 18.5)
                Console.WriteLine("Недостаточная масса тела");
            else if (bodyMassIndex > 18.5 && bodyMassIndex <= 25)
                Console.WriteLine("Норма");
            else if (bodyMassIndex > 25 && bodyMassIndex <= 30)
                Console.WriteLine("Избыточная масса тела");
            else if (bodyMassIndex > 30 && bodyMassIndex <= 35)
                Console.WriteLine("Ожирение");
            else if (bodyMassIndex > 35 && bodyMassIndex <= 40)
                Console.WriteLine("Ожирение резкое");
            else if (bodyMassIndex > 40)
                Console.WriteLine("Очень резкое ожирение");
            //б)
            if(bodyMassIndex < 18.5)
            {
                double good_weight = 18.5 * hight * hight;
                Console.WriteLine($"Для достижения нормального веса необходимо набрать {(good_weight - weight):F2} kg");
            }
            else if (bodyMassIndex > 25)
            {
                double good_weight = 25 * hight * hight;
                Console.WriteLine($"Для достижения нормального веса необходимо похудеть на {(weight - good_weight):F2} kg");
            }
            Console.WriteLine("Нажмите любую кнопку");
            Console.ReadKey();
        }
    }
}
