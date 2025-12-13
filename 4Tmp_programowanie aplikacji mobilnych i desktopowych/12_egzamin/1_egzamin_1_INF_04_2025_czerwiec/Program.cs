
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace egzamin_1_INF_04_2025_czerwiec
{
    // klasa reprezentująca jeden zestaw 6 unikalnych liczb z zakresu 1-49
    public class LottoSet
    {
        public int[] Numbers {  get; private set; }
        public int SetNumber { get; }

        public LottoSet(int setNumber)
        {
            SetNumber = setNumber;
            Numbers = DrawSixUniqueNumbers();
            Array.Sort(Numbers);
        }

        // losowanie 6 różnych liczb z zakresu 1-49


        private int[] DrawSixUniqueNumbers()
        {
            Random random = new Random();
            HashSet<int> unique = new HashSet<int>();

            while (unique.Count < 6)
            {
                unique.Add(random.Next(1, 50));
            }
            return unique.ToArray();
        }

        public override string ToString()
        {
            return $"losowanie {SetNumber,2}: {string.Join(" ", Numbers.Select(n => n.ToString("D2")))}";
        }
    }

    public class Lottery
    {
        private List<LottoSet> _sets;
        private readonly int _numberOfSets;

        public Lottery(int numberOfSets)
        {
            if (numberOfSets <= 0)
            {
                throw new ArgumentException("Liczba zestawów musi być większa od zera");
            }
            _numberOfSets = numberOfSets;
            _sets = new List<LottoSet>();
        }

        public void DrawAllSets()
        {
            _sets.Clear();
            HashSet<string> existingSets = new HashSet<string>();

            int currentNumber = 1;

            while (_sets.Count < _numberOfSets)
            {
                var newSet = new LottoSet(currentNumber);
                string key = string.Join(",", newSet.Numbers);

                if (!existingSets.Contains(key))
                {
                    existingSets.Add(key);
                    _sets.Add(newSet);
                    currentNumber++;
                }
            }
        }
        public void DisplayAllSets()
        {
             Console.WriteLine($"\nWylosowano {_sets.Count} unikalnych zestawów:\n");
             foreach (var set in _sets)
             {
                 Console.WriteLine(set);
             }
             Console.WriteLine("\nWszystkie liczby z zakresu 1-49, w każdym zestawie są unikalne");
             Console.WriteLine("Brak powtórzeń całych zestawów");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== Generator zestawów Lotto ===");

            int count;

            do
            {
                Console.Write("Ile zestawów wylosować? ");
            }
            while (!int.TryParse(Console.ReadLine(), out count) || count <= 0);

            var lottery = new Lottery(count);
            lottery.DrawAllSets();
            lottery.DisplayAllSets();

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
        }
    }
}
