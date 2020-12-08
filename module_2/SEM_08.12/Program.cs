using System;
using System.Text;

namespace SEM_08._12
{
    class Program
    {
        static void Spaces(StringBuilder s)
        {
            for (int i = 0; i < s.Length - 1; ++i)
                while (i + 1 < s.Length && s[i] == ' ' && s[i + 1] == ' ')
                    s.Remove(i + 1, 1);
        }

        static int Words(StringBuilder s, int letters)
        {
            int res = 0;
            int med = 0;

            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == ' ')
                    med = 0;
                else
                {
                    med++;
                    if (med == letters)
                        res++;
                }
                    
            }

            return res;
        }


        static int Vowels(StringBuilder s)
        {
            int res = 0;

            char[] vowels = new char[10]{
            'а', 'у', 'о', 'ы', 'и', 'э', 'я', 'ю', 'ё', 'е' };

            for (int i = 0; i < s.Length; ++i)
            {
                if (i == 0 || s[i - 1] == ' ')
                    for (int j = 0; j < vowels.Length; ++j)
                        if (s[i] == vowels[j])
                            res++;
            }

            return res;
        }



        static void Main(string[] args)
        {
            StringBuilder s = new StringBuilder(Console.ReadLine(), 100);

            Spaces(s);
            Console.WriteLine("Строка без лишних пробелов:");
            Console.WriteLine(s);



            Console.WriteLine("Кол-во слов из более чем 4 букв:");
            Console.WriteLine(Words(s, 4));

            Console.WriteLine("Кол-во слов, начинающихся с гласной буквы:");
            Console.WriteLine(Vowels(s));
        }
    }
}
