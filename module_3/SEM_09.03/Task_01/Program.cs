using System;
using System.IO;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream(Console.ReadLine(), FileMode.Open))
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                string txt = System.Text.Encoding.Default.GetString(bytes);

                foreach (var symb in txt)
                    if (symb >= '0' && symb <= '9')
                        Console.WriteLine(symb);
            }
        }
    }
}
