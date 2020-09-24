using System;
using System.Runtime.Serialization;

// Задача #4 с 14 слайда из Дз #3

namespace Task4_14
{
    class Program
    {
        /*
           Метод для получения информации от пользователя
           * Если пользователь вводит пустую строку, возвращает 2
           * Если введённая пользователем информация некорректна, возвращает 1
           * Иначе возвращает 0
        */

        static sbyte Get_User_Data(ref int x, ref int y, ref int z)
        {
            Console.WriteLine("Введите номер 1ой аудитории\n Или введите пустую строку для завершения работы программы");
            string x_string = Console.ReadLine();

            //Если пользователь ввёл пустую строку, возвращаем 2
            if (x_string == "")
                return 2;

            Console.WriteLine("Введите номер 2ой аудитории\n Или введите пустую строку для завершения работы программы");
            string y_string = Console.ReadLine();

            //Если пользователь ввёл пустую строку, возвращаем 2
            if (y_string == "")
                return 2;

            Console.WriteLine("Введите номер 3ьей аудитории\n Или введите пустую строку для завершения работы программы");
            string z_string = Console.ReadLine();

            //Если пользователь ввёл пустую строку, возвращаем 2
            if (z_string == "")
                return 2;

            bool x_parsed = int.TryParse(x_string, out x),
                 y_parsed = int.TryParse(y_string, out y),
                 z_parsed = int.TryParse(z_string, out z);

            //Если введённые данные некорректны, возвращаем 1
            if (!x_parsed || x < 100 || x > 999 || !y_parsed || y < 100 || y > 999 || !z_parsed || z < 100 || z > 999)
                return 1;
            //Иначе 0 (нет каких-либо ошибок или исключений)
            else
                return 0;
        }


        static void Main(string[] args)
        {
            int x = 0, y = 0, z = 0;

            //Цикл для повторения решения 
            sbyte code = Get_User_Data(ref x, ref y, ref z);

            while (code < 2)
            {
                // Если введённые данные корректны
                if (code == 0)
                {
                    //Находим минимальный номер внутри этаже данных среди аудиторий
                    int min = Math.Min(x % 100, Math.Min(y % 100, z % 100));

                    Console.WriteLine("Аудитория с минимальным номером внутри этажа :");
                    if (min == x % 100)
                        Console.WriteLine(x);
                    else if (min == y % 100)
                        Console.WriteLine(y);
                    else
                        Console.WriteLine(z);
                }
                //Иначе
                else
                    Console.WriteLine("Введённые данные некорректны" +
                        "\nПопробуйте еще раз" +
                        "\nДля завершения работы программы введите пустую строку");

                Console.WriteLine();

                //Еще раз получаем данные от пользователя
                code = Get_User_Data(ref x, ref y, ref z);
            }
        }
    }
}
