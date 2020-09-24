using System;
using System.Threading.Tasks.Dataflow;

// Задача # 5 из ДЗ # 2 

namespace Task5
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
                Console.WriteLine("Введите числовые значения сторон треугольника A, B и C" +
                    "\nСлучай вырожденного треугольника учитывается");

                A_string = Console.ReadLine();
                B_string = Console.ReadLine();
                C_string = Console.ReadLine();

                A_parsed = double.TryParse(A_string, out A);
                B_parsed = double.TryParse(B_string, out B);
                C_parsed = double.TryParse(C_string, out C);

            }
            while (!A_parsed || !B_parsed || !C_parsed);

            //Неравенство из википедии, там учитывается случай вырожденного треугольника
            bool AB_C = (A + B >= C),
                 AC_B = (A + C >= B),
                 BC_A = (B + C >= A);

            Console.WriteLine((AB_C && AC_B && BC_A) ? "Неравенство треугольника верно" : "Неравенство треугольника неверно");
            Console.ReadKey();
        }
    }
}
