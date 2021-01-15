using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_3_3
{
    /// <summary>
    /// Класс класс дробей - рациональных чисел, являющихся отношением двух целых чисел
    /// </summary>
    class Fraction
    {
        int numerator;
        int denominator;
        /// <summary>
        /// Дробь вида q/p
        /// </summary>
        /// <param name="q"></param>
        /// <param name="p"></param>
        public Fraction(int q, int p)
        {
            numerator = q;
            denominator = p;
            if (denominator == 0) //Проверка знаменателя на 0
                throw new ArgumentException("Знаменатель не может быть равен 0");
        }

        /// <summary>
        /// Значение числителя
        /// </summary>
        /// <returns></returns>
        public int Numerator
        {
            get { return numerator; }
        }
        
        /// <summary>
        /// Значение знаменателя
        /// </summary>
        /// <returns></returns>
        public int Denominator
        {
            get { return denominator; }
        }
        /// <summary>
        /// Десятичное представление дроби
        /// </summary>
        public double Decimal
        {
            get { return (double)numerator / (double)denominator; }
        }

        /// <summary>
        /// Сумма двух дробей
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public Fraction Sum(Fraction X)
        {
            Fraction Y = new Fraction((numerator * X.Denominator + X.Numerator * denominator), (denominator * X.Denominator));
            return Y;            
        }

        /// <summary>
        /// Разность двух дробей
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public Fraction Difference(Fraction X)
        {
            Fraction Y = new Fraction((numerator * X.Denominator - X.Numerator * denominator), (denominator * X.Denominator));
            return Y;
        }

        /// <summary>
        /// Произведение двух дробей
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public Fraction Multiplication(Fraction X)
        {
            Fraction Y = new Fraction(numerator * X.Numerator, denominator * X.Denominator);
            return Y;
        }

        /// <summary>
        /// Деление двух дробей
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        public Fraction Division(Fraction X)
        {
            Fraction Y = new Fraction(numerator * X.Denominator, denominator * X.Numerator);
            return Y;
        }

        /// <summary>
        /// Вывод дроби на экран
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"{numerator} \\ {denominator}");
        }

        /// <summary>
        /// Строковое представление данных
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{numerator} / {denominator}";
        }

        /// <summary>
        /// Алгоритм Евклида для вычисления наибольшего общего делителя двух натуральных чисел
        /// </summary>
        /// <returns></returns>
        private int Nod(int a, int b)
        {
            //Нужно заменять большее число на разность большего и меньшего до тех пор, пока одно из них не станет равно нулю; 
            //тогда второе и есть НОД
            int Nod = 1;
            if (a < 0)
                a *= -1;
            if (b < 0)
                b *= -1;
            while(a > 0)
            {
                if(a < b) // a - наибольшее из двух чисел
                {//Поменять местами
                    int t = a;
                    a = b;
                    b = t;
                }
                a -= b;
            }
            Nod = b;
            return Nod;
        }

        /// <summary>
        /// Упрощение дроби (деление числителя и знаменателя на НОД)
        /// </summary>
        public void Simplify()
        {
            int nod = Nod(numerator, denominator);
            if (nod > 1)
            {
                numerator /= nod;
                denominator /= nod;
            }
        }
    }
}
