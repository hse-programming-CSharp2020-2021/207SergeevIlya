using System;

namespace Task_01
{
    /// <summary>
    /// Класс, в котором реализуются методы для перевода температуры в другие единицы измерения.
    /// </summary>
    internal class TemperatureConverterImp
    {
        public double CelcToFar(double tCelc)
        {
            return (tCelc * 9.0 / 5 + 32.0);
        }

        public double FarToCelc(double tFar)
        {
            return ((tFar - 32) * 5.0 / 9);
        }

        public double CelcToRan(double tCelc)
        {
            return (tCelc * 9.0 / 5 + 491.67);
        }

        public double RanToCelc(double tRan)
        {
            return ((tRan - 491.67) * 5.0 / 9 );
        }

        public double CelcToReo(double tCelc)
        {
            return (tCelc * 1.25);
        }

        public double ReoToCelc(double tReo)
        {
            return (tReo / 1.25);
        }
    }

    class Program
    {
        delegate double delegateConvertTemperature(double p);

        /// <summary>
        /// Метод для проверки корректности ввода.
        /// Записывает в переменную res -1, если ввод некорректен.
        /// Записывает в res -2, если пользователь решил отменить ввод.
        /// Иначе записывает номер делегата, который потребуется вызвать.
        /// </summary>
        /// <returns>
        /// Если ввод корректен, true.
        /// Иначе, false.
        /// </returns>
        static bool Validate (string inp, out int res)
        {
            inp = inp.Trim(' ');

            if (inp == "-")
                res = -2;
            else
            {
                string[] inpSplitted = inp.Split(' ');

                if (inpSplitted.Length != 2)
                    res = -1;
                else if (inpSplitted[0] == "tC" && inpSplitted[1] == "tF")
                    res = 0;
                else if (inpSplitted[0] == "tF" && inpSplitted[1] == "tC")
                    res = 1;
                else if (inpSplitted[0] == "tC" && inpSplitted[1] == "tRa")
                    res = 2;
                else if (inpSplitted[0] == "tRa" && inpSplitted[1] == "tC")
                    res = 3;
                else if (inpSplitted[0] == "tC" && inpSplitted[1] == "tRe")
                    res = 4;
                else if (inpSplitted[0] == "tRe" && inpSplitted[1] == "tC")
                    res = 5;
                else
                    res = -1;
            }

            return (res != -1);
        }

        static void Main(string[] args)
        {
            TemperatureConverterImp methodsClass = new TemperatureConverterImp();

            // Собственно, массив делигатов.
            delegateConvertTemperature[] delArray = new delegateConvertTemperature[6];
            delArray[0] = methodsClass.CelcToFar;
            delArray[1] = methodsClass.FarToCelc;
            delArray[2] = methodsClass.CelcToRan;
            delArray[3] = methodsClass.RanToCelc;
            delArray[4] = methodsClass.CelcToReo;
            delArray[5] = methodsClass.ReoToCelc;

            // Выводим таблицу и необходимую информацию.
            // (Решил несколько расширить функционал и сделать ввод поудобнее).
            Console.WriteLine("                |  Из цельсия (tC)          | В цельсия (tC)");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Фаренгейты (tF) |  tF = 9 / 5 * tC + 32     | tC = 5 / 9 * (tF - 32)");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Ранкины (tRa)   | tC * 9.0 / 5 + 491.67     | (tRa - 491.67) * 5.0 / 9 ");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Реомюры (tRe)   | tC * 5 / 4                | tRe * 4 / 5 ");
            Console.WriteLine("----------------------------------------------------------------------\n");

            do
            {
                Console.WriteLine("Введите через пробел наименование величины, из которой хотите перевести, и " +
                    "величину, в которую хотите перевести \n(переводить можно либо из градусов цельсия, либо в них)");
                Console.WriteLine("Прим.: tC tRe");
                Console.WriteLine("Также вы можете ввести '-', чтобы отменить ввод.\n");

                // Получаем от пользователя информацию о том, из какой величины он хочет перевести и в какую.
                int inp;
                while (!Validate(Console.ReadLine(), out inp))
                    Console.WriteLine("Ввод некорректен. Попробуйте ещё раз или введите '-', чтобы отменить ввод и завершить работу.");

                // Если пользователь решил отменить ввод и завершить выполнение программы.
                if (inp == -2)
                    return;

                string[] delNames = new string[6] { "градусах цельсия", "фаренгейтах", "градусах цельсия", "ранкинах", "градусах цельсия", "реомюрах" };

                // Получаем от пользователя температуру в градусах цельсия.
                Console.WriteLine($"Введите температуру в {delNames[inp]}");

                double inpT;
                while (!double.TryParse(Console.ReadLine(), out inpT))
                    Console.WriteLine("Введено некорректное значение. Попробуйте ещё раз.");

                Console.WriteLine($"Переведённое значение температуры: {delArray[inp](inpT)}\n");
            }
            while (true);
        }
    }
}
