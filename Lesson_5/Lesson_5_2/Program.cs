/* Зайцева Марина
 * Урок 5. Задание 2
 * Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
а) Вывести только те слова сообщения, которые содержат не более n букв.
б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
в) Найти самое длинное слово сообщения.
г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
д) ***Создать метод, который производит частотный анализ текста. 
В качестве параметра в него передается массив слов и текст, 
в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. 
Здесь требуется использовать класс Dictionary.
 */
using System;
using System.Collections.Generic;

namespace Lesson_5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----Демонстрация статического класса Message, содержащего статические методы для обработки текста-----");
            string message = @"Краб крабу сделал грабли, подарил грабли крабу: «Грабь граблями гравий, краб» 12345678";
            Console.WriteLine($"\n\tИсходное сообщение:\n{message}");
            //а)
            int len = 5;
            Console.WriteLine($"\n\tСлова сообщения, которые содержат не более {len} букв:");
            Message.PrintChoozenByLength(message, len);
            //б)
            char sign = 'л';//'8';//'\"';
            Message.DeleteWordsBySign(ref message, sign);
            Console.WriteLine($"\n\tПосле удаления всех слов, которые заканчиваются на символ \'{sign}\' сообщение:\n{message}");
            //в)
            Console.WriteLine($"\n\tСамое длинное слово: \"{Message.WordMaxLength(message)}\"");
            //г)
            Console.WriteLine($"\n\tСтрока из самых длинных слов сообщения: \"{Message.GetLongWords(message)}\"");
            //д)
            string[] words = { "Краб", "крабу", "грабли", "краб", "нет" };
            Dictionary<string, int> wordsFrAnalysis = Message.WordFrequencyAnalysis(words, message);
            Console.WriteLine($"\n\tЧастотный анализ текста:");
            foreach (var line in wordsFrAnalysis)
                Console.WriteLine($"Слово \"{line.Key}\" встречается {line.Value} раз(а).");

            Console.WriteLine("\nДля завершения нажмите любую кнопку...");
            Console.ReadLine();
        }
    }
}
