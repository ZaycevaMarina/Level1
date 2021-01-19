/* Зайцева Марина
 * Урок 6. Задание 4
 * Считайте файл различными способами. Смотрите “Пример записи файла различными способами”. 
 * Создайте методы, которые возвращают:
    * массив byte (FileStream, BufferedStream), 
    * строку для StreamReader,
    * массив int для BinaryReader. */
using System;
using System.IO;
using System.Diagnostics;

namespace Lesson_6_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----Чтение файла различными способами-----");
            string file_name = "bigdata.bin";
            long size = 1024 * 1024;// 1Mb
            Console.WriteLine($"Предварительная запись файла размером {size} байт.");
            Console.WriteLine("FileStream. Milliseconds:{0}", WriteFileByFileStream(file_name, size));
            //Console.WriteLine("BinaryStream. Milliseconds:{0}", WriteFileByBinaryStream("bigdata1.bin", size));
            //Console.WriteLine("StreamWriter. Milliseconds:{0}", WriteFileByStreamWriter("bigdata2.bin", size));
            //Console.WriteLine("BufferedStream. Milliseconds:{0}", WriteFileByBufferedStream("bigdata3.bin", size));
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            byte[] bt =  ReadFileByFileStream(file_name);
            stopwatch.Stop();
            Console.WriteLine($"Файл успешно считан с помощью FileStream. Размер: {bt.Length * 4}. {stopwatch.ElapsedMilliseconds} mc");

            stopwatch.Start();
            int[] it = ReadFileByBinaryStream(file_name);
            stopwatch.Stop();
            Console.WriteLine($"Файл успешно считан с помощью BinaryStream. Размер: {it.Length * 4}. {stopwatch.ElapsedMilliseconds} mc");

            stopwatch.Start();
            string st = ReadFileByStreamReader(file_name);
            stopwatch.Stop();
            Console.WriteLine($"Файл успешно считан с помощью BinaryStream. Размер: {st.Length}. {stopwatch.ElapsedMilliseconds} mc");

            stopwatch.Start();
            bt = ReadFileByBufferedStream(file_name);
            stopwatch.Stop();
            Console.WriteLine($"Файл успешно считан с помощью BufferedStream. Размер: {bt.Length * 4}. {stopwatch.ElapsedMilliseconds} mc");

            Console.WriteLine("Для завершения нажмите любую кнопку...");
            Console.ReadKey();
        }

        static long WriteFileByFileStream(string file_name, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(file_name, FileMode.Create, FileAccess.Write);
            for (int i = 0; i < size; i++)
                fs.WriteByte(0);
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        static byte[] ReadFileByFileStream(string file_name)
        {
            FileStream fs = new FileStream(file_name, FileMode.Open);
            long size = fs.Length / 4;
            byte[] bfile = new byte[size];
            for (long i = 0; i < size; i++)
                bfile[i] = (byte)fs.ReadByte();
            fs.Close();
            return bfile;
        }

        static long WriteFileByBinaryStream(string file_name, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(file_name, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 0; i < size; i++)
                bw.Write((byte)0);
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static int[] ReadFileByBinaryStream(string file_name)
        {
            FileStream fs = new FileStream(file_name, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            int[] bfile = new int[fs.Length / 4];
            for (long i = 0; i < fs.Length / 4; i++)
                bfile[i] = br.ReadByte();
            fs.Close();
            return bfile;
        }

        static long WriteFileByStreamWriter(string file_name, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(file_name, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < size; i++)
                sw.Write(0);
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static string ReadFileByStreamReader(string file_name)
        {
            FileStream fs = new FileStream(file_name, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string st = sr.ReadToEnd();
            fs.Close();
            return st;
        }

        static long WriteFileByBufferedStream(string file_name, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(file_name, FileMode.Create, FileAccess.Write);
            int countPart = 4;//количество частей
            int bufsize = (int)(size / countPart);
            byte[] buffer = new byte[size];
            BufferedStream bs = new BufferedStream(fs, bufsize);
            for (int i = 0; i < countPart; i++)
                bs.Write(buffer, 0, (int)bufsize);
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        
        static byte[] ReadFileByBufferedStream(string file_name)
        {
            FileStream fs = new FileStream(file_name, FileMode.Open);
            int size = (int)fs.Length / 4;
            byte[] bt = new byte[size];
            int countPart = 4;//количество частей
            int bufsize = (int)(size / countPart);
            BufferedStream bs = new BufferedStream(fs, bufsize);
            for (int i = 0; i < countPart; i++)
                bs.Read(bt, i * bufsize, bufsize);
            fs.Close();
            return bt;
        }
    }
}
