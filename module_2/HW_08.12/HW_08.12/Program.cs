using System;
using MyLib;

namespace HW_08._12
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ссылка на матрицу.
            int[,] res;
            // Ранг матрицы.
            int rank;

            do
            {
                try
                {
                    rank = IntValue.GetIntValue("Введите ранг матрицы: ");
                    res = Matrix.UnitMatr(rank);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Поробуйте ещё раз.\nДля завершения программы нажмите ESC");
                    continue;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Ошибка: введённая строка имеет значение null");
                    Console.WriteLine("Поробуйте ещё раз.\nДля завершения программы нажмите ESC");
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: введённая строка имеет неправильный формат");
                    Console.WriteLine("Поробуйте ещё раз.\nДля завершения программы нажмите ESC");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка: введённая число меньше минимального допустимого значения" +  int.MinValue 
                        + "или больше максимального допустимого значения" + int.MaxValue);
                    Console.WriteLine("Поробуйте ещё раз.\nДля завершения программы нажмите ESC");
                    continue;
                }

                // Выводим получившуюся матрицу.
                Matrix.MatrPrint(res);
                Console.WriteLine("Для завершения программы нажмите ESC");

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
    }
}
