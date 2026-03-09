namespace _2_losowanie_liczb_2025_zad_1
{
    internal class Program
    {
        /*
         nazwa funkcji:  GenerateSet

         opis funkcji:
         Funkcja losuje jeden zestaw sześciu różnych liczb z zakresu od 1 do 49 i zapisuje je w wybranym wierszu tablicy dwuwymiarowej

         parametry:
         setArray - tablica przechowująca wszystkie zestawy
         rowIndex - numer wiersza, w którym zapiszemy zestaw
         random - generator liczb losowych

         zwracany typ i opis:
         void - funkcja nie zwraca wartości

         autor:
         01234567890
         */
        static void GenerateSet(int[,] setArray, int rowIndex, Random random)
        {
            // tablica pomocnicza sprawdzająca czy dana liczba zostałą już wylosowana
            bool[] usedNumbers = new bool[50];

            // pętla losująca 6 liczb do jednego zestawu
            for (int i = 0; i < 6; i++)
            {
                int number;

                // losujemy liczby dopóki nie trafi się taka, która nie została użyta
                do
                {
                    number = random.Next(1, 50); // losowanie liczby z zakresu 1-49
                }
                while (usedNumbers[number]);

                // oznaczenie liczby jako użyta
                usedNumbers[number] = true;

                // zapisanie liczby do tablicy zestawów
                setArray[rowIndex, i] = number;
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Podaj liczbę zestawów: ");

            // wczytanie liczby zestawów z klawiatury
            int numberOfSets = int.Parse(Console.ReadLine());

            // tablica przechowująca zestawy liczb (n wierszy, 6 kolumn) 
            int[,] setsArray = new int[numberOfSets, 6];

            // tablica do liczenia ile razy wystąpiła każda liczba
            int[] occurrences = new int[50];

            // utworzenie generatora liczb losowych
            Random rand = new Random();

            // pętla losująca wszystkie zestawy
            for (int i = 0; i < numberOfSets; i++)
            {
                GenerateSet(setsArray, i, rand);
            }

            // wyświetlenie wylosowanych zestawów
            Console.WriteLine("\nWylosowane zestawy:");

            for (int i = 0; i < numberOfSets; i++)
            {
                Console.Write("Zestaw " + (i + 1) + ": ");
                for (int j = 0; j < 6; j++)
                {
                    // wypisanie liczby z zestawu
                    Console.Write(setsArray[i, j] + " ");

                    // zwiększenie licznika wystąpień danej liczby
                    occurrences[setsArray[i, j]]++;
                }

                Console.WriteLine();
            }

            // wyświetlenie liczby wystąpień każdej liczby
            Console.WriteLine("\nLiczba wystąpień liczb:");

            for (int i = 1; i <= 49; i++) 
            {
                Console.WriteLine(i + " -> " + occurrences[i]);
            }

        }
    }
}
