using System;
using System.Collections.Generic;

namespace Task_03
{
    struct MaterialPoint
    {
        double m;
        double x;
        double y;

        public MaterialPoint (int m, int x, int y)
        {
            this.m = m;
            this.x = x;
            this.y = y;
        }
    }

    class MPointSet
    {
        public double Radius;
        public List<MaterialPoint> Points;

        public MaterialPoint MassCenter;
    }

    class Program
    {
        static void Main(string[] args)
        {
            MPointSet set = new MPointSet();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; ++i)
            {
                
            }
        }
    }
}
