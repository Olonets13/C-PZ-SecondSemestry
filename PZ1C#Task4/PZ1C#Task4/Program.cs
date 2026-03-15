using System;
using System.Collections.Generic;

namespace BuiltInDelegates
{
    class Program
    {
        static double Add(double a, double b) => a + b;
        static double Subtract(double a, double b) => a - b;
        static double Multiply(double a, double b) => a * b;
        static double Divide(double a, double b) => b != 0 ? a / b : 0;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Func<double, double, double> operation;

            double x = 12, y = 4;

            operation = Add;
            Console.WriteLine($"Додавання: {operation(x, y)}");

            operation = Multiply;
            Console.WriteLine($"Множення: {operation(x, y)}");

            Console.WriteLine("\n--- Пошук студентів ---");

            List<string> students = new List<string>
            {
                "Олексій", "Марія", "Олена", "Іван", "Олег", "Дмитро"
            };

            char searchLetter = 'О';

            List<string> filteredStudents = students.FindAll(name => name.StartsWith(searchLetter));

            Console.WriteLine($"Імена, що починаються на '{searchLetter}':");
            foreach (var name in filteredStudents)
            {
                Console.WriteLine($"- {name}");
            }

            Console.ReadKey();
        }
    }
}