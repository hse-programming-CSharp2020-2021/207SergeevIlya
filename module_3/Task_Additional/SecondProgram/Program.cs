using System;
using System.Collections.Generic;
using System.IO;
using Lib;

namespace SecondProgram
{
    class Program
    {
        /// <summary>
        /// Путь к файлу, из которого будут считаны данные.
        /// </summary>
        static string path = @"../../../../Task_Additional/bin/Debug/net5.0/out.txt";

        static void Main(string[] args)
        {
            // Пробуем считать все строки из файла.
            string[] lines;

            try
            {
                lines = File.ReadAllLines(path);
            }
            catch
            {
                Console.WriteLine("Ошибка с файлом!");
                return;
            }

            // Считываем улицы и выбираем интересующие нас.
            List<Street> streets = GetStreets(lines);

            // Выводим список найденных волшебных улиц.
            Console.WriteLine("\nВот все найденные волшебные улицы: ");
            foreach (var s in streets)
            {
                Console.WriteLine(s.ToString());
            }
            Console.WriteLine("\nP.S.: строки, содержащие инф-ю об улицах с нечётным кол-вом домов" +
                "не расмматривались (т.к они однозначно не волшебные), поэтому и наличие ошибок " +
                "в них не проверялось.");
        }
        
        /// <summary>
        /// Метод, возвращающий список улиц из файла path.
        /// </summary>
        static List <Street> GetStreets (string[] lines)
        {
            // Считываем улицы и выбираем интересующие нас.
            List<Street> streets = new List<Street>(lines.Length);
            for (int i = 0; i < lines.Length; ++i)
            {
                Street newStreet = new Street();

                string[] lineSplitted = lines[i].Split(' ');

                if (lineSplitted.Length < 2)
                {
                    Console.WriteLine($"Ошибка в строке {i}: слишком мало данных.");
                    continue;
                }

                newStreet.Name = lineSplitted[0];

                if (lineSplitted.Length % 2 == 0)
                {
                    // Флаг, обозначающий наличие ошибок в строках.
                    bool err = false;

                    newStreet.Houses = new int[lineSplitted.Length - 1];
                    for (int j = 1; j < lineSplitted.Length && !err; ++j)
                    {
                        try
                        {
                            newStreet.Houses[j - 1] = int.Parse(lineSplitted[j]);
                        }
                        catch
                        {
                            Console.WriteLine($"Ошибка в строке {i}: найден номер дома, не являющийся числом.");
                            err = true;
                        }

                        if (newStreet.Houses[j - 1] < 1 || newStreet.Houses[j - 1] > 100)
                        {
                            Console.WriteLine($"Ошибка в строке {i}: найден номер дома вне диапазона [1;100].");
                            err = true;
                        }
                    }

                    // Ищем дом с номером, содержащим цифру 7.
                    if (!err && !newStreet)
                    {
                        streets.Add(newStreet);
                    }
                }
            }

            return streets;
        }
    }
}
