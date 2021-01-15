/* Зайцева Марина
 * Урок 5. Задание 3
 * *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
        Например:
        badc являются перестановкой abcd.
 */
using System;
using System.Collections.Generic;

namespace Lesson_5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----Для двух строк определить, является ли одна строка перестановкой другой-----");
            string s1 = "badc", s2 = "abcd";
            Console.WriteLine($"Строка 1: {s1}\nСтрока 2: {s2}");
            if (s1.Length != s2.Length)
                Console.WriteLine($"Длины строк различны: {s1.Length} и {s2.Length} соответственно.");
            else
            {
                if (IsPermutaion(s1, s2))
                    Console.WriteLine("Вторая строка является перестановкой первой");
                else
                    Console.WriteLine("Вторая строка не является перестановкой первой");
            }
            Console.WriteLine("\nДля завершения нажмите любую кнопку...");
            Console.ReadLine();
        }
        /// <summary>
        /// Определяет, является ли одна строка перестановкой другой
        /// </summary>
        /// <param name="s1">Первая строка</param>
        /// <param name="s2">Вторая строка</param>
        /// <returns>True - является перестановкой</returns>
        private static bool IsPermutaion(string s1, string s2)
        {
            //Находение частотных анализов символов в словах на основании уникальных символов слова s1
            Dictionary<char, int> signFrequencyAnalysis_s1 = SignFrequencyAnalysis(GetSigns(s1), s1);
            Dictionary<char, int> signFrequencyAnalysis_s2 = SignFrequencyAnalysis(GetSigns(s1), s2);
            bool is_permutation = true;
            //Сравнение частотных анализов символов
            foreach (var line in signFrequencyAnalysis_s1)
            {
                if (signFrequencyAnalysis_s2.ContainsKey(line.Key) == false || line.Value != signFrequencyAnalysis_s2[line.Key])
                {
                    is_permutation = false;//Не совпадают хотя бы в одном значении
                    break;
                }
            }
            return is_permutation;
        }

        /// <summary>
        /// Разбить слово на буквы
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Массив уникальных символов</returns>
        private static char[] GetSigns(string word)
        {
            string word_char_ss = "";
            int i, j;
            for (i = 0; i < word.Length; i++)
            {
                for (j = 0; j < i; j++)
                {
                    if (word[j] == word[i])
                        break;
                }
                if (i == j)
                    word_char_ss += word[i];//Новый символ слова
            }
            return word_char_ss.ToCharArray();
        }
        /// <summary>
        /// Частотный анализ символов слова
        /// </summary>
        /// <param name="signs">массив символов</param>
        /// <param name="word">слово</param>
        /// <returns></returns>
        private static Dictionary<char, int> SignFrequencyAnalysis(char[] signs, string word)
        {
            char[] signs_in_word = GetSigns(word);
            Dictionary<char, int> signFrequencyAnalysis = new Dictionary<char, int>();
            foreach (char char_fr in word)
                foreach (char sign_in_word in signs_in_word)
                {
                    if (char_fr == sign_in_word)
                    {
                        if (!signFrequencyAnalysis.ContainsKey(char_fr))
                            signFrequencyAnalysis[char_fr] = 1;//Символ найден впервые
                        else
                            signFrequencyAnalysis[char_fr]++;//Символ найден повторно
                    }
                    if (!signFrequencyAnalysis.ContainsKey(char_fr))
                        signFrequencyAnalysis[char_fr] = 0;//Символ не найден
                }
            return signFrequencyAnalysis;
        }
    }
}
