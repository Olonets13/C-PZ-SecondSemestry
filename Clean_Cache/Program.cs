namespace Clean_Cache
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть шлях до папки cache (УВАГА: файли будуть видалені): ");
            string cacheDir = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(cacheDir) || !Directory.Exists(cacheDir))
            {
                Console.WriteLine("Папку не знайдено або шлях вказано невірно.");
                return;
            }

            int fileCount = 0;
            long totalSize = 0;

            
            Stack<string> directories = new Stack<string>();

          
            directories.Push(cacheDir);

            Console.WriteLine("Починаємо очищення кешу...");

  
            while (directories.Count > 0)
            {
 
                string currentDir = directories.Pop();

                try
                {

                    string[] subDirs = Directory.GetDirectories(currentDir);
                    foreach (string subDir in subDirs)
                    {
                        directories.Push(subDir);
                    }


                    string[] files = Directory.GetFiles(currentDir);
                    foreach (string file in files)
                    {
                        FileInfo fi = new FileInfo(file);
                        totalSize += fi.Length;
                        fileCount++;

                        fi.Delete(); 
                    }
                }
                catch (UnauthorizedAccessException)
                {
           
                    Console.WriteLine($"Помилка: Немає доступу до {currentDir}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка під час обробки {currentDir}: {ex.Message}");
                }
            }

       
            Console.WriteLine("\n--- Звіт про очищення ---");
            Console.WriteLine($"Видалено файлів: {fileCount}");
            Console.WriteLine($"Звільнено місця: {totalSize} байт");
        }
    }
   }
