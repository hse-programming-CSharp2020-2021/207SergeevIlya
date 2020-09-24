using System;
using System.Runtime.Serialization;

// Задача #3 с 14 слайда из Дз #3

namespace Task3_14
{
    class Program
    {
        /*
           Метод для получения информации от пользователя
           * Если пользователь вводит пустую строку, возвращает 2
           * Если введённая пользователем информация некорректна, возвращает 1
           * Иначе возвращает 0
        */

        static sbyte Get_User_Data(ref double x)
        {

            string x_string = Console.ReadLine();

            //Если пользователь ввёл пустую строку, возвращаем 2
            if (x_string == "")
                return 2;

            bool x_parsed = double.TryParse(x_string, out x);

            //Если введённые данные некорректны, возвращаем 1
            if (!x_parsed)
                return 1;
            //Иначе 0 (нет каких-либо ошибок или исключений)
            else
                return 0;
        }

        static double G (double x)
        {
            if (x <= 0.5)
                return Math.Sin(Math.PI / 2);
            else
                return Math.Sin(Math.PI * ((x - 1) / 2));
        }

        static void Main(string[] args)
        {
            double x = 0;

            //Цикл для повторения решения 
            Console.WriteLine("Введите x\nДля завершения работы программы введите пустую строку");
            sbyte code = Get_User_Data(ref x);

            while (code < 2)
            {
                // Если введённые данные корректны
                if (code == 0)
                {
                    Console.WriteLine("Значение функции G :" + G(x));

                    Console.WriteLine("\nВведите x\nДля завершения работы программы введите пустую строку");
                }
                //Иначе
                else
                    Console.WriteLine("Введённые данные некорректны" +
                        "\nПопробуйте еще раз" +
                        "\nДля завершения работы программы введите пустую строку");

                Console.WriteLine();

                //Еще раз получаем данные от пользователя
                code = Get_User_Data(ref x);
            }
        }
    }
}
