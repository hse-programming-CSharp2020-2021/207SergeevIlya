using System;
using Figures;

namespace MainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point();

            // Точка.
            p.Display();
            Console.WriteLine("p.Area для Point = " + p.Area);
            Console.WriteLine("\n---------------------------\n");

            // Круг.
            p = new Circle(1, 2, 6);
            p.Display();
            Console.WriteLine("p.Area для Circle = " + p.Area);
            Console.WriteLine("\n---------------------------\n");

            // Квадрат.
            p = new Square(3, 5, 8);
            p.Display();
            Console.WriteLine("p.Area для Square = " + p.Area);
        }
    }
}
