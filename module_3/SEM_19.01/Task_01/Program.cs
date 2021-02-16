using System;
using System.Text;

namespace Task_01
{
    delegate string ConvertRule(string s);

    class Converter
    {
        public string Convert(string str, ConvertRule cr)
        {
            return cr(str);
        }
    }

    class Program
    {
        public static string RemoveDigits (string str)
        {
            StringBuilder newStr = new StringBuilder();

            for (int i = 0; i < str.Length; ++i)
                if (str[i] < '0' || str[i] > '9')
                    newStr.Append(str[i]);

            return newStr.ToString();
        }

        public static string RemoveSpaces (string str)
        {
            return str.Replace(" ", "");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите число строк и затем сами строки (по одной на строчку)");
            string[] strs = new string[int.Parse(Console.ReadLine())];

            for (int i = 0; i < strs.Length; ++i)
                strs[i] = Console.ReadLine();

            Converter newConverter = new Converter();

            Console.WriteLine("Результаты удаления цифр:");
            Array.ForEach(strs, (string s) => { Console.WriteLine(newConverter.Convert(s, RemoveDigits)); });

            Console.WriteLine("Результаты удаления пробелов:");
            Array.ForEach(strs, (string s) => { Console.WriteLine(newConverter.Convert(s, RemoveSpaces)); });

            ConvertRule converter = RemoveDigits;
            converter += RemoveSpaces;

            Console.WriteLine("Результат применения многоадресного делегата:");
            Array.ForEach(strs, (string s) => { Console.WriteLine(newConverter.Convert(s, converter)); });
        }
    }
}
