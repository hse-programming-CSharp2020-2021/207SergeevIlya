using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Stack<string> brackets = new Stack<string>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; ++i)
        {
            string inp = Console.ReadLine();

            if (inp == "(" || inp == "{" || inp == "[")
                brackets.Push(inp);
            else if (inp == ")")
            {
                if (brackets.Peek() == "(")
                    brackets.Pop();
                else
                {
                    Console.WriteLine("Не повезло не повезло...");
                    return;
                }
            }
            else if (inp == "}")
            {
                if (brackets.Peek() == "{")
                    brackets.Pop();
                else
                {
                    Console.WriteLine("Не повезло не повезло...");
                    return;
                }
            }
            else if (inp == "]")
            {
                if (brackets.Peek() == "[")
                    brackets.Pop();
                else
                {
                    Console.WriteLine("Не повезло не повезло...");
                    return;
                }
            }
        }

        if (brackets.Count == 0)
            Console.WriteLine("Повезло повезло");
        else
            Console.WriteLine("Не повезло не повезло...");
    }
}