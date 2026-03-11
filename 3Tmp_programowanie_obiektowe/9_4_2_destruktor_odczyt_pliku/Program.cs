using System.IO;
namespace _9_4_2_destruktor_odczyt_pliku
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
                writer = new StreamWriter("dane.txt", true);

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
                // zapisujemy tekst
                file.WriteText("To jest tekst zapisu pliku");
            } // tutaj Dispose() zostanie automatycznie wywołane

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
        }
    }
}
