using System;
using System.Collections.Generic;
using System.IO;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BinaryWriter fOut = new BinaryWriter(new FileStream("example.txt", FileMode.Create)))
            {
                Random rand = new Random();

                for (int i = 0; i <= 10; i++)
                    fOut.Write(rand.Next(1, 100));
            }

            int num = int.Parse(Console.ReadLine());

            List<int> nums = new List<int>();

            using (FileStream f = new FileStream("example.txt", FileMode.Open))
            using (BinaryReader fIn = new BinaryReader(f))
            {
                long n = f.Length / 4; int a;
                for (int i = 0; i < n; i++)
                {
                    nums.Add(fIn.ReadInt32());
                }
            }

            ReadFile();

            bool flag = false;
            for (int i = 0; i < 100 - num; i++)
            {
                if (nums.Contains(num + i) && !flag)
                {
                    nums[nums.IndexOf(num + i)] = num;

                    flag = true;
                }
            }

            using (BinaryWriter fOut = new BinaryWriter(new FileStream("example.txt", FileMode.Create)))
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    fOut.Write(nums[i]);
                }  
            }

            Console.WriteLine();
            ReadFile();
        }

        static public void ReadFile()
        {
            using (FileStream f = new FileStream("example.txt", FileMode.Open))
            {
                using (BinaryReader fIn = new BinaryReader(f))
                {
                    long n = f.Length / 4;

                    for (int i = 0; i < n; i++)
                    {
                        int a = fIn.ReadInt32();

                        Console.Write(a + " ");
                    }
                }
            }

        }
    }
}