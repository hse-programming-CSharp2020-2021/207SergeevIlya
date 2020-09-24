using System;
using System.Runtime.Serialization;

// Задача #7 из Дз #2

namespace Task7
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

        //Метод, возвращаюший целую и дробную части числа
        static void Parts (double x, ref int whole, ref double fract)
        {
            whole = (int)x;
            fract = x - (double)whole;
        }

        //Метод, возвращающий квадрат и корень из числа
        static void Square (double x, ref double sqrt, ref double sqr)
        {
            //Проверяем, можно ли извлечь корень из числа
            if (x >= 0)
                sqrt = Math.Sqrt(x);
            else
                sqrt = double.NaN;

            sqr = x * x;
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
                    int whole = 0;
                    double fract = 0, sqrt = 0, sqr = 0;

                    Parts(x, ref whole, ref fract);
                    Square(x, ref sqrt, ref sqr);

                    if (x < 0)
                        Console.WriteLine("Корень из данного числа не существует");
                    else
                        Console.WriteLine("Корень из числа = " + sqrt);

                    Console.WriteLine("Квадрат числа = " + sqr);
                    Console.WriteLine("Целая часть числа = " + whole);
                    Console.WriteLine("Дробная часть числа = " + fract);

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