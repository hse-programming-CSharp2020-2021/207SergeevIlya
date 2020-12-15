using System;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Тестируем.
            UserString s = new UserString(5, 'a', 'c');
            Console.WriteLine(s.Str);

            Console.WriteLine(s.MoveOff("bb"));
        }
    }
}
