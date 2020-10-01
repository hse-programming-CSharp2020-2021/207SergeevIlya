using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Task_1_Slide_10
{
    class a_b_c
    {
        public int a, b, c;

        public a_b_c (int A, int B, int C)
        {
            this.a = A;
            this.b = B;
            this.c = C;
        }
    }

    class Program
    {
        //Метод поиска всех интересующих нас троек
        static List<a_b_c> Find_a_b_c ()
        {
            List<a_b_c> ALL = new List<a_b_c>();

            //Перебираем все a, b и c, принадлежащие [1;20]
            for (int a = 1; a <= 20; a++)
                for (int b = 1; b <= 20; b++)
                    for (int c = 1; c <= 20; c++)
                        if (a * a + b * b  == c * c)
                        {
                            ALL.Add(new a_b_c(a, b, c));
                        }
                            

            return ALL;
        }

        static void Main(string[] args)
        {
            //Получаем List из троек a, b и c
            List < a_b_c > ALL = new List<a_b_c>();
            ALL = Find_a_b_c();

            //Выводим его
            
            Console.WriteLine("Множество всех a, b и c, удовлетворяющих равенству a * a + b * b == c * c :");

            int n = ALL.Count;
            for (int i = 0; i < n; ++i)
            {
                Console.WriteLine((i + 1) + " : ");
                Console.WriteLine("a = " + ALL[i].a);
                Console.WriteLine("b = " + ALL[i].b);
                Console.WriteLine("c = " + ALL[i].c);
            }
        }
    }
}
