using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib.StringClasses
{
    /// <summary>
    /// Класс, реализующий работу со строками из латинских символов.
    /// </summary>
    public class LatString : MyStrings
    {

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="start">
        /// Первый символ в строке.
        /// </param>
        /// <param name="finish">
        /// Последний символ в строке.
        /// </param>
        /// <param name="n">
        /// Кол-во символов в строке.
        /// </param>
        public LatString(char start, char finish, int n)
        {
            Random rnd = new Random();

            // Проверяем кол-во символов строки и допустимые границы.
            if (n <= 0)
                throw new ArgumentOutOfRangeException("Кол-во символов в строке должно быть больше нуля.");
            else if (start < 'a')
                throw new ArgumentOutOfRangeException("Первый символ строки должен быть буквой латинского алфавита.");
            else if (finish > 'z')
                throw new ArgumentOutOfRangeException("Последний символ строки должен быть буквой латинского алфавита.");
            else
            {
                char[] letters = new char[n];
                for (int i = 0; i < letters.Length; ++i)
                {
                    letters[i] = (char)rnd.Next(start, finish + 1);
                }

                str = new String(letters);
            }
        }

        string str;

        public override bool Validate()
        {
            foreach (char Symb in str)
            {
                if (!(Symb >= 'a' && Symb <= 'z'))
                    return false;
            }

            return true;
        }

        public override bool IsPalindrome()
        {
            for (int i = 0; i < str.Length / 2; ++i)
                if (str[i] != str[str.Length - 1 - i])
                    return false;

            return true;
        }

        public override int CountLetter(char letter)
        {
            int res = 0;

            foreach (char strLetter in str)
            {
                if (strLetter == letter)
                    res++;
            }

            return res;
        }

        public override string ToString()
        {
            return str;
        }
    }
}
