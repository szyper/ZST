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
            // gdy obiekt jest usuwany

        }
        static void Main(string[] args)
        {
            // utworzenie obiektuklasy FileHandler
            FileHandler file = new FileHandler();

            

        }
    }
}
