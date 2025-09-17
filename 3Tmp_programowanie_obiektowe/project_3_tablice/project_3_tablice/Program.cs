// przykład deklaracji i inicjalizacji
int[] numbers = new int[5];
numbers[0] = 10;
numbers[1] = 20;

// deklaracja z inicjalizacją
string[] days = { "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek" };
Console.WriteLine(days[2]);

// iteracja po tablicy
char[] letters = { 'A', 'B', 'C', 'D', 'E' };

for (int i = 0; i < letters.Length; i++)
{
    Console.WriteLine($"Element {i + 1}: {letters[i]}");
}

foreach (char letter in letters)
{
    Console.WriteLine(letter);
}

// sumowanie elementów 
int[] values = { 3, 7, 1, 10, 5 };
int sum = 0;

foreach (int value in values)
{
    sum += value;
}

Console.WriteLine($"Suma = {sum}");

// największa liczba
int[] num = { 12, 6, 50, 11, 10, 12 };
int max = numbers[0];

foreach (int value in num)
{
    if (value > max)
        max = value;
}

Console.WriteLine($"Liczba maksymalna: {max}");

// odwracanie tablicy
foreach (int n in num)
{
    Console.Write($"{n} ");
}

Array.Reverse(num);

Console.WriteLine("\nOwrócona tablica:");
foreach (int n in num)
{
    Console.Write($"{n} ");
}

// zliczanie wystąpień
int count = 0;

foreach (int value in num)
{
    if (value == 12)
        count++;
}

Console.WriteLine($"\nLiczba 12 występuje {count} razy");

// średnia arytmetyczna
sum =  0;

foreach (int value in num)
{
    sum += value;
}

double avg = (double)sum / num.Length;
Console.WriteLine($"Średnia = {avg}\n\n");

// czy wartości w tablicy są rosnące
num = new int[] { 1, 2, 3, 4, 5 };

foreach (int value in num)
{
    Console.Write($"{value} ");
}

bool isAscending = true;
for (int i = 1; i < num.Length; i++)
{
    if (num[i] < num[i-1])
    {
        isAscending = false;
        break;
    }
}

Console.WriteLine(isAscending ? "\nTablica jest rosnąca" : "\nTablica NIE jest rosnąca");

// liczby unikalne
num = new int[] { 1, 2, 3, 4, 4, 2 , 4};

foreach (int value in num)
{
    count = 0;
    foreach (int x in num)
    {
        if (x == value) count++;
    }

    if (count == 1)
        Console.WriteLine(value);
}

//najczęściej występujący element
int mostFrequent = num[0];
int maxCount = 0;

foreach(int x in num)
{
    count = 0;
    foreach (var n in num)
    {
        if (n == x) count++;
    }

    if (count > maxCount)
    {
        maxCount = count;
        mostFrequent = x;
    }

}

Console.WriteLine($"Najczęściej występuje liczba {mostFrequent}, {maxCount} razy");