using System;
using System.Collections.Generic;

namespace DelegateFiltering
{
    public delegate bool FilterPredicate(int number);

    class Program
    {
        static void FilterArray(int[] numbers, FilterPredicate predicate)
        {
            foreach (int n in numbers)
            {
                if (predicate(n))
                {
                    Console.Write($"{n} ");
                }
            }
            Console.WriteLine(); 
        }

        static bool IsEven(int n) => n % 2 == 0;
        static bool IsGreaterThanFive(int n) => n > 5;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("Оригінальний масив: " + string.Join(", ", numbers));
            Console.WriteLine("------------------------------------------");

            Console.Write("Парні числа: ");
            FilterArray(numbers, IsEven);

            Console.Write("Числа більше 5: ");
            FilterArray(numbers, IsGreaterThanFive);

            Console.Write("Непарні числа (лямбда): ");
            FilterArray(numbers, n => n % 2 != 0);

            Console.WriteLine("------------------------------------------");
            Console.ReadKey();
        }
    }
}