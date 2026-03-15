namespace Folder_Inspector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть шлях до папки (наприклад, C:\\Test): ");
            string path = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
            {
                Console.WriteLine("Вказаної папки не існує.");
                return;
            }

            try
            {
                Console.WriteLine("\n--- Підпапки ---");
                string[] subDirs = Directory.GetDirectories(path);
                foreach (string dir in subDirs)
                {
                    Console.WriteLine(Path.GetFileName(dir));
                }

                Console.WriteLine("\n--- Файли ---");
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    Console.WriteLine($"Файл: {fileInfo.Name}");
                    Console.WriteLine($"  Розмір: {fileInfo.Length} байт");
                    Console.WriteLine($"  Дата створення: {fileInfo.CreationTime}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка доступу: {ex.Message}");
            }
        }
    }
    }
