using System;

//Задача 4 из sem_04

namespace Task_sem_04_4
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
            while (!num_parsed)
            {
                Console.WriteLine("Попробуйте еще раз");
                num_parsed = int.TryParse(Console.ReadLine(), out num);
            }

            return num;
        }

        //Метод для создания новой рандомно заполненной квадртаной матрицы
        static int[, ] New_Rand_Matrics(int N, int M, int min, int max)
        {
            int[, ] res = new int[N, M];

            Random rand = new Random();
            for (int i = 0; i < N; ++i)
                for (int j = 0; j < M; ++j)
                    res[i, j] = rand.Next(min, max + 1);
                

            return res;
        }

        //Метод для вывода квадртаной матрицы
        static void Print_Sqr_Matrics(int [,] matrics)
        {
            int L = (int)Math.Sqrt(matrics.Length);

            for (int i = 0; i < L; ++i, Console.WriteLine())
                for (int j = 0; j < L; ++j)
                    Console.Write(matrics[i, j] + " ");
        }

        //Метод поиска определителя матрицы 2x2
        static int det2x2 (int [,] A)
        {
            return A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0]; 
        }

        //Метод поиска определителя 3x3 
        static int det3x3 (int [,] A)
        {
            return A[0, 0] * A[1, 1] * A[2, 2] + A[0, 1] * A[1, 2] * A[2, 0] + A[0, 2] * A[1, 0] * A[2, 1]
                - A[2, 0] * A[1, 1] * A[0, 2] - A[2, 1] * A[1, 2] * A[0, 0] - A[2, 2] * A[1, 0] * A[0, 1]; 
        }

        static void Main(string[] args)
        {
            int min, max;
            min = Get_User_Int("минимальное значение эл-та матрицы");
            max = Get_User_Int("максимальное значние эл-та матрицы");

            int[, ] matrcis2x2 = New_Rand_Matrics(2, 2, min, max),
                   matrics3x3 = New_Rand_Matrics(3, 3, min, max);

            Console.WriteLine("Получившаяся матрица 2 X 2");
            Print_Sqr_Matrics(matrcis2x2);

            Console.WriteLine("Получившаяся матрица 3 X 3");
            Print_Sqr_Matrics(matrics3x3);

            Console.WriteLine("Определитель матрицы 2 X 2");
            Console.WriteLine(det2x2(matrcis2x2));

            Console.WriteLine("Определитель матрицы 3 X 3");
            Console.WriteLine(det3x3(matrics3x3));
        }
    }
}
