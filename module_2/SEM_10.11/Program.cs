using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point()
    {
        X = 0;
        Y = 0;
    }

    public Point(double X0, double Y0)
    {
        X = X0;
        Y = Y0;
    }
}

class Triangle
{
    public Point A { get; set; }
    public Point B { get; set; }
    public Point C { get; set; }

    public double AB
    {
        get
        {
            return Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));
        }
    }

    public double AC
    {
        get
        {
            return Math.Sqrt((A.X - C.X) * (A.X - C.X) + (A.Y - C.Y) * (A.Y - C.Y));
        }
    }

    public double BC
    {
        get
        {
            return Math.Sqrt((B.X - C.X) * (B.X - C.X) + (B.Y - C.Y) * (B.Y - C.Y));
        }
    }

    public double Perimetr
    {
        get
        {
            return AB + BC + AC;
        }
    }

    public double Area
    {
        get
        {
            double p = Perimetr / 2;
            return (Math.Sqrt(p * (p - AB) * (p - AC) * (p - BC)));
        }
    }

    public Triangle()
    {
        A = new Point(0, 0);
        B = new Point(1, 0);
        C = new Point(0, 1);
    }

    public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        A = new Point(x1, y1);
        B = new Point(x2, y2);
        C = new Point(x3, y3);

        if (AB + BC < AC || AB + AC < BC || AC + BC < AB)
            throw new Exception("Не выполнено неравенство треугольника");
    }

    public Triangle(Point FirstPoint, Point SecondPoint, Point ThirdPoint)
    {
        A = FirstPoint;
        B = SecondPoint;
        C = ThirdPoint;

        if (AB + BC < AC || AB + AC < BC || AC + BC < AB)
            throw new Exception("Не выполнено неравенство треугольника");
    }
}

class Programm
{

    static void Main()
    {
        do
        {
            Console.WriteLine("Введите пустую строку, чтобы закончить ввод");
            if (Console.ReadLine() == "")
                break;

            Random rand = new Random();
            int N = rand.Next(5, 16);

            Console.WriteLine("Значение N : " + N);

            Triangle[] T = new Triangle[N];
            for (int i = 0; i < N; ++i)
            {

                double x1 = rand.NextDouble() * 10,
                       y1 = rand.NextDouble() * 10,
                       x2 = rand.NextDouble() * 10,
                       y2 = rand.NextDouble() * 10,
                       x3 = rand.NextDouble() * 10,
                       y3 = rand.NextDouble() * 10;

                Console.WriteLine("Точки, из которых состоит треугольник: ");
                Console.WriteLine(x1 + " " + y1);
                Console.WriteLine(x2 + " " + y2);
                Console.WriteLine(x3 + " " + y3);

                T[i] = new Triangle(x1, y2, x2, y2, x3, y3);
            }

            Array.Sort(T, delegate (Triangle T1, Triangle T2) {
                if (T1.Area > T2.Area)
                    return 1;
                return 0;
            });
        }
        while (true);


    }
}