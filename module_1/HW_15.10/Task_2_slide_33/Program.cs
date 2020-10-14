using System;
using System.Dynamic;
using System.IO;

// Задача 2 из слайда 33

namespace Task_2_slide_33
{
    class Program
    {
        // Метод получения требуемого массива из массива A.
        static int [] GetBArray(int [] A)
        {
            int[] res = new int[A.Length];

            for (int i = 0; i < A.Length; ++i)
                res[i] = (int)(Math.Log2(A[i]));

            return res;
        }

        // Метод для получения массива чисел из файла с путём path.
        static int [] GetArrFromFile (string path)
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
        static void PrintArrToFile(int [] arr, string path, bool add)
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
            string Input_Path = "C:/Users/IlyaLayk/Desktop/207SergeevIlya/module_1/HW_15.10/Task_2_slide_33/input.txt", //Console.ReadLine();
                   Output_Path = "C:/Users/IlyaLayk/Desktop/207SergeevIlya/module_1/HW_15.10/Task_2_slide_33/output.txt";

            // Считываем A.
            int[] A = GetArrFromFile(Input_Path);

            // Создаём и заполняем результирующий массив B.
            int[] B = GetBArray(A);

            // Выводим B.
            PrintArrToFile(B, Output_Path, false);
        }
    }
}
