using System;
using System.Runtime.Serialization;

// Задача #11 из sem_03 в Дз к 10.10 

namespace Task_sem_03_11
{
    class Program
    {
        static int Get_User_Int (string name)
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

        static int[] GetUserArr()
        {
            Console.WriteLine("Введите 0, чтобы завершить выполнение программы или");

            //Ввод длины массива 
            int N = Get_User_Int("N");

            if (N == 0)
                return new int[0];

            //Ввод K
            int K = Get_User_Int("K");

            //Создание массива 
            int[] arr = new int[N];

            //Заполнение массива случайными числами
            Random rand = new Random();
            for (int i = 0; i < N; ++i)
                arr[i] = rand.Next(int.MinValue + 1, int.MaxValue);

            //Вывод массива

            Console.WriteLine("Получившийся маассив : ");
            for (int i = 0; i < N; ++i)
                Console.Write(arr[i] + " ");

            Console.WriteLine("\nТребуемые элементы : ");
            for (int i = K; i <= N; i += K)
                Console.Write(arr[i - 1] + " ");

            return arr;
        }


        static void Main(string[] args)
        {
            int[] arr;

            //Цикл повторения решения
            do
            {
                Console.WriteLine("------------------------------------------------------");
                arr = GetUserArr();
                Console.WriteLine("------------------------------------------------------");
            }
            while (arr.Length > 0);

        }
    }
}