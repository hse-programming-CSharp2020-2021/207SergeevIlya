using System;
using System.Globalization;
using System.Net;
using static System.Console;

namespace Task07
{
    public class SIN
    {
        private double XMin, XMax;

        public SIN(double min, double max)
        {
            XMin = min;
            XMax = max;
        }

        public double this[double Arg]
        {
            get
            {
                if (Arg < XMin || Arg > XMax)
                    return 0;
                return Math.Sin(Arg);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            SIN UserSin = new SIN(0, Math.PI);

            double Arg = double.Parse(ReadLine());
            WriteLine("Значение функции равно: " + UserSin[Arg / 6 * Math.PI]);
        }
    }
}