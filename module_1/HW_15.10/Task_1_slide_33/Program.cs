using System;
using System.IO;
using System.Runtime.Serialization.Formatters;

// Первая задача с 33ьего слайда.

namespace Task_1_slide_33
{
    class Program
    {
        // Метод для получения массива чисел из файла с путём path.
        static int[] GetArrFromFile(string path)
        {
            try
            {
                // Получаем числа в виде строк.
                string strs = File.ReadAllText(path);

                string[] Arr_String = strs.Split(' ');
                int[] Arr = new int[Arr_String.Length];

                // Пробуем преобразовать в int.
                for (int i = 0; i < Arr.Length; ++i)
                {
                    Arr[i] = int.Parse(Arr_String[i]);
                }

                return Arr;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new int[0];
            }
        }

        // Метод для вывода массива arr в файл с путём path.
        static void PrintArrToFile(bool[] arr, string path, bool add)
        {
            try
            {
                // Пробуем вывести через поток в файл (в конец файла, если add == true).
                StreamWriter sw = new StreamWriter(path, add);

                foreach (var el in arr)
                {
                    sw.Write(el + " ");
                }

                // Закрываем файл.
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Main(string[] args)
        {
            // Пути к файлам для чтения и записи.
            string Input_Path = "C:/Users/IlyaLayk/Desktop/207SergeevIlya/module_1/HW_15.10/Task_1_slide_33/input.txt", //Console.ReadLine();
                   Output_Path = "C:/Users/IlyaLayk/Desktop/207SergeevIlya/module_1/HW_15.10/Task_1_slide_33/output.txt";

            // Пробуем считать массив A из файла.
            try
            {
                // Получаем числа в виде строк.
                string s = File.ReadAllText(Input_Path);

                string []  A_String =  s.Split(' ');
                int[] A = new int[A_String.Length];

                // Пробуем преобразовать в int.
                for (int i = 0; i < A.Length; ++i)
                {
                    A[i] = int.Parse(A_String[i]);
                }

                // Создаём и заполняем результирующий массив L.
                bool[] L = new bool[A.Length];
                for (int i = 0; i < A.Length; ++i)
                    L[i] = (A[i] > 0);

                // Выводим L.
                PrintArrToFile(L, Output_Path, false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
