using System;

namespace DelegateExample
{
    public delegate double MathOperation(double x, double y);

    class Program
    {
        static double Add(double a, double b) => a + b;
        static double Subtract(double a, double b) => a - b;
        static double Multiply(double a, double b) => a * b;
        static double Divide(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Помилка: ділення на нуль!");
                return 0;
            }
            return a / b;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            double num1 = 10;
            double num2 = 5;

            MathOperation operation;

            Console.WriteLine($"Числа для розрахунку: {num1} та {num2}\n");

            operation = Add;
            Console.WriteLine($"Додавання: {operation(num1, num2)}");

            operation = Subtract;
            Console.WriteLine($"Віднімання: {operation(num1, num2)}");

            operation = Multiply;
            Console.WriteLine($"Множення: {operation(num1, num2)}");

            operation = Divide;
            Console.WriteLine($"Ділення: {operation(num1, num2)}");

            Console.ReadKey();
        }
    }
}