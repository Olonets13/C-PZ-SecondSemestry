namespace Practical_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "story.txt";
            string outputFilePath = "report.txt";

            if (!File.Exists(inputFilePath))
            {
                File.WriteAllText(inputFilePath, "Це тестовий файл.\nТут кілька рядків та слів.\nДля перевірки.");
                Console.WriteLine("Створено тестовий story.txt");
            }

            int linesCount = 0;
            int wordsCount = 0;
            int charsCount = 0;

            try
            {
                using (StreamReader reader = new StreamReader(inputFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        linesCount++;
                        charsCount += line.Length; 

                        var words = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        wordsCount += words.Length;
                    }
                }

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    writer.WriteLine("--- Статистика файлу story.txt ---");
                    writer.WriteLine($"Кількість рядків: {linesCount}");
                    writer.WriteLine($"Кількість слів: {wordsCount}");
                    writer.WriteLine($"Кількість символів (без переносів): {charsCount}");
                }

                Console.WriteLine("Готово! Статистику збережено у файл report.txt.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Сталася помилка: {ex.Message}");
            }
        }
    }
}
