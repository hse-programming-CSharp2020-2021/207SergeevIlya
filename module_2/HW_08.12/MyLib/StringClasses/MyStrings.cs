using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib.StringClasses
{
    public abstract class MyStrings
    {
        /// <summary>
        /// Метод, возвращающий информацию о палиндромности.
        /// </summary>
        public abstract bool IsPalindrome();

        /// <summary>
        /// Метод, проверяющий корректность входящих в строку символов.
        /// </summary>
        public abstract bool Validate();

        /// <summary>
        /// Метод, подсчитывающий кол-во вхождений символа в строку.
        /// </summary>
        /// <param name="letter">
        /// Буква, которая ищется в строке.
        /// </param>
        public abstract int CountLetter(char letter);

    }
}
