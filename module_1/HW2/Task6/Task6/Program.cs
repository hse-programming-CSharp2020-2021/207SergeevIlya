using System;
using System.Runtime.Serialization;
using System.Globalization;

// Задача #6 из Дз #2

namespace Task6
{
    class Program
    {
        /*
           Метод для получения информации от пользователя
           * Если пользователь вводит пустую строку, возвращает 2
           * Если введённая пользователем информация некорректна, возвращает 1
           * Иначе возвращает 0
        */

        static sbyte Get_User_Data(ref double x, ref int y)
        {
            Console.WriteLine("Чтобы завершить выполнение программы, введите пустую строку");
            Console.WriteLine("Введите бюджет пользователя");
            string x_string = Console.ReadLine();

            //Если пользователь ввёл пустую строку, возвращаем 2
            if (x_string == "")
                return 2;

            Console.WriteLine("Введите процент бюджета, выделенный на компьютерные игры");
            string y_string = Console.ReadLine();

            //То же самое
            if (y_string == "")
                return 2;

            bool x_parsed = double.TryParse(x_string, out x),
                 y_parsed = int.TryParse(y_string, out y);

            //Если введённые данные некорректны, возвращаем 1
            if (!x_parsed || !y_parsed)
                return 1;
            //Иначе 0 (нет каких-либо ошибок или исключений)
            else
                return 0;
        }

        static void Main(string[] args)
        {
            double x = 0;
            int y = 0;

            //Цикл для повторения решения 
            sbyte code = Get_User_Data(ref x, ref y);

            while (code < 2)
            {
                // Если введённые данные корректны
                if (code == 0)
                {
                    double result = x * ((double)y / 100);
                    Console.WriteLine(result.ToString("C", new CultureInfo("ru-RU")));
                }
                //Иначе
                else
                    Console.WriteLine("Введённые данные некорректны" +
                        "\nПопробуйте еще раз");

                Console.WriteLine();

                //Еще раз получаем данные от пользователя
                code = Get_User_Data(ref x, ref y);
            }
        }
    }
}