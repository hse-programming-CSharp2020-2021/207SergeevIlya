using System;
using ClassLibrary2;
using ClassLibrary1;

namespace SEM_12._01
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 22869;
            int[] arr = new int[] {69, 96, 14, 88, 11, 22, 33, 44, 56, 66};

            Delegate1 del1 = new Delegate1(Class1.FormArray);
            Delegate2 del2 = new Delegate2(Class1.DisplayArray);

            del2(del1(num));
            del2(arr);
        }
    }
}
