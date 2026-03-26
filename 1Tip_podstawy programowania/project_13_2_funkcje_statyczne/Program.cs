



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
                Console.WriteLine("3. Utwórz tablicę postrzępioną (jagged array)");
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
                    case "3":
                        CreateJaggedArray();
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

        private static void CreateJaggedArray()
        {
            Console.Write("Podaj liczbę wierszy tablicy postrzępionej: ");
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                Console.Write($"Podaj liczbę elementów w wierszu {i+1}: ");
                int cols = int.Parse(Console.ReadLine());
                jaggedArray[i] = new int[cols];

                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Podaj element [{i}, {j}]: ");
                    jaggedArray[i][j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Tablica postrzępiona:");
            DisplayJaggedArray(jaggedArray);
        }

        private static void DisplayJaggedArray(int[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void CreateMultiDimensionalArray()
        {
            Console.Write("Podaj liczbę wierszy: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Podaj liczbę kolumn: ");
            int cols = int.Parse(Console.ReadLine());

            int[,] array = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Podaj element[{i}, {j}]: ");
                    array[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Tablica dwuwymiarowa:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{array[i, j], -3}");
                }
                Console.WriteLine();
            }
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

            Console.WriteLine("Tablica jednowymiarowa:");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
