/* Зайцева Марина
 * Урок 3. Задание 1
 * а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.
   б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
   в) Добавить диалог с использованием switch, демонстрирующий работу класса.
*/
using System;

namespace Lesson_3_1
{    
    class Program
    {
        static void Main(string[] args)
        {
            #region "a)"
            Console.WriteLine("а)-----Работа структуры Complex-----");

            _Complex a = new _Complex(1, 2);
            _Complex b = new _Complex(3, 5);
            Console.WriteLine($"Первое комплексное число: {a.ToString()}");
            Console.WriteLine($"Второе комплексное число: {b.ToString()}");

            Console.WriteLine($"Сумма чисел: {a.Sum(b).ToString()}\n");
            Console.WriteLine($"Разность чисел: {a.Difference(b).ToString()}\n");
            Console.WriteLine($"Умножение чисел: {a.Multiplication(b).ToString()}\n");

            Console.WriteLine("Для перехода к пункты б) нажмите любую кнопку");
            Console.ReadKey();
            Console.Clear();
            #endregion
            Console.WriteLine("б)-----Работа класса Complex-----");
            Complex c = new Complex(3, 5);            
            Complex d = new Complex(2, 6);
            Console.WriteLine($"Первое комплексное число: {c.ToString()}");
            Console.WriteLine($"Второе комплексное число: {d.ToString()}");
            char user_case = '\0';
            Complex result;
            while (user_case != 'q')
            {
                Console.WriteLine("\nВыбирете действие над комплексными числами: +, -, *, q (для завершения)");
                user_case = Console.ReadKey().KeyChar;
                switch(user_case)
                {
                    case '+':
                        result = c.Sum(d);
                        Console.WriteLine($"\nСумма чисел: {result.ToString()}\n");
                        break;
                    case '-':
                        result = c.Difference(d);
                        Console.WriteLine($"\nРазность чисел: {result.ToString()}\n");
                        break;
                    case '*':
                        result = c.Multiplication(d);
                        Console.WriteLine($"\nПроизведение чисел: {result.ToString()}\n");
                        break;
                    case 'q':
                        break;
                    default:
                        break;
                } 
            }

            Console.WriteLine("\nДля завершения нажмите любую кнопку");
            Console.ReadKey();
        }
    }
    /// <summary>
    /// Комплексное чисело
    /// </summary>
    struct _Complex
    {
        double re;//действительная часть
        double im;//мнимая часть
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="_re"></param>
        /// <param name="_im"></param>
        public _Complex(double _re, double _im)
        {
            re = _re;
            im = _im;
        }
        
        /// <summary>
        /// Сложение двух комплексных чисел
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public _Complex Sum(_Complex x)
        {
            return new _Complex(re + x.re, im + x.im); 
        }
        /// <summary>
        /// Вычитание двух комплексных чисел
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public _Complex Difference(_Complex x)
        {
            return new _Complex(re - x.re, im - x.im);
        }
        /// <summary>
        /// Произведение двух комплексных чисел
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public _Complex Multiplication(_Complex x)
        {
            return new _Complex(re * x.re - im * x.im, re * x.im + im * x.re);
        }
        /// <summary>
        /// Строковое представление данных
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (re == 0 && im == 0)
                return "0"; 
            if (re == 0)
                return $"{im}i";//Только мнимая часть
            string s = $"{re}";
            if (im > 0)
                s += $"+{im}i";
            else if (im < 0)
                s += $"{im}i";            
            return s;
        }
    }
}
