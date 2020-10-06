using System;
using System.Runtime.Serialization;

// Задача #11 из sem_03 в Дз к 10.10 

namespace Task_sem_03_11
{
    class Program
    {

        static int[] GetUserArr()
        {
            //Ввод длины массива 
            int arr_size;
            Console.WriteLine("Введите число эл-тов в массиве или 0 чтобы закончить выполнение программы");

            bool arr_size_parsed = int.TryParse(Console.ReadLine(), out arr_size);

            //Если ввод некорректен
            while (!arr_size_parsed || arr_size < 0)
            {
                Console.WriteLine("Попробуйте еще раз");
                arr_size_parsed = int.TryParse(Console.ReadLine(), out arr_size);
            }

            if (arr_size == 0)
                return new int[0];


            //Создание массива 
            int[] arr = new int[arr_size];

            for (int i = 0; i < arr_size; ++i)
            {
                if (i == 0)
                    arr[i] = 0;
                else if (i == 1)
                    arr[i] = 1;
                else
                    arr[i] = 34 * arr[i - 1] - arr[i - 2] + 2;
            }

            Console.WriteLine("Получившийся маассив : ");
            foreach (int el in arr)
            {
                Console.WriteLine(el);
            }

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