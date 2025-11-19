
namespace _7_słowniki
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> translations = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

            List<string> history = new List<string>();

            while (true)
            {
                DisplayMenu();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Podaj słowo w języku angielskim: ");
                        string key = Console.ReadLine();

                        Console.Write("Podaj tłumaczenie w języku polskim: ");
                        string value = Console.ReadLine();

                        if (!translations.ContainsKey(key))
                        {
                            translations[key] = new List<string>();
                        }

                        if (!translations[key].Contains(value, StringComparer.OrdinalIgnoreCase))
                        {
                            translations[key].Add(value);
                            translations[key].Sort(StringComparer.OrdinalIgnoreCase);
                            Console.WriteLine("Tłumaczenie dodane");
                            history.Add($"[{DateTime.Now: yyyy-MM-dd HH:mm}] [Dodano] {key} -> {value}");
                        }
                        else
                        {
                            Console.WriteLine("To tłumaczenie już istnieje dla tego słowa");
                        }

                            break;

                    case "2":
                        Console.Write("Podaj słowo do przetłumaczenia: ");
                        string searchKey = Console.ReadLine();

                        if (translations.TryGetValue(searchKey, out List<string> translationList))
                        {
                            var sortedList = translationList.OrderBy(t => t, StringComparer.OrdinalIgnoreCase).ToList();
                            Console.WriteLine($"Tłumaczenie dla \"{searchKey}\": {string.Join(", ", sortedList)}");
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono tłumaczenia dla podanego słowa");
                        }
                        break;

                    case "3":
                        Console.WriteLine("\nLista wszystkich tłumaczeń:");
                        foreach (var item in translations)
                        {
                            var sortedValues = item.Value.OrderBy(t => t, StringComparer.OrdinalIgnoreCase).ToList();
                            Console.WriteLine($"{item.Key} -> {string.Join(", ", sortedValues)}");
                        }
                        break;

                    case "4":
                        Console.Write("Podaj słowo, dla którego chcesz usunąć tłumaczenie: ");
                        string deleteKey = Console.ReadLine();

                        if (translations.ContainsKey(deleteKey))
                        {
                            Console.Write("Podaj tłumaczenie do usunięcia: ");
                            string deleteValue = Console.ReadLine();

                            if (translations[deleteKey].Remove(deleteValue))
                            {
                                Console.WriteLine("Tłumaczenie usunięte");
                                history.Add($"[{DateTime.Now: yyyy-MM-dd HH:mm}] [Usunięto] {deleteKey} -> {deleteValue}");

                                if (translations[deleteKey].Count == 0)
                                {
                                    translations.Remove(deleteKey);
                                    Console.WriteLine("Brak pozostałych tłumaczeń dla tego słowa, usunięto klucz");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nie znaleziono takiego tłumaczenia dla podanego słowa");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono takiego słowa w słowniku");
                        }
                            break;

                    case "5":
                        Console.Write("Podaj słowo, którego tłumaczenie chcesz zaktualizować: ");
                        string updateKey = Console.ReadLine();

                        if (translations.ContainsKey(updateKey))
                        {
                            Console.Write("Podaj istniejące tłumaczenie do aktualizacji: ");
                            string oldValue = Console.ReadLine();

                            if (translations[updateKey].Remove(oldValue))
                            {
                                Console.Write("Podaj nowe tłumaczenie: ");
                                string newValue = Console.ReadLine();
                                translations[updateKey].Add(newValue);
                                Console.WriteLine("Tłumaczenie zaktualizowane");
                                history.Add($"[{DateTime.Now: yyyy-MM-dd HH:mm}] [Zaktualizowano] {updateKey} -> {oldValue} -> {newValue}");
                            }
                            else
                            {
                                Console.WriteLine("Nie znaleziono takiego tłumaczenia dla podanego słowa");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono takiego słowa w słowniku");
                        }
                            break;
                    case "6":
                        Console.Write("Podaj tłumaczenie, aby znaleźć odpowiadające mu słowo(a): ");
                        string searchTranslation = Console.ReadLine();

                        List<string> matchingKeys = new List<string>();

                        foreach (var pair in translations)
                        {
                            if (pair.Value.Contains(searchTranslation))
                            {
                                matchingKeys.Add(pair.Key);
                            }
                        }

                        if (matchingKeys.Count > 0)
                        {
                            Console.WriteLine($"Tłumaczenie \"{searchTranslation}\" odpowiada słowu(om): {string.Join(", ", matchingKeys)}");
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono słów dla podanego tłumaczenia");
                        }

                            break;
                    case "7":
                        Console.WriteLine("\nHistoria operacji:");
                        foreach (var entry in history)
                        {
                            Console.WriteLine(entry);
                        }
                        break;

                    case "8":
                        SaveToFile(translations, "slownik.txt");
                        SaveToFile(history, "history.txt");
                        break;

                    case "9":
                        Console.WriteLine("Koniec programu");
                        return;

                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie");
                        break;
                }
            }
        }

        private static void SaveToFile(List<string> history, string v)
        {
            throw new NotImplementedException();
        }

        private static void SaveToFile(Dictionary<string, List<string>> translations, string v)
        {
            throw new NotImplementedException();
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Dodaj nowe tłumaczenie");
            Console.WriteLine("2. Znajdź tłumaczenie");
            Console.WriteLine("3. Wyświetl wszystkie tłumaczenia");
            Console.WriteLine("4. Usuń tłumaczenie");
            Console.WriteLine("5. Zaktualizuj tłumaczenie");
            Console.WriteLine("6. Wyszukiwanie odwrotne");
            Console.WriteLine("7. Wyświetl historię operacji");
            Console.WriteLine("8. Zapis słownika do pliku");
            Console.WriteLine("9. Wyjście");
        }
    }
}
