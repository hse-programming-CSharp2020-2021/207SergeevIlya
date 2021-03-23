using System;
using System.Collections.Generic;
using System.IO;
using Lib;

namespace SecondProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Пробуем считать все строки из файла.
            string[] lines;

            try
            {
                lines = File.ReadAllLines("C:/Users/IlyaLayk/Desktop\207SergeevIlya\module_3\Additional_Task\bin\Debug\net5.0out.txt");
            }
            catch
            {
                Console.WriteLine("Ошибка с файлом!");
                return;
            }

            // Считываем улицы и выбираем интересующие нас.
            List<Street> streets = new List<Street>(lines.Length);
            for (int i = 0; i < lines.Length; ++i)
            {
                Street newStreet = new Street();

                string[] lineSplitted = lines[i].Split(' ');
                newStreet.Name = lineSplitted[0];

                if (lineSplitted.Length % 2 == 1)
                {
                    newStreet.Houses = new int[lineSplitted.Length - 1];
                    for (int j = 1; j < lineSplitted.Length; ++j)
                    {
                        newStreet.Houses[j - 1] = int.Parse(lineSplitted[j]);
                    }

                    // Ищем дом с номером, содержащим цифру 7.
                    if (!newStreet)
                    {
                        streets.Add(newStreet);
                    }
                }
            }

            // Выводим список найденных волшебных улиц.
            Console.WriteLine("Вот все найденные волшебные улицы: ");
            foreach (var s in streets)
            {
                Console.WriteLine(s.ToString());
            }
        }
    }
}
