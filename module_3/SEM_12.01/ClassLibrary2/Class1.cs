using System;

namespace ClassLibrary2
{
    public class Class1
    {
        public static int [] FormArray(int num)
        {
            int[] res = new int[(int)Math.Log10(num) + 1];

            if (num == 0)
                res[0] = 0;

            int i = 1;
            while (num > 0)
            {
                res[res.Length - i] = num % 10;
                num = num / 10;
                ++i;
            }

            return res;
        }

        public static void DisplayArray (int [] arr)
        {
            foreach (int elem in arr)
                Console.WriteLine(elem + " ");
        }
    }
}
