using System;
using System.Net;
using System.Runtime.Serialization;

// Задача #7 с 8 слайда из Дз #4

namespace Task_7
{
    class Program
    {
        /*
           Метод для получения информации от пользователя
           * Если пользователь вводит пустую строку, возвращает 2
           * Если введённая пользователем информация некорректна, возвращает 1
           * Иначе возвращает 0
        */

        static sbyte Get_User_Data(out long x, out long y)
        {
            x = 0;
            y = 0;

            Console.WriteLine("Введите x\n Или введите пустую строку для завершения работы программы");
            string x_string = Console.ReadLine();

            //Если пользователь ввёл пустую строку, возвращаем 2
            if (x_string == "")
                return 2;

            Console.WriteLine("Введите y\n Или введите пустую строку для завершения работы программы");
            string y_string = Console.ReadLine();

            //Если пользователь ввёл пустую строку, возвращаем 2
            if (y_string == "")
                return 2;

            bool x_parsed = long.TryParse(x_string, out x),
                 y_parsed = long.TryParse(y_string, out y);

            //Если введённые данные некорректны, возвращаем 1
            if (!x_parsed)
                return 1;
            //Иначе 0 (нет каких-либо ошибок или исключений)
            else
                return 0;
        }

        //Поиск НОД 
        static long GCD(long a, long b)
        {
            return (b == 0) ? Math.Abs(a) : GCD(b, a % b);
        }

        //Поиск НОД и НОК
        static void GCD_LCM (long x, long y, out long gcd, out long lcm)
        {
            gcd = GCD(x, y);
            lcm = x * y / gcd;
        }


        static void Main(string[] args)
        {
            long x, y;

            //Цикл для повторения решения 
            sbyte code = Get_User_Data(out x, out y);

            while (code < 2)
            {
                // Если введённые данные корректны
                if (code == 0)
                {
                    long gcd, lcm;
                    GCD_LCM(x, y, out gcd, out lcm);

                    Console.WriteLine("НОД = " + gcd);
                    Console.WriteLine("НОК = " + lcm);
                }
                //Иначе
                else
                    Console.WriteLine("Введённые данные некорректны" +
                        "\nПопробуйте еще раз" +
                        "\nДля завершения работы программы введите пустую строку");

                Console.WriteLine();

                //Еще раз получаем данные от пользователя
                code = Get_User_Data(out x, out y);
            }
        }
    }
}