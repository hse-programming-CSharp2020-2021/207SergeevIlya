using System;
using static System.Console;

namespace Task10
{
    class Circle
    {
        public double x, y, r;

        public Circle (double X, double Y, double R)
        {
            x = X;
            y = Y;
            r = R;
        }

        /// <summary>
        /// Метод, возвращающий, пересекается ли данная окр-ть с окр-тью C.
        /// </summary>
        public bool CrossesWith (Circle C)
        {
            return ((x - C.x) * (x - C.x) + (y - C.y) * (y - C.y) <= (r + C.r) * (r + C.r));
        }
    }
    class Program
    {
        /// <summary>
        /// Метод для получения целого числа от пользователя через консоль.
        /// </summary>
        /// <returns>
        /// Возвращает введённое пользователем число.
        /// </returns>
        static int GetIntConsole(int MinValue, int MaxValue)
        {
            string UserData = ReadLine();
            // Проверяем введённые данные.
            if ((int.TryParse(UserData, out int Real) && Real >= MinValue && Real <= MaxValue))
                return Real;
            else
            {
                // Выводим подсказки.
                if (Real < MinValue || Real > MaxValue)
                    WriteLine("Введённое число не принадлежит интервалу [" + MinValue + " ; " + MaxValue + "]");
                else
                    WriteLine("Введеные данные невозможно преобразовать в целое число.");

                // Если пользователь ввёл некорректные данные, рекурсивно перезапускаем процесс.
                return GetIntConsole(MinValue, MaxValue);
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите число окружностей или 0, чтобы завершить программу");
                Circle[] Circles = new Circle[GetIntConsole(0, 10)];
                // Если пользователь отменил ввод, то выходим из цикла.
                if (Circles.Length == 0)
                    break;

                // Заполняем массив.
                Random rand = new Random();
                for (int i = 0; i < Circles.Length; ++i)
                {
                    Circles[i] = new Circle(rand.Next(1, 16), rand.Next(1, 16), rand.Next(1, 16));

                    WriteLine("Окружность №" + (int)(i + 1));
                    WriteLine("Координаты центра: " + Circles[i].x + " " + Circles[i].y);
                    WriteLine("Радиус: " + Circles[i].r + "\n");
                }

                Circle LastCircle = new Circle(rand.Next(1, 16), rand.Next(1, 16), rand.Next(1, 16));
                WriteLine("Отдельная окружность");
                WriteLine("Координаты центра: " + LastCircle.x + " " + LastCircle.y);
                WriteLine("Радиус: " + LastCircle.r + "\n");

                // Выводим информацию о пересекающихся окр-тях.
                WriteLine("С отдельной окружностью пересекаются следующие окр-ти:");
                for (int i = 0; i < Circles.Length; ++i)
                    if (LastCircle.CrossesWith(Circles[i])) 
                    {
                        WriteLine("Окружность №" + (int)(i + 1));
                        WriteLine("Координаты центра: " + Circles[i].x + " " + Circles[i].y);
                        WriteLine("Радиус: " + Circles[i].r + "\n");
                    }
            }
        }
    }
}
