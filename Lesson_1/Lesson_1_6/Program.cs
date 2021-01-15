#region
/*Зайцева Марина
 * Урок 1. Задание 6
 * Создать класс с методами, которые могут пригодиться в учёбе (Print, Pause)
 */
#endregion
using System;

namespace Lesson_1_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 40, y = 13; //Примерно в центре окна
            Print("(с) Марина Зайцева, г.Чехов", x, y);
            Pause();
        }

        public static void Pause()
        {
            Console.ReadKey();
        }

        public static void Print(string msg, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }
    }
}
