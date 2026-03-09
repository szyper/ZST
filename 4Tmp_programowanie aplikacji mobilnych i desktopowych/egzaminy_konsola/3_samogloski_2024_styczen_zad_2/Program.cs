namespace _3_samogloski_2024_styczen_zad_2
{
    // klasa narzędziowa do operacji na tekstach
    /*
     Nazwa klasy: StringTools

     Opis klasy: klasa narzędziowa zawierająca statyczne metody do operacji na łańcuchach znaków. Zawiera metody do liczenia samogłosek oraz usuwania powtarzających się znaków stojących obok siebie

     Metody są statyczne i mogą być wywoływane bez tworzenia obiektu klasy

     Autor: 01234567890
     */
    class StringTools
    {
        // metoda statyczna licząca samogłoski w tekście
        public static int CountVowels(string text)
        {
            // jeśli tekst jest pusty lub null to zwracamy 0
            if (string.IsNullOrEmpty(text))
                return 0;

            // lista polskich samogłosek (małe i duże litery)
            string vowels = "aąeęiouóyAĄEĘIOUÓY";

            int count = 0; // zmienna przechowująca liczbę samogłosek

            // iterujemy przez każdy znak w tekście
            foreach (char c in text)
            {
                // sprawdzamy czy znak znajduje się w zbiorze samogłosek
                if (vowels.Contains(c))
                {
                    count++; // jeśli tak - zwiększamy licznik
                }
            }

            // zwracamy liczbę znalezionych samogłosek
             return count;
        }

        // metoda usuwająca powtarzające się znaki obok siebie
        public static string RemoveDuplicates(string text)
        {
            // jeśli tekst jest pusty lub null, zwracamy pusty string
            if (string.IsNullOrEmpty(text))
                return "";

            // zmienna na wynikowy tekst
            string result = "";

            // Dodajemy pierwszy znak tekstu do wyniku
            result += text[0];

            // pętla przechodzi przez tekst od drugiego znaku
            for (int i = 1; i < text.Length; i++)
            {
                // sprawdzamy czy aktualny znak różni się od poprzedniego
                if (text[i] != text[i - 1])
                    result += text[i]; // jeśli tak to dodajemy literę do rezultatu
            }

            // zwracamy tekst bez powtórzeń obok siebie
            return result;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj tekst: ");

            // pobranie tekstu z klawiatury
            string input = Console.ReadLine();

            // wywołanie metody liczącej samogłoski
            int vowels = StringTools.CountVowels(input);

            // wywołanie metody usuwającej powtórzenia znaków
            string withoutDuplicates = StringTools.RemoveDuplicates(input);

            Console.WriteLine("Liczba samogłosek: " + vowels);
            Console.WriteLine("Tekst bez powtórzeń: " + withoutDuplicates);

            Console.ReadKey();
        }
    }
}
