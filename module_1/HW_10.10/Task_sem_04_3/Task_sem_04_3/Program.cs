using System;
using System.Globalization;
using System.Threading.Channels;

//Задача 3 из sem_04

namespace Task_sem_04_3
{
    class Program
    {
        //Метод для удобного получения пользовательского числа
        static int Get_User_Int(string name = "число")
        {
            int num;
            Console.WriteLine("Введите " + name);

            bool num_parsed = int.TryParse(Console.ReadLine(), out num);

            //Если ввод некорректен
            while (!num_parsed || num < 0)
            {
                Console.WriteLine("Попробуйте еще раз");
                num_parsed = int.TryParse(Console.ReadLine(), out num);
            }

            return num;
        }

        static void Main(string[] args)
        {
            //Получаем N
            int N = Get_User_Int("N");

            //Создаём и заполняем первый массив
            char[][] arr1 = new char[N][];
            for (int i = 0; i < N; ++i)
            {
                arr1[i] = new char[i + 1];
                for (int j = 0; j <= i; ++j)
                    arr1[i][j] = '*';
            }

            //Выводим первый массив 
            for (int i = 0; i < N; ++i, Console.WriteLine())
                for (int j = 0; j <= i; ++j)
                    Console.Write(arr1[i][j] + " ");

            //Создаём и заполняем второй массив
            char[][] arr2 = new char[N][];
            for (int i = 0, d = 1; i < N; ++i, d += 2)
            {
                //Длина iой строки
                int L = i + 4;

                //Инициализируем iую строку
                arr2[i] = new char[L];

                //Расставляем пробелы
                for (int j = 0; j < L - d; ++j)
                {
                    arr2[i][j] = ' ';
                }

                //Расставляем *
                for (int j = Math.Max(0, L - d); j < L; j++)
                {
                    arr2[i][j] = '*';
                }
            }

            //Выводим второй массив 
            for (int i = 0; i < N; ++i, Console.WriteLine())
                for (int j = 0; j < arr2[i].Length; ++j)
                    Console.Write(arr2[i][j] + " ");
        }
    }
}
