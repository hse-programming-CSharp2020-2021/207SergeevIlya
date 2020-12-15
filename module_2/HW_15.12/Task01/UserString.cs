using System;
using System.Collections.Generic;
using System.Text;

namespace Task01
{
    class UserString
    {
        /// <summary>
        /// Сама строка.
        /// </summary>
        public string Str { get; set; }


        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name = "k">
        /// Длина строки.
        /// </param>
        /// <param name = "maxChar">
        /// Верхняя граница диапазона символов.
        /// </param>
        /// <param name = "minChar">
        /// Нижнаяя граница диапазона символов.
        /// </param>
        /// 
        public UserString (int k, char minChar, char maxChar)
        {
            if (k < 0)
                throw new ArgumentException("Аргумент метода должен быть положительным!");
            
            if (maxChar < minChar)
            {
                char c = minChar;
                minChar = maxChar;
                maxChar = c;
            }

            // Пустая строка остаётся пустой, если символов 0.
            string line = String.Empty;

            for (int i = 0; i < k; ++i)
                line += (char)gen.Next(minChar, maxChar + 1);

            Str = line;
        }

        static Random gen = new Random();

        /// <summary>
        /// Метод для удаления всех символов одной строки из другой.
        /// </summary>
        /// <param name="s">
        /// Строка, в которой будут искаться символы.
        /// </param> 
        /// <returns>
        /// Получившуюся строку.
        /// </returns>
        public string MoveOff (string s)
        {
            int index;
            
            // Циклом за квадрат проходимся.
            for (int i = 0; i < s.Length; ++i)
            {
                while ((index = Str.IndexOf(s[i])) >= 0)
                    Str = Str.Remove(index, 1);
            }

            return Str;
        }
    }
}
