using System;
using MyLib;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ссылка на объект типа GeomProgr.
            GeomProgr geomProgrObj = new GeomProgr();
            Console.Clear();

            bool flag;
            int b, q;

            do
            {
                flag = false;

                try
                {
                    b = IntValue.GetIntValue("Введите начальный член прогрессии: ");
                    q = IntValue.GetIntValue("Введите знаменатель прогрессии: ");

                    geomProgrObj = new GeomProgr(b, q);
                }
                // Отлавливаем все исключения, когда знаменатель/первый член равны 0.
                catch (ArgumentException e)
                {
                    flag = true;
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Попробуйте ещё раз.");
                }
                catch (Exception)
                {
                    flag = true;
                    Console.WriteLine("Ошибка: введённые данные невозможно преобразовать в целые числа!");
                    Console.WriteLine("Попробуйте ещё раз.");
                }
            }
            while (flag);

            // Диалог.
            flag = true;
            do
            {
                try
                {
                    // Ввод.
                    int N = IntValue.GetIntValue("Введите N или -1, чтобы завершить выполнение программы.");

                    // Если пользователь решил завершить выполнение программы.
                    if (N == -1)
                        flag = false;

                    // Пробуем получить и вывести информацию.
                    Console.WriteLine("Значение " + N + "-ого члена прогрессии: " + geomProgrObj[N]);
                    Console.WriteLine("Сумма " + N + " членов прогрессии: " + geomProgrObj.ProgSum(N));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введённые данные имеют некорректный формат.");
                    Console.WriteLine("Поробуйте ещё раз");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Введённое число меньше минимального допустимого значения (" + int.MinValue
                        + ") или больше максимального допустимого значения (" + int.MaxValue + ")");
                    Console.WriteLine("Поробуйте ещё раз");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Поробуйте ещё раз");
                }
                catch (Exception)
                {
                    Console.WriteLine("Введённые данные некорректны.");
                    Console.WriteLine("Поробуйте ещё раз");
                }
            }
            while (flag);

            Console.WriteLine("Всего доброго!");
        }
    }
}
