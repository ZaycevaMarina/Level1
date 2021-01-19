/* Зайцева Марина
 * Урок 6. Задание 3
 * Переделать программу «Пример использования коллекций» для решения следующих задач:
а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (частотный массив);
в) отсортировать список по возрасту студента;
г) *отсортировать список по курсу и возрасту студента;
д) разработать единый метод подсчета количества студентов по различным параметрам выбора 
с помощью делегата и методов предикатов.
*/
using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson_6_3
{
    class Student
    {        
        public string firstName;
        public string lastName;
        public string university;
        public string faculty;
        public string department;
        public int course;
        public int age;
        public int group;
        public string city;        
        public Student(string firstName, string lastName, string university, string faculty, string department, int course, int age, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }
    }

    class Program
    {
        /// <summary>
        /// Сравнение студентов по фамилии
        /// </summary>
        /// <param name="st1"></param>
        /// <param name="st2"></param>
        /// <returns></returns>
        static int SortByFirstName(Student stusent_1, Student stusent_2)  
        {
            return String.Compare(stusent_1.firstName, stusent_2.firstName); 
        }
        /// <summary>
        /// Сравнение студентов по возрасту
        /// </summary>
        /// <param name="st1"></param>
        /// <param name="st2"></param>
        /// <returns></returns>
        static int SortByAge(Student stusent_1, Student stusent_2)
        {
            if (stusent_1.age < stusent_2.age)
                return -1;
            else if (stusent_1.age > stusent_2.age)
                return 1;
            return 0;
        }
        /// <summary>
        /// Сравнение студентов по курсу и возрасту
        /// </summary>
        /// <param name="stusent_1"></param>
        /// <param name="stusent_2"></param>
        /// <returns></returns>
        static int SortByCourseAndAge(Student stusent_1, Student stusent_2)
        {
            if (stusent_1.course < stusent_2.course)
                return -1;
            else if (stusent_1.course > stusent_2.course)
                return 1;
            else
            {
                if (stusent_1.age < stusent_2.age)
                    return -1;
                else if (stusent_1.age > stusent_2.age)
                    return 1;
            }
            return 0;
        }

        /// <summary>
        /// Подсчитать количество студентов, учащихся на курсе course и выше
        /// </summary>
        /// <param name="list_of_students"></param>
        /// <param name="course"></param>
        /// <returns></returns>
        static int CalculateStudentsByCourse(List<Student> list_of_students, int course)
        {
            int count = 0;
            foreach (Student student in list_of_students)
            {
                if (student.course >= course)
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Подсчёт количества студентов указанного возраста на каждом курсе
        /// </summary>
        /// <param name="list_of_students"></param>
        /// <param name="age_min"></param>
        /// <param name="age_max"></param>
        /// <returns></returns>
        static Dictionary<int, int> CalculateAndPrintStudentsByAge(List<Student> list_of_students, int age_min, int age_max)
        {
            Dictionary<int, int> students_on_cource_by_age = new Dictionary<int, int>();
            foreach (Student student in list_of_students)
            {
                if (student.age >= age_min && student.age <= age_max)
                {
                    if (!students_on_cource_by_age.ContainsKey(student.course))
                        students_on_cource_by_age[student.course] = 1;
                    else
                        students_on_cource_by_age[student.course]++;
                }
            }
            foreach(var cource in students_on_cource_by_age)
                Console.WriteLine($"Группа №{cource.Key}, количество студентов {cource.Value}");
            return students_on_cource_by_age;
        }
        /// <summary>
        /// Вывод на консоль студентов из списка
        /// </summary>
        /// <param name="list_of_students"></param>
        static void PrintList(List<Student> list_of_students)
        {
            Console.WriteLine($"{"Фамилия",10} {"Имя",10} {"Институт",10} {"Факультет",18} " +
                                  $"{"Кафедра",25} Курс Возраст Группа {"Город",15}");
            foreach (Student st in list_of_students)
                Console.WriteLine($"{st.firstName,10} {st.lastName,10} {st.university,10} {st.faculty,18} " +
                                  $"{st.department,25} {st.course,4} {st.age,7} {st.group,6} {st.city,15}");
        }

        static int CalculateStudents(List<Student> list_of_students, Predicate<Student> condition)
        {
            int count = 0;
            foreach (Student student in list_of_students)
            {
                if (condition(student))
                    count++;
            }
            return count;
        }

        static void Main(string[] args)
        {
            List<Student> list_of_students = new List<Student>(); 
            StreamReader sr = new StreamReader("students_6.txt");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    list_of_students.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Для завершения нажмите любую кнопку...");
                    Console.ReadKey();
                    return;
                }
            }
            sr.Close();
            Console.WriteLine("Всего студентов:" + list_of_students.Count);
            list_of_students.Sort(new Comparison<Student>(SortByFirstName));
            PrintList(list_of_students);
            
            //а)
            Console.WriteLine($"\nа) Количество студентов учащихся на 5 и 6 курсах: {CalculateStudentsByCourse(list_of_students, 5)}");
            
            Console.WriteLine("\nДля перехода к пункту б) нажмите любую кнопку...");
            Console.ReadKey();
            Console.Clear();
            
            //б)
            Console.WriteLine($"б) Количество студентов в возрасте от 18 до 20 лет на каком курсе учатся (частотный массив)");
            CalculateAndPrintStudentsByAge(list_of_students, 18, 20);            
            
            //в)
            Console.WriteLine("\nв) Отсортированный список по возрасту студента");
            list_of_students.Sort(new Comparison<Student>(SortByAge));
            PrintList(list_of_students);

            Console.WriteLine("\nДля перехода к пункту г) нажмите любую кнопку...");
            Console.ReadKey();
            Console.Clear();
            
            //г)
            Console.WriteLine("г) Отсортированный список по курсу и возрасту студента");
            list_of_students.Sort(new Comparison<Student>(SortByCourseAndAge));
            PrintList(list_of_students);

            //д)
            Console.WriteLine("\nд) Единый метод подсчета количества студентов по различным параметрам выбора с помощью делегата и методов предикатов");
            Predicate<Student> isMagister = delegate (Student st) { return st.course >= 5; };
            Predicate<Student> isOlder = delegate (Student st) { return st.age >= 24; };
            Predicate<Student> isInGroup = delegate (Student st) { return st.group == 2; };
            Console.WriteLine($"Количество студентов-магистров: {CalculateStudents(list_of_students, isMagister)}");
            Console.WriteLine($"Количество студентов, 24 и более лет: {CalculateStudents(list_of_students, isOlder)}");
            Console.WriteLine($"Количество студентов в группе №2 {CalculateStudents(list_of_students, isInGroup)}");

            Console.WriteLine("\nДля завершения нажмите любую кнопку...");
            Console.ReadKey();
        }

    }
}
