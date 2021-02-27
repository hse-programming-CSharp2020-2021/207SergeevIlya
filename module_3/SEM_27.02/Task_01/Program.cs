using System;

namespace Task_01
{
    struct Coords
    {
        public double X;

        public double Y;

        public Coords(double x, double y)
        {
            X = x;
            Y = y;
        }

        public new string ToString()
        {
            return X.ToString() + "" + Y.ToString();
        }
    }

    struct Circle
    {
        Coords center;

        double radius;

        public Circle (double x, double y, double r)
        {
            if (r < 0)
                throw new ArgumentException("Radius should be not less than zero.");

            center = new Coords(x, y);
            radius = r;
        }

        public new string ToString()
        {
            return "x, y: " + center.ToString() + " r: " + radius.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(13, 3, 7);
            Console.WriteLine(circle.ToString());

            circle = new Circle(6, 6, -6);
        }
    }
}
