using System;

namespace Task_arr
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
 
            for (int i = 0; i < n; ++i)
                arr[i] = int.Parse(Console.ReadLine());

            int m = 0;
            for (int i = 0; i < n; ++i)
                if (arr[i] >= 0)
                    m++;

            int[] res_arr = new int[n];
            for (int i = 0, j = 0, k = m; i < n; ++i)
                if (arr[i] >= 0)
                {
                    res_arr[j] = arr[i];
                    j++;
                }
                else
	            {
                    res_arr[k] = arr[i];
                    k++;
	            }

            for (int i = 0; i < n; ++i)
                Console.WriteLine(res_arr[i]);
                    
        }
    }
}
