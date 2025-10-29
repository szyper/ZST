namespace ex_1_listy
{
    internal class Program
    {
        static string logFile = "log.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<string> shoppingList = new List<string>();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nLista zakupów:");
                Console.WriteLine("1. Dodaj produkt");
                Console.WriteLine("2. Usuń produkt");
                Console.WriteLine("3. Wyszukaj produkt");
                Console.WriteLine("4. Wyświetl listę zakupów");
                Console.WriteLine("5. Zapisz listę do pliku");
                Console.WriteLine("6. Wczytaj listę z pliku");
                Console.WriteLine("7. Wyjdź");
                Console.WriteLine("8. Wyświetl logi");
                Console.Write("Wybierz opcję: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Podaj nazwę produktu: ");
                        string product = Console.ReadLine().Trim();
                        if (string.IsNullOrWhiteSpace(product))
                        {
                            LogAction($"nazwa produktu nie może być pusta!", LogType.Error);
                            break;
                        }

                        if (shoppingList.Any(p => p.Equals(product, StringComparison.OrdinalIgnoreCase)))
                        {
                            LogAction($"'{product}' już istnieje na liście!", LogType.Error);
                        }
                        else
                        {
                            shoppingList.Add(product);
                            LogAction($"Dodano produkt: {product}", LogType.Success);
                        }
                        break;
                    case "2":
                        Console.Write("Podaj nazwę produktu do usunięcia: ");
                        string productToRemove = Console.ReadLine().Trim();

                        if (string.IsNullOrWhiteSpace(productToRemove))
                        {
                            LogAction($"Błąd: nazwa produktu nie może być pusta!", LogType.Error);
                            break;
                        }

                        string existingProduct = shoppingList.FirstOrDefault(p => p.Equals(productToRemove, StringComparison.OrdinalIgnoreCase));
                        if (existingProduct != null)
                        {
                            shoppingList.Remove(existingProduct);
                            Console.WriteLine($"Produkt '{existingProduct}' usunięto z listy");
                            LogAction($"Usunięto produkt: {existingProduct}", LogType.Success);
                        }
                        else
                        {
                            LogAction($"Błąd: produkt '{productToRemove}' nie istnieje na liście", LogType.Error);
                        }
                        break;

                    case "3":
                        Console.Write("Podaj fragment nazwy produktu: ");
                        string searchTerm = Console.ReadLine().Trim();
                        if (string.IsNullOrWhiteSpace(searchTerm))
                        {
                            Console.WriteLine("Błąd: fragment wyszukiwania nie może być pusty");
                            break;
                        }

                        var foundProducts = shoppingList.Where(p => p.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
                        if (foundProducts.Any())
                        {
                            Console.WriteLine("Znalezione produkty:");
                            foreach (var foundProduct in foundProducts)
                            {
                                Console.WriteLine($"- {foundProduct}");
                            }
                            LogAction($"Wyszukano produkty zawierające: '{searchTerm}' ({foundProducts.Count} wyników)");
                        }
                        else
                        {
                            Console.WriteLine($"Nie znaleziono produktów zawierających '{searchTerm}'");
                            LogAction($"Wyszukano produkty zawierające: '{searchTerm}' (brak wyników)");
                        }
                        break;
                    case "4":
                        if (shoppingList.Count == 0)
                        {
                            Console.WriteLine("Lista zakupów jest pusta");
                        }
                        else
                        {
                            Console.WriteLine("Lista zakupów:");
                            var sortedList = shoppingList.OrderBy(p => p, StringComparer.OrdinalIgnoreCase).ToList();
                            for (int i = 0; i < sortedList.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {sortedList[i]}");
                            }
                        }
                        LogAction("Wyświetlono listę zakupów", showOnConsole: false);
                        break;
                    case "5":
                        try
                        {
                            File.WriteAllLines("shoppingList.txt", shoppingList);
                            Console.WriteLine("Lista zapisana do pliku 'shoppingList.txt'");
                            LogAction($"Zapisano listę zakupów do pliku");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Błąd podczas zapisu: {ex.Message}");
                            LogAction($"Błąd zapisu do pliku: {ex.Message}");
                        }
                        break;
                    case "6":
                        try
                        {
                            string path = "shoppingList.txt";

                            if (File.Exists(path))
                            {
                                string[] lines = File.ReadAllLines(path);
                                shoppingList.Clear();

                                // dodano niepuste linie
                                foreach (string line in lines)
                                {
                                    string trimmed = line.Trim();
                                    if (!string.IsNullOrWhiteSpace(trimmed))
                                    {
                                        shoppingList.Add(trimmed);
                                    }
                                }

                                if (shoppingList.Count == 0)
                                {
                                    Console.WriteLine("Uwaga: plik jest pusty lub zawiera tylko puste linie - brak produktów na liście");
                                    LogAction($"Wczytano plik, ale był pusty lub zawierał tylko puste linie");
                                }
                                else
                                {
                                    Console.WriteLine($"Wczytano listę zakupów z pliku ({shoppingList.Count} produktów)");
                                    LogAction($"Wczytano listę zakupów z pliku ({shoppingList.Count} produktów)");

                                    Console.WriteLine("\nAktualna lista zakupów:");

                                    // posortowanie alfabetyczne listy ignorując wielkość liter
                                    shoppingList.Sort(StringComparer.OrdinalIgnoreCase);

                                    for (int i = 0; i < shoppingList.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. {shoppingList[i]}");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Błąd: plik 'shoppingList.txt' nie istnieje!");
                            }
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine($"Błąd podczas wczytywania z pliku: {ex.Message}");
                            LogAction($"Błąd podczas wczytywania z pliku: {ex.Message}");
                        }
                        break;
                    case "7":
                        running = false;
                        Console.WriteLine("Do widzenia!");
                        LogAction("Zakończono działanie programu");
                        break;
                    case "8":
                        ShowLogs();
                        break;

                }
            }
        }

        enum LogType
        {
            Info,
            Success,
            Error,
            Warning
        }

        // funkcja zapisująca log z datą i godzina
        private static void LogAction(string message, LogType type = LogType.Info, bool showOnConsole = true)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string emoji = type switch 
            { 
                LogType.Info => "[i]",
                LogType.Success => "[V]",
                LogType.Error => "[X]",
                LogType.Warning => "[!]",
                _ => ""
            };

            string logEntry = $"[{timestamp}] {emoji} [{type}] {message}";

            // zapis do pliku logów
            try
            {
                File.AppendAllText(logFile, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                if (showOnConsole)
                    Console.WriteLine($"Błąd: nie można zapisać logów: {ex.Message}");
            }

            if (!showOnConsole)
                return;

            switch (type)
            {
                case LogType.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogType.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case LogType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }

            Console.WriteLine($"{logEntry}");
            Console.ResetColor();

        }


        // funkcja wyświetlająca logi
        private static void ShowLogs()
        {
            if (!File.Exists(logFile))
            {
                Console.WriteLine("Brak pliku z logami");
                return;
            }

            string[] logs = File.ReadAllLines(logFile);

            if (logs.Length == 0)
            {
                Console.WriteLine("Brak zapisanych logów");
                return;
            }

            // menu kontekstowe
            Console.WriteLine("\n=== Filtr logów ===");
            Console.WriteLine("1. Wszystkie logi");
            Console.WriteLine("2. Tylko błędy");
            Console.WriteLine("3. Tylko sukcesy");
            Console.WriteLine("4. Tylko ostrzeżenia");
            Console.Write("Wybierz opcję: ");
            string choice = Console.ReadLine();

            string filter = choice switch
            {
                "2" => "[Error]",
                "3" => "[Success]",
                "4" => "[Warning]",
                _ => ""             // wszystkie logi
            };

            Console.WriteLine("\n=== Historia operacji ===");
            
            // mapa typów logów na kolory
            var logColors = new Dictionary<string, ConsoleColor>()
            {
                ["[Error]"] = ConsoleColor.Red,
                ["[Warning]"] = ConsoleColor.Yellow,
                ["[Success]"] = ConsoleColor.Green,
                ["[Info]"] = ConsoleColor.Cyan
            };

            foreach (string line in logs) 
            {
                if (!string.IsNullOrEmpty(filter) && !line.Contains(filter))
                    continue;

                // domyślny kolor
                ConsoleColor color = ConsoleColor.White;

                // szukamy pierwszego pasującego typu logu w linii
                foreach (var kvp in logColors)
                {
                    if (line.Contains(kvp.Key))
                    {
                        color = kvp.Value;
                        break;
                    }
                }

                Console.ForegroundColor = color;
                Console.WriteLine(line);
            }
            Console.ResetColor();
        }
    }
}