using System;
using System.Linq;

namespace Task1
{
    class Program
    {
        static char [] num_to_char_arr (int num)
        {
            int n; 
            if (num != 0)
                n = (int)Math.Log10(((double)num)) + 1;
            else
                n = 1;


            char[] arr = new char[n];

            if (num == 0)
                arr[0] = '0';

            int i = n - 1;
            while (num > 0)
            {
                arr[i] = (char)(num % 10 + '0');

                num /= 10;
                i--;
            }

            return arr;
        }

        static void Main(string[] args)
        {
            int n;
            n = int.Parse(Console.ReadLine());

            char[] arr = num_to_char_arr(n);

            for (int i = 0; i < arr.Length; ++i)
                Console.WriteLine(arr[i]);
        }
    }
}
