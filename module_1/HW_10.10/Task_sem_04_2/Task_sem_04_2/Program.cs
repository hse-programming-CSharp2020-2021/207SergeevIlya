using System;

namespace Task_sem_04_2
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

            //Создаём ступенчатый массив
            int[][] Arr = new int[N][];

            //Заполняем его
            for (int i = 0, d = 0; i <= N; ++i, d += i)
            {
                //Заполняем строку i
                Arr[i] = new int[i];

                for (int j = 0; j < i; ++j)
                {
                    Arr[i][j] = N - d - j;
                }
            }

            //Выводим ступенчатый массив
            for (int i = 0; i < N; ++i)

        }
    }
}
