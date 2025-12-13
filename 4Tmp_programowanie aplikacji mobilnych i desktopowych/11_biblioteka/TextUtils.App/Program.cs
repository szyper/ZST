using TextUtils.Library;

Console.Write("Podaj tekst: ");
var input = Console.ReadLine();

Console.WriteLine($"Odwrócony tekst: {TextTools.Reverse(input)}");
Console.WriteLine($"Odwrócony tekst: {TextTools.CountWords(input)}");