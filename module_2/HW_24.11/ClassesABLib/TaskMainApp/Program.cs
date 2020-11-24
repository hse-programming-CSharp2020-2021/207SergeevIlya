using System;
using Task01;
using static System.Console;

namespace TaskMainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаём массив из объектов родительского класса.
            ClassParent[] arr = new ClassParent[10];
            Random rand = new Random();

            // Заполняем массив случайными объектами.
            for (int k = 0; k < arr.Length; ++k)
            {
                if (rand.Next(0, 3) % 2 == 0)
                    arr[k] = new A();
                else
                    arr[k] = new B();
            }

            WriteLine("Вывод для всех объектов: ");
            // Выводим значения, которые будет возвращать getA для всех объектов.
            foreach (ClassParent d in arr)
                WriteLine(d.getA());

            WriteLine("\nВывод для объектов класса B: ");
            // Выводим то же самое, но для объектов B.
            foreach (ClassParent d in arr)
                if (d is B)
                    WriteLine(d.getA());

            WriteLine("\nВывод для объектов класса A: ");
            // Выводим то же самое, но для объектов A.
            foreach (ClassParent d in arr)
                if (d is A)
                    WriteLine(d.getA());
        }
    }
}
