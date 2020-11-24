using System;
using System.Collections.Generic;
using System.Text;

namespace Figures
{
    /// <summary>
    /// Класс для окружности.
    /// </summary>
    public class Circle : Point
    {
        protected double Rad;

        /// <summary>
        /// Поле для радиус.
        /// </summary>
        public double rad 
        {
            get => Rad;
            set
            {
                Rad = value;
            }
        }

        /// <summary>
        /// Поле для получения длины окружности.
        /// </summary>
        public double Len
        { 
            get
            {
                return Math.PI * 2 * Rad;
            }
        }

        /// <summary>
        /// Свойство для получения площади.
        /// </summary>
        public override double Area 
        {
            get => rad * rad * Math.PI;
        }

        /// <summary>
        /// Метод для вывода информации об объекте.
        /// </summary>
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Радиус: " + rad);
            Console.WriteLine("Длина окр-ти: " + Len);
        }

        public Circle(double x, double y, double r) : base(x, y)
        {
            rad = r;
            Name = "Окружность";
        }
    }
}
