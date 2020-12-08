using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
    /// <summary>
    /// Класс, реализующий функционал геометрической прогрессии.
    /// </summary>
    public class GeomProgr
    {
        /// <summary>
        /// Кол-во созданных объектов класса.
        /// </summary>
        public static uint objectNumber = 0;

        double _b;

        /// <summary>
        /// Первый член прогрессии b != 0.
        /// </summary>
        public double B
        {
            get
            {
                return _b;
            }

            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Недопустимое значение первого члена прогрессии!");
                }

                _b = value;
            }
        }

        double _q;

        /// <summary>
        /// Знаменатель прогрессии q != 0.
        /// </summary>
        public double Q
        {
            get
            {
                return _q;
            }

            set
            {
                if (value == 0)
                    throw new ArgumentException("Недопустимое значение знаменателся прогрессии!");

                _q = value;
            }
        }

        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        /// <remarks>
        /// Присваивает первому члену проргессии и знаменателю прогрессии 1.
        /// </remarks>
        public GeomProgr ()
        {
            B = 1;
            Q = 1;

            objectNumber++;
            Console.WriteLine(objectNumber + ": Конструктор без параметров.");
        }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="b">
        /// Первый член прогрессии (не равный 0).
        /// </param>
        /// <param name="q">
        /// Знамнатель прогрессии (не равный 0).
        /// </param>
        public GeomProgr (double b, double q)
        {
            B = b;
            Q = q;

            Console.WriteLine(objectNumber + ": Конструктор с параметрами.");
        }

        public double this[int n]
        {
            get
            {
                if (n == 1)
                    return B;
                else if (n > 1)
                    return this[1] * Math.Pow(Q, n - 1);
                else
                    throw new ArgumentOutOfRangeException("Номер эл-та прогрессии должен быть больше либо равен 1");
            }
        }

        /// <returns>
        /// Возвращает сумму первых n членов прогрессии.
        /// </returns>
        public double ProgSum (int n)
        {
            if (n >= 1)
                return B * (Math.Pow(Q, n) - 1) / (Q - 1);
            else
                throw new ArgumentOutOfRangeException("Номер эл-та прогрессии должен быть больше либо равен 1");
        }
    }
}