using System;

namespace Task_sem_04_1
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

        /*
            Метод SnakeFillSqr принимает одним из аргументов квадратную матрицу и заполняет все её эл-ты, 
            находящиеся по краям прямоугольной области матрицы начинающейся с эл-та в строке x1 и столбце y1
            и заканчивающейся в эл-те в строке x2 и столбце y1
            
        */
        static void SnakeFillSqr (int [,] Matrics, int Cur_Num, int x1, int y1, int x2, int y2)
        {
            // Если надо заполнить всего один эл-т
            if (x1 == x2)
            {
                Matrics[x1, y1] = Cur_Num;
                return;
            }

            //Если мы уже целиком заполнили матрицу
            if (x1 > x2)
            {
                return;
            }

            //Иначе:

            //Заполняем верхние эл-ты
            for (int j = y1; j <= y2; ++j, ++Cur_Num)
                Matrics[x1, j] = Cur_Num;

            // Заполняем правые эл-ты
            for (int i = x1 + 1; i < x2; ++i, ++Cur_Num)
                Matrics[i, y2] = Cur_Num;

            // Заполняем нижние эл-ты
            for (int j = y2; j >= y1; --j, ++Cur_Num)
                Matrics[x2, j] = Cur_Num;

            // Заполняем левые эл-ты
            for (int i = x2 - 1; i > x1; --i, ++Cur_Num)
                Matrics[i, y1] = Cur_Num;


            //Повторяем процесс, но для матрицы без эл-тов, которые мы уже обработали
            SnakeFillSqr(Matrics, Cur_Num, x1 + 1, y1 + 1, x2 - 1, y2 - 1);
        }

        static void Main(string[] args)
        {
            //Вводим N
            int N;
            N = Get_User_Int("N");

            //Создаём матрицу
            int [,] Matrics = new int [N, N];

            //Заполняем матрицу
            SnakeFillSqr(Matrics, 1, 0, 0, N - 1, N - 1);

            // Выводим получившуюся матрицу
            for (int i = 0; i < N; ++i, Console.WriteLine())
                for (int j = 0; j < N; ++j)
                    Console.Write(Matrics[i, j] + "\t");
        }
    }
}
