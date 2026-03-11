using System.IO;
namespace _9_4_3_destruktor_odczyt_pliku_dane_od_usera
{

    internal class Program
    {
        // klasa obsługująca plik i implementująca IDisposable
        class FileHandler : IDisposable
        {
            // obiekt do zapisywania tekstu do pliku
            private StreamWriter writer;

            // konstruktor - uruchamia sięw momencie tworzenia obiektu
            public FileHandler()
            {
                // otwarcie pliku dane.txt
                // parametr true oznacza dopisywanie do istniejącego pliku
                Console.Write("Wybierz tryb: 1 - nadpisz plik, 2 - dopisz do pliku"):;
                string choice = Console.ReadLine();
                bool append = choice == "2";

                writer = new StreamWriter("dane.txt", append);

                // komunikat dla użytkownika
                Console.WriteLine("Plik został otwarty");

            }

            // metoda zapisująca tekst do pliku
            public void WriteText(string text)
            {
                // zapisanie tekstu do pliku
                // Obiekt StreamWriter nie zapisuje od razu pliku. Najpierw zapis trafia do bufora w pamięci, a dpowiro później jest zapisywany na dysk
                // program -> bufor w pamięci -> plik na dysku
                writer.WriteLine(text);

                // wymuszanie zapisania danych z bufora do pliku
                // Flush służy do natychmiastowego zapisania danych z bufora do pliku
                writer.Flush();

                // komunikat w konsoli
                Console.WriteLine("Zapisano tekst do pliku");
            }

            public void Dispose()
            {
                writer.Close(); // zamknięcie pliku
                Console.WriteLine("Plik został zamknięty przez Dispose");
            }

        }
        static void Main(string[] args)
        {
            // blok Using - gwarantuje automatyczne wywołanie Dispose() po zakończeniu bloku
            using (FileHandler file = new FileHandler())
            {
                while (true)
                {
                    // odczyt danych z klawiatury
                    string input = Console.ReadLine();

                    if (input.ToLower() == "koniec")
                        break;

                    // zabezpieczenie przed pustymi liniami lub samymi spacjami
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Nie można zapisać pustej linii, spróbuj ponownie");
                        continue;
                    }

                    // zapis wprowadzonych danych do pliku
                    file.WriteText(input);
                }
            } // Dispose() wywołane automatycznie w tym miejscu

            Console.WriteLine("\n--- Zawartość pliku dane.txt ---");

            // odczyt całaj zawartości pliku i wyświetlenie w konsoli
            try
            {
                string content = File.ReadAllText("dane.txt");
                Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd odczytu pliku: " + ex.Message);
            }


            Console.WriteLine("Koniec programu");

            // kolejność działań:
            // otwarcie -> zapis -> zamknięcie -> koniec programu

            // dokończyć zabezpieczenie przed wprowadzaniem błędnego trybu (np. 44) otwarcia pliku
        }
    }
}
