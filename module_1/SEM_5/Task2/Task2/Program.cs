using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            
            Random rand = new Random();
            for (int i = 0; i < n; ++i)
                arr[i] = rand.Next(-10, 11);



            Console.WriteLine("Было : ");
            for (int i = 0; i < n; ++i)
                Console.WriteLine(arr[i]);


            int m = 0;
            for (int i = 0, j = 0; i < n; ++i)
                if (Math.Abs(arr[i]) % 2 == 0)
                {
                    arr[j] = arr[i];
                    m++;
                    j++;
                }

            if (m > 0)
                Array.Resize(ref arr, n - m);

            Console.WriteLine("Стало : ");
            for (int i = 0; i < n - m; ++i)
                Console.WriteLine(arr[i]);
        }
    }
}
