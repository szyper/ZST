
namespace _7_słowniki
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> translations = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

            while (true)
            {
                DisplayMenu();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Podaj słowo w języku angielskim: ");
                        string key = Console.ReadLine();

                        if (!translations.ContainsKey(key))
                        {
                            translations[key] = new List<string>();
                        }

                        Console.Write("Podaj tłumaczenie w języku polskim: ");
                        string value = Console.ReadLine();

                        if (!translations[key].Contains(value))
                        {
                            translations[key].Add(value);
                            Console.WriteLine("Tłumaczenie dodane");
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
                            Console.WriteLine($"Tłumaczenie dla \"{searchKey}\": {string.Join(", ", translationList)}");
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
                            Console.WriteLine($"{item.Key} -> {string.Join(", ", item.Value)}");
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
                        Console.WriteLine("Do widzenia");
                        return;

                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie");
                        break;
                }
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Dodaj nowe tłumaczenie");
            Console.WriteLine("2. Znajdź tłumaczenie");
            Console.WriteLine("3. Wyświetl wszystkie tłumaczenia");
            Console.WriteLine("4. Usuń tłumaczenie");
            Console.WriteLine("5. Zaktualizuj tłumaczenie");
            Console.WriteLine("6. Wyjście");
        }
    }
}
