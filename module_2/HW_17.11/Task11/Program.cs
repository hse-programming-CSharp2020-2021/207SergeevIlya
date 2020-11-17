using System;
using static System.Console;

namespace Task11
{
    class GeometricProgression
    {
        double _start { get; set; }
        double _increment { get; set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public GeometricProgression ()
        {
            _start = 0;
            _increment = 1;
        }

        /// <summary>
        /// Ещё один конструктор класса.
        /// </summary>
        /// <param name="start">
        /// Начальное значение посл-ти
        /// </param>
        /// <param name="increment">
        /// Заменатель прогрессии
        /// </param>
        public GeometricProgression(double start, double increment)
        {
            _start = start;
            _increment = increment;
        }

        /// <summary>
        /// Индексатор.
        /// </summary>
        public double this[int index]
        {
            get
            {
                double CurrentElem = _start;

                for (int i = 0; i < index; ++i)
                    CurrentElem *= _increment;

                return CurrentElem;

            }
        }

        /// <summary>
        /// Метод для получения инф-ции о посл-ти в виде строкиЮ
        /// </summary>
        /// <returns></returns>
        public string GetInfo ()
        {
            return "Начальное значение посл-ти: " + _start + ". Заменатель прогрессии: " + _increment;
        }

        /// <summary>
        /// Метод, возвращающий сумму первых n членов.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public double GetSum (int n )
        {
            double Result = 0,
                   CurrentElem = _start;

            for (int i = 0; i < n; ++i)
            {
                Result += CurrentElem;
                CurrentElem *= _increment;
            }

            return Result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Random rand = new Random();
                // Создаём отдельную последовательность.
                GeometricProgression FirstProgression = new GeometricProgression(rand.NextDouble() * 10, rand.NextDouble() * 5);
                WriteLine("Отдельная посл-ть:\n" + FirstProgression.GetInfo());

                // Создаём массив прогрессий.
                GeometricProgression[] Progs = new GeometricProgression[rand.Next(5, 16)];
                for (int i = 0; i < Progs.Length; ++i)
                {
                    Progs[i] = new GeometricProgression(rand.NextDouble() * 10, rand.NextDouble() * 5);
                    WriteLine("Посл-ть №" + (int)(i + 1) + " :\n" + Progs[i].GetInfo());
                }

                WriteLine();

                int step = rand.Next(3, 16);
                for (int i = 0; i < Progs.Length; ++i)
                {
                    if (Progs[i][step] > FirstProgression[step])
                    {
                        WriteLine("У посл-ти №" + (int)(i + 1) + " значение эл-та " + step + " больше, чем у отдельной. :\n" + Progs[i].GetInfo());
                    }
                    WriteLine("У посл-ти №" + (int)(i + 1) + " сумма первых " + step + " эл-тов равна " + Progs[i].GetSum(step));
                }

                WriteLine("Чтобы завершить выполнение программы, введите пустую строку.");
                WriteLine("Введите что угодно, чтобы перезапустить процесс.");
            }
            while (ReadLine() != "");
        }

    }
}
