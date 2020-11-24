using System;
using System.Collections.Generic;
using System.Text;

namespace Figures
{
    /// <summary>
    /// Класс для точек.
    /// </summary>
    public class Point
    {
        /// <summary>
        /// Поле для имени геом. объекта.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Координаты фигуры (центра).
        /// </summary>
        public double X, Y;

        /// <summary>
        /// Виртуальное св-во площади объекта.
        /// </summary>
        public virtual double Area { get; set; }

        /// <summary>
        /// Виртуальный метод для вывода информации об объекте.
        /// </summary>
        public virtual void Display()
        {
            Console.WriteLine(Name + ":");
            Console.WriteLine("Координаты: " + X + " " + Y);
        }

        public Point (double x, double y)
        {
            X = x;
            Y = y;
            Name = "Точка";
        }

        public Point ()
        {
            Random rand = new Random();
            X = rand.Next(0, 100);
            Y = rand.Next(0, 100);

            Name = "Случайная точка";
        }
    }
}
