using System.Text;

namespace _9_pliki
{
    internal class Program
    {
        static string logFile = "logs.txt";
        static string dataFile = "book.csv";
        static List<string> library = new List<string>();
        static readonly string CsvHeader = "Tytuł;Autor;Rok;Gatunek";
        static bool isDirty = false;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Log("=== Uruchomiono program biblioteki ===", LogType.Info);
            LoadFromFile();
            bool running = true;

            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine()?.Trim();

                switch (choice) 
                {
                    case "1": AddBook(); break;
                    case "2": RemoveBook(); break;
                    case "7": SaveToFile(); break;
                    case "8": DisplayAll(); break;
                    case "0": running = false; break;
                    default:
                        Log("Nieznana opcja. Wybierz ponownie", LogType.Error);
                        break;
                }
            }

            if (isDirty)
            {
                SaveToFile();
                Log("Dane zapisane automatycznie przy wyjściu", LogType.Info);
            }

            Log("=== Zakończono działanie programu ===");
        }

        private static void RemoveBook()
        {
            if (!library.Any())
            {
                Log("Biblioteka jest pusta - nie ma czego usunąć!");
                return;
            }

            DisplayBooks(library, "Książki dostępne do usunięcia");

            Console.Write("Podaj numer książki do usunięcia (lub 0 aby anulować)");
            if (!int.TryParse(Console.ReadLine(), out int index) || index == 0)
            {
                Log($"Nieprawidłowy numer: {index}. Dostępne: 1-{library.Count}", LogType.Error);
                return;
            }

            string bookToRemove = library[index - 1];
            string[] parts = bookToRemove.Split(';');
            string title = parts.Length > 0 ? parts[0] : "Nieznany tytuł";
            string author = parts.Length > 1 ? parts[1] : "Nieznany autor";

            // dokończyć
        }

        private static void LoadFromFile()
        {
            if (!File.Exists(dataFile))
            {
                Log($"Plik {dataFile} nie istnieje - tworzony nowy", LogType.Info);
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(dataFile, Encoding.UTF8);

                if (lines.Length == 0 || lines.All(string.IsNullOrWhiteSpace))
                {
                    Log("Plik jest pusty", LogType.Info);
                    return;
                }

                // pomijamy nagłówek, jeśli istnieje 
                int start = lines[0].Trim() == CsvHeader.Trim() ? 1 : 0;

                for (int i = start; i < lines.Length; i++)
                {
                    string line = lines[i].Trim();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        library.Add(line);
                    }
                }

                Log($"Wczytano {library.Count} książek z pliku {dataFile}", LogType.Success);
            }
            catch (Exception ex)
            {
                Log($"Błąd podczas wczytywania pliku: {ex.Message}", LogType.Error);
            }
        }

        private static void SaveToFile()
        {
            var linesToSave = new List<string> { CsvHeader };
            linesToSave.AddRange(library);
            File.WriteAllLines(dataFile, linesToSave, Encoding.UTF8);
            Log($"Zapisano bibliotekę do pliku ({library.Count} książek)", LogType.Success);
            isDirty = false;
        }

        private static void DisplayAll()
        {
            DisplayBooks(library, "Wszystkie książki w bibliotece");
            Log("Wyświetlono całą bibliotekę", LogType.Info, false);
        }

        private static void DisplayBooks(List<string> books, string title)
        {
            Console.WriteLine($"\n=== {title} ===");
            if (!books.Any())
            {
                Log("Brak książek", LogType.Info, true);
                return;
            }

            for (int i = 0; i < books.Count; i++) 
            {
                Console.WriteLine($"{i + 1, 2}. {FormatBook(books[i])}");
            }
            Console.WriteLine($"Łącznie: {books.Count} pozycji\n");
        }

        private static void AddBook()
        {
            Console.Write("Tytuł: ");
            string title = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(title))
            {
                Log("Tytuł nie może być pusty!", LogType.Error); return;
            }

            Console.Write("Autor: ");
            string author = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(author))
            {
                Log("Autor nie może być pusty!", LogType.Error); return;
            }

            Console.Write("Rok wydania (np. 2025): ");
            string yearInput = Console.ReadLine();
            if (!int.TryParse(yearInput, out int year))
            {
                Log($"Nieprawidłowy rok : '{yearInput}' (nie jest liczbą)", LogType.Error); return;
            }

            int currentYear = DateTime.Now.Year;
            int maxYear = currentYear + 1;
            if (year < 1450 || year > maxYear)
            {
                Log($"Nieprawidłowy rok: {year} (dopuszczalny zakres: 1450 - {maxYear})");
                return;
            }

            Console.Write("Gatunek: ");
            string genre = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(genre))
            {
                Log("Gatunek nie może być pusty!", LogType.Error); return;
            }

            string key = $"{title.ToLowerInvariant()};{author.ToLowerInvariant()}";
            bool alredyExists = library.Any(line => line.ToLowerInvariant().StartsWith(key));
            if (alredyExists) 
            {
                Log($"Książka '{title}' autorstwa {author} już istnieje na liście");
                return;
            }

            string csvLine = $"{title};{author};{year};{genre}";
            library.Add(csvLine);
            string formatted = FormatBook(csvLine);

            Log($"Dodano książkę: {formatted}", LogType.Success);
            isDirty = true;
        }

        private static string FormatBook(string csvLine)
        {
            string[] parts = csvLine.Split(';');
            if (parts.Length < 4)
            {
                return csvLine;
            }
            return $"{parts[0]} - {parts[1]} ({parts[2]}), gatunek: {parts[3]})";
        }

        enum LogType { Info, Success, Error, Edit, Filter }
        private static void Log(string message, LogType type = LogType.Info, bool showOnConsole = true)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string typeStr = type.ToString().PadRight(7);
            string logEntry = $"[{timestamp}] [{typeStr}] {message}";

            // zapis do pliku
            try
            {
                File.AppendAllText(logFile, logEntry + Environment.NewLine, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"NIE UDAŁO SIĘ ZAPISAĆ LOGU: {ex.Message}");
            }

            if (showOnConsole)
            {
                ConsoleColor original = Console.ForegroundColor;

                Console.ForegroundColor = type switch
                {
                    LogType.Success     => ConsoleColor.Green,
                    LogType.Error       => ConsoleColor.Red,
                    LogType.Info        => ConsoleColor.Cyan,
                    LogType.Edit        => ConsoleColor.Yellow,
                    LogType.Filter      => ConsoleColor.Magenta,
                    _                   => ConsoleColor.Gray
                };

                Console.WriteLine(message);
                Console.ForegroundColor = original;
            }
            Console.ReadKey();
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("    SYSTEM ZARZĄDZANIA BIBLIOTEKĄ    ");
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("1. Dodaj książkę");
            Console.WriteLine("2. Usuń książkę");
            Console.WriteLine("3. Edytuj książkę");
            Console.WriteLine("4. Wyszukaj książkę");
            Console.WriteLine("5. Sortuj książki");
            Console.WriteLine("6. Filtruj książki");
            Console.WriteLine("7. Zapisz do pliku");
            Console.WriteLine("8. Wyświetl wszystkie książki");
            Console.WriteLine("9. Pokaż logi");
            Console.WriteLine("0. Wyjdź");
        }
        
        
    }
}
