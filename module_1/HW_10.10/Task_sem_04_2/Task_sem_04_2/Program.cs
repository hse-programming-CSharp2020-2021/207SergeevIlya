using System;
using System.Globalization;

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
            int i, d; 
            for (i = 0, d = 0; N - d > 0; ++i, d += i)
            {
                //Заполняем строку i
                Arr[i] = new int[i + 1];

                for (int j = 0; j <= i; ++j)
                {
                    Arr[i][j] = N - d - j;
                }
            }
            //В конце выполнения цикла кол-во строк в массиве, в которых что-то хранится будет равно i

            //Выкидывам лишние эл-ты
            Array.Resize(ref Arr, i);

            //Выводим ступенчатый массив
            for (int k  = 0; k < i; ++k, Console.WriteLine())
                for (int j = 0; j <= k; ++j)
                    Console.Write(Arr[k][j] + " ");
        }
    }
}
