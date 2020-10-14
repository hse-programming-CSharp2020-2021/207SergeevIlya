using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.IO;
using System.Linq.Expressions;

// Задача 4 

namespace Task_4
{
    class Program
    {
        // Метод добавления нового словаря 
        static void AddNewLanguage ()
        {
            Console.WriteLine("Введите название словаря: ");
            string dictName = Console.ReadLine() + ".txt";

            if (File.Exists(dictName))
            {
                try
                {
                    Console.WriteLine("Такой словарь уже существует");
                }
                catch (IOException)
                {
                    Console.WriteLine("Ошибка при создании словаря");
                }
            }
            else
            {
                File.AppendAllText(dictName, "");
            }
        }

        // Метод добавления нового слова в словарь
        static void AddNewWord ()
        {
            // Ищем словарь
            string dictName;
            try
            {
                dictName = CheckIfExist();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Введите новое слово");
            string word = Console.ReadLine();
            Console.WriteLine("Введите перевод: ");
            string translate = Console.ReadLine();
            try
            {
                File.AppendAllText(dictName, word + "-" + translate + "\n");
            }
            catch (IOException)
            {
                Console.WriteLine("Не удалось добавить новое слово");
            }
        }

        // Метод поиска перевода слова
        static void FindTranslate()
        {
            // Ищем словарь
            string dictName;
            try
            {
                dictName = CheckIfExist();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Введите слово: ");
            string word = Console.ReadLine();
            string[] allWords = null;
            try
            {
                allWords = File.ReadAllLines(dictName);
            }
            catch (IOException)
            {
                Console.WriteLine("Не удалось считать слова");
            }

            // Ищем первое слово в словаре нужное нам
            foreach (string str in allWords)
            {
                if (str.Split('-').Length != 2)
                {
                    Console.WriteLine("Ошибка в записи " + str);
                    continue;
                }

                string dictWord = str.Split('-')[0];
                if (dictWord == word)
                {
                    Console.WriteLine("Перевод: " + str.Split('-')[1]);
                    return;
                }
            }

            Console.WriteLine("Слово отсутствует");
        }

        static string scorePath = "C:/Users/IlyaLayk/Desktop/207SergeevIlya/module_1/HW_15.10/Task_4/Score.csv.txt";

        // Метод игры в карточки
        static void PlayCard()
        {
            // Ищем словарь
            int newScore = 0;
            string dictName;

            try
            {
                dictName = CheckIfExist();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Random rnd = new Random();
            string[] allWords = null;
            try
            {
                allWords = File.ReadAllLines(dictName);
            }
            catch (IOException)
            {
                Console.WriteLine("Не удалось считать слова");
            }

            Console.WriteLine("Вам будут выводиться слова на выбранном языке," +
                "а вам необходимо написать перевод. \nДля выхода в меню" +
                "\"Exit\"");

            int len = allWords.Length;
            while (true)
            {
                // Рандомно выбираем слово 
                string pair = allWords[rnd.Next(len)];
                // При ошибке в записи выходим из игры
                if (pair.Split('-').Length != 2)
                {
                    Console.WriteLine("Ошибка в записи" + pair +
                        "\nИсправьте");

                    return;
                }

                // Выводим карточку 
                Console.WriteLine(pair.Split('-')[0]);
                string answer = Console.ReadLine();

                // При выходе записываем результат 
                if (answer == "Exit")
                {
                    Console.Write("Введите ваше имя для сохранения результатов: ");
                    string name = Console.ReadLine();

                    try
                    {
                        File.AppendAllText(scorePath, name + ";" + newScore + ";" +
                            System.DateTime.Now.ToString() + '\n');
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Не удалось записать результат");
                    }
                    return;
                }

                if (answer == pair.Split('-')[1])
                {
                    Console.WriteLine("Верно!");
                    ++newScore;
                }
                else
                {
                    Console.WriteLine("Неверно. Верный ответ: " + pair.Split('-')[1]);
                }
            }
        }

        static string CheckIfExist()
        {
            Console.WriteLine("Введите название словаря: ");
            string dictName = Console.ReadLine() + ".txt";

            if (!File.Exists(dictName))
                throw new ArgumentException("Такого словаря не существует");

            return dictName;
        }

        // Метод для считывания числа
        static int ReadInt (int l, int r)
        {
            int res;
            bool res_parsed = int.TryParse(Console.ReadLine(), out res);

            while (!res_parsed || res > r || res < l)
            {
                Console.WriteLine("Попробуйте еще раз");
                res_parsed = int.TryParse(Console.ReadLine(), out res);
            }

            return res;
        }

        static void Start()
        {
            PrintMainMenu();
            int n = ReadInt(0, 4);

            switch (n)
            {
                case 0: Environment.Exit(0); break;
                case 1: AddNewLanguage(); break;
                case 2: AddNewWord(); break;
                case 3: FindTranslate(); break;
                case 4: PlayCard(); break;
            }
        }

        // Метод вывода меню 
        static void PrintMainMenu ()
        {
            Console.WriteLine("Добро пожаловать в ваш личный словарь!!!\n" +
                "Выберите номер пункта, что вы хотите сделать:\n" +
                "\t 1. Добавить новый словарь.\n" +
                "\t 2. Добавить новое слово и перевод.\n" +
                "\t 3. Найти перервод слова.\n" +
                "\t 4. Игра в карточки\n" +
                "\t Для выхода введите 0");
        }

        static void Main(string[] args)
        {
            while (true)
                Start();
        }
    }
}
