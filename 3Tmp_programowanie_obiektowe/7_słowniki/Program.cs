
namespace _7_słowniki
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> translations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            while (true)
            {
                DisplayMenu();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Podaj słowo w języku angielskim: ");
                        string key = Console.ReadLine();

                        if (translations.ContainsKey(key))
                        {
                            Console.WriteLine("Słowo istniej już w słowniku");
                            break;
                        }
                        else
                        {
                            Console.Write("Podaj tłumaczenie w języku polskim: ");
                            string value = Console.ReadLine();
                            translations.Add(key, value);
                            Console.WriteLine("Tłumaczenie dodane");
                        }
                        break;
                    case "2":
                        Console.Write("Podaj słowo do przetłumaczenia: ");
                        string searchKey = Console.ReadLine();

                        if (translations.TryGetValue(searchKey, out string translation))
                        {
                            Console.WriteLine($"Tłumaczenie: {translation}");
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
                            Console.WriteLine($"{item.Key} -> {item.Value}");
                        }
                        break;
                    case "4":
                        Console.Write("Podaj słowo do usunięcia: ");
                        string deleteKey = Console.ReadLine();

                        if (translations.Remove(deleteKey))
                        {
                            Console.WriteLine("Tłumaczenie usunięte");
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono takieg osłowa w słowniku");
                        }
                            break;
                    case "5":
                        Console.Write("Podaj słowo, którego tłumaczenie chcesz zaktualizować: ");
                        string updateKey = Console.ReadLine();

                        if (translations.ContainsKey(updateKey))
                        {
                            Console.Write("Podaj nowe tłumaczenie: ");
                            string newValue = Console.ReadLine();
                            translations[updateKey] = newValue;
                            Console.WriteLine("Tłumaczenie zaktualizowane");
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono takiego słowa w słowniku");
                        }
                            break;
                    case "6":
                        Console.WriteLine("Do widzenia");
                        return;
                        break;
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
