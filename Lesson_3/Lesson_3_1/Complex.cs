using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_3_1
{
    /// <summary>
    /// Класс комплекчных чисел
    /// </summary>
    class Complex
    {
        double re;//действительная часть
        double im;//мнимая часть
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Complex()
        {
            re = 0;
            im = 0;
        }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="_re"></param>
        /// <param name="_im"></param>
        public Complex(double _re, double _im)
        {
            re = _re;
            im = _im;
        }
        /// <summary>
        /// Действительная часть комплексного числа
        /// </summary>
        public double Re
        {
            get { return re; }
            set { re = value; }
        }
        /// <summary>
        /// Мнимая часть комплексного числа
        /// </summary>
        public double Im
        {
            get { return im; }
            set { im = value; }
        }
        /// <summary>
        /// Сложение комплексных чисел
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Complex Sum(Complex x)
        {
            return new Complex(re + x.Re, im + x.Im);
        }
        /// <summary>
        /// Вычитание комплексных чисел
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Complex Difference(Complex x)
        {
            return new Complex(re - x.Re, im - x.Im);
        }
        /// <summary>
        /// Произведение комплексных чисел
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public Complex Multiplication(Complex x)
        {
            return new Complex(re * x.Re - im * x.Im, re * x.Im + im * x.Re);
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
