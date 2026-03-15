using System;

namespace FlexibleLogger
{
    public class Logger
    {
        public Action<string> LogHandler;

        public void Log(string message)
        {
            LogHandler?.Invoke(message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Logger myLogger = new Logger();

            myLogger.LogHandler = message => Console.WriteLine($"[Console Log]: {message}");

            Console.WriteLine("--- Перший запуск ---");
            myLogger.Log("Програма розпочала роботу.");

            myLogger.LogHandler = message =>
            {
                string upperMessage = message.ToUpper();
                Console.WriteLine($"[UPPER LOG]: {upperMessage}");
            };

            Console.WriteLine("\n--- Другий запуск (після зміни логіки) ---");
            myLogger.Log("важливе сповіщення про помилку!");

            myLogger.LogHandler += message => Console.WriteLine($"[Length]: Довжина повідомлення - {message.Length}");

            Console.WriteLine("\n--- Третій запуск (мультикаст) ---");
            myLogger.Log("Тестування завершено.");

            Console.ReadKey();
        }
    }
}