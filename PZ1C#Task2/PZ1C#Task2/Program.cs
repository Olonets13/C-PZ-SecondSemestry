using System;

namespace MulticastDelegateExample
{
    public delegate void NotificationHandler(string message);

    class Program
    {
        static void SendEmail(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }

        static void SendSMS(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string myMessage = "Ваше замовлення готове!";

            NotificationHandler notifier = SendEmail;

            notifier += SendSMS;

            Console.WriteLine("--- Виклик об'єднаного делегата ---");

            notifier(myMessage);


            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}