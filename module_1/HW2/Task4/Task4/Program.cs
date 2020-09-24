using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


// Задача # 4 из ДЗ # 2

namespace Task4
{
    class Program
    {
        /*
           Метод для получения информации от пользователя
           * Если пользователь вводит пустую строку, возвращает 3
           * Если пользователь вводит не четырёхзначное число, возвращает 2
           * Если введённая пользователем информация некорректна, возвращает 1
           * Иначе возвращает 0
        */

        static sbyte Get_User_Data(ref int P)
        {

            string x_string = Console.ReadLine();

            //Если пользователь ввёл пустую строку, возвращаем 2
            if (x_string == "")
                return 3;

            bool x_parsed = int.TryParse(x_string, out P);

            //Если введённые данные некорректны, возвращаем 1
            if (!x_parsed)
                return 1;
            //Если введено не четырёзначное число или ненатуральное число
            else if (P < 1000 || P > 9999)
                return 2;
            //Иначе 0 (нет каких-либо ошибок или исключений)
            else
                return 0;
        }

        //Рекурсивная функция, выводящая цифры числа в обратном порядке
        static void solve(int P, int T)
        {
            if (T > 1)
                solve(P % T, T / 10);

            Console.WriteLine(P / T);
        }

        static void Main(string[] args)
        {
            int P = 0;

            //Цикл для повторения решения 

            Console.WriteLine("Введите четырёхзначное число P\nДля завершения работы программы введите пустую строку");
            sbyte code = Get_User_Data(ref P);

            while (code < 3)
            {

                // Если введённые данные корректны
                if (code == 0)
                {
                    solve(P, 1000);

                    Console.WriteLine("Введите четырёхзначное число P\nДля завершения работы программы введите пустую строку");
                }
                //Если введено не четырёхзначное или ненатуральное число
                else if (code == 2)
                    Console.WriteLine("Введено нечетырёхзначное или ненатуральное число" +
                        "\nПопробуйте еще раз" +
                        "\nДля завершения работы программы введите пустую строку");
                //Иначе
                else
                    Console.WriteLine("Введённые данные некорректны\nПопробуйте еще раз\nДля завершения работы программы введите пустую строку");

                Console.WriteLine();

                //Еще раз получаем данные от пользователя
                code = Get_User_Data(ref P);
            }
        }
    }
}