using System;

namespace ConsoleApp1
{
    class Program
    {
        delegate int Cast(double val);

        static void Main(string[] args)
        {
            Cast cast1 = delegate (double num) {
                return (int)(num + 0.5);
            };

            Cast cast2 = delegate (double num)
            {
                return (int)(Math.Log10(num)) + 1;
            };

            double num = double.Parse(Console.ReadLine());

            Console.WriteLine(cast1);
            Console.WriteLine(cast2);
        }
    }
}
