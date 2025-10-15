using System;

class Program
{
  static void Main(string[] args)
  {
    // Krok 1: Tworzenie tablicy (3 rzędy x 4 fotele)
    Console.Write("Podaj liczbę rzędów w kinie: ");
    int rows = int.TryParse(Console.ReadLine(), out int r) && r > 0 ? r : 3;
    Console.Write("Podaj liczbę foteli w rzędzie: ");
    int cols = int.TryParse(Console.ReadLine(), out int c) && c > 0 ? c : 4;

    string[,] seats = new string[rows, cols];

    // Krok 2: Wypełnianie tablicy statusami miejsc
    Console.WriteLine("\nWprowadź status miejsc (np. 'Wolne' lub 'Zajęte'):");
    for (int i = 0; i < seats.GetLength(0); i++)
    {
      for (int j = 0; j < seats.GetLength(1); j++)
      {
        Console.Write($"Rząd {i + 1}, fotel {j + 1}: ");
        string input = Console.ReadLine();
        seats[i, j] = string.IsNullOrWhiteSpace(input) ? "Wolne" : input;
      }
    }

    // Wyświetlenie układu miejsc
    Console.WriteLine("\nUkład miejsc w kinie:");
    DisplaySeats(seats);

    // Krok 3: Informacje o tablicy
    Console.WriteLine($"\nLiczba wymiarów (Rank): {seats.Rank}");
    Console.WriteLine($"Całkowita liczba miejsc (Length): {seats.Length}");

    // Krok 4: Sprawdzanie statusu miejsca
    Console.Write("\nPodaj numer rzędu do sprawdzenia (1-{0}): ", rows);
    int row = int.TryParse(Console.ReadLine(), out int r2) && r2 > 0 && r2 <= rows ? r2 - 1 : 0;
    Console.Write("Podaj numer fotela (1-{0}): ", cols);
    int col = int.TryParse(Console.ReadLine(), out int c2) && c2 > 0 && c2 <= cols ? c2 - 1 : 0;

    if (row >= 0 && row < seats.GetLength(0) && col >= 0 && col < seats.GetLength(1))
    {
      Console.WriteLine($"Status miejsca w rzędzie {row + 1}, fotel {col + 1}: {seats[row, col]}");
    }
    else
    {
      Console.WriteLine("Nieprawidłowy rząd lub fotel!");
    }

    // Krok 5: Kopia tablicy
    string[,] clonedSeats = (string[,])seats.Clone();
    Console.WriteLine("\nSklonowany układ miejsc:");
    DisplaySeats(clonedSeats);
  }

  // Metoda do wyświetlania tablicy
  static void DisplaySeats(string[,] matrix)
  {
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
      Console.Write($"Rząd {i + 1}:\t");
      for (int j = 0; j < matrix.GetLength(1); j++)
      {
        Console.Write(matrix[i, j] + "\t");
      }
      Console.WriteLine();
    }
  }
}