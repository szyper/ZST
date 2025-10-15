using System;

class Program
{
  static void Main(string[] args)
  {
    // Krok 1: Tworzenie tablicy jednowymiarowej z losowymi liczbami
    Random random = new Random();
    int[] oneDArray = new int[10];
    for (int i = 0; i < oneDArray.Length; i++)
    {
      oneDArray[i] = random.Next(1, 100); // Losowe liczby od 1 do 99
    }

    // Wyświetlenie oryginalnej tablicy
    Console.WriteLine("Oryginalna tablica jednowymiarowa:");
    Console.WriteLine(string.Join(", ", oneDArray));

    // Krok 2: Sortowanie tablicy za pomocą Array.Sort
    Array.Sort(oneDArray);
    Console.WriteLine("\nPosortowana tablica jednowymiarowa:");
    Console.WriteLine(string.Join(", ", oneDArray));

    Array.Reverse(oneDArray);
    Console.WriteLine("\nPosortowana tablica jednowymiarowa:");
    Console.WriteLine(string.Join(", ", oneDArray));
    
    // Krok 3: Użycie właściwości Length
    Console.WriteLine($"\nLiczba elementów w tablicy: {oneDArray.Length}");

    // Krok 4: Tworzenie kopii tablicy za pomocą Clone
    int[] clonedArray = (int[])oneDArray.Clone();
    Console.WriteLine("\nSklonowana tablica:");
    Console.WriteLine(string.Join(", ", clonedArray));

    // Krok 5: Tworzenie tablicy dwuwymiarowej (3x4)
    int[,] twoDArray = new int[3, 4];
    for (int i = 0; i < twoDArray.GetLength(0); i++)
    {
      for (int j = 0; j < twoDArray.GetLength(1); j++)
      {
        twoDArray[i, j] = random.Next(1, 50); // Losowe liczby od 1 do 49
      }
    }

    // Wyświetlenie tablicy dwuwymiarowej
    Console.WriteLine("\nTablica dwuwymiarowa (macierz 3x4):");
    for (int i = 0; i < twoDArray.GetLength(0); i++)
    {
      for (int j = 0; j < twoDArray.GetLength(1); j++)
      {
        Console.Write(twoDArray[i, j] + "\t");
      }
      Console.WriteLine();
    }

    // Krok 6: Użycie właściwości Rank i GetLength
    Console.WriteLine($"\nLiczba wymiarów tablicy (Rank): {twoDArray.Rank}");
    Console.WriteLine($"Liczba elementów w pierwszym wymiarze (wiersze): {twoDArray.GetLength(0)}");
    Console.WriteLine($"Liczba elementów w drugim wymiarze (kolumny): {twoDArray.GetLength(1)}");

    // Krok 7: Kopiowanie tablicy jednowymiarowej do nowej tablicy za pomocą CopyTo
    int[] targetArray = new int[oneDArray.Length + 5]; // Nowa tablica z dodatkowym miejscem
    oneDArray.CopyTo(targetArray, 2); // Kopiowanie od indeksu 2
    Console.WriteLine("\nNowa tablica po użyciu CopyTo (z przesunięciem od indeksu 2):");
    Console.WriteLine(string.Join(", ", targetArray));
  }
}