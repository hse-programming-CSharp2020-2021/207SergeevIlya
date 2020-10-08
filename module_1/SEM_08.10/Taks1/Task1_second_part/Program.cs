using System;
using System.IO;
using System.Net.Http.Headers;

namespace Task1_second_part
{
    class Program
    {
        static int Bin_To_Int (string s)
        {
            int res = 0;
            for (int i = s.Length - 1, two = 1; i >= 0; --i)
            {
                if (s[i] == '1')
                    res += two;

                two *= 2;
            }
            

            return res;
        }

        static void Main(string[] args)
        {
            string s = File.ReadAllText("C:/Users/IlyaLayk/Desktop/207SergeevIlya/module_1/SEM_08.10/Taks1/Taks1/intNumber.txt");
            
            int n = Bin_To_Int(s);
            Console.WriteLine("В файле было записано число " + n);
        }
    }
}
