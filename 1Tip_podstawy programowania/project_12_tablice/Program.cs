namespace project_10_tablice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // deklaracja tablicy
            int[] tab1 = new int[5];

            // deklaracja i inicjalizacja tablicy
            int[] tab2 = new int[5] { 1, 2, 3, 4, 5};

            // wyświetlenie tablicy 
            Console.Write("Tablica zawiera: ");
            for (int i = 0; i < tab2.Length; i++) 
            {
                Console.Write(tab2[i] + " ");
            }
            Console.WriteLine();

            // przykład 2 - foreach
            int[] tab3 = { 10, 20, 30, 40, 50 };
            Console.Write("Elementy tablicy: ");
            foreach (int element in tab3)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            // przykład 3 - tablica stringów i wyświetlenie zawartości
            string[] names = { "Franciszek", "Anna", "Janusz"};

            Console.Write("Imiona w tablicy: ");
            for (int i = 0; i < names.Length; i++)
            {
                Console.Write(names[i] + " ");
            }
            Console.WriteLine();

            // przykład 4 - tablica stringów, wprowadzenie danych przez użytkownika
            Console.Write("Podaj liczbę elementów tablicy: ");
            int n = int.Parse(Console.ReadLine());

            string[] names2 = new string[n];

            // wprowadzanie danych do tablicy
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Podaj imię [{i}]: ");
                names2[i] = Console.ReadLine();
            }

            // wyświetlanie tablicy
            Console.WriteLine("Wprowadzone imiona:");
            foreach(string name in names2)
            {
                Console.Write(name + " ");
            }
            Console.WriteLine();
        }
    }
}
