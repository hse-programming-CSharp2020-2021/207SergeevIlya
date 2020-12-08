using System;
using MyLib.StringClasses;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = 'к',
                 finish = 'ю';

            do
            {
                MyStrings testString = new RusString(start, finish, 10);
                Console.WriteLine(testString);
                Console.WriteLine(testString.CountLetter('o'));

                // Тестируем.
                try
                {
                    testString = new RusString(start, finish, -11);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Ошибка:" + ex.Message);
                    Console.WriteLine("Состояние объекта не изменено");
                }

                Console.WriteLine(testString);
                Console.WriteLine(testString.CountLetter('o'));
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            // Теперь тестируем класс для латинских строк.
            start = 'f';
            finish = 'l';
            Console.WriteLine("\n");
            do
            {
                MyStrings testString = new LatString(start, finish, 10);
                Console.WriteLine(testString);
                Console.WriteLine(testString.CountLetter('h'));

                // Тестируем.
                try
                {
                    testString = new RusString(start, finish, -11);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Ошибка:" + ex.Message);
                    Console.WriteLine("Состояние объекта не изменено");
                }

                Console.WriteLine(testString);
                Console.WriteLine(testString.CountLetter('h'));
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
