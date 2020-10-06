using System;
using System.Runtime.Serialization;

// Задача #20 из sem_03 в Дз к 10.10 

namespace Task_sem_03_20
{
    class Program
    {
        //Метод для удобного получения пользовательского числа
        static int Get_User_Int(string name)
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

        static int[] CreateArr()
        {
            //Ввод длины массива 
            Console.WriteLine("Введите 0, чтобы закончить выполнение программы или");
            int N = Get_User_Int("N");

            if (N == 0)
                return new int[0];


            //Создание массива 
            int[] arr = new int[N];

            Random rand = new Random();
            for (int i = 0; i < N; ++i)
                arr[i] = rand.Next(10, 101);

            //Вывод исходного массива
            Console.WriteLine("Исходный массив : ");
            foreach (double el in arr)
            {
                Console.WriteLine(el);
            }

            return arr;
        }

        /*
            Требуемый метод, дублирующий эл-ты массива
            (! Меняет исходный массив !)
        */
        static void ArrayItemDouble (ref int [] A, int X)
        {
            //Считаем новую длину массива (с учётом дублирований)
            int New_Length = A.Length;
            for (int i = 0; i < A.Length; ++i)
                if (A[i] == X)
                    New_Length++;

            //Создаём копию старого массива (для дальнейшего дублирования эл-тов)
            int [] A_Cloned = (int[])A.Clone();
            
            //Изменяем размер массива 
            Array.Resize(ref A, New_Length);

            //Дублируем эл-ты массива A 
            for (int i = 0, j = 0; i < A_Cloned.Length; ++i, ++j)
            {
                A[j] = A_Cloned[i];

                //Если эл-т в исходном массиве равен X
                if (A_Cloned[i] == X)
                {
                    j++;
                    A[j] = A_Cloned[i];
                }

            }
        }

        //Метод для вывода массива
        static void PrintArray (int [] A)
        {
            Console.WriteLine("Результирующий массив : ");
            for (int i = 0; i < A.Length; ++i)
                Console.WriteLine(A[i]);
        }

        static void Main(string[] args)
        {
            int[] A;
            int Y;

            //Цикл повторения решения
            do
            {
                Console.WriteLine("------------------------------------------------------");
                A = CreateArr();

                //Получаем Y, выполняем дублирования в массиве и выводим его
                if (A.Length > 0)
                {
                    Y = Get_User_Int("Y");
                    ArrayItemDouble(ref A, Y); 
                    PrintArray(A);
                } 

                Console.WriteLine("------------------------------------------------------");
            }
            while (A.Length > 0);

        }
    }
}