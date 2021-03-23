using System;
using System.IO;
using System.Text;
using Lib;

namespace Additional_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            // Получаем от пользователя N.
            Console.WriteLine("Введите число N:");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Введено некорректное значение. Попробуйте ещё раз.");
            }
            Console.WriteLine();

            // Получаем массив улиц, с которым в дальнейшем будем работать.
            Street[] streets = GetStreets(n);

            // Выводим информацию обо всех улицах.
            for (int i = 0; i < streets.Length; ++i)
            {
                Console.WriteLine($"Улица {i}:\n" + streets[i].ToString());
            }

            // Выводим в файл.
            StreamWriter sw = new StreamWriter("out.txt");
            foreach (var street in streets)
            {
                sw.WriteLine(street.ToString());
            }
            sw.Close();
        }

        /// <summary>
        /// Метод, проверяющий корректность строк.
        /// </summary>
        /// <param name="lines">
        /// Список строк, которые необходимо проверить на корректность.
        /// </param>
        /// <returns>
        /// Строку с ошибкой, если содержимое lines некорректно.
        /// Пустую строку, если содержимое lines корректно.
        /// </returns>
        static string CheckLines(string[] lines)
        {
            // Проверяем наличие строк.
            if (lines.Length == 0)
            {
                return "Ошибка при загрузке файла";
            }

            for (int i = 0; i < lines.Length; ++i)
            {
                string[] line_splitted = lines[i].Split(' ');

                // Проверяем наличие ошибок в строках.
                if (line_splitted.Length == 0)
                {
                    return $"Ошибка в строке {i}: пустая строка.";
                }
                else if (line_splitted.Length == 1)
                {
                    return $"Ошибка в строке {i}: на улице {line_splitted[0]} нет домов.";
                }
                else
                {
                    if (line_splitted[0] == "")
                    {
                        return $"Ошибка в строке {i}: пустое имя улицы.";
                    }

                    // Проверяем номера улиц.
                    for (int j = 1; j < line_splitted.Length; ++j)
                    {
                        if (!int.TryParse(line_splitted[j], out int res))
                        {
                            return $"Ошибка в строке {i}: '{line_splitted[j]}' не является числом.";
                        }
                        else if (res <= 0)
                        {
                            return $"Ошибка в строке {i}: все номера домов должны быть положительными числами.";
                        }
                        else if (res > 100)
                        {
                            return $"Ошибка в строке {i}: все номера домов должны быть меньше 100.";
                        }
                    }
                }
            }

            return "";
        }

        /// <summary>
        /// Метод для получения массива всех улиц.
        /// </summary>
        /// <param name="n">
        /// Кол-во улиц.
        /// </param>
        static Street[] GetStreets(int n)
        {
            // Пробуем получить все строки из файла с инф-ей об улицах.
            string[] lines;
            try
            {
                lines = File.ReadAllLines("data.txt");
            }
            catch
            {
                lines = new string[0];
            }

            // Проверяем файл.
            Street[] streets;
            string check = CheckLines(lines);
            if (check != "")
            {
                Console.WriteLine(check);
                Console.WriteLine("Будет сгенерирован массив из случайных улиц.");

                streets = new Street[n];

                // Генерируем улицы.
                for (int i = 0; i < n; ++i)
                {
                    Random rand = new Random();
                    streets[i] = new Street();

                    // Генерируем дома.
                    streets[i].Houses = new int[rand.Next(1, 10)];
                    for (int j = 0; j < streets[i].Houses.Length; ++j)
                    {
                        streets[i].Houses[j] = 10 * j + rand.Next(0, 9);
                    }

                    // Генерируем имя.
                    int k = rand.Next(3, 8);
                    StringBuilder newName = new StringBuilder(k);
                    for (int j = 0; j < k; ++j)
                    {
                        newName.Append((char)('a' + rand.Next(0, 25)));
                    }

                    streets[i].Name = newName.ToString();
                }
            }
            else
            {
                streets = new Street[Math.Min(n, lines.Length)];

                // Считывам массив из файла.
                for (int i = 0; i < Math.Min(n, lines.Length); ++i)
                {
                    string[] lineSplitted = lines[i].Split(' ');
                    streets[i].Name = lineSplitted[0];

                    for (int j = 1; j < lineSplitted.Length; ++j)
                    {
                        streets[i].Houses[j - 1] = int.Parse(lineSplitted[j]);
                    }
                }
            }

            return streets;
        }
    }
}
