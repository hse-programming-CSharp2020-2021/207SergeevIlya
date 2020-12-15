using System;

namespace Task02
{
    class Program
    {
        /// <summary>
        /// Валидатор, проверяющий, состоит ли строка только из символов латинского алфавита и пробелов.
        /// </summary>
        public static bool Validate (string str)
        {
            for (int i = 0; i < str.Length; ++i)
                if (!((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'A' && str[i] <= 'Z') || (str[i] == ' ')))
                    return false;

            return true;
        }

        /// <summary>
        /// Валидатор строки на соответствие формату.
        /// </summary>
        /// <param name="str">
        /// Сама строка.
        /// </param>
        /// <param name="ch">
        /// Разделитель в строке.
        /// </param>
        public static string[] ValidateSplit (string str, char ch)
        {
            string[] output = str.Split(ch);

            foreach (string s in output)
            {
                if (!Validate(s))
                    return null;
            }

            return output;
        }

        /// <summary>
        /// Метод, обрезающий строку по первому гласному.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Shorten (string str)
        {
            char[] alph = { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U', 'y', 'Y' };
            int ind = str.IndexOfAny(alph);

            return str.Substring(0, ind + 1);
        }

        /// <summary>
        /// Метод для получения аббревиатуры строки.
        /// </summary>
        /// <returns>
        /// Возвращает аббревиатуру.
        /// </returns>
        public static string Abbrevation (string str)
        {
            string output = String.Empty;

            if (str != String.Empty)
            {
                string[] tmp = str.Split(' ');

                foreach (string s in tmp)
                {
                    string shortenS = Shorten(s);
                    FirstUpcase(ref shortenS);
                    output += shortenS;
                }
            }

            return output;
        }

        /// <summary>
        /// Метод для преобразования первого символа к заглавному.
        /// </summary>
        public static void FirstUpcase (ref string str)
        {
            char[] chars = str.ToCharArray();
            str = str[0].ToString().ToUpper() + str.ToLower().Substring(1);
        }

        static void Main(string[] args)
        {
            // Получаем на вход строку.
            string inp = Console.ReadLine();

            // Сплиттим.
            string[] inp_splitted = ValidateSplit(inp, ';');

            // Выводим, если данные корректны.
            if (inp_splitted != null)
            {
                foreach (string s in inp_splitted)
                    try
                    {
                        Console.WriteLine(Abbrevation(s));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Одна из введённых строк имеет некорректный формат (вероятно, отсутствуют гласные).");
                    }
            }
            else
                Console.WriteLine("Данные некорректны!");
        }
    }
}
