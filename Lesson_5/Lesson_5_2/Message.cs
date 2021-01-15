/* Cтатический класс Message, содержащий следующие статические методы для обработки текста:
а) Вывести только те слова сообщения, которые содержат не более n букв.
б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
в) Найти самое длинное слово сообщения.
г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
д) ***Создать метод, который производит частотный анализ текста. 
В качестве параметра в него передается массив слов и текст, 
в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. 
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_5_2
{
    static class Message
    {
        /// <summary>
        /// Вывести только те слова сообщения, которые содержат не более n букв
        /// </summary>
        /// <param name="message"></param>
        /// <param name="n">ограничение длины слова</param>
        public static void PrintChoozenByLength(string message, int n)
        {
            string[] words = GetWords(message);            
            foreach (string word in words)
            {
                if (word.Length <= n)
                    Console.WriteLine(word);
            }
        }
        /// <summary>
        /// Удалить из сообщения все слова, которые заканчиваются на заданный символ
        /// </summary>
        /// <param name="message"></param>
        /// <param name="sign">буква или число в конце слова</param>
        public static void DeleteWordsBySign(ref string message, char sign)
        {
            StringBuilder text = new StringBuilder(message);
            int i_start = 0;
            bool word_start = false;
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetterOrDigit(text[i]))
                {
                    if (word_start == false)
                    {
                        i_start = i;
                        word_start = true;
                    }
                }
                else if (char.IsPunctuation(text[i]) || char.IsSeparator(text[i]) || char.IsWhiteSpace(text[i]))
                {
                    if (word_start == true)
                    {
                        if (text[i-1] == sign)//Последний символ слова
                        {//Удалить слово, заканчивающееся на заданный символ 'sign'
                            text.Remove(i_start, i - i_start);
                            i = i_start;//Длина сообщения уменшилась на i_start (длину удалённого слова)
                        }
                        word_start = false;
                    }
                }
                if (i == text.Length - 1 && word_start == true)
                {//Конец текста
                    if (text[i] == sign)
                        text.Remove(i_start, i - i_start + 1);//Удалить слово, заканчивающееся на заданный символ 'sign'
                }
            }   
            message = text.ToString();//Сохранение изменений в исходном сообщении
        }
        /// <summary>
        /// Найти самое длинное слово сообщения
        /// </summary>
        /// <param name="message"></param>
        public static string WordMaxLength(string message)
        {
            string[] words = GetWords(message);
            int max_length = 0;
            string wordMaxLength = "";
            foreach(string word in words)
            {
                if(max_length < word.Length)
                {
                    max_length = word.Length;
                    wordMaxLength = word;
                }
            }
            return wordMaxLength;
        }
        /// <summary>
        /// Разбить сообщение на слова без знаков пунктуации
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static string[] GetWords(string message)
        {
            StringBuilder text = new StringBuilder(message);
            for (int i = 0; i < text.Length;)
                if (char.IsPunctuation(text[i]))
                    text.Remove(i, 1);
                else ++i;
            string text1 = text.ToString();
            return text1.Split(' ');
        }
        /// <summary>
        /// Сформировать строку из самых длинных слов сообщения
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string GetLongWords(string message)
        {
            string messageLongWords = "";
            string[] words = Message.GetWords(message);//Выделение слов из сообщнеия с использованием StringBuilder
            int max_length = 0;
            //Находнение максимальной длины слова в сообщении
            foreach (string word in words)
                if (max_length < word.Length)
                    max_length = word.Length;
            //Находнение всех слов максимальной длины
            foreach (string word in words)
                if (word.Length == max_length)
                    messageLongWords += word + " ";//Формирование строки из самых длинных слов сообщения
            if (messageLongWords.Length > 0)
                messageLongWords = messageLongWords.Remove(messageLongWords.Length - 1);//Удаление последнего " "
            return messageLongWords;
        }
        /// <summary>
        /// Частотный анализ текста
        /// </summary>
        /// <param name="words">массив слов</param>
        /// <param name="message">текст</param>
        /// <returns></returns>
        public static Dictionary<string, int> WordFrequencyAnalysis(string[] words, string message)
        {
            string[] words_from_message = Message.GetWords(message);
            Dictionary<string, int> wordFrequencyAnalysis = new Dictionary<string, int>();
            foreach(string word_fr in words)
                foreach(string word_msg in words_from_message)
                {
                    if(word_fr == word_msg)
                    {
                        if (!wordFrequencyAnalysis.ContainsKey(word_fr))
                            wordFrequencyAnalysis[word_fr] = 1;//Слово найдено впервые
                        else
                            wordFrequencyAnalysis[word_fr]++;//Слово найдено повторно
                    }
                    if (!wordFrequencyAnalysis.ContainsKey(word_fr))
                        wordFrequencyAnalysis[word_fr] = 0;//Слово word не найдено
                }
            return wordFrequencyAnalysis;
        }
    }
}
