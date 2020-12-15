using System;
using System.Collections.Generic;
using System.Text;

namespace Task01
{
    static class IntValue
    {
        /// <summary>
        /// Метод для получения числа от пользователя.
        /// </summary>
        /// <param name="comment">
        /// Комментарий, который будет выведен на экран.
        /// </param>
        public static int GetIntValue(string comment)
        {
            int intVal;

            do Console.WriteLine(comment);
            while (!int.TryParse(Console.ReadLine(), out intVal));

            return intVal; 
        }
    }
}
