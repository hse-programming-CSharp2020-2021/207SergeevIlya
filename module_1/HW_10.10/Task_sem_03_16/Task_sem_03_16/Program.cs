using System;
using System.Runtime.Serialization;

// Задача #16 из sem_03 в Дз к 10.10 

namespace Task_sem_03_16
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


            //Ввод массива 
            int[] arr = new int[arr_size];


            Console.WriteLine("Введите эл-ты массива по-одному в строке");
            for (int i = 0; i < arr_size; ++i)
            {
                bool arr_el_parsed = int.TryParse(Console.ReadLine(), out arr[i]);

                //Если ввод некорректен
                while (!arr_el_parsed)
                {
                    Console.WriteLine("Попробуйте еще раз");
                    arr_el_parsed = int.TryParse(Console.ReadLine(), out arr[i]);
                }
            }

            return arr;
        }

        //Метод поиска индекса минимального эл-та
        static int MinInd (int [] arr)
        {
            int mn = 0;
            for (int i = 1; i < arr.Length; ++i)
                if (arr[i] < arr[mn])
                    mn = i;

            return mn;
        }

        //Метод поиска индекса максимального эл-та
        static int MaxInd(int[] arr)
        {
            int mx = 0;
            for (int i = 1; i < arr.Length; ++i)
                if (arr[i] > arr[mx])
                    mx = i;

            return mx;
        }

        static void Main(string[] args)
        {
            int[] arr;

            //Цикл повторения решения
            do
            {
                Console.WriteLine("------------------------------------------------------");
                arr = GetUserArr();

                //Вывод
                if (arr.Length > 0)
                {
                    Console.WriteLine("Индекс минимального эл-та : " + (int)(MinInd(arr) + 1));
                    Console.WriteLine("Сумма индексов минимального и максимального эл-тов : " + (int)(MinInd(arr) + MaxInd(arr) + 2));
                    Console.WriteLine("(Индексы отсчитыватся с 1)");
                }

                Console.WriteLine("------------------------------------------------------");
            }
            while (arr.Length > 0);

        }
    }
}