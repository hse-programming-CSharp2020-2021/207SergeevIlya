using System;
using System.IO;

namespace Taks1
{
    class Program
    {
        static string Int_To_Binary(int x)
        {
            string res = "";

            while (x > 0)
            {
                res = (x % 2).ToString() + res;
                x /= 2;
            }

            return res;
        }

        static void Main(string[] args)
        { 
            int n = int.Parse(Console.ReadLine());

            File.WriteAllText("C:/Users/IlyaLayk/Desktop/207SergeevIlya/module_1/SEM_08.10/Taks1/Taks1/intNumber.txt", Int_To_Binary(n));
        }
    }
}
