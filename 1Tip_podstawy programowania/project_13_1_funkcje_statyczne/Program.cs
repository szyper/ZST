

namespace project_13_1_funkcje_statyczne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowMenu();
        }

        private static void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Utwórz tablicę jednowymiarową");
                Console.WriteLine("2. Utwórz tablicę wielowymiarową");
                Console.WriteLine("0. Wyjście");
                Console.Write("Wybierz opcję: ");

                string choice = Console.ReadLine();

                switch (choice) 
                {
                    case "1":
                        CreateOneDimensionalArray();
                        break;
                    case "2":
                        CreateMultiDimensionalArray();
                        break;
                    case "0":
                        Console.WriteLine("Koniec programu");
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie");
                        break;
                }

                Console.WriteLine("\nNaciśnij dowolny klawisz, aby wrócić do menu...");
                Console.ReadKey();
            }
        }

        private static void CreateMultiDimensionalArray()
        {
            throw new NotImplementedException();
        }

        private static void CreateOneDimensionalArray()
        {
            Console.Write("Podaj rozmiar tablicy jednowymiarowej: ");
            int size = int.Parse(Console.ReadLine());

            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Podaj element {i+1}: ");
                array[i] = int.Parse(Console.ReadLine());
            }
        }
    }
}
