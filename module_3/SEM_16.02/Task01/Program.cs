using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    interface ICalculation
    {
        double Perform(double num);
    }

    class Add : ICalculation
    {
        double val;
        
        public Add (double val)
        {
            this.val = val;
        }

        public double Perform(double num)
        {
            val += num;
            return val;
        }
    }

    class Multiply : ICalculation
    {
        double val;

        public Multiply(double val)
        {
            this.val = val;
        }

        public double Perform(double num)
        {
            val *= num;
            return val;
        }
    }

    class Program
    {
        static double Calculate(double num, ICalculation action1, ICalculation action2)
        {
            return action2.Perform(action1.Perform(num));
        }

        static void Main(string[] args)
        {
            double inp = int.Parse(Console.ReadLine());
            ICalculation act1 = new Add(13.37),
                         act2 = new Multiply(14.88);

            Console.WriteLine(Calculate(inp, act1, act2));
        }
    }
}
