using System;
using System.Dynamic;
using System.Linq;
using System.IO;

// Задача 6 

namespace Task_6
{
    class Program
    {
        // Требуемый метод.
        static int [] Get_Integers (string [] s)
        {
            int[] res = new int[s.Length];

            int new_ind = 0;
            foreach (string str in s)
            {
                // Пробуем преобразовать в int.
                if (int.TryParse(str, out int num))
                {
                    res[new_ind] = num;
                    new_ind++;
                }
            }

            Array.Resize(ref res, new_ind);

            return res; 
        }

        static void Main(string[] args)
        {
            string Input_Path = "C:/Users/IlyaLayk/Desktop/207SergeevIlya/module_1/HW_15.10/Task_6/input.txt", //Console.ReadLine();
                   Output_Path = "C:/Users/IlyaLayk/Desktop/207SergeevIlya/module_1/HW_15.10/Task_6/output.txt";

            // Считываем строку.
            try
            {
                string S = File.ReadAllText(Input_Path);

                // Разделяем строку по ';' и получаем массив из строки.
                int[] ans = Get_Integers(S.Split(';'));

                // Используем поток для записи в файл.
                StreamWriter sw = new StreamWriter(Output_Path, true);

                // Выводим массив. 
                sw.WriteLine("Получившийся массив : ");
                foreach (int i in ans)
                {
                    sw.Write(i + " ");
                }

                // Вычисляем и выводим среднее значение эл-тов массива ans.
                sw.WriteLine("\nСреднее значение эл-тов данного массива :");
                sw.WriteLine(ans.Average());

                // Закрываем файл.
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
