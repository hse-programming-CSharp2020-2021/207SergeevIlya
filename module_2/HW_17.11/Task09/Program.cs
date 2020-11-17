using System;
using System.Collections.Generic;
using static System.Console;

namespace Task09
{
    class LinearEquation : IComparable
    {
        public double a, b, c;

        public LinearEquation (double A, double B, double C)
        {
            a = A;
            b = B;
            c = C;
        }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Result">
        /// Переменная, в которую будет записан результат вычисления корня.
        /// </param>
        /// <returns>
        /// Возвращает 0, если корней у уравнения нет.
        /// 1, если есть.
        /// 2, если их бесконечно много.
        /// </returns>
        public int GetSolution (out double Result)
        {
            Result = 0;

            // Случай, когда корней нет.
            if (b - c != 0 && a == 0)
                return 0;
            // Случай, когда корней бесконечно много
            else if (b - c == 0 && a == 0)
                return 2;
            // Случай, когда корень один.
            else
            {
                Result = (b - c) / a;
                return 1;
            }
        }

        /// <summary>
        /// Компаратор для сортировки.
        /// </summary>
        public int CompareTo(object Eq)
        {
            LinearEquation Equation = Eq as LinearEquation;

            double Solution1, Solution2;
            if (GetSolution(out Solution1) != 1 || Equation.GetSolution(out Solution2) != 1)
                throw new Exception("Невозможно сравнить два объекта");

            return Solution1.CompareTo(Solution2);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите число уравнений или 0, чтобы завершить программу");
                LinearEquation[] Equations = new LinearEquation[GetIntConsole(0, 10)];
                if (Equations.Length == 0)
                    break;

                // Генерируем уравнения.
                Random rand = new Random();
                for (int i = 0; i < Equations.Length; ++i)
                {
                    Equations[i] = new LinearEquation(rand.Next(1, 11), rand.Next(1, 11), rand.Next(1, 11));

                    // Выводим информацию обо всех уравнениях.
                    WriteLine("Уравнение №" + i + ": ");
                    WriteLine("a = " + Equations[i].a + ", b = " + Equations[i].b + ", c = " + Equations[i].c);
                }

                WriteLine("Отсортированный массив по возрастанию решений: ");
                // Сортируем.
                Array.Sort(Equations);
                for (int i = 0; i < Equations.Length; ++i)
                {
                    // Выводим информацию обо всех уравнениях.
                    WriteLine("Уравнение №" + i + ": ");
                    WriteLine("a = " + Equations[i].a + ", b = " + Equations[i].b + ", c = " + Equations[i].c);
                }
            }
        }
    }
}
