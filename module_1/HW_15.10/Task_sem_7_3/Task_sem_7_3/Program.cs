using System;
using System.Text;
using System.IO;

namespace Task_sem_7_3
{
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            // основные настройки 
            const string fileName = "dialog.txt";
            Encoding enc = Encoding.Unicode;
            const int linesCount = 6; // кол-во предложений
            // Создаём файл на диске 
            File.WriteAllText(fileName, string.Empty, enc); // Создаём пустой файл
            Console.WriteLine("Переписка до форматирования");
            for (int i = 0; i < linesCount; i++)
            {
                string message = string.Empty; // предложение
                int length = rand.Next(20, 51); // Длина сообщения
                for (int j = 0; j < length; j++)
                {
                    message += (char)rand.Next('А','Я'); // Посимвольное добавление букв в сообщение . "Е" нет в диапазоне от А до Я!
                }
                message += '.' + Environment.NewLine; // Добавляем в сообщение точку и перенос на следующую строку
                File.AppendAllText(fileName, message, enc); // Добавляем строку в файл
                Console.Write(message);
            }
            // читаем сформированинный файл и обрабатываем предложения 
            string[] messages = File.ReadAllLines(fileName, enc); // Массив сообщений из переписки
            Console.WriteLine(Environment.NewLine + "Переписк после формирования:");
            foreach (string item in messages)
                Console.WriteLine(item.Substring(0, item.Length - 1)); // Выводим сообщения из переписки без точек на экран
                    
        }
    }
}
