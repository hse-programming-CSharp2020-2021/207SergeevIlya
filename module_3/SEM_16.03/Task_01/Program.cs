// Проект 2. Чтение целых из двоичного потока. 
// ЧИТАТЬ И ЗАПИСЫВАТЬ СТРОГО ПО ОДНОМУ ЧИСЛУ!!! 
using System;
using System.IO;

namespace Task_01
{
    class Program
    {
        static void Main()
        {
            FileStream f = new FileStream("example.txt", FileMode.Open);
            BinaryReader fIn = new BinaryReader(f);
            long n = f.Length / 4; int a;
            for (int i = 0; i < n; i++)
            {
                a = fIn.ReadInt32();
                Console.Write(a + " ");
            }
            Console.WriteLine("\nЧисла в обратном порядке:");

            // 1) TODO: Прочитать и напечатать все числа из файла в обратном порядке

            for (int i = 1; i <= n; i++)
            {
                f.Seek(-4 * i, SeekOrigin.End);
                Console.WriteLine(fIn.ReadInt32());
            }

            // 2) TODO: увеличить  все числа в файле в 5 раз
            BinaryWriter bWrite = new BinaryWriter(f);
            for (int i = 0; i < n; i++)
            {
                a = fIn.ReadInt32();
                f.Seek(i * 4, SeekOrigin.Begin);

                bWrite.Write(a * 5);
            }

            bWrite.Close();

            // 3) TODO: Прочитать и напечатать все числа из файла в прямом порядке
            using FileStream fRead = new FileStream("example.txt", FileMode.Open);
            using BinaryReader fIn2 = new BinaryReader(fRead);
            for (int i = 0; i < n; i++)
            {
                Console.Write(fIn2.ReadInt32() + " ");
            }
        }
    }

}
