using System.IO;
namespace _9_4_destruktor
{
    internal class Program
    {
        class FileHandler
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

            // destruktor - uruchamia się automatycznie
            // gdy obiekt jest usuwany z pamieci przez Garbage Collector
            ~FileHandler()
            {
                // zamknięcie pliku
                writer.Close();

                Console.WriteLine("Plik został zamknięty przez destruktor");
            }

        }
        static void Main(string[] args)
        {
            // pamięć przed utworzeniem obiektu
            Console.WriteLine($"Pamięć przed utworzeniem obiektu: {GC.GetTotalMemory(false)} bajtów");

            // utworzenie obiektuklasy FileHandler
            FileHandler file = new FileHandler();

            // pamięć po utworzeniu obiektu
            Console.WriteLine($"Pamięć po utworzeniu obiektu: {GC.GetTotalMemory(false)} bajtów");

            // wywołanie metody zapisującej tekst do pliku
            file.WriteText("To jest tekst zapisu do pliku");

            // usunięcie referencji do obiektu
            file = null;

            // pamieć po usunięciu referencji przez GC (Garbage Collector)
            Console.WriteLine($"Pamięć po usunięciu referencji obiektu: {GC.GetTotalMemory(false)} bajtów");

            // ręczne uruchomienie Garbage Collector
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }
    }
}
