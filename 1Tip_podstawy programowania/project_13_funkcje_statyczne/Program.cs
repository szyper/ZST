namespace project_13_funkcje_statyczne
{
    internal class Program
    {
        // funkcja statyczna licząca samogłoski w tekście
        static int CountVowels(string text)
        {
            // jeśli tekst jest pusty lub null to zwracamy 0
            if (string.IsNullOrEmpty(text))
                return 0;

            // polskie samogłoski
            string vowels = "aąeęiouóyAĄEĘIOUÓY";

            // licznik samogłosek
            int count = 0;

            // jeśli znak jest samogłoską to zwiększamy licznik
            foreach (char c in text)
            {
                if (vowels.Contains(c))
                    count++; // zwiększamy licznik
                // Console.Write(c + " ");
            }
            return count; // zwracamy liczbę samogłosek
        }

        static string RemoveDuplicates(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "";

            // wynikowy tekst
            string result = "";

            // dodajemy pierwszy znak
            result += text[0];

            for (int i = 1; i < text.Length; i++)
            {
                // jeśli znka różni się od poprzedniego to dodajemy go do wyniku
                if (text[i] != text[i - 1])
                    result += text[i];
            }

            return result;
        }

        static void Main(string[] args)
        {
            Console.Write("Podaj tekst: ");

            // pobranie tekstu
            string input = Console.ReadLine();

            // wywołanie funkcji statycznej
            // liczba samogłosek
            int vowels = CountVowels(input);

            // tekst bez powtórzeń
            string withoutDuplicates = RemoveDuplicates(input);

            // wyświetlenie wyników
            Console.WriteLine("Liczba samogłosek: " + vowels);
            Console.WriteLine("Tekst bez powtórzeń: " + withoutDuplicates);

            Console.ReadKey();
        }
    }
}
