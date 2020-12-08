using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
    public static class IntValue
    {
        public static int GetIntValue(string comment)
        {
            Console.WriteLine(comment);
            return int.Parse(Console.ReadLine());
        }
    }
}
