using System;

//Задача #6 из sem_04

namespace Task_sem_04_6
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

        //Метод для вывода квадртаной матрицы
        static void Prin_Matrics(int[][] matrics)
        {
            for (int i = 0; i < matrics.Length; ++i, Console.WriteLine())
                for (int j = 0; j < matrics[i].Length; ++j)
                    Console.Write(matrics[i][j] + " ");
        }


        //Метод поиска определителя 3x3 
        static int det3x3_l(int[][] A)
        {
            return A[0][0] * A[1][1] * A[2][2] + A[0][1] * A[1][2] * A[2][0] + A[0][2] * A[1][0] * A[2][1]
                - A[2][0] * A[1][1] * A[0][2] - A[2][1] * A[1][2] * A[0][0] - A[2][2] * A[1][0] * A[0][1];
        }

        static int det3x3_r (int [][] A)
        {
            return A[0][3] * A[1][4] * A[2][5] + A[0][4] * A[1][5] * A[2][3] + A[0][5] * A[1][3] * A[2][4]
                - A[2][3] * A[1][4] * A[0][5] - A[2][4] * A[1][5] * A[0][3] - A[2][5] * A[1][3] * A[0][4];
        }

        static void Main(string[] args)
        {
            //Создаём матрицу
            int[][] matrics = New_Rand_Matrics(3, 6, 0, 20);

            //Выводим её
            Console.WriteLine("Вот получившаяся матрица :");
            Prin_Matrics(matrics);

            //Создаём и заполняем массив
            int[] dets = new int[2];
            dets[0] = det3x3_l(matrics);
            dets[1] = det3x3_r(matrics);

            //Выводим определители
            Console.WriteLine("Определитель левой части");
            Console.WriteLine(dets[0]);

            Console.WriteLine("Определитель правой части");
            Console.WriteLine(dets[1]);
        }
    }
}
