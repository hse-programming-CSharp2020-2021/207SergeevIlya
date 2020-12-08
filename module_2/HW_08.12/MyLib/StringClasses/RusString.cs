using System;
using System.Collections.Generic;
using System.Text;
using MyLib;

namespace MyLib.StringClasses
{
    /// <summary>
    /// Класс, представляющий строки символов русского алфавита и методы работы с ними.
    /// </summary>
    public class RusString : MyStrings
    {
        String str;

        static Random rnd = new Random();

        public override bool Validate()
        {
            foreach (char Symb in str)
            {
                if (!(Symb >= 'а' && Symb <= 'я'))
                    return false;
            }
            
            return true;
        }

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
        public RusString(char start, char finish, int n)
        {
            // Проверяем кол-во символов строки и допустимые границы.
            if (n <= 0)
                throw new ArgumentOutOfRangeException("Кол-во символов в строке должно быть больше нуля.");
            else if (start < 'а')
                throw new ArgumentOutOfRangeException("Первый символ строки должен быть буквой русского алфавита.");
            else if (finish > 'я')
                throw new ArgumentOutOfRangeException("Последний символ строки должен быть буквой русского алфавита.");
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

        public override bool IsPalindrome ()
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
