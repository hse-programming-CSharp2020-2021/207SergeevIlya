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
            File.WriteAllText(fileName, "Переписка до форматирования\n", enc); // Создаём пустой файл
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
            }
            // читаем сформированинный файл и обрабатываем предложения 
            string[] messages = File.ReadAllLines(fileName, enc); // Массив сообщений из переписки

            File.AppendAllText(fileName, "\nПереписка после формирования:\n", enc);
            for (int it = 1; it < messages.Length; ++it)
                File.AppendAllText(fileName, messages[it].Substring(0, messages[it].Length - 1) + '\n', enc);  // Выводим сообщения из переписки без точек на экран
                    
        }
    }
}
