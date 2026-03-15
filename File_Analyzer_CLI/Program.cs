namespace File_Analyzer_CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Помилка: Вкажіть шлях до папки.");
                Console.WriteLine("Використання: analyzer.exe <Шлях_до_папки>");
                return;
            }

            string path = args[0];

            if (!Directory.Exists(path))
            {
                Console.WriteLine($"Помилка: Папка '{path}' не існує.");
                return;
            }

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);

                var allFolders = dirInfo.GetDirectories("*", SearchOption.AllDirectories);
                var allFiles = dirInfo.GetFiles("*", SearchOption.AllDirectories);

                int foldersCount = allFolders.Length;
                int filesCount = allFiles.Length;

                long totalSizeBytes = allFiles.Sum(f => f.Length);
                double totalSizeMB = (double)totalSizeBytes / (1024 * 1024);

                var largestFile = allFiles.OrderByDescending(f => f.Length).FirstOrDefault();

               
                Console.WriteLine($"Folders: {foldersCount}");
                Console.WriteLine($"Files: {filesCount}");
                Console.WriteLine($"Total size: {Math.Round(totalSizeMB)} MB");

                if (largestFile != null)
                {
                    Console.WriteLine($"Largest file: {largestFile.Name}");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Помилка: У вас немає прав доступу до деяких підпапок.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Сталася помилка: {ex.Message}");
            }
        }
    }
    }

