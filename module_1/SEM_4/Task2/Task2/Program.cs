using System;

//Задача 2 с четвертого семинара

namespace Task2
{
    class Program
    {
        static bool Shift (ref char ch)
        {
            if (ch >= 'a' && ch <= 'z')
            {
                ch = (char)((int)'a' + ((int)ch - (int)'a' + 4) % 26);
                return true;
            }
            else if (ch >= 'A' && ch <= 'Z')
            {
                ch = (char)((int)'A' + ((int)ch - (int)'A' + 4) % 26);
                return true; 
            }
            else
                return false; 
        }

        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            char c = s[0];

            if (Shift(ref c))
                Console.WriteLine(c);
            else
                Console.WriteLine("Ошибка");
        }
    }
}
