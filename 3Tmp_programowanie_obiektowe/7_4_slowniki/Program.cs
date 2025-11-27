namespace _7_4_slowniki
{
    enum RecipeCategory
    {
        Unknown = 0,
        Breakfast = 1,
        Dinner = 2,
        Dessert = 3,
        Snack = 4,
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // klucz: nazwa przepisu, wartość: tablica stringów ze składnikami
            Dictionary<string, string[]> recipeIngredients = new Dictionary<string, string[]>();

            // klucz: nazwa przepisu, wartość: kategoria (enum)
            Dictionary<string, RecipeCategory> recipeCategory = new Dictionary<string, RecipeCategory>();

            // klucz: nazwa przepisu, wartość: data i godzina dodania
            Dictionary<string, DateTime> recipeDate = new Dictionary<string, DateTime>();

            // lista składników dostępnych w lodówce
            List<string> ownedIngredients = new List<string>();

            bool running = true;

            while (running) 
            {
                Console.WriteLine("\n=== SYSTEM REKOMENDACJI PRZEPISÓW ===");
                Console.WriteLine("1. Dodaj przepis");
                Console.WriteLine("2. Wyświetl wszystkie przepisy");
                Console.WriteLine("3. Podaj składniki w lodówce");
                Console.WriteLine("4. Znajdź dopasowane przepisy");
                Console.WriteLine("5. Wyjście");
                Console.Write("Wybór: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddRecipe(recipeIngredients, recipeCategory, recipeDate);
                        break;
                    case "2":
                        ShowRecipes(recipeIngredients, recipeCategory, recipeDate);
                        break;
                    case "3":
                        ownedIngredients = GetOwnedIngredients();
                        break;
                    case "4":
                        FindMatchingRecipes(recipeIngredients, ownedIngredients);
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór");
                        break;
                }
            }
        }

        // Funkcja znajduje dopasowane przepisy
        private static void FindMatchingRecipes(Dictionary<string, string[]> recipeIngredients, List<string> owned)
        {
            if (recipeIngredients.Count == 0)
            {
                Console.WriteLine("Brak przepisów do sprawdzenia");
                return;
            }

            if (owned.Count == 0)
            {
                Console.WriteLine("Nie podano żadnych składników w lodówce");
                return;
            }

            Console.Write("Maksymalna liczba brakujących składników: ");
            int maxMissing = int.Parse(Console.ReadLine());

            Console.WriteLine("\n=== PROPONOWANE PRZEPISY ===");

            bool found = false;

            foreach (KeyValuePair<string, string[]> entry in recipeIngredients)
            {
                string name = entry.Key;
                string[] ingredients = entry.Value;
                int missingCount = CountMissingIngredients(ingredients, owned);
                if (missingCount <= maxMissing)
                {
                    Console.WriteLine(name + " (brakuje: " + missingCount + ")");
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("Brak pasujących przepisów");
        }

        // licznik brakujących składników

        private static int CountMissingIngredients(string[] recipeIngredients, List<string> owned)
        {
            int missing = 0;

            for (int i = 0; i < recipeIngredients.Length; i++)
            {
                bool found = false;

                for (int j = 0; j < owned.Count; j++)
                {
                    if (recipeIngredients[i] == owned[i])
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                    missing++;
            }
            return missing;
        }

        // funkcja pobierająca składniki dostępne w lodówce
        private static List<string> GetOwnedIngredients()
        {
            Console.Write("Podaj skłądniki w lodówce (oddzielone przecinkami): ");
            string input = Console.ReadLine();

            string[] parts = SplitIngredients(input);

            List<string> list = new List<string>();

            for (int i = 0; i < parts.Length; i++)
            {
                list.Add(parts[i]);
            }
            return list;
        }

        // funkcja wyświetlająca wszystkie przepisy
        private static void ShowRecipes(Dictionary<string, string[]> recipeIngredients, Dictionary<string, RecipeCategory> recipeCategory, Dictionary<string, DateTime> recipeDate)
        {
            if (recipeIngredients.Count == 0)
            {
                Console.WriteLine("Brak przepisów");
                return;
            }

            Console.WriteLine("=== LISTA PREPISÓW ===");

            foreach (KeyValuePair<string, string[]> entry in recipeIngredients)
            {
                string name = entry.Key;
                string[] ingredients = entry.Value;
                RecipeCategory category = recipeCategory[name];
                DateTime date = recipeDate[name];

                // tłumaczenie enuma na język polski
                string polishCategory = category switch 
                { 
                    RecipeCategory.Breakfast    => "Śniadanie",
                    RecipeCategory.Dinner       => "Obiad",
                    RecipeCategory.Dessert      => "Deser",
                    RecipeCategory.Snack        => "Przekąska",
                    RecipeCategory.Unknown      => "Nieznana kategoria",
                    _                           => "Nieznana kategoria"
                };

                Console.Write("- " + name + " | kategoria: " + polishCategory + " | dodano: " + date.ToShortDateString() + " | składniki: ");

                for (int i = 0; i < ingredients.Length; i++)
                {
                    Console.Write(ingredients[i]);
                    if (i < ingredients.Length - 1)
                        Console.Write(", ");
                    {
                        
                    }
                }
                Console.WriteLine();
            }
        }

        // funkcja dodająca nowy przepis
        private static void AddRecipe(Dictionary<string, string[]> recipeIngredients, Dictionary<string, RecipeCategory> recipeCategory, Dictionary<string, DateTime> recipeDate)
        {
            Console.Write("Podaj nazwę przepisu: ");
            string name = Console.ReadLine();

            Console.Write("Podaj składniki (oddzielone przecinkami): ");
            string input = Console.ReadLine();

            string[] parts = SplitIngredients(input);

            Console.WriteLine("Wybierz kategorię przepisu:");
            Console.WriteLine("1. Śniadanie");
            Console.WriteLine("2. Obiad");
            Console.WriteLine("3. Deser");
            Console.WriteLine("4. Przekąska");
            Console.Write("Wybór: ");

            int catNum;
            RecipeCategory category = RecipeCategory.Unknown;

            if (int.TryParse(Console.ReadLine(), out catNum))
            {
                if (catNum >= 1 && catNum <= 4)
                    category = (RecipeCategory)catNum;
            }

            recipeIngredients[name] = parts;
            recipeCategory[name] = category;
            recipeDate[name] = DateTime.Now;

            Console.WriteLine("\n=== Przepis dodany ===\n");

        }

        private static string[] SplitIngredients(string? input)
        {
            string[] raw = input.Split(',');
            string[] cleaned = new string[raw.Length];

            for (int i = 0; i < raw.Length; i++)
            {
                cleaned[i] = raw[i].Trim().ToLower();
            }
            return cleaned;
        }
    }
}
