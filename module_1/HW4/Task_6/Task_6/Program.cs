using System;
using System.Net;
using System.Runtime.Serialization;

// Задача #6 с 7 слайда из Дз #4

namespace Task_6
{
    class Program
    {
        /*
           Метод для получения информации от пользователя
           * Если пользователь вводит пустую строку, возвращает 2
           * Если введённая пользователем информация некорректна, возвращает 1
           * Иначе возвращает 0
        */

        static sbyte Get_User_Data(out decimal x)
        {
            x = 0;

            Console.WriteLine("Введите x\n Или введите пустую строку для завершения работы программы");
            string x_string = Console.ReadLine();

            //Если пользователь ввёл пустую строку, возвращаем 2
            if (x_string == "")
                return 2;

            bool x_parsed = decimal.TryParse(x_string, out x);

            //Если введённые данные некорректны, возвращаем 1
            if (!x_parsed)
                return 1;
            //Иначе 0 (нет каких-либо ошибок или исключений)
            else
                return 0;
        }

        //S1
        static decimal S1(decimal x)
        {
            decimal Sum = x * x, d = -8 * x * x * x * x / (1 * 2 * 3 * 4), n = 5;

            while (d != 0)
            {   
                Sum += d;
                d = -1 * d * x * x * 4 / (n * (n + 1));

                n += 2;
            }
            

            return Sum;
        }

        //S2
        static decimal S2(decimal x)
        {
            decimal Sum = 0, d = 1, n = 1;

            while (d != 0)
            {
                Sum += d;

                d *= x;
                d /= n;
                n++;
            }

            return Sum;
        }


        static void Main(string[] args)
        {
            decimal x = 0;

            //Цикл для повторения решения 
            sbyte code = Get_User_Data(out x);

            while (code < 2)
            {
                // Если введённые данные корректны
                if (code == 0)
                {
                    Console.WriteLine("S1 = " + S1(x));
                    Console.WriteLine("S2 = " + S2(x));
                }
                //Иначе
                else
                    Console.WriteLine("Введённые данные некорректны" +
                        "\nПопробуйте еще раз" +
                        "\nДля завершения работы программы введите пустую строку");

                Console.WriteLine();

                //Еще раз получаем данные от пользователя
                code = Get_User_Data(out x);
            }
        }
    }
}
