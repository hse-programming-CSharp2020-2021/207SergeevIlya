using System;
using System.Collections.Generic;
using System.Text;

namespace Figures
{
    public class Square : Point
    {
        protected double side;

        /// <summary>
        /// Поле для стороны квадрата.
        /// </summary>
        public double Side 
        { 
            get => side; 
            set 
            {
                side = value;
            }
        }

        /// <summary>
        /// Поле для получения периметра квадрата.
        /// </summary>
        public double Len { get => side * 4; }

        /// <summary>
        /// Свойство для получения площади квадрата.
        /// </summary>
        public override double Area
        {
            get
            {
                return side * side;
            }
        }

        public Square(double x, double y, double side) : base(x, y)
        {
            Side = side;
            Name = "Квадрат";
        }

        /// <summary>
        /// Метод для вывода информации об объекте.
        /// </summary>
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Сторона: " + side);
            Console.WriteLine("Периметр: " + Len);
        }
    }
}
