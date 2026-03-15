using System;

namespace ClosureValidator
{
    public delegate bool Validator(string input);

    class Program
    {
        static Validator GetValidator(int minLength)
        {
            return input => input != null && input.Length >= minLength;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Validator loginValidator = GetValidator(3);
            Validator passwordValidator = GetValidator(8);

            string testLogin = "Ai";
            string testPassword = "super_secret_123";

            Console.WriteLine("--- Перевірка логіна (мін. 3 симв.) ---");
            bool isLoginValid = loginValidator(testLogin);
            Console.WriteLine($"Логін '{testLogin}': {(isLoginValid ? "Прийнято" : "Занадто короткий")}");

            Console.WriteLine("\n--- Перевірка пароля (мін. 8 симв.) ---");
            bool isPasswordValid = passwordValidator(testPassword);
            Console.WriteLine($"Пароль: {(isPasswordValid ? "Надійний" : "Слабкий (мінімум 8 символів)")}");

            Console.WriteLine("\nВведіть новий логін для перевірки:");
            string userInput = Console.ReadLine();

            if (loginValidator(userInput))
            {
                Console.WriteLine("Логін відповідає вимогам системи.");
            }
            else
            {
                Console.WriteLine("Помилка: логін має містити хоча б 3 символи.");
            }

            Console.ReadKey();
        }
    }
}