using System;
using System.IO;

namespace Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream f = new FileStream("example.txt", FileMode.OpenOrCreate))
            {
                using (StreamWriter fWrite = new StreamWriter(f))
                {
                    Random rand = new Random();

                    for (int i = 0; i < 100; ++i)
                        fWrite.WriteLine(rand.Next(100, 1000));
                }
            }

            using (FileStream f = new FileStream("example.txt", FileMode.Open))
            {
                using (StreamReader fRead = new StreamReader(f))
                {
                    Console.SetIn(fRead);

                    int sum = 0,
                        n = 0;

                    string inp = Console.ReadLine();
                    while (inp != "")
                    {
                        sum += int.Parse(inp);
                        n++;

                        inp = Console.ReadLine();
                    }

                    Console.WriteLine("Среднее значение: " + ((double)sum/n));
                }   
            }

            var standardInput = new StreamReader(Console.OpenStandardInput());
            Console.SetIn(standardInput);
        }
    }
}
