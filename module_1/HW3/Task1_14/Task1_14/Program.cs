using System;
using System.Runtime.Serialization;

// Задача №1 с 14 слайда из Дз №3 

namespace Task1_14
{
    class Program
    {
        /*
           Метод для получения информации от пользователя
           * Если пользователь вводит пустую строку, возвращает 2
           * Если введённая пользователем информация некорректна, возвращает 1
           * Иначе возвращает 0
        */

        static sbyte Get_User_Data(ref double x, ref double y)
        {
            Console.WriteLine("Введите x\nДля завершения работы программы введите пустую строку");
            string x_string = Console.ReadLine();

            //Если пользователь ввёл пустую строку, возвращаем 2
            if (x_string == "")
                return 2;

            // То же самое
            Console.WriteLine("Введите y");
            string y_string = Console.ReadLine();

            if (y_string == "")
                return 2;

            bool x_parsed = double.TryParse(x_string, out x),
                 y_parsed = double.TryParse(y_string, out y);

            //Если введённые данные некорректны, возвращаем 1
            if (!x_parsed || !y_parsed)
                return 1;
            //Иначе 0 (нет каких-либо ошибок или исключений)
            else
                return 0;
        }

        static bool is_in_G (double x, double y)
        {
            return (x * x + y * y <= 4) && (y <= x) && (x >= 0);
        }

        static void Main(string[] args)
        {
            double x = 0, y = 0;

            //Цикл для повторения решения 
            sbyte code = Get_User_Data(ref x, ref y);

            while (code < 2)
            {
                // Если введённые данные корректны
                if (code == 0)
                {
                    Console.WriteLine((is_in_G(x, y)) ? "Точка принадлжеит фигуре G": "Точка не принадлежит фигуре G");
                }
                //Иначе
                else
                    Console.WriteLine("Введённые данные некорректны" +
                        "\nПопробуйте еще раз" +
                        "\nДля завершения работы программы введите пустую строку");

                Console.WriteLine();

                //Еще раз получаем данные от пользователя
                code = Get_User_Data(ref x, ref y);
            }
        }
    }
}
