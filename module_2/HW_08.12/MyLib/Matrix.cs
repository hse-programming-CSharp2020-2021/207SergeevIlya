using System;

namespace MyLib
{
    public class Matrix
    {
        /// <summary>
        /// Поле, в котором хранится сама матрица.
        /// </summary>
        public int Content { get; set; }

        /// <summary>
        /// Метод для вывода матрицы в консоль.
        /// </summary>
        /// <param name="ar">
        /// Собственно, сама матрица, которую надо вывести.
        /// </param>
        public static void MatrPrint(int[,] ar)
        {
            for (int i = 0; i < ar.GetLength(0); ++i)
            {
                for (int j = 0; j < ar.GetLength(1); ++j)
                    Console.Write(ar[i, j] + " ");

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод, формирующий квадратную единичную матрицу.
        /// </summary>
        /// <param name="n">
        /// Размер матрицы.
        /// </param>
        /// <returns>
        /// Собственно, саму единичную матрицу.
        /// </returns>
        public static int[,] UnitMatr(int n)
        {
            if (n <= 0)
                throw new ArgumentOutOfRangeException("Аргумент метода должен быть положительным!");

            int[,] ar = new int[n, n];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    ar[i, j] = (i == j ? 1 : 0);

            return ar;
        }
    }
}