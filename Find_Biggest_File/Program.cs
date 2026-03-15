namespace Find_Biggest_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть шлях до папки: ");
            string path = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
            {
                Console.WriteLine("Папку не знайдено.");
                return;
            }

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);

               
                var largestFile = dirInfo.EnumerateFiles("*", SearchOption.AllDirectories)
                                         .OrderByDescending(f => f.Length)
                                         .FirstOrDefault();

                if (largestFile != null)
                {
                    Console.WriteLine("\nНайбільший файл знайдено:");
                    Console.WriteLine($"Name: {largestFile.Name}");
                    Console.WriteLine($"Size: {largestFile.Length} байт");
                    Console.WriteLine($"Path: {largestFile.FullName}");
                }
                else
                {
                    Console.WriteLine("Папка порожня або не містить файлів.");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Помилка: Немає доступу до деяких системних або прихованих підпапок.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
    }

