using System;
using System.Threading.Tasks.Dataflow;

// Задача # 3 из ДЗ # 2 

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            double A, B, C;
            string A_string, B_string, C_string;
            bool A_parsed, B_parsed, C_parsed;

            // К сожалению, в этой задаче запрещено использование конструкции if
            // поэтому повторения решения не будет(

            // Но разрешены циклы, пэтому вот проверка верности входных данных
            // !!ВАЖНО!! По смыслу я не заменяю циклом do while оператор if, а лишь использую его для соответствия одному из критериев

            do
            { 
                Console.WriteLine("Введите числовые значения коэффицентов A, B и C квадратного уравнения");

                A_string = Console.ReadLine();
                B_string = Console.ReadLine();
                C_string = Console.ReadLine();

                A_parsed = double.TryParse(A_string, out A);
                B_parsed = double.TryParse(B_string, out B);
                C_parsed = double.TryParse(C_string, out C);

            }
            while (!A_parsed || !B_parsed || !C_parsed);

            //Считаем корни
            double D = B * B - 4 * A * C;

            string ans1 = "" + ((D >= 0) ? ((-B + Math.Sqrt(D)) / (2 * A)) : Double.NaN);
            string ans2 = "" + ((D >= 0) ? ((-B - Math.Sqrt(D)) / (2 * A)) : Double.NaN);

            //Вычисляем число -B / 2A (на случай, если у нас будут комплексные корни)
            double first_int_sum = (-1 * B) / (2 * A);

            // Выводим корни :
            // (комплексные корни выводим в виде суммы)
            Console.WriteLine("Первый корень = " + ((D < 0) ? (first_int_sum + " + ( Sqrt(" + D + ") / " + 2 * A) : ans1));
            Console.WriteLine("Второй корень = " + ((D < 0) ? (first_int_sum + " - ( Sqrt(" + D + ") / " + 2 * A) : ans2));

            Console.ReadKey();
        }
    }
}
