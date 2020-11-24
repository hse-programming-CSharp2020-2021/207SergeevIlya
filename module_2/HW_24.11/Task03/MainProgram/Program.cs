using System;
using ClassLibrary;
using static System.Console;

namespace MainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Кол-во работников.
            int n;

            WriteLine("Введите кол-во работников.");
            while (!int.TryParse(ReadLine(), out n) || n <= 0)
                WriteLine("Некорректный ввод.");

            // Сами работники.
            Employee[] Workers = new Employee[n];

            for (int i = 0; i < n; ++i)
            {
                WriteLine("Введите имя работника.");
                string Name = ReadLine();

                WriteLine("Введите заплату работника.");
                decimal Payment;
                while (!decimal.TryParse(ReadLine(), out Payment) || Payment < 0)
                    WriteLine("Некорректный ввод.");

                // В зависимости от типа работника, получаем разную информацию.
                WriteLine("Введите 1, если следующий работник - внештатный.");
                if (ReadLine() == "1")
                {
                    Console.WriteLine("Введите надбавку");
                    decimal Salesbonus;
                    while (!decimal.TryParse(ReadLine(), out Salesbonus) || Salesbonus < 0)
                        WriteLine("Некорректный ввод.");

                    Workers[i] = new SalesEmployee(Name, Payment, Salesbonus);
                }
                else
                {
                    Console.WriteLine("Введите число рабочих дней.");
                    int WorkingDays;
                    while (!int.TryParse(ReadLine(), out WorkingDays) || WorkingDays <= 0)
                        WriteLine("Некорректный ввод.");

                    Workers[i] = new PartTimeEmployee(Name, Payment, WorkingDays);
                }
            }

            // Сортируем и выводим информацию.
            Array.Sort(Workers);
            foreach (Employee Worker in Workers)
            {
                WriteLine("Имя Работника: " + Worker.name);
                WriteLine("Зарплата работника: " + Worker.CalculatePay());
            }
        }
    }
}
