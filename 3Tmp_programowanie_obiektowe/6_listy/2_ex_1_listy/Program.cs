namespace ex_1_listy
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                Console.Write("Wybierz opcję: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Podaj nazwę produktu: ");
                        string product = Console.ReadLine().Trim();
                        if (string.IsNullOrWhiteSpace(product))
                        {
                            Console.WriteLine("Błąd: nazwa produktu nie może być pusta!");
                            break;
                        }

                        if (shoppingList.Any(p => p.Equals(product, StringComparison.OrdinalIgnoreCase)))
                        {
                            Console.WriteLine($"Błąd: Produkt '{product}' już istnieje na liście!");
                        }
                        else
                        {
                            shoppingList.Add(product);
                            Console.WriteLine($"Produkt '{product}' dodano do listy");
                        }
                        break;
                    case "2":
                        Console.Write("Podaj nazwę produktu do usunięcia: ");
                        string productToRemove = Console.ReadLine().Trim();

                        if (string.IsNullOrWhiteSpace(productToRemove))
                        {
                            Console.WriteLine("Błąd: nazwa produktu nie może być pusta!");
                            break;
                        }

                        string existingProduct = shoppingList.FirstOrDefault(p => p.Equals(productToRemove, StringComparison.OrdinalIgnoreCase));
                        if (existingProduct != null) 
                        { 
                            shoppingList.Remove(existingProduct);
                            Console.WriteLine($"Produkt '{existingProduct}' usunięto z listy");
                        }
                        else
                        {
                            Console.WriteLine($"Błąd: produkt '{productToRemove}' nie istnieje na liście");
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
                        }
                        else
                        {
                            Console.WriteLine($"Nie znaleziono produktów zawierających '{searchTerm}'");
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
                        break;
                    case "5":
                        try
                        {
                            File.WriteAllLines("shoppingList.txt", shoppingList);
                            Console.WriteLine("Lista zapisana do pliku 'shoppingList.txt'");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Błąd podczas zapisu: {ex.Message}");
                        }
                        break;
                    case "6":
                        try
                        {
                            if (File.Exists("shoppingList.txt"))
                            {
                                shoppingList = new List<string>(File.ReadAllLines("shoppingList.txt"));
                                Console.WriteLine("Lista wczytana z pliku 'shoppingList.txt'");
                            }
                            else
                            {
                                Console.WriteLine("Błąd: plik 'shoppingList.txt' nie istnieje");
                            }
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine($"Błąd podczas wczytywania z pliku: {ex.Message}");
                        }
                        break;
                    case "7":
                        running = false;
                        Console.WriteLine("Do widzenia!");
                        break;

                }
            }
        }
    }
}
