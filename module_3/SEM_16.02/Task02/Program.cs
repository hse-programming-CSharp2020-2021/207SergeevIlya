using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    interface ISequence
    {
        double GetElement(int id);
    }

    class ArithmeticProgression : ISequence
    {
        double a, d;

        public ArithmeticProgression (double a, double d)
        {
            this.a = a;
            this.d = d;
        }

        public double GetElement (int id)
        {
            return a + d * (id - 1);
        }
    }

    class GeometricProgression : ISequence
    {
        double b, q;

        public GeometricProgression(double b, double q)
        {
            this.b = b;
            this.q = q;
        }

        public double GetElement (int id)
        {
            return b * Math.Pow(q, id - 1);
        }
    }


    class Program
    {
        static double Sum (ISequence seq, int count)
        {
            double sum = 0;

            for (int i = 0; i < count; ++i)
                sum += seq.GetElement(i);

            return sum;
        }

        static void Main(string[] args)
        {
            var s = Sum(new ArithmeticProgression(6.0, 6.0), 6);

            Console.WriteLine(s);
        }
    }
}
