using System;
using System.Runtime.Serialization;

// Задача #9 из sem_03 в Дз к 10.10 

namespace Task_sem_03_9
{
    class Program
    {

        static double[] GetUserArr()
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
                return new double[0];


            //Ввод массива 
            double[] arr = new double[arr_size];

            /*
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
            //*/

            Random rand = new Random();
            
            for (int i = 0; i < arr_size; ++i)
                arr[i] = rand.NextDouble() * 20 - 10;

            Console.WriteLine("Исходный массив : ");
            foreach (double el in arr)
            {
                Console.WriteLine(el);
            }

            return arr;
        }

        static void ArrayHill(double[] A)
        {
            //Создаём копию массива
            double[] A_Copy = (double[])A.Clone();
            
            //Сортируем копию
            Array.Sort(A_Copy);

            //Меняем эл-ты исходного массива
            for (int i = 0; i < A_Copy.Length; i += 2)
            {
                A[i / 2] = A_Copy[i];
            }

            for (int i = 1; i < A_Copy.Length; i += 2)
            {
                A[A.Length - i / 2 - 1] = A_Copy[i];
            }

            //Выводим
            Console.WriteLine("Итоговый массив :");
            foreach (double el in A)
            {
                Console.WriteLine(el);
            }
        }

        static void Main(string[] args)
        {
            double[] arr;

            //Цикл повторения решения
            do
            {
                Console.WriteLine("------------------------------------------------------");
                arr = GetUserArr();

                //Выполняем перестановки в массиве
                if (arr.Length > 0)
                    ArrayHill(arr);

                Console.WriteLine("------------------------------------------------------");
            }
            while (arr.Length > 0);

        }
    }
}