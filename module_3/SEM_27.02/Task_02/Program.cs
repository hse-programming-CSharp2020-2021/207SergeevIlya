using System;

namespace Task_02
{
    struct PointS
    {
        double x;
        double y;

        public double GetX()
        {
            return x;
        }

        public double GetY()
        {
            return y;
        }

        public PointS (double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        static public double Distance (PointS first, PointS second)
        {
            return Math.Sqrt((first.x - second.x) * (first.x - second.x) + (first.y - second.y) * (first.y - second.y));
        }
    }

    struct CircleS : IComparable
    {
        PointS center;

        public PointS Center
        {
            get
            {
                return center;
            }
        }

        double rad;

        public double Rad 
        {
            get
            {
                return rad;
            }
        }

        public CircleS (double x, double y, double r)
        {
            if (r < 0)
                throw new ArgumentException("r >= 0!!");

            center = new PointS(x, y);
            rad = r;
        }

        public double Length ()
        {
            return 2 * Math.PI * rad;
        }

        public new string ToString ()
        {
            return $"x: {center.GetX()}, y: {center.GetY()}, r: {rad}";
        }

        public int CompareTo (object circ)
        {
            if (circ is CircleS)
                return Length().CompareTo(((CircleS)circ).Length());
            else
                throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            CircleS[] circles = new CircleS[3];

            for (int i = 0; i < circles.Length; i++)
            {
                circles[i] = new CircleS(random.Next(0, 69) + random.NextDouble(), random.Next(-22, 8) + random.NextDouble(), random.Next(-13, 37) + random.NextDouble());
            }

            Array.Sort(circles);

            foreach (var circle in circles)
            {
                Console.WriteLine(circle);
            }
        }
    }
}
