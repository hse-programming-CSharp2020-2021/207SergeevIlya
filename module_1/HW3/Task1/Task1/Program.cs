using System;
using System.Runtime.CompilerServices;

// Задача №1 из ДЗ №3

namespace Task1
{
    
    class Program
    {
        //Требуемый метод поиска числа
        static int Find_Num (ref int i)
        {
            int sum = 0;
            bool check;
            i = 0;

            do
            {
                // Рассматриваем все значения числовых посл-тей
                i++;
                sum += i;
               
                //Проверяем, является ли число трёхзначным, и если да, то равны ли его цифры
                check = (sum > 99 && sum < 1000 && sum / 100 == sum % 10 && (sum % 100) / 10 == sum % 10);
                
            }
            while (!check && sum < 1000);

            return sum;
        }

        static void Main(string[] args)
        {
            int n = 0;
            int sum = Find_Num(ref n);

            Console.WriteLine("Полученное трёхзначное число : " + sum);
            Console.WriteLine("Кол-во членов ряда : " + n);
            Console.WriteLine("Число можно представить как :");
            Console.WriteLine("1 + 2 + 3 + ... + " + (n - 2) + " + " + (n - 1) + " + " + n);

            Console.ReadKey();
        }
    }
}
