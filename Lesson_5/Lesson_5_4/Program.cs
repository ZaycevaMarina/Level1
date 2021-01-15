/* Зайцева Марина
 * Урок 5. Задание 4
 * На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы. 
 * В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, 
 * каждая из следующих N строк имеет следующий формат:
    <Фамилия> <Имя> <оценки>,
    где <Фамилия> — строка, состоящая не более чем из 20 символов, 
        <Имя> — строка, состоящая не более чем из 15 символов, 
        <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. 
    <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом. Пример входной строки:
    Иванов Петр 4 5 3
Требуется написать как можно более эффективную программу, 
которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. 
Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
 */
using System;
using System.IO;
//using System.Collections.Generic;

namespace Lesson_5_4
{
    class Program
    {
        /// <summary>
        /// Содержит фамилию, имя, средний балл
        /// </summary>
        class Student
        {
            string surname;
            string name;
            double markMiddle;// Средний балл
            /// <summary>
            /// Ученик с тремя оценками
            /// </summary>
            /// <param name="_surname"></param>
            /// <param name="_name"></param>
            /// <param name="_mark_1"></param>
            /// <param name="_mark_2"></param>
            /// <param name="_mark_3"></param>
            public Student(string _surname, string _name, int _mark_1, int _mark_2, int _mark_3)
            {
                surname = _surname;
                name = _name;
                markMiddle = ((double)_mark_1 + _mark_2 + _mark_3) / 3;
            }
            /// <summary>
            /// Средний балл
            /// </summary>
            public double MarkMiddle
            {
                get { return markMiddle; }
            }
            /// <summary>
            /// Фамилия и имя ученика
            /// </summary>
            public string Name
            {
                get { return $"{surname} {name}"; }
            }
            /// <summary>
            /// Заполнение полей из строки вида "Фамилия Имя оценки"
            /// </summary>
            /// <param name="line"></param>
            public Student (string line)
            {
                int mark_1, mark_2, mark_3;

                surname = line.Remove(line.IndexOf(' '));
                line = line.Remove(0, line.IndexOf(' ') + 1);

                name = line.Remove(line.IndexOf(' '));
                line = line.Remove(0, line.IndexOf(' ') + 1);

                mark_1 = int.Parse(line.Remove(line.IndexOf(' ')));
                line = line.Remove(0, line.IndexOf(' ') + 1);

                mark_2 = int.Parse(line.Remove(line.IndexOf(' ')));
                line = line.Remove(0, line.IndexOf(' ') + 1);

                mark_3 = int.Parse(line);

                markMiddle = ((double)mark_1 + mark_2 + mark_3) / 3;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("-----Выявление трёх худших по среднему баллу учеников на основании сведений о сдаче трёх экзаменов-----");
            string file_name = "info.txt";
            try
            {
                StreamReader sr = new StreamReader(file_name);
                int.TryParse(sr.ReadLine(), out int N);//Количество учеников

                double mark_min_1 = 0, mark_min_2 = 0, mark_min_3 = 0;
                Student[] students = new Student[N];
                Console.WriteLine($"Всего сведений по {N} ученикам из файла \'{file_name}\'");
                for (int i = 0; i < N; i++)
                {
                    students[i] = new Student(sr.ReadLine());
                    MarksMin(ref mark_min_1, ref mark_min_2, ref mark_min_3, students[i].MarkMiddle, i);
                }
                //Формирование списка учеников с наименьшими значениями среднего балла
                string students_min_mark_1 = "", students_min_mark_2 = "", students_min_mark_3 = "";
                foreach (Student st in students)
                {
                    if (st.MarkMiddle == mark_min_1)
                        students_min_mark_1 += st.Name + ", ";
                    if (st.MarkMiddle == mark_min_2)
                        students_min_mark_2 += st.Name + ", ";
                    if (st.MarkMiddle == mark_min_3)
                        students_min_mark_3 += st.Name + ", ";
                }
                //Удаления последнего разделителя в списке
                students_min_mark_1 = students_min_mark_1.Remove(students_min_mark_1.LastIndexOf(','), 2);
                students_min_mark_2 = students_min_mark_2.Remove(students_min_mark_2.LastIndexOf(','), 2);
                students_min_mark_3 = students_min_mark_3.Remove(students_min_mark_3.LastIndexOf(','), 2);

                Console.WriteLine($"\nФамилии и имена трёх худших по среднему баллу учеников\n" +
                                    $"{mark_min_1:F2}: {students_min_mark_1}\n" +
                                    $"{mark_min_2:F2}: {students_min_mark_2}\n" +
                                    $"{mark_min_3:F2}: {students_min_mark_3}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            Console.WriteLine("\nДля завершения нажмите любую кнопку...");
            Console.ReadLine();
        }

        private static void MarksMin(ref double mark_min_1, ref double mark_min_2, ref double mark_min_3, double markMiddle, int i)
        {
            if (i == 0)
                mark_min_1 = mark_min_2 = mark_min_3 = markMiddle;
            else
            {
                if (mark_min_1 > markMiddle)
                {
                    mark_min_3 = mark_min_2;
                    mark_min_2 = mark_min_1;
                    mark_min_1 = markMiddle;
                }
                else if (mark_min_2 > markMiddle && mark_min_1 != markMiddle)
                {
                    mark_min_3 = mark_min_2;
                    mark_min_2 = markMiddle;
                }
                else if (mark_min_3 > markMiddle && mark_min_2 != markMiddle)
                    mark_min_3 = markMiddle;
            }
        }
    }
}
