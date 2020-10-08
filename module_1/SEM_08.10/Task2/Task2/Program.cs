using System;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Text;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"Data.txt";

            // Создаем файл с данными
            if (File.Exists(path))
            {
                // Сейчас данные для записи вбиты в коде
                // TODO1: сохранить в файл целые случайные значения из диапазона [10;100)
                const int L = 15;
                string createText = "";
                Random rand = new Random();
                for (int i = 0; i < L; ++i)
                    createText += (rand.Next(10, 100)) + ((i % 4 == 0) ? "\n" : " ");

                File.WriteAllText(path, createText, Encoding.UTF8);
            }

            // Open the file to read from
            if (File.Exists(path))
            {
                string readText = File.ReadAllText(path);
                string[] strVal = readText.Split(' ');

                int[] arr = StringArrayToIntArray(strVal);
                foreach (int i in arr)
                {
                    Console.Write(i + " ");
                }

                int[] evenInd = new int[0];
                int[] oddInd = new int[0];

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0)
                    {
                        Array.Resize(ref evenInd, evenInd.Length + 1);
                        evenInd[evenInd.Length - 1] = i;
                    }
                    else
                    {
                        Array.Resize(ref oddInd, oddInd.Length + 1);
                        oddInd[oddInd.Length - 1] = i;
                        arr[i] = 0;

                    }
                }
                Console.Write('\n');

                foreach (int i in arr)
                    Console.Write(i + " ");

            }

        } // end of Main()

        // преобразование массива строк в массив целых чисел
        public static int[] StringArrayToIntArray(string[] str)
        {
            int[] arr = null;
            if (str.Length != 0)
            {
                arr = new int[0];
                foreach (string s in str)
                {
                    int tmp;
                    if (int.TryParse(s, out tmp))
                    {
                        Array.Resize(ref arr, arr.Length + 1);
                        arr[arr.Length - 1] = tmp;
                    }
                } // end of foreach (string s in str)      
            }
            return arr;
        } // end of StringToIntArray()
    } // end of Program
}
