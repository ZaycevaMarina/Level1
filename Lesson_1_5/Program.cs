#region
/*Зайцева Марина
 * Урок 1. Задание 5
 * а) Вывести на экран имя, фамилию и город проживания
 * б) Организовать в центре экрана
 * в) использовать собственный метод
 */
#endregion
using System;

namespace Lesson_1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 40, y = 13; //Примерно в центре окна
            Print("(с) Марина Зайцева, г.Чехов", x, y);
            Console.ReadKey();            
        }

        private static void Print(string msg, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }
    }
}
