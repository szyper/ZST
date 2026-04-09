// List<int> numbers = new();
List<int> numbers = new List<int>();

Console.WriteLine("Podaj 5 liczb:");

for (int i = 0; i < 5; i++)
{
    Console.Write("Podaj " + (i + 1) + ": ");
    int value = int.Parse(Console.ReadLine());
    numbers.Add(value);
}

Console.WriteLine("\nPrzed posortowaniem:");
PrintList(numbers);

SortList(numbers);

Console.WriteLine("\nPo posortowaniu:");
PrintList(numbers);

void PrintList(List<int> numbers)
{
    foreach (int num in numbers)
    {
        Console.WriteLine(num);
    }
}


void SortList(List<int> numbers)
{
    numbers.Sort();
}