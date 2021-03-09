using System;
using System.IO;

namespace Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            int[] nums = new int[10];
            for (int i = 0; i < nums.Length; ++i)
                nums[i] = rand.Next();

            string nums_parsed = "";
            for (int i = 0; i < nums.Length; ++i)
                nums_parsed += nums[i].ToString() + "\n";


            // 1.
            File.WriteAllText(@"../../../../MyTest1.txt", nums_parsed);
            Console.WriteLine("В файл MyTest1.txt записано:\n" + File.ReadAllText(@"../../../../MyTest1.txt"));

            // 2.
            using (FileStream fs = new FileStream(@"../../../../MyTest2.txt", FileMode.OpenOrCreate))
            {
                byte[] bytes = System.Text.Encoding.Default.GetBytes(nums_parsed);

                fs.Write(bytes);
            }

            Console.WriteLine("В файл MyTest2.txt записано:\n" + File.ReadAllText(@"../../../../MyTest2.txt"));

            // 3.
            using (StreamWriter sw = new StreamWriter(@"../../../../MyTest3.txt"))
            {
                sw.Write(nums_parsed);
            }

            Console.WriteLine("В файл MyTest3.txt записано:\n" + File.ReadAllText(@"../../../../MyTest3.txt"));

            // 4.
            using (BinaryWriter bw = new BinaryWriter(File.Open(@"../../../../MyTest4.txt", FileMode.OpenOrCreate)))
            {
                bw.Write(nums_parsed);
            }

            Console.WriteLine("В файл MyTest4.txt записано:\n" + File.ReadAllText(@"../../../../MyTest4.txt"));

            // Считаем сумму чётных чисел.
            int sum = 0;

            using (StreamReader sr = new StreamReader(@"../../../../MyTest2.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);

                    int num = int.Parse(line);
                    if (num % 2 == 0)
                        sum += num;
                }
            }

            Console.WriteLine("Сумма чётных в файле MyTest2.txt:" + sum);
        }
    }
}
