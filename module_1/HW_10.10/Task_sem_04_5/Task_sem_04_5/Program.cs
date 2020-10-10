using System;

//Задача #5 из sem_04

namespace Task_sem_04_5
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
        static int[][] New_Rand_Matrics(int N, int M, int min = int.MinValue, int max = int.MaxValue - 1)
        {
            int[][] res = new int[N][];

            Random rand = new Random();
            for (int i = 0; i < N; ++i)
            {
                res[i] = new int[M];
                for (int j = 0; j < M; ++j)
                    res[i][j] = rand.Next(min, max + 1);
            }
                
            return res;
        }

        static void Main(string[] args)
        {
            //Создаём матрицу
            int[,] = New_Rand_Matrics(N, N);
        }
    }
}
