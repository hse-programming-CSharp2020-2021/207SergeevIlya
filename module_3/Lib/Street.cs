using System;

namespace Lib
{
    /// <summary>
    /// Класс, реализующий функционал улицы.
    /// </summary>
    public class Street
    {
        /// <summary>
        /// Имя улицы.
        /// </summary>
        public string Name;

        /// <summary>
        /// Номера домов на улице.
        /// </summary>
        public int[] Houses;

        public static int operator ~(Street s) => s.Houses.Length;

        public static bool operator !(Street s)
        {
            // Проверяем, имеется ли дом, содержащий в своём номере цифру 7.
            foreach (int num in s.Houses)
            {
                if (num.ToString().Contains('7'))
                    return true;
            }

            return false;
        }

        public override string ToString()
        {
            string res = "Street " + this.Name;

            // Получаем строковое представление массива всех домов.
            foreach (int num in this.Houses)
            {
                res += " " + num.ToString();
            }

            return res;
        }
    }
}
