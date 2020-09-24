using System;

// Задача №2 из ДЗ №3

namespace Task2
{
    class Program
    {
        //Рекурсивная функция, выводящая цифры числа в обратном порядке
        static long solve(long P, long T)
        {
            if (T > 1)
                return solve(P % T, T / 10) * 10 + P / T;
            else
                return P;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите число, которое хотите развернуть\n" +
                "Ведущие нули отбрасываются, т.к требуется в итоге получить число, а не строку");

            long num;
            bool num_parsed = long.TryParse(Console.ReadLine(), out num);

            if (num_parsed)
            {
                //Находим наибольшую степень десятки, на которую делится число num
                long num_1 = num, T = 1;
                while (num_1 / 10 > 0)
                {
                    num_1 /= 10;
                    T *= 10;
                }

                //Находим и выводим развернутое число
                //Ведущие нули отбрасываются, т.к в задаче требуется в итоге получить число, а не строку
                Console.WriteLine("Развёрнутое число : "  + solve(num, T));
            }
            else
                Console.WriteLine("Некорректный формат данных");

            Console.WriteLine("Нажмите любую клавишу, чтобы закончить");
            Console.ReadKey();
        }
    }
}
