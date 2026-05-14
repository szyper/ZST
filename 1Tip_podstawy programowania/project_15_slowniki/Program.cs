namespace project_15_slowniki
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> persons = new Dictionary<string, int>();

            persons.Add("Anna", 20);
            persons.Add("Tomasz", 18);
            persons.Add("Franek", 4);


            Console.WriteLine("Lista osób:");
            Console.WriteLine(persons["Anna"]); // 20
            
            var firstPerson = persons.ElementAt(0); // pierwszy eleement ze słownika
            Console.WriteLine("Klucz pierwszej osoby: " + firstPerson.Key);
            Console.WriteLine("Wartość pierwszej osoby: " + firstPerson.Value);

            Console.WriteLine("\nWszystkie klucze ze słownika:");
            foreach (var person in persons)
            {
                Console.WriteLine("Klucz: " + person.Key);
            }

            Console.WriteLine("\nWszystkie wartości ze słownika:");
            foreach (var person in persons)
            {
                Console.WriteLine("Wartość: " + person.Value);
            }

            Console.WriteLine("\n" + persons["Anna"]);


            if (persons.ContainsKey("anna"))
            {
                Console.WriteLine("\n" + persons["anna"]);
            } else
            {
                Console.WriteLine("Brak klucza w słowniku");
            }

            if (persons.ContainsKey("Franek"))
            {
                Console.WriteLine("\n" + persons["Franek"]);
            }
            else
            {
                Console.WriteLine("Brak klucza w słowniku");
            }

            Console.WriteLine("Lista osób:");
            foreach (var person in persons)
            {
                Console.WriteLine(person.Key + " ma " + person.Value + " lat");
            }


            // wyszukiwanie osoby


        }
    }
}
