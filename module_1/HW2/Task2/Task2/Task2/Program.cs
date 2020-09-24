using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


// Задача # 2 из ДЗ # 2

namespace Task2
{
    class Program
    {
        /*
           Метод для получения информации от пользователя
           * Если пользователь вводит пустую строку, возвращает 3
           * Если пользователь вводит не трёхзначное число, возвращает 2
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
            //Если введено не трёзначное число или ненатуральное число
            else if (P < 100 || P > 999)
                return 2;
            //Иначе 0 (нет каких-либо ошибок или исключений)
            else
                return 0;
        }

        //Метод для перестановки значений двух переменных
        static void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }

        static int solve(int P)
        {
            //Первая цифра P
            int P_1 = P / 100;
            P %= 100;
            //Вторая
            int P_2 = P / 10;
            P %= 10;
            //Третья 
            int P_3 = P;

            //Самая большая цифра
            int Max_1 = Math.Max(P_1, Math.Max(P_2, P_3));

            //Ставим самую большую цифру на первое место
            if (Max_1 == P_2)
                Swap(ref P_1, ref P_2);
            else if (Max_1 == P_3)
                Swap(ref P_1, ref P_3);

            //Меняем (если надо) две оставшихся цифры местами
            if (P_2 < P_3)
                Swap(ref P_2, ref P_3);

            return P_1 * 100 + P_2 * 10 + P_3;
        }

        static void Main(string[] args)
        {
            int P = 0;

            //Цикл для повторения решения 

            Console.WriteLine("Введите трёхзначное число P\nДля завершения работы программы введите пустую строку");
            sbyte code = Get_User_Data(ref P);

            while (code < 3)
            {

                // Если введённые данные корректны
                if (code == 0)
                {
                    int result = solve(P);
                    Console.WriteLine(result);

                    Console.WriteLine("Введите трёхзначное число P\nДля завершения работы программы введите пустую строку");
                }
                //Если введено не трёхзначное или ненатуральное число
                else if (code == 2)
                    Console.WriteLine("Введено нетрёхзначное или ненатуральное число" +
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